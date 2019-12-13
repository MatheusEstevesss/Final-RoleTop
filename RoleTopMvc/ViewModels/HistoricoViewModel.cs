using System.Collections.Generic;
using RoleTopMvc.Models;

namespace RoleTopMvc.ViewModels
{
    public class HistoricoViewModel : BaseViewModel
    {
        public List<Evento> Eventos {get; set;}
    }
}