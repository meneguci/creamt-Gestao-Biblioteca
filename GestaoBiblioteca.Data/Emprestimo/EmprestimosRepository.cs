using System;
using System.Collections.Generic;
using System.Linq;
using GestaoBiblioteca.Common;
using GestaoBiblioteca.Entities.Emprestimo;
using GestaoBiblioteca.Entities.Emprestimo.ViewModels;


namespace GestaoBiblioteca.Data
{
    public class EmprestimosRepository
    {
        public List<EmprestimoDisplayViewModel> ObterEmprestimos()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Emprestimo> lista = new List<Emprestimo>();
                lista = context.Emprestimos.ToList();

                if (lista != null)
                {
                    List<EmprestimoDisplayViewModel> listaDisplay = new List<EmprestimoDisplayViewModel>();
                    foreach (var x in lista)
                    {
                        var item = new EmprestimoDisplayViewModel()
                        {
                            Id = x.Id,
                            DataDevolucao = x.DataDevolucao,
                            DataEmprestimo = x.DataEmprestimo,
                            DataMaxEmprestimo = x.DataMaxEmprestimo,
                            FuncionarioNome = x.Funcionario.Nome,
                            LivroNome = x.Livro.Titulo,
                            PessoaNome = x.Pessoa.Nome,
                            
                        };
                        if (item.DataDevolucao.HasValue)
                        {
                            item.EmprestimoSituacao = Util.GetEnumDescription(EmprestimoSituacao.Devolvido);
                        }
                        else if (item.DataMaxEmprestimo > DateTime.Now && !item.DataDevolucao.HasValue)
                        {
                            item.EmprestimoSituacao = Util.GetEnumDescription(EmprestimoSituacao.Atrasado);
                            x.EmprestimoSituacao = EmprestimoSituacao.Atrasado;
                            context.Entry(x).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            item.EmprestimoSituacao = Util.GetEnumDescription(EmprestimoSituacao.Emprestado);
                        }

                        listaDisplay.Add(item);
                    }
                    return listaDisplay;
                }
                return null;
            }
        }
        public bool IncluirEmprestimo(EmprestimoEditViewModel item)
        {
            if (item != null)
            {
                using (var context = new ApplicationDbContext())
                {
                    var tran = context.Database.BeginTransaction();
                    try
                    {
                        var emprestimo = new Emprestimo()
                        {
                            DataEmprestimo = DateTime.Now,
                            EmprestimoSituacao = EmprestimoSituacao.Emprestado,
                            FuncionarioId = item.FuncionarioId,
                            LivroId = item.LivroId,
                            PessoaId = item.PessoaId
                        };

                        var pessoa = context.Pessoas.Find(item.PessoaId);
                        if (pessoa.Tipo == PessoaTipo.Profissional)
                            emprestimo.DataMaxEmprestimo = emprestimo.DataEmprestimo.AddDays(15);
                        else
                            emprestimo.DataMaxEmprestimo = emprestimo.DataEmprestimo.AddDays(10);

                        context.Emprestimos.Add(emprestimo);

                        var livro = context.Livros.Find(item.LivroId);
                        livro.Situacao = LivroSituacao.Emprestado;
                        context.Entry(livro).State = System.Data.Entity.EntityState.Modified;

                        context.SaveChanges();

                        tran.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }

                }
            }
            return false;
        }

        public bool DevolverEmprestimo(int item)
        {
            using (var context = new ApplicationDbContext())
            {
                var tran = context.Database.BeginTransaction();
                try
                {
                    var emprestimo = context.Emprestimos.Find(item);
                    emprestimo.DataDevolucao = DateTime.Now;
                    emprestimo.EmprestimoSituacao = EmprestimoSituacao.Devolvido;
                    context.Entry(emprestimo).State = System.Data.Entity.EntityState.Modified;

                    var livro = context.Livros.Find(emprestimo.LivroId);
                    livro.Situacao = LivroSituacao.Disponivel;
                    context.Entry(livro).State = System.Data.Entity.EntityState.Modified;

                    context.SaveChanges();

                    tran.Commit();
                    return true;
                }
                catch (Exception)
                {
                    tran.Rollback();
                }
            }
            return false;
        }
    }
}
