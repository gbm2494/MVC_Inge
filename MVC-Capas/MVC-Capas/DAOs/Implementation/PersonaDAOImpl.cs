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

        void IPersonaDAO.insertarCliente(Persona persona)
        {
            db.Persona.Add(persona);
            db.SaveChanges();
        }

        List<Persona> IPersonaDAO.ordenarPorCedula(List<Persona> clientes)
        {
            return clientes.OrderBy(s => s.cedula).ToList();
        }

        List<Persona> IPersonaDAO.ordenarPorApellido1(List<Persona> clientes)
        {
            return clientes.OrderBy(s => s.apellido1).ToList();
        }

        List<Persona> IPersonaDAO.ordenarPorApellido2(List<Persona> clientes)
        {
            return clientes.OrderBy(s => s.apellido2).ToList();
        }

        List<Persona> IPersonaDAO.ordenarPorNombre(List<Persona> clientes)
        {
            return clientes.OrderBy(s => s.nombre).ToList();
        }

        List<Persona> IPersonaDAO.obtenerClientes()
        {
            var clientes = from s in db.Persona
                           select s;
            return clientes.ToList();
        }

        List<Persona> IPersonaDAO.obtenerClientesPorFiltro(List<Persona> clientes, string filtro)
        {
            return clientes.Where(s => s.apellido1.Contains(filtro)
                                       || s.nombre.Contains(filtro) || s.apellido2.Contains(filtro)).ToList();
        }
    }
}
