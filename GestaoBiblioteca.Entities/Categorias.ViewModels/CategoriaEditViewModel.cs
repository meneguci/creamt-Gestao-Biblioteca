using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBiblioteca.Entities.Categoria.ViewModels
{
    public class CategoriaEditViewModel
    {
        [Display(Name = "Código")] 
        public Int32? Id { get; set; }
        [Display(Name = "Decrição")]
        public String Nome { get; set; }
        [Display(Name = "Ativo")]
        public Boolean Ativo { get; set; }
    }
}
