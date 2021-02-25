using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HMS_Techer.Servicos.Cliente.Modelos;

namespace HMS_Techer.Dados
{
    class DadosServico
    {
        public static void CarregarDados()
        {
            Console.WriteLine("Caminho arquivo Clientes: " + Path.GetFullPath(DadosLocais.ArquivoClientes));
            Console.WriteLine("Caminho arquivo Quartos: " + Path.GetFullPath(DadosLocais.ArquivoQuartos));
            Console.WriteLine("Caminho arquivo Reservas: " + Path.GetFullPath(DadosLocais.ArquivoReservas));

            DadosLocais.ClienteCadastrados.Clear();

            try
            {
                using(StreamReader sr = File.OpenText(DadosLocais.ArquivoClientes))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] dadosLidos = line.Split(',');

                        DadosLocais.ClienteCadastrados.Add(new Entidades.Cliente
                        {
                            Cpf = dadosLidos[0],
                            NomeCompleto = dadosLidos[1],
                            DataNascimento = DateTime.Parse(dadosLidos[2]),
                            Email = dadosLidos[3],
                            TelefoneCelular = dadosLidos[4],
                            DataCriacao = DateTime.Parse(dadosLidos[5])
                        });
                    }

                }
                
            }
            catch(IOException e)
            {
                Console.WriteLine("Ocorreu um erro: ");
                Console.WriteLine(e.Message);
            }
        }

        public static void SalvarDados()
        {

        }

        public static void AtualizarDados()
        {


        }

        /*public static void CadastrarNovoCliente(ClienteFormularioModelo clienteFormularioModelo)
        {
            //Fazer o append pro csv
        }*/

        /*public static ClienteModelo BuscarCliente(string cpf)
        {
            
        }*/
    }
}
