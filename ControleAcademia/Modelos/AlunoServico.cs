using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class AlunoServico
    {
        public int AlunoServicoID { get; set; }
        public  virtual Aluno _Aluno { get; set; }
        public virtual Servico _Servico { get; set; }
        public DateTime DataPlano { get; set; }



    }
}
