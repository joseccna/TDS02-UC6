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

            Console.WriteLine("Digite o modelo do veículo: ");
            string modelo = Console.ReadLine() ?? "";

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






    }
}
