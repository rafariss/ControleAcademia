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
        public frmAlunos()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {

            AlunosController alunosController = new AlunosController();
            Aluno aluno = new Aluno();
            aluno.Matricula = Convert.ToInt32(txtMatricula.Text);
            aluno.Nome = txtNome.Text;
            aluno.Endereco = txtEndereco.Text;
            aluno.DataInicio = dtCalendario.SelectedDate.Value;
            alunosController.Adicionar(aluno);
            MessageBox.Show("Cadastro efetuado com sucesso");

            ListaAluno(alunosController);

        }


        private void ListaAluno(AlunosController alunosController)
        {
            listAluno.ItemsSource = alunosController.ListarTodos();
        }

        private void listAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AlunosController alunosController = new AlunosController();
            Aluno a = (Aluno)listAluno.SelectedItem;
        }

        public void Preenche(Aluno a) {

            //txtNome.Text = a.g



        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            AlunosController alunosController = new AlunosController();
            ListaAluno(alunosController);
        }
    }
}
