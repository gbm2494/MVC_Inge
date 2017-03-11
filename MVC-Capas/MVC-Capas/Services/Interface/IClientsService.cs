using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Capas.Models;

namespace MVC_Capas.Services.Interface
{
    public interface IClientsService
    {
        List<Persona> selectClients();
        List<Persona> selectClientsByFilter(List<Persona> clients, string filter);
        List<Persona> orderById(List<Persona> clients);
        List<Persona> orderByName(List<Persona> clients);
        List<Persona> orderByLastName1(List<Persona> clients);
        List<Persona> orderByLastName2(List<Persona> clients);

    }
}
