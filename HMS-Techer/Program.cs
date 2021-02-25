using System;
using System.Threading;

namespace HMS_Techer
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.SetWindowSize(120, 30);

            //Views.Tela.ConfigurarJanela();
            Console.WriteLine("Hello World!");
            Thread.Sleep(1000);
            Views.Tela.Carregar();
            Console.WriteLine("OK");*/

            Dados.DadosServico.CarregarDados();

            Console.ReadLine();
        }
    }
}
