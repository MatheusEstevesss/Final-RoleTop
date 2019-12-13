using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class SobreNosController : AbstractController
    {
        public IActionResult Index()
        {
            return View(new BaseViewModel()
            {
                NomeView = "SobreNos",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}