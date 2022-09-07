using CrudEFCoreNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEFCoreNet6.Datos
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        { 
        }

        //agregar el modelo de usuarios y todos los modelos aqui
        public DbSet<Usuario> Usuarios
        {
            get;  set;

        }
        public object Usuario { get; internal set; }
    }
}
