using GestaoBiblioteca.Common;
using GestaoBiblioteca.Data;
using GestaoBiblioteca.Entities.Livro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoBiblioteca.Controllers
{
    public class LivroController : Controller
    {        
        LivrosRepository livrosRepository = new LivrosRepository();
        PessoasRepository pessoasRepository = new PessoasRepository();
        CategoriasRepository categoriasRepository = new CategoriasRepository();
        public ActionResult Index()
        {
            return View(livrosRepository.ObterLivros());
        }

        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(categoriasRepository.ObterCategorias(), "Id", "Nome");
            ViewBag.AutorId = new SelectList(pessoasRepository.ObterPessoas(PessoaTipo.Autor), "Id", "Nome");
            ViewBag.Situacao = new SelectList(Util.EnumToSelectList<LivroSituacao>(), "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Create(LivroEditViewModel livroEditViewModel)
        {
            if (livrosRepository.IncluirLivro(livroEditViewModel))
                return RedirectToAction("Index");

            ViewBag.CategoriaId = new SelectList(categoriasRepository.ObterCategorias(), "Id", "Nome", livroEditViewModel.CategoriaId);
            ViewBag.Autor = new SelectList(pessoasRepository.ObterPessoas(PessoaTipo.Autor), "Id", "Nome", livroEditViewModel.AutorId);
            ViewBag.Situacao = new SelectList(Util.EnumToSelectList<LivroSituacao>(), "Value", "Text", livroEditViewModel.Situacao);

            return View(livroEditViewModel);
        }

        public ActionResult Edit(int id)
        {
            LivroEditViewModel livroEditViewModel = livrosRepository.ObterLivro(id);

            ViewBag.CategoriaId = new SelectList(categoriasRepository.ObterCategorias(), "Id", "Nome", livroEditViewModel.CategoriaId);
            ViewBag.Autor = new SelectList(pessoasRepository.ObterPessoas(PessoaTipo.Autor), "Id", "Nome", livroEditViewModel.AutorId);
            ViewBag.Situacao = new SelectList(Util.EnumToSelectList<LivroSituacao>(), "Value", "Text", livroEditViewModel.Situacao);

            return View(livroEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(LivroEditViewModel livroEditViewModel)
        {
            if (livrosRepository.AlterarLivro(livroEditViewModel))
                return RedirectToAction("Index");

            ViewBag.CategoriaId = new SelectList(categoriasRepository.ObterCategorias(), "Id", "Nome", livroEditViewModel.CategoriaId);
            ViewBag.Autor = new SelectList(pessoasRepository.ObterPessoas(PessoaTipo.Autor), "Id", "Nome", livroEditViewModel.AutorId);
            ViewBag.Situacao = new SelectList(Util.EnumToSelectList<LivroSituacao>(), "Value", "Text", livroEditViewModel.Situacao);

            return View(livroEditViewModel);
        }
    }
}