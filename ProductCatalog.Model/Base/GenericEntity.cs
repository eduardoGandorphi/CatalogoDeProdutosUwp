using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Model.Base
{
    
    public class GenericEntity : IGenericEntity
    {
        //Data Annotation que define Codigo como
        //chave primária
        [Key]
        public int Codigo { get; set; }

        public bool Ativo { get; set; }

    }
}
