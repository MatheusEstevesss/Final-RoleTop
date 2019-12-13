using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMvc.Enums;
using RoleTopMvc.Models;
using RoleTopMvc.Repositories;
using RoleTopMvc.ViewModels;
using RoleTopMVC.Models;
using System;

namespace RoleTopMvc.Controllers
{  
    public class EventoController : AbstractController
    {
        EventoRepository eventoRepository = new EventoRepository();
        ServicosRepository servicosRepository = new ServicosRepository();
        PagamentoRepository pagamentoRepository = new PagamentoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index()
        {
            EventoViewModel evm = new EventoViewModel();
            evm.Servicos = servicosRepository.ObterTodos();
            evm.Pagamento = pagamentoRepository.ObterTodos();

            var usuarioLogado = ObterUsuarioSession();

            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            evm.NomeUsuario = ObterUsuarioNomeSession();;

            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                evm.NomeUsuario = nomeUsuarioLogado;
            }
            var clienteLogado = clienteRepository.obterPor(usuarioLogado);
            if(clienteLogado != null)
            {
                evm.Cliente = clienteLogado;
            }

            evm.NomeView = "Evento";
            evm.UsuarioEmail = usuarioLogado;
            evm.UsuarioNome = nomeUsuarioLogado;
            
            return View(evm);
        }

        public IActionResult Registrar(IFormCollection form)
        {
            ViewData["Action"] = "Evento";
            Evento evento  = new Evento();

            var nomeServicos = form["opcao-servicos"];
            Servicos servicos = new Servicos();
            servicos.Nome = nomeServicos;
            servicos.Preco = servicosRepository.obterPrecoDe(nomeServicos);

            evento.Servicos = servicos;

            var nomePagamento = form["forma-pagamento"];
            Pagamento pagamento = new Pagamento(nomePagamento, pagamentoRepository.obterPrecoDe(nomePagamento));   

            evento.Pagamento = pagamento;

            // var nomeServicos = form["opcao-servicos"];
            // Servicos servicos = new Servicos (nomeServicos, servicosRepository.obterPrecoDe(nomeServicos));

            // evento.Servicos = servicos;
            
            Cliente cliente = new Cliente()
            {
                Nome = form["nome"],
                Endereco = form["endereco"],
                Email = form["email"],
                Telefone = form["telefone"],
                Documento = form["documento"]
            };

            evento.Cliente = cliente;

            if(eventoRepository.Inserir(evento))
            {
                return View("Sucesso", new RespostaViewModel()
                {
                    Mensagem = "Aguarde a aprovação dos nossos administradores",
                    NomeView = "Sucesso",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
            else
            {
                return View("Erro", new RespostaViewModel()
                {
                    Mensagem = "Houve um erro ao processar o seu pedido",
                    NomeView = "Erro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }

        public IActionResult Aprovar (ulong id)
        {
            var evento = eventoRepository.obterPor(id);
            evento.Status = (uint) StatusEvento.APROVADO;

            if(eventoRepository.Atualizar(evento))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else
            {
                return View("Erro", new RespostaViewModel("Não foi possível aprovar este pedido")
                {
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });  
            }
        }

        public IActionResult Reprovar (ulong id)
        {
            var evento = eventoRepository.obterPor(id);
            evento.Status = (uint) StatusEvento.REPROVADO;

            if(eventoRepository.Atualizar(evento))
            {
                return RedirectToAction("Dashboard", "Administrador");
            }
            else
            {
                return View("Erro", new RespostaViewModel("Não foi possível aprovar este pedido")
                {
                    NomeView = "Dashboard",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });  
            }
        }
    }
}