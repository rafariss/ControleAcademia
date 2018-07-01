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
    /// Lógica interna para frmAlunoServico.xaml
    /// </summary>
    public partial class frmAlunoServico : Window
    {
        public frmAlunoServico()
        {
            InitializeComponent();
        }

        private void listaServicoAluno_Initialized(object sender, EventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            listaServicoAluno.ItemsSource = servicoController.ListarTodos();
        }

        private void listaServicoAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            Servico servico = new Servico();
                        
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            ServicoController servicoController = new ServicoController();
            Servico servico = new Servico();
            Aluno aluno = new Aluno();
            servico = (Servico)listaServicoAluno.SelectedItem;
            var ser = servico.ServicoID;
            aluno.IDServico = ser;
            this.Close();
            
        }
    }
}
