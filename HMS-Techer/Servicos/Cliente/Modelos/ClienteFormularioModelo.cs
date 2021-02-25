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
            if (string.IsNullOrEmpty(Cpf))
                throw new Exception("CPF Invalido ou não preenchido!");
        }
        public override string ToString()
        {
            return System.Environment.NewLine
                 + "Nome Completo: "
                 + NomeCompleto
                 + System.Environment.NewLine
                 + "Cpf: "
                 + Cpf
                 + System.Environment.NewLine
                 + "Email: "
                 + Email
                 + System.Environment.NewLine
                 + "Telefone Celular: "
                 + TelefoneCelular
                 + System.Environment.NewLine;
        }
    }

}
