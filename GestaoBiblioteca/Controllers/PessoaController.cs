using GestaoBiblioteca.Common;
using GestaoBiblioteca.Data;
using GestaoBiblioteca.Entities.Pessoa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoBiblioteca.Controllers
{
    public class PessoaController : Controller
    {
        PessoasRepository pessoasRepository = new PessoasRepository();
        // GET: Pessoa
        public ActionResult Index()
        {
            return View(pessoasRepository.ObterPessoas());
        }

        public ActionResult Create()
        {
            ViewBag.Tipo = new SelectList(Util.EnumToSelectList<PessoaTipo>(), "Value", "Text");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PessoaEditViewModel pessoaEditViewModel)
        {
            if (pessoasRepository.IncluirPessoa(pessoaEditViewModel))
                return RedirectToAction("Index");

            ViewBag.Tipo = new SelectList(Util.EnumToSelectList<PessoaTipo>(), "Value", "Text", pessoaEditViewModel.Tipo);

            return View(pessoaEditViewModel);
        }

        public ActionResult Edit(int id)
        {
            PessoaEditViewModel pessoaEditViewModel = pessoasRepository.ObterPessoa(id);

            ViewBag.Tipo = new SelectList(Util.EnumToSelectList<PessoaTipo>(), "Value", "Text", pessoaEditViewModel.Tipo);

            return View(pessoaEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(PessoaEditViewModel pessoaEditViewModel)
        {
            if (pessoasRepository.AlterarPessoa(pessoaEditViewModel))
                return RedirectToAction("Index");

            ViewBag.Tipo = new SelectList(Util.EnumToSelectList<PessoaTipo>(), "Value", "Text", pessoaEditViewModel.Tipo);

            return View(pessoaEditViewModel);
        }
    }
}