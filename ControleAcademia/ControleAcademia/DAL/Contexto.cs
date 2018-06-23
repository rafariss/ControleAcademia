using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Modelos;

namespace Controllers.DAL
{
    class Contexto : DbContext
    {

        public Contexto() : base("conexaoDB") {

            //drop da tabela
            //Database.SetInitializer(new DropCreateDatabaseAlways<Contexto>());

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contexto>());

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<AlunoServico> AlunoServico { get; set; }



    }
}
