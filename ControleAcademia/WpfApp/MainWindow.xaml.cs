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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CadastroAluno_Click(object sender, RoutedEventArgs e)
        {
            frmAlunos cadAlunos = new frmAlunos();
            cadAlunos.ShowDialog();
        }

        private void btnServico_Click(object sender, RoutedEventArgs e)
        {
            frmServico cadServico = new frmServico();
            cadServico.ShowDialog();
        }

       // private void Carregar()
        //{
          //  AlunoServico aaa = new AlunoServico();
            //frmAlunoServico form = new frmAlunoServico(aaa);
        //}
    }
}
