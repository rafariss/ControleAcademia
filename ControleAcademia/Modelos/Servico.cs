using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Servico : Aluno
    {
        public int ValorID { get; set; }
        public string NomeServico { get; set; }
        public float Valor { get; set; }
        public int ContadorDias { get; set; }



    }
}
