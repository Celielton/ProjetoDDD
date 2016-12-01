using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.Mvc.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "* campo obrigatorio")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "* campo obrigatorio")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "* campo obrigatorio")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}