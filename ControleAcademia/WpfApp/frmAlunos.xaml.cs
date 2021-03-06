﻿using ControleAcademia;
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
        Aluno aluno = new Aluno();
        private int iDServico;

        public frmAlunos()
        {
            InitializeComponent();
           // txtIDServico.Text = aluno.IDServico.ToString();
            btnExcluir.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Hidden;
            

        }

        public frmAlunos(int iDServico)
        {
            this.iDServico = iDServico;
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {

            AlunosController alunosController = new AlunosController();
            Aluno aluno = new Aluno();


            //ServicoController servico = new ServicoController();
            // Servico ser = new Servico();

            if(aluno is null)
            {

                MessageBox.Show("Não foi possivel efetuar o cadastro");

            }
            try
            {
                aluno.Matricula = Convert.ToInt32(txtMatricula.Text);
                aluno.Nome = txtNome.Text;
                aluno.Endereco = txtEndereco.Text;
                aluno.IDServico = ((Servico)cbServico.SelectedItem).ServicoID;

                txtIDServico.Text = aluno.IDServico.ToString();
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
            catch
            {
                MessageBox.Show("Revise os dados para cadastro");

            }
            // var serv = cbServico.SelectedIndex.;
            //ser.ServicoID = serv.; 

            //aluno._Servico.Insert(serv, ser);
            //aluno._Servico.Add(ser);
          
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
                txtIDServico.Text = Convert.ToString(a.IDServico);
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
            
                AlunosController alunosController = new AlunosController();
                Aluno aluno = new Aluno();
            if(aluno is null)
            {

                MessageBox.Show("Aluno não encontrado");
            }

            try
            {
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

        private void cbServico_Loaded(object sender, RoutedEventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            cbServico.ItemsSource = servicoController.ListarTodos();

        }

        private void cbServico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnAddServico_Click(object sender, RoutedEventArgs e)
        {
            frmAlunoServico servicoAluno = new frmAlunoServico();
            servicoAluno.ShowDialog();
        }

        private void TelaAlunos_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void frmAlunos1_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
