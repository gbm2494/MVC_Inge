using MVC_Capas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Capas.DAOs.Interface
{
    public interface ICuentaDAO
    {
        void insertarCuenta(Cuenta cuenta);
    }
}
