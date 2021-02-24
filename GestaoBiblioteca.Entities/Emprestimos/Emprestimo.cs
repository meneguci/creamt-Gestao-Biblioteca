using GestaoBiblioteca.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoBiblioteca.Entities.Emprestimo
{
    [Table("Emprestimos")]
    public class Emprestimo
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 LivroId { get; set; }
        public Int32 FuncionarioId { get; set; }
        public Int32 PessoaId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataMaxEmprestimo { get; set; }
        public Nullable<DateTime> DataDevolucao { get; set; }
        public EmprestimoSituacao EmprestimoSituacao { get; set; }
        public virtual Livro.Livro Livro { get; set; }
        public virtual Pessoa.Pessoa Pessoa { get; set; }
        public virtual Pessoa.Pessoa Funcionario { get; set; }
    }
}