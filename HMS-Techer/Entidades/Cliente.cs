using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HMS_Techer.Entidades
{
    public class Cliente
    {
        public Cliente()
        {

        }
        [Key]
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
