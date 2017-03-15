using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Capas.Models;
using PagedList;
using MVC_Capas.Services.Interface;

namespace MVC_Capas.Controllers
{
    public class ClientesController : Controller
    {
        IClientesService clientesService;
        ICuentasService cuentasService;

        public ClientesController(IClientesService clientServ, ICuentasService accountServ){
            clientesService = clientServ;
            cuentasService = accountServ;
        }

        // GET: Clientes
        public ActionResult nuevoCliente(){
            return View();
        }

        // GET: Clientes
        public ActionResult listaClientes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CedulaSortParm = String.IsNullOrEmpty(sortOrder) ? "cedula" : "";
            ViewBag.NombreSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre" : "";
            ViewBag.Ape1SortParm = String.IsNullOrEmpty(sortOrder) ? "apellido1" : "";
            ViewBag.Ape2SortParm = String.IsNullOrEmpty(sortOrder) ? "apellido2" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = clientesService.obtenerClientes();

            if (!String.IsNullOrEmpty(searchString))
            {
                students = clientesService.obtenerClientesPorFiltro(students, searchString);
            }

            switch (sortOrder)
            {
                case "cedula":
                    students = clientesService.ordenarPorCedula(students);
                    break;
                case "nombre":
                    students = clientesService.ordenarPorNombre(students);
                    break;
                case "apellido1":
                    students = clientesService.ordenarPorApellido1(students);
                    break;
                case "apellido2":
                    students = clientesService.ordenarPorApellido2(students);
                    break;
                default:
                    students = clientesService.ordenarPorNombre(students);
                    break;
            }
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult nuevoCliente(ModeloIntermedio modelo)
        {
            if (ModelState.IsValid)
            {
                clientesService.insertarCliente(modelo.modeloPersona);
                
                if (modelo.modeloCuenta1.numero != null)
                {
                    modelo.modeloCuenta1.cedula = modelo.modeloPersona.cedula;
                    cuentasService.insertarCuenta(modelo.modeloCuenta1);
                }

                if (modelo.modeloCuenta2.numero != null)
                {
                    modelo.modeloCuenta2.cedula = modelo.modeloPersona.cedula;
                    cuentasService.insertarCuenta(modelo.modeloCuenta2);
                }

                if (modelo.modeloCuenta3.numero != null)
                {
                    modelo.modeloCuenta3.cedula = modelo.modeloPersona.cedula;
                    cuentasService.insertarCuenta(modelo.modeloCuenta3);
                }

                
                return RedirectToAction("listaClientes");
            }
            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View(modelo);
            }
        }
    }
}