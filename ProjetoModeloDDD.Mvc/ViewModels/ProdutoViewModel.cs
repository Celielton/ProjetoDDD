using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.Mvc.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "* campo obrigatorio")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "* campo obrigatorio")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal),"0","999999999")]
        public decimal Valor { get; set; }
        [Display(Name = "Disponível?")]
        public bool Disponivel { get; set; }

        public int ClienteId { get; set; }

        public virtual ClienteViewModel Cliente { get; set; }
    }
}