using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Servicos.Cliente.Modelos
{
    class ClienteModelo
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }

        public override string ToString()
        {
            return "Nome Completo: "
                + NomeCompleto
                + System.Environment.NewLine
                + "Idade: "
                + Idade
                + " anos"
                + System.Environment.NewLine
                + "Email: "
                + Email
                + System.Environment.NewLine
                + "Telefone Celular: "
                + TelefoneCelular
                + System.Environment.NewLine
        }
    }
}
