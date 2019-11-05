using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.DAO;
using ProductCatalog.Model;

namespace ProductCatalog.Services
{
    public class CategoriaService : GenericService<Categoria>
    {
        public CategoriaService(DataContext context) : base(context)
        {
        }
    }
}
