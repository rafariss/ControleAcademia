using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Aluno
    {
        public int AlunoID { get; set; }
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Endereco { get; set; }
        public DateTime DataInicio { get; set; }
        public bool Status { get; set; }
        public int IDServico { get; set; }
        

        //public List<Servico> _Servico { get; set; }

        //falta entender como fazer o vencimento


    }
}
