using BlogCore.AccesoDatos.Data.Repository;
using BlogCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCore.Areas.Admin.Controllers
{
    [Authorize]  //necesario para no permitir acceso por la barra de direccion del navegador, solo cuando acceseda usuario con rol autorizado//
    [Area("Admin")]
    public class CategoriasController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //ayuda a proteger y que no te hacken el formulario//
        public IActionResult Create(Categoria categoria)
        {
            // en el if evaluamos si el modelo es valido//
            if (ModelState.IsValid)  
            {
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index)); //si se guardo correctamente nos redirigira//
            }
            return View(categoria); //sino retorna la vista categoria//
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);

            if (categoria == null)
            {
                return NotFound(); //metodo asp  significa no encontrado//
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //ayuda a proteger y que no te hacken el formulario//
        public IActionResult Edit(Categoria categoria)
        {
            // en el if evaluamos si el modelo es valido//
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index)); //si se guardo correctamente nos redirigira//
            }
            return View(categoria); //sino retorna la vista categoria//
        }


        //Llamar a las apis//
        #region LLAMADAS A LA API
        [HttpGet]
        public ActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Categoria.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando categoria" });
            }
            _contenedorTrabajo.Categoria.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoría borrada correctamente" });
        }

        #endregion
    }
}
