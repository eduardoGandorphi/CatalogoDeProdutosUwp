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
	public partial class CatalogoView : ContentPage
	{
        List<ProdutoModel> catalogo;

        public CatalogoView ()
		{

            InitializeComponent();

		}

        private void VCatalogo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //pega o item selecionado (objeto) da lista 
            var produto = e.SelectedItem as ProdutoModel;
            //Navega para a pagina do produto 
            //envia o produto selecionado
            Navigation.PushAsync(new ProdutoView(produto));
        }

        private void VBusca_SearchButtonPressed(object sender, EventArgs e)
        {
            var termo = vBusca.Text;
            var consulta = catalogo.Where(p => p.Titulo.Contains(termo) || p.Descricao.Contains(termo)).ToList();
            vCatalogo.ItemsSource = consulta;
        }



        private void BtnAdicionar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProdutoView(new ProdutoModel()));
        }

        private void BtnSlecionar_Clicked(object sender, EventArgs e)
        {
            var id = (int)((MenuItem)sender).CommandParameter;
            DisplayAlert("Teste", $"Id={id}", "Fechar");
            
        }

        ProdutoDAO produtosDao = new ProdutoDAO();
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var listaDoBanco = produtosDao.Read(p => true);
            vCatalogo.ItemsSource = listaDoBanco;
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var produto = (ProdutoModel)((MenuItem)sender).CommandParameter;
            var dao = new ProdutoDAO();            

            dao.Delete(produto);
            var listaDoBanco = dao.ReadAll();

            vCatalogo.ItemsSource = null;
            vCatalogo.ItemsSource = listaDoBanco;

            DisplayAlert("Teste", "Produto apagado com sucesso", "Fechar");

        }
    }
}