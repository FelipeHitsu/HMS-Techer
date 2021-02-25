using HMS_Techer.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_Techer.Dados
{
    class DadosLocais
    {
        public static List<Cliente> ClienteCadastrados = new List<Cliente>();

        public static List<Quarto> Quartos = new List<Quarto>();

        public static List<Reserva> Reservas = new List<Reserva>;

        private string ArquivoClientes = "";

        private string ArquivoQuartos = "";

        public string Arquivo { get; private set; } = ""; 
       
    }
}
