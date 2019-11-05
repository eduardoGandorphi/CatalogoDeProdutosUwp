using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Model
{
    public class Usuario : Base.GenericEntity
    {
        //Data Annotation que determina que um campo é
        // de preenchimento obrigatório (NOT NULL)
        [Required]
        //Data Annocation que determina o tamanho máximo em caracteres
        [StringLength(50)]
        public string Nome { get; set; }

        [Required,StringLength(100)]
        //Data Annotation que exige que o dado esteja no 
        // formato de um Email
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required,StringLength(32)]
        //Data Annotation que indica a renderização de um campo
        // do tipo Senha (password)
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        //Campo adicionado após a criação do Banco de Dados
        [DataType(DataType.PhoneNumber), StringLength(20)]
        public string Telefone { get; set; }

        [DataType(DataType.ImageUrl), StringLength(500)]
        public string Images { get; set; }

        public Usuario()
        {
            Ativo = true;
        }

    }
}
