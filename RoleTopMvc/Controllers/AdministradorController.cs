using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Enums;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class AdministradorController : AbstractController
    {
        EventoRepository eventoRepository = new EventoRepository();
        public IActionResult Dashboard()
        {
            var ninguemLogado= string.IsNullOrEmpty(ObterUsuarioTipoSession());
            if(!ninguemLogado && (uint) TiposUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
                var eventos = eventoRepository.ObterTodos();
                DashboardViewModel dashboardViewModel = new DashboardViewModel();

                foreach (var evento in eventos)
                {
                    switch (evento.Status)
                    {
                        case (uint) StatusEvento.APROVADO:
                            dashboardViewModel.EventosAprovados++;
                        break;

                        case (uint) StatusEvento.REPROVADO:
                        dashboardViewModel.EventosReprovados++;
                        break;

                        default:
                            dashboardViewModel.EventosPendentes++;
                            dashboardViewModel.Eventos.Add(evento);
                        break;
                    }
                }
                dashboardViewModel.NomeView = "Dashboard";
                dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

                return View(dashboardViewModel);
            }
            else 
            {
                return View("Erro", new RespostaViewModel()
                {
                    NomeView = "Dashboard",
                    Mensagem = "Voce não pode acessar está parte"
                });
            }
        }
    }
}