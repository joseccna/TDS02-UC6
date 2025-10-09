
using CadastroDeUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuario.Data
{
    internal class AppDbContext : DbContext // Tem que erdar DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Construtor que recebe opções e passa para a classe base
        {

        }
               
        
        public DbSet<Usuario> Usuarios { get; set; } // Representa a tabela Usuarios no banco de dados


    }
}
