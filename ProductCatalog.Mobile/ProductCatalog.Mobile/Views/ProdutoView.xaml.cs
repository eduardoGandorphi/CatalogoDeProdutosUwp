using ProductCatalog.Mobile.DAO;
using ProductCatalog.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductCatalog.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProdutoView : ContentPage
	{
        private ProdutoDAO dao = new ProdutoDAO();
        ProdutoModel produtoAntigo;

		public ProdutoView (ProdutoModel produto)
		{
			InitializeComponent ();
            produtoAntigo = produto;
            //Alerta em tela
            //DisplayAlert("Produto", $"Id = {produto.Id}\n Produto{produto.Titulo}", "Fechar");
            this.vTitulo.Text = produto.Titulo;
            this.vPreco.Text = produto.Preco.ToString("C2");
            this.vDescricao.Text = produto.Descricao;
            this.vEstoque.Text = produto.Estoque.ToString("N2");
            this.vFoto.Source = produto.Imagem;

		}

        private void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            var produto = new ProdutoModel();
            produto.Id = produtoAntigo.Id;
            produto.Titulo = this.vTitulo.Text;
            produto.Preco = decimal.Parse(this.vPreco.Text.Remove(0,2));
            produto.Descricao = this.vDescricao.Text;
            produto.Estoque = decimal.Parse(this.vEstoque.Text);

            if (produto.Id == 0)
                dao.Inserir(produto);
            else
                dao.Update(produto);
           
            Navigation.PopAsync();
        }
    }
}