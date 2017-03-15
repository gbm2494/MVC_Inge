using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Capas.Models
{
    public class ModeloIntermedio
    {
        public Persona modeloPersona { get; set; }
        public Cuenta modeloCuenta1 { get; set; }
        public Cuenta modeloCuenta2 { get; set; }
        public Cuenta modeloCuenta3 { get; set; }

    }
}