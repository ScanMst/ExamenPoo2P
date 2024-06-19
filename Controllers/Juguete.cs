using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen2Poo;
using examen2Poo.Entities;
using examen2Poo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUDProductCatalog.Controllers
{
    public class JugueteController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JugueteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult JugueteList()
        {

            List<JugueteModel> list = new List<JugueteModel>();
            list = _context.Juguetes.Select(j => new JugueteModel()
            {
                Id = j.Id,
                Codigo= j.Codigo,
                Nombre = j.Nombre,
                Precio = j.Precio,
            }).ToList();

            return View(list);

        }


        [HttpGet]
        public IActionResult JugueteAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult JuguetetAdd(JugueteModel model)
        {
            //para insertar
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Juguete j = new Juguete();
            j.Id = model.Id;
            j.Codigo= model.Codigo;
            j.Nombre = model.Nombre;
            j.Precio = model.Precio;

            this._context.Juguetes.Add(j);
            this._context.SaveChanges();

            return RedirectToAction("JugueteList", "Juguete");
        }

        [HttpGet]
        public IActionResult JugueteEdit(Guid Id)
        {
            Juguete? juguete = this._context.Juguetes.Where(s => s.Id == Id).FirstOrDefault();

            if (juguete == null)
            {
                return RedirectToAction("JugueteList", "Juguete");
            }

            JugueteModel model = new JugueteModel();
            model.Id = Id;
            model.Codigo = juguete.Codigo;
            model.Nombre = juguete.Nombre;
            model.Precio = juguete.Precio;

            return View(model);
        }

        [HttpPost]
        public IActionResult JugueteEdit(JugueteModel model)
        {

            Juguete jugueteactualiza = this._context.Juguetes
            .Where(s => s.Id == model.Id).First();

            if (jugueteactualiza == null)
            {
                return RedirectToAction("JugueteList", "Juguete");
            }

            jugueteactualiza.Codigo = model.Codigo;
            jugueteactualiza.Nombre = model.Nombre;
            jugueteactualiza.Precio = model.Precio;


            this._context.Juguetes.Update(jugueteactualiza);
            this._context.SaveChanges();
            return RedirectToAction("JugueteList", "Juguete");
        }

        [HttpGet]
        public IActionResult JugueteDelete(Guid Id)
        {
            //borrar registro
            Juguete? jugueteborrado = this._context.Juguetes.Where(s => s.Id == Id).FirstOrDefault();

            if (jugueteborrado == null)
            {
                return RedirectToAction("JugueteList", "Juguete");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("JugueteList", "Juguete");
            }

            JugueteModel model = new JugueteModel();
            model.Id = Id;
            model.Codigo = jugueteborrado.Codigo;
            model.Nombre = jugueteborrado.Nombre;
            model.Precio = jugueteborrado.Precio;

            return View(model);
        }

        [HttpPost]
        public IActionResult SpecialistDelete(JugueteModel model)
        {
            bool exists = this._context.Juguetes.Any(s => s.Id == model.Id);

            if (!exists)
            {
                return RedirectToAction("JugueteList", "Juguete");
            }

            Juguete jugueteborrado = this._context.Juguetes.Where(s => s.Id == model.Id).First();

            this._context.Juguetes.Remove(jugueteborrado);
            this._context.SaveChanges();

            return RedirectToAction("JugueteList", "Juguete");
        }
    }
}