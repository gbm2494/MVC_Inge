using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Capas.Models;
using MVC_Capas.Services.Interface;
using MVC_Capas.DAOs.Interface;

namespace MVC_Capas.Services.Implementation
{
    public class ClientesServiceImpl : IClientesService
    {
        IPersonaDAO personaDAO;

        public ClientesServiceImpl(IPersonaDAO persona)
        {
            personaDAO = persona;
        }

        public List<Persona> obtenerClientesPorFiltro(List<Persona> clientes, string filtro)
        {
            return personaDAO.obtenerClientesPorFiltro(clientes, filtro);
        }

        void IClientesService.insertarCliente(Persona nueva)
        {
            personaDAO.insertarCliente(nueva);
        }

        List<Persona> IClientesService.ordenarPorCedula(List<Persona> clientes)
        {
            return personaDAO.ordenarPorCedula(clientes);
        }

        List<Persona> IClientesService.ordenarPorApellido1(List<Persona> clientes)
        {
            return personaDAO.ordenarPorApellido1(clientes);
        }

        List<Persona> IClientesService.ordenarPorApellido2(List<Persona> clientes)
        {
            return personaDAO.ordenarPorApellido2(clientes);
        }

        List<Persona> IClientesService.ordenarPorNombre(List<Persona> clientes)
        {
            return personaDAO.ordenarPorNombre(clientes);
        }

        List<Persona> IClientesService.obtenerClientes()
        {
            return personaDAO.obtenerClientes();
        }

    }
}
