using ControleAcademia;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Lógica interna para frmAlunos.xaml
    /// </summary>
    public partial class frmAlunos : Window
    {

        AlunosController alunosController = new AlunosController();
       

        public frmAlunos()
        {
            InitializeComponent();
            
            btnExcluir.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Hidden;

        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {

            AlunosController alunosController = new AlunosController();
            Aluno aluno = new Aluno();
            aluno.Matricula = Convert.ToInt32(txtMatricula.Text);
            aluno.Nome = txtNome.Text;
            aluno.Endereco = txtEndereco.Text;
            //aluno._Servico = 
            try
            {
                aluno.DataInicio = dtCalendario.SelectedDate.Value;           
                alunosController.Adicionar(aluno);
                MessageBox.Show("Cadastro efetuado com sucesso");
                ListaAluno(alunosController);
            }
            catch
            {

                MessageBox.Show("Preencha a data");
            }
        }


        private void ListaAluno(AlunosController alunosController)
        {
            listAluno.ItemsSource = alunosController.ListarTodos();
        }

        private void  listAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            AlunosController alunosController = new AlunosController();
            try
            {
                Aluno a = (Aluno)listAluno.SelectedItem;
                Preenche(a);
            }
            catch
            {
                MessageBox.Show("Sem alunos para seleção");

            }
            //MessageBox.Show("o q tem no a" + a.AlunoID);
        }

        

        public void Preenche(Aluno a) {
            

             if(a == null)
            {
                
                MessageBox.Show("Não Foi possivel encontrar sua busca");
                CarregaLista(a);

            }
            
                txtId.Text = Convert.ToString(a.AlunoID);
                txtId.IsEnabled = false;
                txtNome.Text = a.Nome;
                txtEndereco.Text = a.Endereco;
                txtMatricula.Text = Convert.ToString(a.Matricula);
                dtCalendario.SelectedDate = a.DataInicio;
                btnGravar.Visibility = Visibility.Hidden;
                btnExcluir.Visibility = Visibility.Visible;
                btnEditar.Visibility = Visibility.Visible;
           
            
          
        }
        

        private void Grid_Initialized(object sender, EventArgs e)
        {
            AlunosController alunosController = new AlunosController();
            ListaAluno(alunosController);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            
            AlunosController alunosController = new AlunosController();            
            Aluno aluno = new Aluno();
            aluno.AlunoID = Convert.ToInt32(txtId.Text);
            aluno.Matricula = Convert.ToInt32(txtMatricula.Text);
            aluno.Nome = txtNome.Text;
            aluno.Endereco = txtEndereco.Text;
            aluno.DataInicio = dtCalendario.SelectedDate.Value;
            alunosController.Editar(aluno);
            MessageBox.Show("Editado com Sucesso");
            btnGravar.Visibility = Visibility.Visible;
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtMatricula.Text = "";
            
            
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            
            var idExclusao = Convert.ToInt32(txtId.Text);
            alunosController.Excluir(idExclusao);
            MessageBox.Show("Exclusão efetuada com sucesso");           

        }

     
        private void btnBuscarServ_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AlunosController alunosController = new AlunosController();
                Aluno aluno = new Aluno();
                listAluno.ItemsSource = new List<Aluno>();
                listAluno.ItemsSource = alunosController.BuscarPorNome(txtConsulta.Text);
            }
            catch
            {

                MessageBox.Show("Aluno não encontrado");
            }
        }

        private void CarregaLista(Aluno a)
        {
            AlunosController alunosController = new AlunosController();
            Aluno aluno = new Aluno();
            listAluno.ItemsSource = new List<Aluno>();
            listAluno.ItemsSource = alunosController.BuscarPorNome(txtConsulta.Text);


        }

        
    }
}
