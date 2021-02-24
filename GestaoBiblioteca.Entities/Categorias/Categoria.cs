using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoBiblioteca.Entities.Categoria
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public Int32 Id { get; set; }
        public String Nome { get; set; }
        public Boolean Ativo { get; set; }
    }
}