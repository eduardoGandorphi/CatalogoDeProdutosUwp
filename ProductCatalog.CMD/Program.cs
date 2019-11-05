using ProductCatalog.DAO;
using ProductCatalog.Model;
using ProductCatalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //using - Destroy o Objeto ao término do Uso
            //Instancializamos o Contexto do Banco de Dados
            using (DataContext ctx = new DataContext())
            {
                //Crio as categorias para poder inserir no Banco de Dados
                var cat1 = new Categoria() { Titulo = "Alimentos",
                    Imagem = "alimentos.jpg" };
                var cat2 = new Categoria() { Titulo = "Sapatos",
                    Imagem = "sapatos.jpg" };
                var cat3 = new Categoria() { Titulo = "Eletrônicos",
                    Imagem = "eletronicos.jpg" };
                var cat4 = new Categoria() { Titulo = "Móveis",
                    Imagem = "moveis.jpg" };
                var cat5 = new Categoria() { Titulo = "Celulares",
                    Imagem = "celulares.jpg" };
                //Instancializo a Service para as Ações de Categorias e
                //passo o Contexto para o Construtor
                CategoriaService categoriaService = 
                    new CategoriaService(ctx);
                categoriaService.Inserir(cat1);
                categoriaService.Inserir(cat2);
                categoriaService.Inserir(cat3);
                categoriaService.Inserir(cat4);
                categoriaService.Inserir(cat5);

                //Inserir 3 Usuarios
                var usu1 = new Usuario(){
                    Nome = "Josias",
                    Email = "josias@gmail.com",
                    Senha = "123"
                    //,Telefone = "12-3333-5555"
                };

                var usuarioService = new UsuarioService(ctx);
                usuarioService.Inserir(usu1);

                ctx.SaveChanges();

            }

        }
    }
}
