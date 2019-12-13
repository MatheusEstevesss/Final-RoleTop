using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Enums;
using RoleTopMvc.Models;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;

namespace RoleTopMvc.Controllers
{
    public class CadastroController : AbstractController
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Cadastro()
        {
            return View(new BaseViewModel()
            {
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()

            });
        }
        public IActionResult CadastrarCliente (IFormCollection form)
        {
            ViewData["Action"] = "Cadastro";
            try{
                Cliente cliente = new Cliente(
                    form["nome"],
                    form["email"],
                    form["documento"],
                    form["telefone"],
                    DateTime.Parse(form["data-nascimento"]),
                    form["endereco"],
                    form["senha"]                                  
                );
                cliente.TipoUsuario = (uint) TiposUsuario.CLIENTE;

                clienteRepository.Inserir(cliente);

                return View("Sucesso", new RespostaViewModel()
                {
                    Mensagem = "Cadastro realizado com sucesso",
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }

            catch (Exception e){
                System.Console.WriteLine(e.StackTrace);
                return View("Erro", new RespostaViewModel($"Nao foi possível realizar o cadastro"));
            }
        }
    }
}