using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Servicos.Cliente.Modelos;
using HMS_Techer.Entidades;

namespace HMS_Techer.Servicos.Cliente
{
    class ClienteServico
    {
        public static void CadastrarCliente(ClienteFormularioModelo clienteFormularioModelo)//model
        {
            clienteFormularioModelo.Validar();
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
        public static void ListarTodosOsClientes()
        {
            foreach (Entidades.Cliente cliente in Dados.DadosLocais.ClienteCadastrados)
            {
                ClienteModelo clienteModelo = new ClienteModelo
                {
                    NomeCompleto = cliente.NomeCompleto,
                    DataNascimento = cliente.DataNascimento,
                    Idade = DateTime.Now.Year - cliente.DataNascimento.Year,
                    Email = cliente.Email,
                    TelefoneCelular = cliente.TelefoneCelular
                };

                Console.WriteLine(clienteModelo.ToString());
            }
        }
        public static void MostrarCliente(string cpf)
        {
            //Usar var
            Entidades.Cliente clienteBusca = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == cpf);

            ClienteModelo clienteModelo = new ClienteModelo
            {
                NomeCompleto = clienteBusca.NomeCompleto,
                DataNascimento = clienteBusca.DataNascimento,
                Idade = DateTime.Now.Year - clienteBusca.DataNascimento.Year,
                Email = clienteBusca.Email,
                TelefoneCelular = clienteBusca.TelefoneCelular
            };

            if (clienteBusca != null)
            {
                Console.WriteLine(clienteModelo.ToString());
            }
            else
                Console.WriteLine("Cliente não cadastrado");
        }

        public static ClienteFormularioModelo BuscarCliente(string cpf)
        {
            Entidades.Cliente clienteBusca = Dados.DadosLocais.ClienteCadastrados.Find(a => a.Cpf == cpf);

            if (clienteBusca == null)
                return null;

            ClienteFormularioModelo clienteFormularioModelo = new ClienteFormularioModelo
            {
                NomeCompleto = clienteBusca.NomeCompleto,
                DataNascimento = clienteBusca.DataNascimento,
                Cpf = clienteBusca.Cpf,
                Email = clienteBusca.Email,
                TelefoneCelular = clienteBusca.TelefoneCelular
            };

            return clienteFormularioModelo;
        }
    }
}
