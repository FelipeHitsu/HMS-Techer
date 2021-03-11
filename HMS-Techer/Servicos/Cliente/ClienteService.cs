using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Servicos.Cliente.Modelos;
using HMS_Techer.Exceptions;
using HMS_Techer.Dados;
using System.Linq;

namespace HMS_Techer.Servicos.Cliente
{
    class ClienteService
    {
        private readonly HmsTecherContext _context;

        public ClienteService(HmsTecherContext context)
        {
            _context = context;
        }


        //Retirar estatico trabalhar por instancia
        //Cadastrar - Ja esta na service cliente
        public void CadastrarCliente(ClienteFormularioModel clienteFormularioModel)
        {
            //Sem estatico construtor da classe faz a referencia do contexto
            _context.Cliente.Add(new Entidades.Cliente
            {
                Cpf = clienteFormularioModel.Cpf,
                NomeCompleto = clienteFormularioModel.NomeCompleto,
                DataNascimento = clienteFormularioModel.DataNascimento,
                Email = clienteFormularioModel.Email,
                TelefoneCelular = clienteFormularioModel.TelefoneCelular,
                DataCriacao = DateTime.Now
            }
            );
            _context.SaveChanges();
        }
        public List<ClienteModel> ListarTodosOsClientes()
        {
            var clientes = _context.Cliente
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
        public ClienteFormularioModel BuscarClienteCompleto(string cpf)
        {
            var clienteBusca = _context.Cliente
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
        public ClienteModel BuscarCliente(string cpf)
        {
            var clienteBusca = _context.Cliente
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

        public bool Validar(ClienteFormularioModel cliente)
        {
            try
            {
                if (string.IsNullOrEmpty(cliente.Cpf) || cliente.Cpf.Length != 11)
                    throw new MyException("CPF Invalido ou não preenchido!");

                if (string.IsNullOrEmpty(cliente.NomeCompleto))
                    throw new MyException("Nome não preenchido");

                if (string.IsNullOrEmpty(cliente.DataNascimento.ToString()) || cliente.DataNascimento > DateTime.Now || (DateTime.Now.Year - cliente.DataNascimento.Year) < 18)
                    throw new MyException("Data de nascimento Invalida ou não preenchida");

                if (string.IsNullOrEmpty(cliente.Email))
                    throw new MyException("Email não preenchido");

                if (string.IsNullOrEmpty(cliente.TelefoneCelular) || cliente.TelefoneCelular.Length != 11)
                    throw new MyException("Telefone Invalido ou não preenchido!");

                var cpfBusca = BuscarCliente(cliente.Cpf);

                if (cpfBusca != null)
                    throw new MyException("CPF ja cadastrado !");
            }
            catch (MyException e)
            {
                Console.WriteLine("Erro no cadastro: " + e.Message);
                return false;
            }
            return true;
        }
    }
}
