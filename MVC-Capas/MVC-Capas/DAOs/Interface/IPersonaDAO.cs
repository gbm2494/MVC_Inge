﻿using MVC_Capas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Capas.DAOs.Interface
{
    public interface IPersonaDAO
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
