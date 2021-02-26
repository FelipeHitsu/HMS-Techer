using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Views
{
    class MenuPrincipal
    {
        public static int Run()
        {
            Console.Clear();
            Console.WriteLine("VOCE CHEGOU NO MENU PRINCIPAL");

            Console.ReadLine();

            return (int)Views.Telas.Inicio;
        }
    }
}
