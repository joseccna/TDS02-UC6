using CadastroDeUsuario.Controller;
using CadastroDeUsuario.Data;
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

}).Build();

var usuarioController = host.Services.GetRequiredService<UsuarioController>();

MenuPrincipal();

void MenuPrincipal()
{
    bool sair = false;
    while (!sair) 
    {
        Console.Clear();
        Console.WriteLine("==== Menu Principal ====");
        Console.WriteLine("1. Gerenciar Usuários");
        Console.WriteLine("0. Sair");

        string? opcao = Console.ReadLine();

        if (opcao == "1")
        {
            MenuUsuarios();
        } 
        else if (opcao == "0")
        {
            sair = true;
        }

    }


}

void MenuUsuarios()
{
    bool voltar = false;
    while (!voltar)
    {
        Console.Clear();
        Console.WriteLine("==== Gerenciar Usuários ====");
        Console.WriteLine("1. Listar usuários");
        Console.WriteLine("2. Cadastrar usuário");
        Console.WriteLine("0. Voltar");

        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                usuarioController.Listar();
                break;
            case "2":
                usuarioController.Adicionar();
                break;
            case "0":
                voltar = true;
                break;

        }
    }

}