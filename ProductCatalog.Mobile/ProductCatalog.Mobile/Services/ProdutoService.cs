using ProductCatalog.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Mobile.Services
{
    public class ProdutoService : SauloService<ProdutoModel>
    {

        public ProdutoService()
        {
            this.ApiName = "api/produtos/";
        }

    }
}
