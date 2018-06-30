using ControleAcademia;
using Modelos;
using System;
using System.Collections.Generic;
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
    /// Lógica interna para frmServico.xaml
    /// </summary>
    public partial class frmServico : Window
    {
        public frmServico()
        {
            InitializeComponent();

            btnExcluir.Visibility = Visibility.Hidden;
            btnEditar.Visibility = Visibility.Hidden;
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            Servico servico = new Servico();
            servico.NomeServico = txtServico.Text;
            servico.Valor = Convert.ToInt32(txtValor.Text);
            servico.Categoria = txtCategoria.Text;
            servicoController.Adicionar(servico);
            MessageBox.Show("Cadastrado com sucesso");
            ListaServicos(servicoController);
            
        }

        //preneche a lista depois de clicar em gravar
        public void  ListaServicos (ServicoController servicoController) {

            listServico.ItemsSource = servicoController.ListarTodos();

        }
        // carrega a lista ao inicialiar a tela
        private void listServico_Initialized(object sender, EventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            listServico.ItemsSource = servicoController.ListarTodos();
        }

        // preenche os dados nos text box e habilita os botões de editar e excluir
        public void  Preencher (Servico ser) {

            txtId.Text = Convert.ToString(ser.ServicoID);
            txtId.IsEnabled = false;
            txtServico.Text = ser.NomeServico;
            txtValor.Text = Convert.ToString(ser.Valor);
            txtCategoria.Text = ser.Categoria;
            btnGravar.Visibility = Visibility.Hidden;
            btnExcluir.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Visible;

        }


        //editar o serviço na tela

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            ServicoController servicoController = new ServicoController();
            Servico servico = new Servico();
            servico.ServicoID = Convert.ToInt32(txtId.Text);
            servico.NomeServico = txtServico.Text;
            servico.Valor = Convert.ToInt32(txtValor.Text);
            servico.Categoria = txtCategoria.Text;
            servicoController.Editar(servico);
            MessageBox.Show("Editado com sucesso");
            btnGravar.Visibility = Visibility.Visible;
            listServico.Items.Refresh();
            txtId.Text = "";
            txtServico.Text = "";
            txtValor.Text = "";
            txtCategoria.Text = "";
            ListaServicos(servicoController);

        }



        //seleciona o item na lista
        private void listServico_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ServicoController servicoController = new ServicoController();
            Servico servico = (Servico)listServico.SelectedItem;
            Preencher(servico);

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            var idExclusão = Convert.ToInt32(txtId.Text);
            servicoController.Excluir(idExclusão);
            MessageBox.Show("Excluido com sucesso");
            servicoController.ListarTodos();
            //listServico.ItemsSource = servicoController.ListarTodos();
        }


    }
}
