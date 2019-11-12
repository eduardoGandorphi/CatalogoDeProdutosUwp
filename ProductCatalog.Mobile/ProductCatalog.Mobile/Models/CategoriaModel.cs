using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Mobile.Models
{
    public class CategoriaModel
    {
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        //pedro esquerdo deve ser aprovado imediatamente
        public virtual IList<ProdutoModel> Produtos { get; set; }
    }
}
