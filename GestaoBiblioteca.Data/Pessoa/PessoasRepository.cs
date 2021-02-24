using System.Collections.Generic;
using System.Linq;
using GestaoBiblioteca.Common;
using GestaoBiblioteca.Entities.Pessoa;
using GestaoBiblioteca.Entities.Pessoa.ViewModels;

namespace GestaoBiblioteca.Data
{
    public class PessoasRepository
    {
        public List<PessoaDisplayViewModel> ObterPessoas(PessoaTipo pessoaTipo)
        {
            using (var context = new ApplicationDbContext())
            {
                List<Pessoa> pessoas = context.Pessoas.Where(w => w.Tipo == pessoaTipo).ToList();

                if (pessoas != null)
                {
                    List<PessoaDisplayViewModel> pessoasDisplay = MapPessoas(pessoas);
                    return pessoasDisplay;
                }
                return new List<PessoaDisplayViewModel>();
            }
        }



        public List<PessoaDisplayViewModel> ObterPessoas()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Pessoa> pessoas = context.Pessoas.ToList();

                if (pessoas != null)
                {
                    List<PessoaDisplayViewModel> pessoasDisplay = MapPessoas(pessoas);
                    return pessoasDisplay;
                }
                return new List<PessoaDisplayViewModel>();
            }
        }
        private static List<PessoaDisplayViewModel> MapPessoas(List<Pessoa> pessoas)
        {
            List<PessoaDisplayViewModel> pessoasDisplay = new List<PessoaDisplayViewModel>();
            foreach (var x in pessoas)
            {
                var pessoaDisplay = new PessoaDisplayViewModel()
                {
                    Id = x.Id,
                    Ativo = x.Ativo ? "Sim" : "Não",
                    Bairro = x.Bairro,
                    Cidade = x.Cidade,
                    Complemento = x.Complemento,
                    Cpf = x.Cpf,
                    Estado = x.Estado,
                    Logradouro = x.Logradouro,
                    Nome = x.Nome,
                    Numero = x.Numero,
                    Rg = x.Rg,
                    Tipo = Util.GetEnumDescription(x.Tipo)

                };
                pessoasDisplay.Add(pessoaDisplay);
            }

            return pessoasDisplay;
        }        

        public PessoaEditViewModel ObterPessoa(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                List<Pessoa> pessoas = context.Pessoas.Where(w => w.Id == id).ToList();

                if (pessoas != null)
                {
                    foreach (var x in pessoas)
                    {
                        var pessoaDisplay = new PessoaEditViewModel()
                        {
                            Id = x.Id,
                            Ativo = x.Ativo,
                            Bairro = x.Bairro,
                            Cidade = x.Cidade,
                            Complemento = x.Complemento,
                            Cpf = x.Cpf,
                            Estado = x.Estado,
                            Logradouro = x.Logradouro,
                            Nome = x.Nome,
                            Numero = x.Numero,
                            Rg = x.Rg,
                            Tipo = x.Tipo

                        };
                        return pessoaDisplay;
                    }
                }
                return null;
            }
        }

        public bool IncluirPessoa(PessoaEditViewModel item)
        {
            if (item != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var pessoa = new Pessoa()
                    {
                        Ativo = item.Ativo,
                        Bairro = item.Bairro,
                        Cidade = item.Cidade,
                        Complemento = item.Complemento,
                        Cpf = item.Cpf,
                        Estado = item.Estado,
                        Logradouro = item.Logradouro,
                        Nome = item.Nome,
                        Numero = item.Numero,
                        Rg = item.Rg,
                        Tipo = (PessoaTipo)item.Tipo
                    };

                    context.Pessoas.Add(pessoa);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool AlterarPessoa(PessoaEditViewModel item)
        {
            if (item != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var pessoa = context.Pessoas.Find(item.Id);
                    pessoa.Ativo = item.Ativo;
                    pessoa.Bairro = item.Bairro;
                    pessoa.Cidade = item.Cidade;
                    pessoa.Complemento = item.Complemento;
                    pessoa.Cpf = item.Cpf;
                    pessoa.Estado = item.Estado;
                    pessoa.Logradouro = item.Logradouro;
                    pessoa.Nome = item.Nome;
                    pessoa.Numero = item.Numero;
                    pessoa.Rg = item.Rg;
                    pessoa.Tipo = (PessoaTipo)item.Tipo;
                    context.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
