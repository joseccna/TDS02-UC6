using VeiculoCadastro.Models;
using VeiculoCadastro.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeiculoCadastro.Controller
{
    internal class VeiculoController
    {

        private AppDbContext _context;

        public VeiculoController(AppDbContext context)
        {
            _context = context;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a marca do veículo: ");
            string marca = Console.ReadLine() ?? "";

            if (string.IsNullOrEmpty(marca))
            {
                Console.WriteLine("\nMarcar embranco!");
                Console.WriteLine("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Digite o modelo do veículo: ");
            string modelo = Console.ReadLine() ?? "";

            if (modelo == "" || modelo == null)
                {
                Console.WriteLine("\nModelo em branco!");
                Console.WriteLine("Pressione qualquer tecla para voltar.");
                Console.ReadKey();
                return;
            }

            var novoVeiculo = new Veiculo()
            {
                Marca = marca,
                Modelo = modelo
            };

            _context.Veiculos.Add(novoVeiculo);
            _context.SaveChanges();

            Console.WriteLine("Veículo adicionado com sucesso!");
            Console.ReadKey();

        }

        public void ListarVeiculos()
        {
            var veiculos = _context.Veiculos.ToList();
            Console.WriteLine("Lista de Veículos Cadastrados:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"ID: {veiculo.Id}, Marca: {veiculo.Marca}, Modelo: {veiculo.Modelo}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
        }

        public void Detalhes()
        {
            Console.Clear();
            Console.WriteLine("=== Detalhes do Veículo ===");

            Console.Write("Digite o ID do veículo: ");
            var idCarro = int.Parse(Console.ReadLine() ?? "0");

            var veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == idCarro);

            if (veiculo == null)
            {
                Console.WriteLine("\nVeiculo não encontrado");
            }
            else
            {
                Console.WriteLine("=== Detalhes do Veículo ===");
                Console.WriteLine($"\nID: {veiculo.Id}");
                Console.WriteLine($"Marca: {veiculo.Marca}");
                Console.WriteLine($"Modelo: {veiculo.Modelo}");
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar.");
            Console.ReadKey();

        }

        public void Atualizar()
        {
            // Implementar método de atualização de veículo
            Console.Clear();
            Console.WriteLine("=== Atualizar Veículo ===");
            Console.Write("Digite o ID do veículo que deseja atualizar: ");
            var idCarro = int.Parse(Console.ReadLine() ?? "0");

            var veiculoParaAtualizar = 
                _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == idCarro);

            if(veiculoParaAtualizar == null)
            {
                Console.WriteLine("\nVeículo não encontrado.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nAtualizando veículo: {veiculoParaAtualizar.Marca}");
            Console.Write("Nova marca (deixe em branco para manter a atual): ");
            string novaMarca = Console.ReadLine() ?? "";
            Console.Write("Novo modelo (deixe em branco para manter o atual): ");
            string novoModelo = Console.ReadLine() ?? "";

            veiculoParaAtualizar.Marca = novaMarca;
            veiculoParaAtualizar.Modelo = novoModelo;

            _context.Veiculos.Update(veiculoParaAtualizar);
            _context.SaveChanges();

            Console.WriteLine("\nVeículo atualizado com sucesso!");
            Console.ReadKey();
        }


        public void Remover()
        {
            Console.Clear();
            Console.WriteLine("=== Remover Veículo ===");
            Console.Write("Digite o ID do veículo que deseja remover: ");

            var idCarro = int.Parse(Console.ReadLine() ?? "0");
            var VeiculoParaRemover =
                _context.Veiculos.FirstOrDefault(veicu => veicu.Id == idCarro);

            if(VeiculoParaRemover == null)
            {
                Console.WriteLine("\nVeículo não encontrado.");
                Console.ReadKey();
                return;
            }

            _context.Veiculos.Remove(VeiculoParaRemover);
            _context.SaveChanges();

            Console.WriteLine("\nVeículo removido com sucesso!");
            Console.ReadKey();

        }



    }
}
