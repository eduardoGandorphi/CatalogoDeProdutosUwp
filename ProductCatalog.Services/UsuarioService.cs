using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.DAO;
using ProductCatalog.Model;

namespace ProductCatalog.Services
{
    public class UsuarioService : GenericService<Usuario>
    {
        public UsuarioService(DataContext context) : base(context)
        {
           

        }
        public Usuario Buscar(string email, string senha)
        {
            var retorno = DataContext.Usuarios.Where(u=> u.Ativo==true)
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            return retorno;
        }
    }
}
