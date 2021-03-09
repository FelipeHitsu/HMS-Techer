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

        public bool Validar()
        {
            try
            {
                if (string.IsNullOrEmpty(Cpf) || Cpf.Length != 11)
                    throw new MyException("CPF Invalido ou não preenchido!");

                if (string.IsNullOrEmpty(NomeCompleto))
                    throw new MyException("Nome não preenchido");

                if (string.IsNullOrEmpty(DataNascimento.ToString()) || DataNascimento > DateTime.Now || (DateTime.Now.Year - DataNascimento.Year) < 18)
                    throw new MyException("Data de nascimento Invalida ou não preenchida");

                if (string.IsNullOrEmpty(Email))
                    throw new MyException("Email não preenchido");

                if (string.IsNullOrEmpty(TelefoneCelular) || TelefoneCelular.Length != 11)
                    throw new MyException("Telefone Invalido ou não preenchido!");

                var cpfBusca = ClienteService.BuscarCliente(Cpf);

                if (cpfBusca != null)
                    throw new MyException("CPF ja cadastrado !");
            }
            catch(MyException e)
            {
                Console.WriteLine("Erro no cadastro: " + e.Message);
                return false;
            }
            return true;
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
