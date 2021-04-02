using Banco.MVC.Models;
using Microsoft.EntityFrameworkCore;
namespace Banco.MVC.Data
{
    public class ContaContext : DbContext
    {
        public ContaContext (DbContextOptions<ContaContext> options)
            : base (options){}
        
        public DbSet<Conta> Conta { get; set;}
    }
}