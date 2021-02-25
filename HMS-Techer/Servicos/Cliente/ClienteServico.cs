using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Servicos.Cliente.Modelos;
using HMS_Techer.Entidades;

namespace HMS_Techer.Servicos.Cliente
{
    class ClienteServico
    {
        public static void CadastrarCliente(ClienteFormularioModelo clienteFormularioModelo)
        {
            Dados.DadosLocais.ClienteCadastrados.Add(new Entidades.Cliente
            {
                Cpf = clienteFormularioModelo.Cpf,
                NomeCompleto = clienteFormularioModelo.NomeCompleto,
                DataNascimento = clienteFormularioModelo.DataNascimento,
                Email = clienteFormularioModelo.Email,
                TelefoneCelular = clienteFormularioModelo.TelefoneCelular,
                DataCriacao = DateTime.Now
            });
        }

        public static void BuscarCliente(string cpf)
        {
            Entidades.Cliente clienteBusca = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == cpf);

            if (clienteBusca != null)
            {
                ClienteModelo clienteModelo = new ClienteModelo
                {
                    NomeCompleto = clienteBusca.NomeCompleto,
                    DataNascimento = clienteBusca.DataNascimento,
                    Idade = DateTime.Now.Year - clienteBusca.DataNascimento.Year,
                    Email = clienteBusca.Email,
                    TelefoneCelular = clienteBusca.TelefoneCelular
                };
                Console.WriteLine("Cliente ja cadastrado: " + clienteModelo.ToString());
            }
            else
                Console.WriteLine("Cliente não cadastrado");
        }
    }
}
