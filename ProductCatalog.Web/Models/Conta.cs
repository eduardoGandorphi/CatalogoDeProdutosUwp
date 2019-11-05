using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductCatalog.Web.Models
{
    public class Conta
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage ="Campo obrigatório")]
        [StringLength(150, ErrorMessage ="Atingiu a quantidade máxima de caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Formato de e-mail inválido")]
        public string Email { get; set; }

        [Display(Name ="Senha")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(8, ErrorMessage = "Digite uma senha de no mínimo 8 caracteres")]
        [DataType(DataType.Password, ErrorMessage = "Formato de senha inválido")]
        public string Senha { get; set; }

    }
}