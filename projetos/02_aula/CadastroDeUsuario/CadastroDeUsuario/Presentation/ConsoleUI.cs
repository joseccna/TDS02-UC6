using CadastroDeUsuario.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeUsuario.Presentation
{
    internal class ConsoleUI
    {
        private UsuarioController _usuarioController;

        private ProdutoController _produtoController;

        

        public ConsoleUI(UsuarioController usuarioController) 
        {
            _usuarioController = usuarioController;
        
        }

        public ConsoleUI(ProdutoController produtoController)
        {
            _produtoController = produtoController;
        }

        //MenuPrincipal();

        public void MenuPrincipal()
        {
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("==== Menu Principal ====");
                Console.WriteLine("1. Gerenciar Usuários");
                Console.WriteLine("2. Gerenciar Produtos");
                Console.WriteLine("0. Sair");

                string? opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    MenuUsuarios();
                }
                else if (opcao == "2")
                {
                    // MenuProdutos();
                    MenuProdutos();

                }
                else if (opcao == "0")
                {
                    sair = true;
                }

            }


        }


        void MenuProdutos()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("==== Gerenciar Produtos ====");
                Console.WriteLine("1. Listar produtos");
                Console.WriteLine("2. Detalhes do produto");
                Console.WriteLine("3. Cadastrar produto");
                Console.WriteLine("5. Remover produto");
                Console.WriteLine("0. Voltar");
                string? opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        _produtoController.Listar();
                        break;
                    case "2":
                        _produtoController.Descricao();
                        break;
                    case "3":
                        _produtoController.Adicionar();
                        break;
                    case "5":
                        _produtoController.Remover();
                        break;
                    case "0":
                        voltar = true;
                        break;
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
                Console.WriteLine("2. Detalhes do usuário");
                Console.WriteLine("3. Cadastrar usuário");
                Console.WriteLine("4. Atualizar usuário");
                Console.WriteLine("5. Remover usuário");

                Console.WriteLine("0. Voltar");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _usuarioController.Listar();
                        break;
                    case "2":
                        _usuarioController.Detalhes();
                        break;
                    case "3":
                        _usuarioController.Adicionar();
                        break;
                    case "4":
                        _usuarioController.AtualizarUsuario();
                        break;
                    case "5":
                        _usuarioController.Remover();
                        break;
                    case "0":
                        voltar = true;
                        break;

                }
            }

        }
    }
}
