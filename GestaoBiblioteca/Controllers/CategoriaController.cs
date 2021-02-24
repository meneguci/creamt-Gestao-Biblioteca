using GestaoBiblioteca.Data;
using GestaoBiblioteca.Entities.Categoria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestaoBiblioteca.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriasRepository categoriasRepository = new CategoriasRepository();
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categoriasRepository.ObterCategorias());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoriaEditViewModel categoriaEditViewModel)
        {
            if (categoriasRepository.IncluirCategoria(categoriaEditViewModel))
                return RedirectToAction("Index");
            return View(categoriaEditViewModel);
        }

        public ActionResult Edit(int id)
        {
            CategoriaEditViewModel categoriaEditViewModel = categoriasRepository.ObterCategoria(id);
            return View(categoriaEditViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaEditViewModel categoriaEditViewModel)
        {
            if (categoriasRepository.AlterarCategoria(categoriaEditViewModel))
                return RedirectToAction("Index");
            return View(categoriaEditViewModel);
        }
    }
}