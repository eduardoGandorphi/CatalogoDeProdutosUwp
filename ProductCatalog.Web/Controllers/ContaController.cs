using ProductCatalog.DAO;
using ProductCatalog.Model;
using ProductCatalog.Services;
using ProductCatalog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductCatalog.Web.Controllers
{
    public class ContaController : Controller
    {
        //Serviço de banco de dados
        DataContext contextoBd;

        public ContaController()
        {
            contextoBd = new DataContext();
        }

        public ActionResult Logout ()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }


        // GET: Conta
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Conta conta)
        {
            if (ModelState.IsValid){
                var usuarioServicoBd = new UsuarioService(contextoBd);

                var contaUsuario = usuarioServicoBd
                    .Buscar(conta.Email, conta.Senha);

                if (contaUsuario == null)
                {
                    ModelState.AddModelError("Conta", "E-mail ou senha inválido");
                }

                //Gera o cookie do usuário autenticado
                var cookie = AutenticarPorCookie(contaUsuario, "Admin");

                //Manda o cookie para o computador do cliente
                Response.Cookies.Add(cookie);

                //envia para area admin
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }

        private HttpCookie AutenticarPorCookie(Usuario usuario, string permissao)
        {
            //Cria o ticket de autnticação
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usuario.Nome, DateTime.Now,
                DateTime.Now.AddMinutes(30), false, permissao,"/");

            //Cria o cookie de autentificação
            HttpCookie cookie = new HttpCookie(
                FormsAuthentication.FormsCookieName,
                FormsAuthentication.Encrypt(ticket));
            return cookie;
        }

    }
}