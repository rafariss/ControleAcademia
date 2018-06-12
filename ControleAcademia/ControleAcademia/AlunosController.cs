using Controllers.Base;
using Controllers.DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleAcademia
{
    public class AlunosController : IBaseController<Aluno>
    {

        private Contexto contexto = new Contexto();


        public void Adicionar(Aluno entity)
        {
            contexto.Alunos.Add(entity);
            contexto.SaveChanges();
        }

        public Aluno BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> ListarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IList<Aluno> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
