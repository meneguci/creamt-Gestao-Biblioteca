using GestaoBiblioteca.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Entities.Emprestimo.ViewModels
{
    public class EmprestimoDisplayViewModel
    {
        [Display(Name = "Código")]
        public Int32 Id { get; set; }
        [Display(Name = "Livro")]
        public String LivroNome { get; set; }
        [Display(Name = "Funcionário")]
        public String FuncionarioNome { get; set; }
        [Display(Name = "Pessoa")]
        public String PessoaNome { get; set; }
        [Display(Name = "Data Empréstimo")]
        public DateTime DataEmprestimo { get; set; }
        [Display(Name = "Data Máx. Empréstimo")]
        public DateTime DataMaxEmprestimo { get; set; }
        [Display(Name = "Data Devolução")]
        public Nullable<DateTime> DataDevolucao { get; set; }
        [Display(Name = "Situação")]
        public String EmprestimoSituacao { get; set; }
    }
}
