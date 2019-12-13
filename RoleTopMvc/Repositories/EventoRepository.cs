using System;
using System.Collections.Generic;
using System.IO;
using RoleTopMvc.Models;
using RoleTopMVC.Models;

namespace RoleTopMvc.Repositories
{
    public class EventoRepository : RepositorieBase
    {
        private const string PATH = "Database/Evento.csv";

        public EventoRepository()
        {
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        public bool Inserir (Evento evento)
        {
            var quantidadeLinhas = File.ReadAllLines(PATH).Length;
            evento.Id = (ulong) ++quantidadeLinhas;

            var linha = new string[] {PrepararRegistroCSV(evento)};
            File.AppendAllLines(PATH, linha);
            return true;
        }
        public List<Evento> ObterTodosPorCliente(string emailCliente)
        {
            var eventosTotais = ObterTodos();

            List<Evento> eventosCliente = new List<Evento>();
            foreach (var evento in eventosTotais)
            {
                if(evento.Cliente.Email.Equals(emailCliente))
                {
                    eventosCliente.Add(evento);
                }
            }
            return eventosCliente;
        }
        public List<Evento> ObterTodos()
        {
            var linhas = File.ReadAllLines(PATH);
            List<Evento> eventos = new List<Evento>();
            foreach (var linha in linhas)
            {
                Evento evento = new Evento();

                evento.Id = ulong.Parse(ExtrairValorDoCampo("id", linha));
                evento.Status = uint.Parse(ExtrairValorDoCampo("status_evento", linha));
                evento.Cliente.Nome = ExtrairValorDoCampo ("cliente_nome", linha);
                evento.TipoPessoa = ExtrairValorDoCampo ("tipo_pessoa", linha);
                evento.Cliente.Documento = ExtrairValorDoCampo ("cliente_documento", linha);
                evento.Cliente.Telefone = ExtrairValorDoCampo ("cliente_telefone", linha);
                evento.Cliente.Email = ExtrairValorDoCampo ("cliente_email", linha);
                evento.DataDoEvento = DateTime.Parse(ExtrairValorDoCampo ("data_evento", linha));
                evento.Servicos.Nome = ExtrairValorDoCampo ("opcao_aluguel", linha);
                evento.FormaPagamento = ExtrairValorDoCampo ("forma_pagamento", linha);
                evento.TipoEvento = ExtrairValorDoCampo ("tipo_evento", linha);
                evento.Descricao = ExtrairValorDoCampo("descricao", linha);
            
                eventos.Add(evento);
            }
            return eventos;
        }
        public Evento obterPor(ulong id)
        {
            var eventosTotais = ObterTodos();
            foreach (var pedido in eventosTotais)
            {
                if(pedido.Id == id)
                {
                    return pedido;
                }
            }
            return null;
        }
        public bool Atualizar (Evento evento)
        {
            var eventosTotais = File.ReadAllLines(PATH);
            var eventoCSV = PrepararRegistroCSV(evento);
            var linhaEvento = -1;
            var resultado = false;

            for(int i =0; i < eventosTotais.Length; i++)
            {
                var idConvertido = ulong.Parse(ExtrairValorDoCampo("id", eventosTotais[i]));
                if (evento.Id.Equals(idConvertido))
                {
                    linhaEvento = i;
                    resultado = true;
                    break;
                }
            }
            if (resultado)
            {
                eventosTotais[linhaEvento] = eventoCSV;
                File.WriteAllLines(PATH,eventosTotais);
            }
            return resultado;
        }
        public string PrepararRegistroCSV(Evento evento)
        {
            Cliente cliente = evento.Cliente;
            Servicos s = evento.Servicos;
            Pagamento p = evento.Pagamento;

            
            return $"id={evento.Id};status_evento={evento.Status};cliente_nome={cliente.Nome};tipo_pessoa={evento.TipoPessoa};cliente_documento={cliente.Documento};cliente_telefone={cliente.Telefone};cliente_email={cliente.Email};data_evento={evento.DataDoEvento};opcao_aluguel={s.Nome};forma_pagamento={p.Nome};tipo_evento={evento.TipoEvento};descricao={evento.Descricao}";
        }
    }  
}