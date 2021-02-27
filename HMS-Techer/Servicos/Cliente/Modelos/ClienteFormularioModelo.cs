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

        public void Validar()
        {
            // fazer um try catch com todas as validações com excessoes customizadas
            if (string.IsNullOrEmpty(Cpf) || Cpf.Length != 11)
                throw new Exception("CPF Invalido ou não preenchido!");
        }
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
