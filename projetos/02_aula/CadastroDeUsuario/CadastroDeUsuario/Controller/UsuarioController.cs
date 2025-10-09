using CadastroDeUsuario.Data;
using CadastroDeUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuario.Controller
{
    internal class UsuarioController
    {
        private AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar()
        {
            #region Pedir Dados
            Console.WriteLine("Primeiro Nome: ");
            string primeiroNome = Console.ReadLine() ?? "";

            Console.WriteLine("Sbrenome: ");
            string sobrenome = Console.ReadLine() ?? "";

            Console.WriteLine("Data de Nacimento: ");
            DateOnly nascimento = DateOnly.Parse( Console.ReadLine() ?? "");
            #endregion
            var novoUsuario = new Usuario()
            {
                PrimeiroNome = primeiroNome,
                Sobrenome = sobrenome,
                DataNascimento = nascimento 
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            Console.WriteLine("Usuário cadastrado");
            Console.ReadKey();
        }

        public void Listar()
        {
            var usuarios = _context.Usuarios.ToList();

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado");
                
            } else
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id} - Nome: {usuario.PrimeiroNome} {usuario.Sobrenome} - Data de Nascimento: {usuario.DataNascimento}");
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar.");
            Console.ReadKey();

        }

    }

}
