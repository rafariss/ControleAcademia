using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
   public class Servico 
    {
        public int ServicoID { get; set; }
        public string NomeServico { get; set; }
        public float Valor { get; set; }
        public string Categoria { get; set; }
        public int ContadorDias { get; set; }

       
        //public ICollection<Aluno> Aluno { get; set; }

}

   
}
