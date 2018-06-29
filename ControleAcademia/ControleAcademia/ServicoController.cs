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
    public class ServicoController : IBaseController<Servico>
    {
        private Contexto contexto = new Contexto();

        public void Adicionar(Servico entity)
        {
            contexto.Servicos.Add(entity);
            contexto.SaveChanges();
        }

        public Servico BuscarPorID(int id)
        {
            return contexto.Servicos.Find(id);
        }

        public void Editar(Servico entity)
        {
            contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Servico serv = BuscarPorID(id);

            if (serv != null)
            {
                //1a forma
                //contexto.Entry(usu).State = System.Data.Entity.EntityState.Deleted;

                // 2a forma
                contexto.Servicos.Remove(serv);
                contexto.SaveChanges();

            }
        }

        public IList<Servico> ListarPorNome(string nome)
        {
            var ServicoPorNome = from serv in contexto.Servicos
                               where serv.NomeServico == nome
                               select serv;

            return ServicoPorNome.ToList();
        }

        public IList<Servico> ListarTodos()
        {
            return contexto.Servicos.ToList();

        }


    }
}
