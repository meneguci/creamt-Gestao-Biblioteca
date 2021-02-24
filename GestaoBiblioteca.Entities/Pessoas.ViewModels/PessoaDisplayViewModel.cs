using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Entities.Pessoa.ViewModels
{
    public class PessoaDisplayViewModel
    {
        [Display(Name = "Código")]
        public Int32 Id { get; set; }
        [Display(Name = "Nome")]
        public String Nome { get; set; }
        [Display(Name = "CPF")]
        public String Cpf { get; set; }
        [Display(Name = "RG")]
        public String Rg { get; set; }
        [Display(Name = "Logradouro")]
        public String Logradouro { get; set; }
        [Display(Name = "Número")]
        public String Numero { get; set; }
        [Display(Name = "Complemento")]
        public String Complemento { get; set; }
        [Display(Name = "Bairro")]
        public String Bairro { get; set; }
        [Display(Name = "Cidade")]
        public String Cidade { get; set; }
        [Display(Name = "Estado")]
        public String Estado { get; set; }
        [Display(Name = "Tipo")]
        public String Tipo { get; set; }
        [Display(Name = "Ativo")]
        public String Ativo { get; set; }
    }
}
