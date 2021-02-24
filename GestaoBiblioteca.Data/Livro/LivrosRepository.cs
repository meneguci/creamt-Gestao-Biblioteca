using System.Collections.Generic;
using System.Linq;
using GestaoBiblioteca.Common;
using GestaoBiblioteca.Entities.Livro;
using GestaoBiblioteca.Entities.Livro.ViewModels;

namespace GestaoBiblioteca.Data
{
    public class LivrosRepository
    {
        public List<LivroDisplayViewModel> ObterLivros()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Livro> livros = context.Livros.ToList();

                if (livros != null)
                {
                    List<LivroDisplayViewModel> livrosDisplay = new List<LivroDisplayViewModel>();
                    foreach (var x in livros)
                    {
                        var livroDisplay = new LivroDisplayViewModel()
                        {
                            Id = x.Id,
                            Ano = x.Ano,
                            Autor = x.Autor.Nome,
                            Edicao = x.Edicao,
                            Editora = x.Editora,
                            Isbn = x.Isbn,
                            Situacao = Util.GetEnumDescription(x.Situacao),
                            Titulo = x.Titulo

                        };
                        livrosDisplay.Add(livroDisplay);
                    }
                    return livrosDisplay;
                }
                return new List<LivroDisplayViewModel>();
            }
        }

        public LivroEditViewModel ObterLivro(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                List<Livro> livros = context.Livros.Where(w => w.Id == id).ToList();

                if (livros != null)
                {
                    foreach (var x in livros)
                    {
                        var livroDisplay = new LivroEditViewModel()
                        {
                            Id = x.Id,
                            Ano = x.Ano,
                            AutorId = x.AutorId,
                            Edicao = x.Edicao,
                            Editora = x.Editora,
                            Isbn = x.Isbn,
                            Situacao = x.Situacao,
                            Titulo = x.Titulo

                        };
                        return livroDisplay;
                    }
                }
                return null;
            }
        }

        public bool IncluirLivro(LivroEditViewModel item)
        {
            if (item != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var livro = new Livro()
                    {
                        Ano = item.Ano,
                        AutorId = item.AutorId,
                        CategoriaId = item.CategoriaId,
                        Edicao = item.Edicao,
                        Editora = item.Editora,
                        Isbn = item.Isbn,
                        Situacao = (LivroSituacao)item.Situacao,
                        Titulo = item.Titulo
                    };

                    context.Livros.Add(livro);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool AlterarLivro(LivroEditViewModel item)
        {
            if (item != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var livro = context.Livros.Find(item.Id);
                    livro.Ano = item.Ano;
                    livro.AutorId = item.AutorId;
                    livro.CategoriaId = item.CategoriaId;
                    livro.Edicao = item.Edicao;
                    livro.Editora = item.Editora;
                    livro.Isbn = item.Isbn;
                    livro.Situacao = (LivroSituacao)item.Situacao;
                    livro.Titulo = item.Titulo;
                    context.Entry(livro).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
