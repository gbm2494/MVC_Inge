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
        Entities db = new Entities();
        IClientsService clientService;

        public ClientesController(IClientsService clientServ){
            clientService = clientServ;
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

            var students = clientService.selectClients();

            if (!String.IsNullOrEmpty(searchString))
            {
                students = clientService.selectClientsByFilter(students, searchString);
            }

            switch (sortOrder)
            {
                case "cedula":
                    students = clientService.orderById(students);
                    break;
                case "nombre":
                    students = clientService.orderByName(students);
                    break;
                case "apellido1":
                    students = clientService.orderByLastName1(students);
                    break;
                case "apellido2":
                    students = clientService.orderByLastName2(students);
                    break;
                default:
                    students = clientService.orderByName(students);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
    }
}