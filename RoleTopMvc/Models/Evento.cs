using System;
using RoleTopMvc.Enums;
using RoleTopMVC.Models;

namespace RoleTopMvc.Models
{
    public class Evento
    {
        public ulong Id {get; set;}
        public Cliente Cliente {get; set;}
        public DateTime DataDoEvento {get; set;}
        public Servicos Servicos {get; set;}
        public Pagamento Pagamento {get; set;}
        public string FormaPagamento {get; set;}
        public string TipoEvento {get; set;}
        public string TipoPessoa {get; set;}
        public string OpcaoServicos {get; set;}
        public string Descricao {get; set;}
        public uint Status {get; set;}

        public Evento ()
        {
            this.Cliente = new Cliente();
            this.Servicos = new Servicos();
            this.Pagamento = new Pagamento();
            this.DataDoEvento = DataDoEvento;
            this.FormaPagamento = FormaPagamento;
            this.TipoEvento = TipoEvento;
            this.TipoPessoa = TipoPessoa;
            this.OpcaoServicos = OpcaoServicos;
            this.Descricao = Descricao;
            this.Id = 0;
            this.Status = (uint) StatusEvento.PENDENTE;
        }
    }
}