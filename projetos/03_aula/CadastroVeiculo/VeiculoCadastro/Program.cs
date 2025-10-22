using VeiculoCadastro.Models;
using VeiculoCadastro.Data;
using VeiculoCadastro.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeiculoCadastro.Presentation;

namespace VeiculoCadastro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UsuariosDB;Trusted_Connection=True;"));
                    services.AddTransient<VeiculoController>();

                    services.AddTransient<ConsoleUI>();
                })
                .Build();
            var consoleUI = host.Services.GetRequiredService<ConsoleUI>();
            consoleUI.Menu();


            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var dbContext = services.GetRequiredService<AppDbContext>();
            //    dbContext.Database.Migrate();

            //    var veiculoController = services.GetRequiredService<VeiculoController>();

            //    while (true)
            //    {
            //        Console.Clear();
            //        Console.WriteLine("Cadastro de Veículos");
            //        Console.WriteLine("1. Adicionar Veículo");
            //        Console.WriteLine("2. Listar Veículos");
            //        Console.WriteLine("3. Detalhes do Veículo");
            //        Console.WriteLine("4. Atualizar Veículo");
            //        Console.WriteLine("5. Remover Veículo");
            //        Console.WriteLine("0. Sair");
            //        Console.Write("Escolha uma opção: ");
            //        var choice = Console.ReadLine();
            //        switch (choice)
            //        {
            //            case "1":
            //                veiculoController.AdicionarVeiculo();
            //                break;
            //            case "2":
            //                veiculoController.ListarVeiculos();
            //                break;
            //            case "3":
            //                veiculoController.Detalhes();
            //                break;
            //            case "4":
            //                veiculoController.Atualizar();
            //                break;
            //            case "5":
            //                veiculoController.Remover();
            //                break;
            //            case "0":
            //                return;
            //            default:
            //                Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
            //                Console.ReadKey();
            //                break;
            //        }
            //    }
            //}







        }
    }
}
