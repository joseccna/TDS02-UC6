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

        public void Detalhes()
        {
            // Dizer onde estou 
            Console.Clear();
            Console.WriteLine("==== Detalhes do Usuário ====");

            // Pedir o ID do usuário
            Console.WriteLine("Digite o ID do usuário: ");
            var idUsuario = int.Parse(Console.ReadLine());

            // Buscar o usuário no banco de dados
            //var usuario = _context.Usuarios.Find(idUsuario);
            var usuario = _context.Usuarios.FirstOrDefault(user => user.Id == idUsuario);

            // Se não encontrar, avisar o usuário
            if (usuario == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
            }
            else // Se encontrar, mostrar os detalhes do usuário
            {
                Console.WriteLine("--- Dados do Usuário ---");
                Console.WriteLine($"ID: {usuario.Id}");
                Console.WriteLine($"Nome: {usuario.PrimeiroNome}");
                Console.WriteLine($"Sobrenome: {usuario.Sobrenome}");
                Console.WriteLine($"Nascimento: {usuario.DataNascimento}");
            }

            
            Console.WriteLine("\nPressione qualquer tecla para voltar.");
            Console.ReadKey();

        }


        public void Remover()
        {
            // Dizer onde estou 
            Console.Clear();
            Console.WriteLine("==== Remover Usuário ====");
            // Pedir o ID do usuário
            Console.WriteLine("Digite o ID do usuário: ");

            // Buscar o usuário no banco de dados
            var idUsuario = int.Parse(Console.ReadLine());
            var usuarioParaDeletar = 
                _context.Usuarios.FirstOrDefault(user => user.Id == idUsuario);

            // Se não encontrar, avisar o usuário
            if (usuarioParaDeletar == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
                Console.ReadKey();
                return;
            }


            // Se encontrar, remover o usuário
            _context.Usuarios.Remove(usuarioParaDeletar);
            _context.SaveChanges(); // Salvar as mudanças no banco de dados

            Console.WriteLine("\nUsuário removido com sucesso!");
            Console.ReadKey();

        }

    }

}
