using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Capas.DAOs.Interface;
using MVC_Capas.Models;

namespace MVC_Capas.DAOs.Implementation
{
    public class PersonaDAOImpl : IPersonaDAO
    {
        Entities db = new Entities();

        List<Persona> IPersonaDAO.orderById(List<Persona> clients)
        {
            return clients.OrderBy(s => s.cedula).ToList();
        }

        List<Persona> IPersonaDAO.orderByLastName1(List<Persona> clients)
        {
            return clients.OrderBy(s => s.apellido1).ToList();
        }

        List<Persona> IPersonaDAO.orderByLastName2(List<Persona> clients)
        {
            return clients.OrderBy(s => s.apellido2).ToList();
        }

        List<Persona> IPersonaDAO.orderByName(List<Persona> clients)
        {
            return clients.OrderBy(s => s.nombre).ToList();
        }

        List<Persona> IPersonaDAO.selectClients()
        {
            var clients = from s in db.Persona
                           select s;
            return clients.ToList();
        }

        List<Persona> IPersonaDAO.selectClientsByFilter(List<Persona> clients, string filter)
        {
            return clients.Where(s => s.apellido1.Contains(filter)
                                       || s.nombre.Contains(filter) || s.apellido2.Contains(filter)).ToList();
        }
    }
}
