using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Servicos.Cliente.Modelos
{
    class ClienteModel
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }

        public override string ToString()
        {
            return System.Environment.NewLine
                + "\t\t     Nome Completo: "
                + NomeCompleto
                + System.Environment.NewLine
                + "\t\t     Idade: "
                + Idade
                + " anos"
                + System.Environment.NewLine
                + "\t\t     Email: "
                + Email
                + System.Environment.NewLine
                + "\t\t     Telefone Celular: "
                + TelefoneCelular
                + System.Environment.NewLine;
        }
    }
}
