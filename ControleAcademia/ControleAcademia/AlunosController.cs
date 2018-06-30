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
            return contexto.Alunos.Find(id);
        }

        public ICollection<Aluno>
        BuscarPorNome(string nome)
        {

            return contexto.Alunos.Where(aluno => aluno.Nome.Contains(nome)).ToList();
        }

        public void Editar(Aluno entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Aluno alu = BuscarPorID(id);

            if (alu != null)
            {
                //1a forma
                //contexto.Entry(usu).State = System.Data.Entity.EntityState.Deleted;

                // 2a forma
                contexto.Alunos.Remove(alu);
                contexto.SaveChanges();
                
            }
        }

        public IList<Aluno> ListarPorNome(string nome)
        {
            var AlunoPorNome = from alu in contexto.Alunos
                                where alu.Nome ==  nome
                                select alu;

            return AlunoPorNome.ToList();
        }

        public IList<Aluno> ListarTodos()
        {
            return contexto.Alunos.ToList();

        }
    }
}
