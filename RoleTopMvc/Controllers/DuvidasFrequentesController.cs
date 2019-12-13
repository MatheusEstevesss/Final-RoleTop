using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class DuvidasFrequentesController : AbstractController
    {
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                NomeView = "DuvidasFrequentes",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}