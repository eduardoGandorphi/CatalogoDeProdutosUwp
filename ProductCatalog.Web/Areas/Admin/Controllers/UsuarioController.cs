using ProductCatalog.DAO;
using ProductCatalog.Model;
using ProductCatalog.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProductCatalog.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        //Servico de banco de dados
        DataContext contextoBd;   

        //Construtor para inicializar o serviço
        public UsuarioController()
        {
            //Inicializa o banco de dados
            contextoBd = new DataContext();
        }

        // GET: Admin/Usuario
        public ActionResult Index()
        {
            //Inicializa o serviço do banco de dados para a tabela usuario
            var usuarioServicoBd = new UsuarioService(contextoBd);
            //Cria a lista de usuarios a partir dos registros do banco de dados
            var listaUsuarios = usuarioServicoBd.Listar();
            //Envia para view a lista
            return View(listaUsuarios);
        }

        [HttpGet]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inserir(Usuario usuario)
        {
            //Verifica se o modelo de dados é válido
            if (ModelState.IsValid)
            {
                //Inicializa o serviço do banco de dados para a tabela usuario
                var usuarioServicoBd = new UsuarioService(contextoBd);
                //Executa o comando de inserção
                usuarioServicoBd.Inserir(usuario);
                //Executa o serviço no banco de dados
                contextoBd.SaveChanges();
                //Redireciona para a index do controller usuario
                return RedirectToAction("Index", "Usuario", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            //Inicializa o serviço do banco de dados para a tabela usuario
            var usuarioServicoBd = new UsuarioService(contextoBd);
            //Seleciona o usuario com o codigo informado
            var usuario = usuarioServicoBd.BuscarPorCodigo(id);
            //Verifica se é um usuario válido
            if (usuario == null)
            {
                //Redireciona para a index do controller usuario
                return RedirectToAction("Index");
                //Ou retorna um erro padrao nao encontrado
                //return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            //Envia o usuario para ser prenchido na View
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Alterar(Usuario usuario)
        {
            //Inicializa o servico de banco de dados do usuario
            var usuarioServicoBd = new UsuarioService(contextoBd);
            //Verifica se o usuario é valido 
            if (ModelState.IsValid)
            {
                //Faz a alteracao do usuario
                usuarioServicoBd.Alterar(usuario);
                //Executa o serviço no banco de dados
                contextoBd.SaveChanges();
                //Redireciona para a index do controller usuario por area
                return RedirectToAction("Index", "Usuario", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Excluir(int id=0)
        {            
            //Seleciona o usuario com o codigo informado
            if (id > 0)
            {
                //Inicializa o serviço do banco de dados para a tabela usuario
                var usuarioServicoBd = new UsuarioService(contextoBd);
                //Seleciona o usuario
                var usuario = usuarioServicoBd.BuscarPorCodigo(id);
                //Verifica se é um usuario válido
                if (usuario == null)
                {
                    //Redireciona para a index do controller usuario
                    return RedirectToAction("Index");
                    //Ou retorna um erro padrao nao encontrado
                    //return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
                //Envia o usuario para ser prenchido na View
                return View(usuario);
            }
            //Retorna a pagina principal
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Excluir(Usuario usuario)
        {
            if (usuario == null)
            {
                //Redireciona para a index do controller usuario
                return RedirectToAction("Index");
                //Ou retorna um erro padrao nao encontrado
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Inicializa o serviço do banco de dados para a tabela usuario
            var usuarioServicoBd = new UsuarioService(contextoBd);
            //Exclui o usuario
            usuarioServicoBd.Excluir(usuario.Codigo);
            //Executa o serviço do banco de dados
            contextoBd.SaveChanges();
            //Retorna para a pagina principal
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase arquivo)
        {
            if(arquivo != null && arquivo.ContentLength > 0)
            {
                //Define a pasta que sera salvo o arquivo
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(arquivo.FileName));
                //Salva o arquivo na pasta
                arquivo.SaveAs(path);
                //Atividade: salva no banco de dados o caminho com o nome do arquivo =  path
                ViewBag.Mensagem = "Imagem salva com sucesso";
                return View();
            }
            ViewBag.Mensagem = "Erro ao salvar a imagem";
            return View();
        }

    }
}