using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Capas.Models;

namespace MVC_Capas.Services.Interface
{
    public interface ICuentasService
    {
        void insertarCuenta(Cuenta cuenta);
    }
}
