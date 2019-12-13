using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class GaleriaController : AbstractController
    {
        public IActionResult Galeria()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Galeria",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
        public IActionResult Aniversario()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Aniversario",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
        public IActionResult Baladas()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Baladas",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
        public IActionResult Palestras()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Palestras",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }
    }
}