using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Entidades
{
    class Cliente
    {
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
