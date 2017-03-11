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
    public class ClientsServiceImpl : IClientsService
    {
        IPersonaDAO personaDAO;

        public ClientsServiceImpl(IPersonaDAO persona)
        {
            personaDAO = persona;
        }

        public List<Persona> selectClientsByFilter(List<Persona> clients, string filter)
        {
            return personaDAO.selectClientsByFilter(clients, filter);
        }

        List<Persona> IClientsService.orderById(List<Persona> clients)
        {
            return personaDAO.orderById(clients);
        }

        List<Persona> IClientsService.orderByLastName1(List<Persona> clients)
        {
            return personaDAO.orderByLastName1(clients);
        }

        List<Persona> IClientsService.orderByLastName2(List<Persona> clients)
        {
            return personaDAO.orderByLastName2(clients);
        }

        List<Persona> IClientsService.orderByName(List<Persona> clients)
        {
            return personaDAO.orderByName(clients);
        }

        List<Persona> IClientsService.selectClients()
        {
            return personaDAO.selectClients();
        }

        List<Persona> IClientsService.selectClientsByFilter(List<Persona> clients, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
