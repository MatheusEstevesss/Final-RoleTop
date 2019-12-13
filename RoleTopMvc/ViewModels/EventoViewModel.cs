using System.Collections.Generic;
using RoleTopMvc.Models;
using RoleTopMVC.Models;

namespace RoleTopMvc.ViewModels
{
    public class EventoViewModel : BaseViewModel
    {
        public List<Servicos> Servicos {get; set;}
        public List<Pagamento> Pagamento {get; set;}
        public string NomeUsuario {get; set;}
        public Cliente Cliente {get; set;}
        

        public EventoViewModel()
        {
            this.Servicos = new List<Servicos>();
            this.Pagamento = new List<Pagamento>();
            this.NomeUsuario = "Doppelganger";
            this.Cliente = new Cliente();
        }
    }
}