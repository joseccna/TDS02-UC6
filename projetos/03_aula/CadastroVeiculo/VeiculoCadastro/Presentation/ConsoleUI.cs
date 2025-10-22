using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeiculoCadastro.Controller;

namespace VeiculoCadastro.Presentation
{
    internal class ConsoleUI
    {
        private VeiculoController _veiculoController;

        public ConsoleUI(VeiculoController veiculoController)
        {
            _veiculoController = veiculoController;
        }

        public void Menu() 
        { 
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Cadastro de Veículos");
                Console.WriteLine("1. Adicionar Veículo");
                Console.WriteLine("2. Listar Veículos");
                Console.WriteLine("3. Detalhes do Veículo");
                Console.WriteLine("4. Atualizar Veículo");
                Console.WriteLine("5. Remover Veículo");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _veiculoController.AdicionarVeiculo();
                        break;
                    case "2":
                        _veiculoController.ListarVeiculos();
                        break;
                    case "3":
                        _veiculoController.Detalhes();
                        break;
                    case "4":
                        _veiculoController.Atualizar();
                        break;
                    case "5":
                        _veiculoController.Remover();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }


    }
}
