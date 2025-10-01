using EstacionamentoConsole.Controllers;
using EstacionamentoConsole.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<EstacionamentoDbContext>(opt =>
            opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EstacionamentoDB;Trusted_Connection=True;TrustServerCertificate=True;"));

        // 💡 Adiciona o registro do Controller aqui
        services.AddTransient<ClienteController>();
    })
    .Build();

var clienteController = host.Services.GetRequiredService<ClienteController>();

bool sair = false; // Variável de controle para o loop principal



while (!sair)
{
    Console.Clear();
    Console.WriteLine("===== Sistema de Estacionamento =====");
    Console.WriteLine("1. Lista Clientes");
    Console.WriteLine("2. Adicionar Cliente");
    Console.WriteLine("3. (A Fazer) Gerenciar Veículos");
    Console.WriteLine("4. (A Fazer) Gerenciar Vagas");
    Console.WriteLine("5. Ver Detalhes do Cliente");
    Console.WriteLine("0. Sair");

    String opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            clienteController.ListarClientes();
            break;
        case "2":
            clienteController.AdicionarCliente();
            break;
        case "3":
            Console.WriteLine("Chamou o Gerenciar Veiculos.");
            break;
        case "4":
            Console.WriteLine("Chamou o Gerenciar Vagas.");
            break;
        case "5":
            clienteController.VerDetalhesCliente();
            break;
        case "0":
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            Console.ReadKey();
            break;
    }
}

Console.WriteLine("Obrigado por usar o sistema de estacionamento. Até logo!");


