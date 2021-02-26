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

        private static string Arquivo = @"C:\Users\felipe.santos\Documents\Codes\Techer HMS\HMS-Techer\HMS-Techer\Dados\Tabelas";
        private static string ArquivoCasa = @"F:\Documentos\Projetos\C#\HMS Techer\HMS-Techer\Dados\Tabelas";
        public static string ArquivoClientes { get; private set; } = ArquivoCasa + @"\Clientes.csv";
        public static string ArquivoQuartos { get; private set; } = ArquivoCasa + @"\Quartos.csv";
        public static string ArquivoReservas { get; private set; } = ArquivoCasa + @"\Reservas.csv"; 
       
    }
}
