using System;
using System.Collections.Generic;
using System.Text;
using HMS_Techer.Dados;

namespace HMS_Techer.Servicos.Cliente.Modelos
{
    class ClienteFormularioModelo
    {
        public string Cpf { get; set; }
        public string NomeCompletoModelo { get; set; }
        public DateTime DataNascimentoModelo { get; set; }
        public string EmailModelo { get; set; }
        public string TelefoneCelularModelo { get; set; }

        public void AdicionarNovoCliente()
        {
            DadosLocais.ClienteCadastrados.Add(new Entidades.Cliente
            {
                Cpf = Cpf
            }) ;

        }

    }
}
