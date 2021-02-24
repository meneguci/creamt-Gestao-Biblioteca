using GestaoBiblioteca.Common;
using GestaoBiblioteca.Data;
using GestaoBiblioteca.Entities.Emprestimo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoBiblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        LivrosRepository livrosRepository = new LivrosRepository();
        PessoasRepository pessoasRepository = new PessoasRepository();
        EmprestimosRepository emprestimosRepository = new EmprestimosRepository();
        
        public ActionResult Index()
        {
            return View(emprestimosRepository.ObterEmprestimos());
        }

        public ActionResult Create()
        {
            ViewBag.LivroId = new SelectList(livrosRepository.ObterLivros(), "Id", "Titulo");
            ViewBag.PessoaId = new SelectList(pessoasRepository.ObterPessoas(), "Id", "Nome");
            ViewBag.FuncionarioId = new SelectList(pessoasRepository.ObterPessoas(PessoaTipo.Profissional), "Id", "Nome");
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmprestimoEditViewModel emprestimoEditViewModel)
        {
            if (emprestimosRepository.IncluirEmprestimo(emprestimoEditViewModel))
                return RedirectToAction("Index");

            ViewBag.LivroId = new SelectList(livrosRepository.ObterLivros(), "Id", "Titulo", emprestimoEditViewModel.LivroId);
            ViewBag.PessoaId = new SelectList(pessoasRepository.ObterPessoas(), "Id", "Nome", emprestimoEditViewModel.PessoaId);
            ViewBag.FuncionarioId = new SelectList(pessoasRepository.ObterPessoas(PessoaTipo.Profissional), "Id", "Nome", emprestimoEditViewModel.FuncionarioId);

            return View(emprestimoEditViewModel);
        }
     
        [HttpPost]
        public ActionResult DevolverEmprestimo(int id)
        {
            if (emprestimosRepository.DevolverEmprestimo(id))
                return Json("Ok");

            return Json("Erro");
        }
    }
}