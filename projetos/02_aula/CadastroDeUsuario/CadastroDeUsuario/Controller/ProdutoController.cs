using CadastroDeUsuario.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuario.Controller
{
    internal class ProdutoController
    {
        private AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar()
        {
            #region Pedir Dados
            Console.WriteLine("Nome do Produto: ");
            string nome = Console.ReadLine() ?? "";
            Console.WriteLine("Preço: ");
            decimal preco = decimal.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Data de Vencimento: ");
            DateOnly vencimento = DateOnly.Parse(Console.ReadLine() ?? "");
            #endregion
            var novoProduto = new Models.Produto()
            {
                Nome = nome,
                Preco = preco,
                Vencimento = vencimento
            };
            _context.Produtos.Add(novoProduto);
            _context.SaveChanges();
            Console.WriteLine("Produto cadastrado");
            Console.ReadKey();
        }

        public void Descricao() 
        {
            // Dizer onde estou
            Console.Clear();
            Console.WriteLine("==== Detalhes do Produto ====");

            // Pedir o ID do usuário
            Console.WriteLine("Digite o ID do produto: ");
            var idProduto = int.Parse(Console.ReadLine() ?? "");

            // Buscar o usuário no banco de dados
            var produto = _context.Produtos.FirstOrDefault(produ => produ.Id == idProduto);

            // Se não encontrar, avisar o usuário
            if (produto == null)
            {
                Console.WriteLine("\nProduto não encontrado!");
            }
            else
            {
                Console.WriteLine("--- Detalhes do Produto---");
                Console.WriteLine($"ID: {produto.Id}");
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Preço: {produto.Preco}");
                Console.WriteLine($"Data de Vencimento: {produto.Vencimento}");
            }

            Console.WriteLine("\nPressione qualquer teclar para voltar.");
            Console.ReadKey();

        }

        public void Listar()
        {
            var produtos = _context.Produtos.ToList();
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado");
            }
            else
            {
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.Id} - Nome: {produto.Nome} - Preço: {produto.Preco} - Data de Vencimento: {produto.Vencimento}");
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar.");
            Console.ReadKey();
        }

        public void Remover()
        {
            // Dizer onde estou
            Console.Clear();
            Console.WriteLine("==== Remover Produto ====");
            // Pedir o ID do usuário
            Console.WriteLine("Digite o ID do produto: ");

            // Bucar o usuário no banco de dados
            var idProduto = int.Parse(Console.ReadLine() ?? "");
            var produtoParaDeletar = 
                _context.Produtos.FirstOrDefault(produto => produto.Id == idProduto);

            // Se não encontrar, avisar o usuário
            if (produtoParaDeletar == null)
            {
                Console.WriteLine("\nProduto não encontrado!");
                Console.ReadKey();
                return;
            }
            // Se encontrar, remover o usuário
            _context.Produtos.Remove(produtoParaDeletar);
            _context.SaveChanges(); // Salvar as mudanças no banco de dados

            Console.WriteLine("Produto removido com sucesso!");
            Console.ReadKey();
        }








    }
}
