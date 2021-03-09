using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class CadastroClientes 
    {
        public static int Run()
        {
            Console.Clear();
            Tela.Header();
            Tela.Footer();

            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t     Cadastrar um novo cliente               ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t                                             ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            Console.Write("\t\t Número CPF (11 Digitos sem pontuação): ");
            string cpfCadastro = Console.ReadLine();

            Console.Write("\t\t Nome Completo: ");
            string nomeCadastro = Console.ReadLine();

            Console.Write("\t\t Data de Nascimento (dd/MM/yyyy): ");
            DateTime dataNascimentoCadastro = DateTime.Parse(Console.ReadLine()); // erro caso vazio

            Console.Write("\t\t Email : ");
            string emailCadastro = Console.ReadLine();

            Console.Write("\t\t Telefone Celular (11 digitos numero e DDD): ");
            string telefoneCadastro = Console.ReadLine();

            var novoCadastro = new Servicos.Cliente.Modelos.ClienteFormularioModel
            {
                Cpf = cpfCadastro,
                NomeCompleto = nomeCadastro,
                DataNascimento = dataNascimentoCadastro,
                Email = emailCadastro,
                TelefoneCelular = telefoneCadastro
            };

            if (!novoCadastro.Validar())
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
                return (int)Views.Telas.MenuPrincipal;
            }


            Servicos.Cliente.ClienteService.CadastrarCliente(novoCadastro);

            Console.WriteLine();
            ConsolePrint.Print("\t\t     CADASTRO REALIZADO COM SUCESSO          ", ConsoleColor.Green, ConsoleColor.Gray);
            Console.WriteLine();
            ConsolePrint.Print("\t\t     Pressione qualquer tecla para retornar  ", ConsoleColor.DarkCyan, ConsoleColor.Gray);
            Console.WriteLine();

            Console.ReadLine();
            return (int)Views.Telas.MenuPrincipal;
        }
    }
}
