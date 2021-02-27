using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using HMS_Techer.Servicos.Cliente.Modelos;
using HMS_Techer.Servicos;

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
                using (StreamReader sr = File.OpenText(DadosLocais.ArquivoClientes))
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

                using (StreamReader sr = File.OpenText(DadosLocais.ArquivoQuartos))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] dadosLidos = line.Split(',');

                        DadosLocais.Quartos.Add(new Entidades.Quarto
                        {
                            QuartoId = int.Parse(dadosLidos[0]),
                            Tipo = Servicos.Quarto.QuartoServico.ParseTipoQuarto(int.Parse(dadosLidos[1])),
                            Situacao = Servicos.Quarto.QuartoServico.ParseSituacao(int.Parse(dadosLidos[2])),
                        });
                    }

                }

                using (StreamReader sr = File.OpenText(DadosLocais.ArquivoReservas))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] dadosLidos = line.Split(',');
                        //string[] HospedeCpfTestes = dadosLidos[5].Split('/');

                        DadosLocais.Reservas.Add(
                                new Entidades.Reserva
                                {
                                    ReservaId = int.Parse(dadosLidos[0]),
                                    DataCriacao = DateTime.Parse(dadosLidos[1]),
                                    DataCheckIn = DateTime.Parse(dadosLidos[2]),
                                    DataCheckOut = DateTime.Parse(dadosLidos[3]),
                                    Cliente = Servicos.Cliente.ClienteServico.BuscarCliente(dadosLidos[4]),
                                    HospedesJSON = dadosLidos[5],
                                    Quarto = Servicos.Quarto.QuartoServico.BuscarQuarto(int.Parse(dadosLidos[6])),
                                    QuartoSituacaoID = int.Parse(dadosLidos[7]),
                                    ValorDiarias = double.Parse(dadosLidos[8],CultureInfo.InvariantCulture),
                                    TaxasConsumo = double.Parse(dadosLidos[9], CultureInfo.InvariantCulture),
                                    ValorFinal = double.Parse(dadosLidos[10], CultureInfo.InvariantCulture)
                                }
                                );
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro: ");
                Console.WriteLine(e.Message);
            }
        }

        public static void SalvarTodosOsDados()
        {
            try
            {
                //Escrever Clientes no CSV
                File.WriteAllText(DadosLocais.ArquivoClientes, string.Empty);
                using (StreamWriter sw = File.AppendText(DadosLocais.ArquivoClientes))
                {
                    foreach (Entidades.Cliente cliente in DadosLocais.ClienteCadastrados)
                    {
                        sw.WriteLine(
                            cliente.Cpf
                            + ","
                            + cliente.NomeCompleto
                            + ","
                            + cliente.DataNascimento.ToString()
                            + ","
                            + cliente.Email
                            + ","
                            + cliente.TelefoneCelular
                            + ","
                            + cliente.DataCriacao.ToString()
                            );

                    }
                }
                //Escrever Quartos no CSV
                /*File.WriteAllText(DadosLocais.ArquivoQuartos, string.Empty);
                using (StreamWriter sw = File.AppendText(DadosLocais.ArquivoQuartos))
                {
                    foreach (Entidades.Quarto quarto in DadosLocais.Quartos)
                    {
                        sw.WriteLine(quarto.QuartoId + "," + quarto.Tipo.TipoId + "," + quarto.Situacao.SituacaoId);
                    }

                }
                //Escrever Reservas no CSV
                File.WriteAllText(DadosLocais.ArquivoReservas, string.Empty);
                using (StreamWriter sw = File.AppendText(DadosLocais.ArquivoReservas))
                {
                    foreach (Entidades.Reserva reserva in DadosLocais.Reservas)
                    {
                        sw.WriteLine(
                            reserva.ReservaId
                            + ","
                            + reserva.DataCriacao.ToString()
                            + ","
                            + reserva.DataCheckIn.ToString()
                            + ","
                            + reserva.DataCheckOut.ToString()
                            + ","
                            + reserva.Cliente.Cpf
                            + ","
                            + reserva.HospedesJSON
                            + ","
                            + reserva.Quarto.QuartoId
                            + ","
                            + reserva.Quarto.Situacao.SituacaoId
                            + ","
                            + reserva.ValorDiarias.ToString("F2", CultureInfo.InvariantCulture)
                            + ","
                            + reserva.TaxasConsumo.ToString("F2", CultureInfo.InvariantCulture)
                            + ","
                            + reserva.ValorFinal.ToString("F2", CultureInfo.InvariantCulture)
                            );
                    }

                }*/

                Console.WriteLine("Dados Salvos com sucesso");

            }
            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro: ");
                Console.WriteLine(e.Message);
            }

        }

        public static void AtualizarDados()
        {


        }
    }
}
