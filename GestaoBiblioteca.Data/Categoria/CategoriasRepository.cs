using System.Collections.Generic;
using System.Linq;
using GestaoBiblioteca.Entities.Categoria;
using GestaoBiblioteca.Entities.Categoria.ViewModels;

namespace GestaoBiblioteca.Data
{
    public class CategoriasRepository
    {
        public List<CategoriaDisplayViewModel> ObterCategorias()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Categoria> categorias = new List<Categoria>();
                categorias = context.Categorias.AsNoTracking().ToList();

                if (categorias != null)
                {
                    List<CategoriaDisplayViewModel> categoriasDisplay = new List<CategoriaDisplayViewModel>();
                    foreach (var x in categorias)
                    {
                        var categoriaDisplay = new CategoriaDisplayViewModel()
                        {
                            Nome = x.Nome,
                            Ativo = x.Ativo ? "Sim" : "Não" ,
                            Id = x.Id
                        };
                        categoriasDisplay.Add(categoriaDisplay);
                    }
                    return categoriasDisplay;
                }
                return null;
            }
        }
        public CategoriaEditViewModel ObterCategoria(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                List<Categoria> categorias;
                categorias = context.Categorias.Where(w => w.Id == id).ToList();

                if (categorias != null)
                {
                    foreach (var x in categorias)
                    {
                        var categoriaDisplay = new CategoriaEditViewModel()
                        {
                            Id = x.Id,
                            Nome = x.Nome,
                            Ativo = x.Ativo

                        };
                        return categoriaDisplay;
                    }
                }
                return null;
            }
        }

        public bool IncluirCategoria(CategoriaEditViewModel item)
        {
            if (item != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var categoria = new Categoria()
                    {
                        Nome = item.Nome,
                        Ativo = item.Ativo
                    };

                    context.Categorias.Add(categoria);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool AlterarCategoria(CategoriaEditViewModel item)
        {
            if (item != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var categoria = context.Categorias.Find(item.Id);
                    categoria.Nome = item.Nome;
                    categoria.Ativo = item.Ativo;
                    context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

    }
}
