using System.Data.Entity;
using Modelo.Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Modelo.DAL
{
    public class DBConexion : DbContext
    {
       public DbSet<SystemUser> systemuser { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
