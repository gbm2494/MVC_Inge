using MVC_Capas.DAOs.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Capas.Models;

namespace MVC_Capas.DAOs.Implementation
{
    public class CuentaDAOImpl : ICuentaDAO
    {
        Entities db = new Entities();

        void ICuentaDAO.insertarCuenta(Cuenta cuenta)
        {
            db.Cuenta.Add(cuenta);
            db.SaveChanges();
        }
    }
}
