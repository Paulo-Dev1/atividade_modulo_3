using Flyturismo.Models;
using Microsoft.EntityFrameworkCore;

namespace Flyturismo.Data
{
    public class TurismoContext : DbContext
    {
        public TurismoContext(DbContextOptions<TurismoContext> opt): base(opt)
        {

        }

        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Destino> Destinos {get; set;}
        public DbSet<Hospedagem> Hospedagens {get; set;}
    }
}