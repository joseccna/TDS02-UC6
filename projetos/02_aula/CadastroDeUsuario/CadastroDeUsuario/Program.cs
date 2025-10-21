using CadastroDeUsuario.Controller;
using CadastroDeUsuario.Data;
using CadastroDeUsuario.Presentation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
.ConfigureServices((context, services) =>
{
    // Configurar serviços aqui, se necessário
    services.AddDbContext<AppDbContext>(optinos =>
     optinos.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UsuariosDB;Trusted_Connection=True;")); // Adiciona o contexto do banco de dados ao contêiner de serviços

    services.AddTransient<UsuarioController>(); // Adiciona o controlador de usuário ao contêiner de serviços

    services.AddTransient<ProdutoController>(); // Adiciona o controlador de produto ao contêiner de serviços

    services.AddTransient<ConsoleUI>(); // Adiciona a interface do console ao contêiner de serviços

}).Build();

var usuarioController = host.Services.GetRequiredService<UsuarioController>();

var produtoController = host.Services.GetRequiredService<ProdutoController>();

var consoleUI = host.Services.GetRequiredService<ConsoleUI>();

consoleUI.MenuPrincipal();

//MenuPrincipal();

//MenuProdutos();

//void MenuPrincipal()
//{
//    bool sair = false;
//    while (!sair)
//    {
//        Console.Clear();
//        Console.WriteLine("==== Menu Principal ====");
//        Console.WriteLine("1. Gerenciar Usuários");
//        Console.WriteLine("2. Gerenciar Produtos");
//        Console.WriteLine("0. Sair");

//        string? opcao = Console.ReadLine();

//        if (opcao == "1")
//        {
//            MenuUsuarios();
//        }
//        else if (opcao == "2")
//        {
//            // MenuProdutos();
//            MenuProdutos();

//        }
//        else if (opcao == "0")
//        {
//            sair = true;
//        }

//    }


//}


//void MenuProdutos()
//{
//    bool voltar = false;
//    while (!voltar)
//    {
//        Console.Clear();
//        Console.WriteLine("==== Gerenciar Produtos ====");
//        Console.WriteLine("1. Listar produtos");
//        Console.WriteLine("2. Detalhes do produto");
//        Console.WriteLine("3. Cadastrar produto");
//        Console.WriteLine("5. Remover produto");
//        Console.WriteLine("0. Voltar");
//        string? opcao = Console.ReadLine();
//        switch (opcao)
//        {
//            case "1":
//                produtoController.Listar();
//                break;
//            case "2":
//                produtoController.Descricao();
//                break;
//            case "3":
//                produtoController.Adicionar();
//                break;
//            case "5":
//                produtoController.Remover();
//                break;
//            case "0":
//                voltar = true;
//                break;
//        }
//    }
//}

//void MenuUsuarios()
//{
//    bool voltar = false;
//    while (!voltar)
//    {
//        Console.Clear();
//        Console.WriteLine("==== Gerenciar Usuários ====");
//        Console.WriteLine("1. Listar usuários");
//        Console.WriteLine("2. Detalhes do usuário");
//        Console.WriteLine("3. Cadastrar usuário");
//        Console.WriteLine("4. Atualizar usuário");
//        Console.WriteLine("5. Remover usuário");

//        Console.WriteLine("0. Voltar");

//        string? opcao = Console.ReadLine();

//        switch (opcao)
//        {
//            case "1":
//                usuarioController.Listar();
//                break;
//            case "2":
//                usuarioController.Detalhes();
//                break;
//            case "3":
//                usuarioController.Adicionar();
//                break;
//            case "4":
//                usuarioController.AtualizarUsuario();
//                break;
//            case "5":
//                usuarioController.Remover();
//                break;
//            case "0":
//                voltar = true;
//                break;

//        }
//    }

//}