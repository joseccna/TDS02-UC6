using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoEstacionamento.Models
{
    internal class Cliente
    {

        public Cliente(string nome)
        {
            Nome = nome;
            
        }


        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }
}
