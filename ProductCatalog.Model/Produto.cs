using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Model
{
    //Atributo Table - Permite determinar nome da Tabela vinculada à Model
    //[Table("Produtos")]
    public class Produto : Base.GenericEntity
    {
        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        //Annotation que determina a renderização de um Campo Texto
        // multilinha
        [DataType(DataType.MultilineText)]
        public string  Descricao { get; set; }
        [Required]
        //Annotation que determina que o campo será renderizado como
        // representação de Moeda
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [Required,StringLength(100)]
        public string Imagem { get; set; }

        //Associação com Categoria (Relacionamento)
        public virtual Categoria Categoria { get; set; }
        
        //Data Annotation que cria a FK de Categoria
        [ForeignKey("Categoria")]
        public int CategoriaCodigo { get; set; }

        public decimal Estoque { get; set; }
    }
}
