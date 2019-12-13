using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Enums;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        private EventoRepository eventoRepository = new EventoRepository();
        [HttpGet]
        public IActionResult Login()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        public IActionResult Login (IFormCollection form)
        {
            ViewData["Action"] = "Login";
            try
            {
                System.Console.WriteLine("++++++++++++++++++++");
                System.Console.WriteLine(form["email"]);
                System.Console.WriteLine(form["senha"]);
                System.Console.WriteLine("++++++++++++++++++++");

                var usuario = form["email"];
                var senha = form["senha"];

                var cliente = clienteRepository.obterPor(usuario);

                if(cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        switch (cliente.TipoUsuario)
                        {
                            case (uint) TiposUsuario.CLIENTE:
                            HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                            HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                            HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());
                            return RedirectToAction("Historico", "Cliente");

                            default:
                                HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                                HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                                HttpContext.Session.SetString(SESSION_TIPO_USUARIO, cliente.TipoUsuario.ToString());
                                return RedirectToAction("Dashboard", "Administrador");
                        }
                    }
                    else
                    {
                        return View ("Erro", new RespostaViewModel()
                        {   
                            Mensagem = $"senha incorreta {senha}",
                            NomeView = "Erro"
                        });
                    }
                }
                else 
                {
                    return View("Erro", new RespostaViewModel ()
                    {
                        Mensagem = $"Usuario: {usuario} não foi encontrado",
                        NomeView = "Erro"                        
                    });
                }
            }
            catch(Exception e){
                System.Console.WriteLine("======================");
                System.Console.WriteLine(e.StackTrace);
                 System.Console.WriteLine("======================");
                return View("Erro",new RespostaViewModel()
                {
                    NomeView = "Erro"
                });
            } 
        }
        public IActionResult Historico()
        {
            var emailCliente = ObterUsuarioSession();
            var evento = eventoRepository.ObterTodosPorCliente(emailCliente);
            return View(new HistoricoViewModel()
            {
                Eventos = evento,
                NomeView = "Historico",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
                return RedirectToAction ("Index", "Home");
        }
    }
}