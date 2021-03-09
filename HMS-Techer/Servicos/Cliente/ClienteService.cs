using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Servicos.Cliente.Modelos;
using HMS_Techer.Entidades;
using HMS_Techer.Dados;
using System.Linq;

namespace HMS_Techer.Servicos.Cliente
{
    class ClienteService
    {
        //Retirar estatico trabalhar por instancia
        //Cadastrar - Ja esta na service cliente
        public static void CadastrarCliente(ClienteFormularioModel clienteFormularioModel)
        {
            //Sem estatico construtor da classe faz a referencia do contexto
            var context = new HmsTecherContext();
            context.Cliente.Add(new Entidades.Cliente
            {
                Cpf = clienteFormularioModel.Cpf,
                NomeCompleto = clienteFormularioModel.NomeCompleto,
                DataNascimento = clienteFormularioModel.DataNascimento,
                Email = clienteFormularioModel.Email,
                TelefoneCelular = clienteFormularioModel.TelefoneCelular,
                DataCriacao = DateTime.Now
            }
            );
            context.SaveChanges();
        }
        public static List<ClienteModel> ListarTodosOsClientes()
        {
            var context = new HmsTecherContext();
            var clientes = context.Cliente
                .AsQueryable()
                .OrderBy(c => c.DataCriacao)
                .Select(c => new ClienteModel
                {
                    NomeCompleto = c.NomeCompleto,
                    DataNascimento = c.DataNascimento,
                    Idade = DateTime.Now.Year - c.DataNascimento.Year,
                    Email = c.Email,
                    TelefoneCelular = c.TelefoneCelular
                }).ToList();
            return clientes;
        }
        //Validação no service
        public static ClienteFormularioModel BuscarClienteCompleto(string cpf)
        {
            var context = new HmsTecherContext();
            var clienteBusca = context.Cliente
                .Where(c => c.Cpf == cpf)
                .Select(c => new ClienteFormularioModel
                {
                    Cpf = c.Cpf,
                    NomeCompleto = c.NomeCompleto,
                    DataNascimento = c.DataNascimento,
                    Email = c.Email,
                    TelefoneCelular = c.TelefoneCelular
                }).FirstOrDefault();

            if (clienteBusca == null)
                return null;

            return clienteBusca;
        }
        public static ClienteModel BuscarCliente(string cpf)
        {
            var context = new HmsTecherContext();
            var clienteBusca = context.Cliente
                .Where(c => c.Cpf == cpf)
                .Select(c => new ClienteModel
                {
                    NomeCompleto = c.NomeCompleto,
                    DataNascimento = c.DataNascimento,
                    Idade = DateTime.Now.Year - c.DataNascimento.Year,
                    Email = c.Email,
                    TelefoneCelular = c.TelefoneCelular
                }).FirstOrDefault();

            if (clienteBusca == null)
                return null;

            return clienteBusca;
        }
    }
}
