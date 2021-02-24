using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Entities.Livro.ViewModels
{
    public class LivroDisplayViewModel
    {
        [Display(Name = "Código")] 
        public Int32 Id { get; set; }
        [Display(Name = "Autor")]
        public String Autor { get; set; }
        [Display(Name = "ISBN")]
        public String Isbn { get; set; }
        [Display(Name = "Título")]
        public String Titulo { get; set; }
        [Display(Name = "Editora")]
        public String Editora { get; set; }
        [Display(Name = "Edição")]
        public String Edicao { get; set; }
        [Display(Name = "Ano")]
        public String Ano { get; set; }
        [Display(Name = "Situação")]
        public String Situacao { get; set; }
    }
}
