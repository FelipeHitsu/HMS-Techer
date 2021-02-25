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

        public static List<Reserva> Reservas = new List<Reserva>();

        public string ArquivoClientes { get; private set; } = "";
        public string ArquivoQuartos { get; private set; } = "";
        public string ArquivoReservas { get; private set; } = ""; 
       
    }
}
