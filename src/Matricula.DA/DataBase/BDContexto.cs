
using Matricula.Model.Entidades;
using Microsoft.EntityFrameworkCore;



namespace Matricula.DA.DataBase
{
    public class DBContexto : DbContext
    {
        public DbSet<Model.Entidades.Estudiante> Estudiantes { get; set; }

        public DBContexto(DbContextOptions<DBContexto> opciones) : base(opciones) //Constructor
        {



        }

        public DBContexto() { } 

     


    }
}
