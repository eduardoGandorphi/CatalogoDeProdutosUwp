using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Model
{
    public class Categoria : Base.GenericEntity
    {
        [Required,StringLength(50)]
        public string Titulo { get; set; }
        [Required,StringLength(100)]
        public string Imagem { get; set; }
        
        //Associação com Produto (Relacionamento)
        public virtual IList<Produto> Produtos { get; set; }
    }
}
