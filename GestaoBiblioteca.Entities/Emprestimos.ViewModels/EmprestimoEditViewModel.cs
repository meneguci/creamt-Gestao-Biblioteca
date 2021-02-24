using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Entities.Emprestimo.ViewModels
{
    public class EmprestimoEditViewModel
    {
        [Display(Name = "Código")]
        public Int32 Id { get; set; }
        [Display(Name = "Livro")]
        public String Livro { get; set; }
        [Display(Name = "Funcionário")]
        public String Funcionario { get; set; }
        [Display(Name = "Pessoa")]
        public String Pessoa { get; set; }
        [Display(Name = "Situação")]
        public Int32 EmprestimoSituacao { get; set; }

        [Display(Name = "Livro")] 
        public Int32 LivroId { get; set; }
        [Display(Name = "Funcionário")]
        public Int32 FuncionarioId { get; set; }
        [Display(Name = "Pessoa")]
        public Int32 PessoaId { get; set; }
    }
}
