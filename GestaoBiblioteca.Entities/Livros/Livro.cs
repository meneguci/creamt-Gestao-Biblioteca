using GestaoBiblioteca.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoBiblioteca.Entities.Livro
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public Int32 Id { get; set; }
        public Int32 CategoriaId { get; set; }
        public Int32 AutorId { get; set; }
        [Index("IX_ISBN", IsUnique = true)]
        [MaxLength(18)]
        public String Isbn { get; set; }
        public String Titulo { get; set; }
        public String Editora { get; set; }
        public String Edicao { get; set; }
        public String Ano { get; set; }
        public LivroSituacao Situacao { get; set; }

        public virtual Pessoa.Pessoa Autor { get; set; }
        
    }
}