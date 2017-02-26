using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Capas.Models;
using PagedList;

namespace MVC_Capas.Controllers
{
    public class ClientesController : Controller
    {
        Entities db = new Entities();

        // GET: Clientes
        public ActionResult nuevoCliente()
        {
            return View();
        }

        // GET: Clientes
        public ActionResult listaClientes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre" : "";
            ViewBag.ApeSortParm = sortOrder == "apellido1" ? "apellido2" : "apellido1";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in db.Persona
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.apellido1.Contains(searchString)
                                       || s.nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nombre":
                    students = students.OrderByDescending(s => s.nombre);
                    break;
                case "apellido1":
                    students = students.OrderBy(s => s.apellido1);
                    break;
                case "apellido2":
                    students = students.OrderByDescending(s => s.apellido2);
                    break;
                default:
                    students = students.OrderBy(s => s.cedula);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
    }
}