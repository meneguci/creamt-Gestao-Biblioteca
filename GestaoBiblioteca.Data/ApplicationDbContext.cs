using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GestaoBiblioteca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {

        }
        public DbSet<Entities.Pessoa.Pessoa> Pessoas { get; set; }
        public DbSet<Entities.Livro.Livro> Livros { get; set; }
        public DbSet<Entities.Emprestimo.Emprestimo> Emprestimos { get; set; }
        public DbSet<Entities.Categoria.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<GestaoBiblioteca.Entities.Categoria.ViewModels.CategoriaEditViewModel> CategoriaEditViewModels { get; set; }

        public System.Data.Entity.DbSet<GestaoBiblioteca.Entities.Livro.ViewModels.LivroDisplayViewModel> LivroDisplayViewModels { get; set; }

        public System.Data.Entity.DbSet<GestaoBiblioteca.Entities.Livro.ViewModels.LivroEditViewModel> LivroEditViewModels { get; set; }

        public System.Data.Entity.DbSet<GestaoBiblioteca.Entities.Pessoa.ViewModels.PessoaDisplayViewModel> PessoaDisplayViewModels { get; set; }

        public System.Data.Entity.DbSet<GestaoBiblioteca.Entities.Pessoa.ViewModels.PessoaEditViewModel> PessoaEditViewModels { get; set; }

        public System.Data.Entity.DbSet<GestaoBiblioteca.Entities.Emprestimo.ViewModels.EmprestimoDisplayViewModel> EmprestimoDisplayViewModels { get; set; }

        public System.Data.Entity.DbSet<GestaoBiblioteca.Entities.Emprestimo.ViewModels.EmprestimoEditViewModel> EmprestimoEditViewModels { get; set; }
    }
}
