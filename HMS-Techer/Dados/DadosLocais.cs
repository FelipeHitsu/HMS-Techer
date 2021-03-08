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

        public static string NomeFuncionario;


        private static string Arquivo = @"C:\Users\felipe.santos\Documents\Codes\Techer HMS\HMS-Techer\HMS-Techer\Dados\Tabelas";
        private static string ArquivoCasa = @"F:\Documentos\Projetos\C#\HMS-Techer\HMS-Techer\Dados\Tabelas";

        public static string DbDefault = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=HmsTecher;Data Source=DESKTOP-V9S9EG0";
        public static string DbTecher = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=felipe.santos;Data Source=SERVER";

        public static string ArquivoClientes { get; private set; } = ArquivoCasa + @"\Clientes.csv";
        public static string ArquivoQuartos { get; private set; } = ArquivoCasa + @"\Quartos.csv";
        public static string ArquivoReservas { get; private set; } = ArquivoCasa + @"\Reservas.csv"; 
       
    }
}
