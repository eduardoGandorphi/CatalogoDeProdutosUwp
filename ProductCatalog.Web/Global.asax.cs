using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace ProductCatalog.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Verifica a requisição do cliente ao servidor
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //Verifica se o cliente tem um cookie de autenticação
            var cookie = Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            //Verifica se existe um cookie válido
            if(cookie == null)
            {
                //Retorna pedindo para gerar um novo cookie
                return;
            }
            //Validar o cookie do usuário
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            //Pega os dados do cookie 
            var permissao = ticket.UserData.Split(",".ToCharArray());
            //Autentica o usuário e cria a identidade no servidor
            var identidade = new GenericPrincipal(new GenericIdentity(ticket.Name), permissao);
            //Adiciona ele na sessao atual no uso do sevidor
            Context.User = identidade;

        }
    }
}
