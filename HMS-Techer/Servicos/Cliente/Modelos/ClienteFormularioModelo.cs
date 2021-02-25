using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Dados;

namespace HMS_Techer.Servicos.Cliente.Modelos
{
    class ClienteFormularioModelo
    {
        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }
    }
}
