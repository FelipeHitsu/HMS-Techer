using System;

namespace HMS_Techer.Views
{
    class Inicio 
    {
        public static Telas Run()
        {

            Console.Clear();
            Tela.Header();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t Bem Vindo");
            Console.Write("\t\t\t Insira seu nome: ");
            Dados.DadosLocais.NomeFuncionario = Console.ReadLine();
            

            return Telas.MenuPrincipal;
        }
    }
}
