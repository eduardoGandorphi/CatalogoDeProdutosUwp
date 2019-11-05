using ProductCatalog.DAO;
using ProductCatalog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Services
{
    public class ProdutoService : GenericService<Produto>
    {
        public ProdutoService(DataContext context) : base(context)
        {
        }
    }
}
