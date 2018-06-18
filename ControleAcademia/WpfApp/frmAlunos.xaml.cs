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
            aluno.Nome = txtNome.Text;

            alunosController.Adicionar(aluno);



           
            
           
        }
    }
}
