using ProductCatalog.Mobile.DAO;
using ProductCatalog.Mobile.Models;
using ProductCatalog.Mobile.Services;
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
        private ProdutoService produtoService = new ProdutoService();
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

        private async void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            var produto = new ProdutoModel();
            produto.Id = produtoAntigo.Id;
            produto.Titulo = this.vTitulo.Text;
            produto.Preco = decimal.Parse(this.vPreco.Text.Remove(0,1));
            produto.Descricao = this.vDescricao.Text;
            produto.Estoque = decimal.Parse(this.vEstoque.Text);
            produto.CategoriaCodigo = 1;
            produto.Imagem = @"https://www.google.com.br/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png";
            produto.Ativo = true;

            SauloWrapper<ProdutoModel> RET = null;
            if (produto.Id == 0)
                RET = await produtoService.PostObj(produto); //dao.Inserir(produto);
            else
                dao.Update(produto);

            if (RET.Success)
                await Navigation.PopAsync();
            else
                await DisplayAlert("Alerta", RET.msg, "OK");
        }
    }
}