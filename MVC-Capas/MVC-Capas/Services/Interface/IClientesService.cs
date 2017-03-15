using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Capas.Models;

namespace MVC_Capas.Services.Interface
{
    public interface IClientesService
    {
        List<Persona> obtenerClientes();
        List<Persona> obtenerClientesPorFiltro(List<Persona> clientes, string filtro);
        List<Persona> ordenarPorCedula(List<Persona> clientes);
        List<Persona> ordenarPorNombre(List<Persona> clientes);
        List<Persona> ordenarPorApellido1(List<Persona> clientes);
        List<Persona> ordenarPorApellido2(List<Persona> clientes);
        void insertarCliente(Persona nueva);

    }
}
