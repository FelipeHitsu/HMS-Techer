using System;
using HMS_Techer.Exceptions;

namespace HMS_Techer.Servicos.Cliente.Modelos
{
    public class ClienteFormularioModel
    {

        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }

        
        public override string ToString()
        {
            return System.Environment.NewLine
                 + "\t\t     Nome Completo: "
                 + NomeCompleto
                 + System.Environment.NewLine
                 + "\t\t     Cpf: "
                 + Cpf
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
