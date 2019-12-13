using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RoleTopMvc.Controllers
{
    public class AbstractController : Controller 
    {
        protected const string SESSION_CLIENTE_EMAIL = "cliente_email";
        protected const string SESSION_CLIENTE_NOME = "cliente_nome";
        protected const string  SESSION_TIPO_USUARIO = "tipo_usuario";
        protected string ObterUsuarioSession()
        {
            var email = HttpContext.Session.GetString(SESSION_CLIENTE_EMAIL); //
            if(!string.IsNullOrEmpty(email)) //caso atinja o tempo limite os dados do usuario vão ser apagados 
            {
                return email;
            } 
            else
            {
                return "";
            }
        }

        protected string ObterUsuarioNomeSession()
        {
            var nome = HttpContext.Session.GetString(SESSION_CLIENTE_NOME); //
            if(!string.IsNullOrEmpty(nome)) //caso atinja o tempo limite os dados do usuario vão ser apagados 
            {
                return nome;
            } 
            else
            {
                return "";
            }
        }
        protected string ObterUsuarioTipoSession()
        {
            var tipoUsuario = HttpContext.Session.GetString(SESSION_TIPO_USUARIO); //
            if(!string.IsNullOrEmpty(tipoUsuario)) //caso atinja o tempo limite os dados do usuario vão ser apagados 
            {
                return tipoUsuario;
            } 
            else
            {
                return "";
            }
        }
    }
}