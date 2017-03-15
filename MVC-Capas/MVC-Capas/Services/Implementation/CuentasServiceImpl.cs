using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Capas.Services.Interface;
using MVC_Capas.DAOs.Interface;
using MVC_Capas.Models;

namespace MVC_Capas.Services.Implementation
{
    public class CuentasServiceImpl : ICuentasService
    {
        ICuentaDAO cuentaDAO;

        public CuentasServiceImpl(ICuentaDAO cuenta)
        {
            cuentaDAO = cuenta;
        }

        public void insertarCuenta(Cuenta cuenta)
        {
            cuentaDAO.insertarCuenta(cuenta);
        }
    }
}
