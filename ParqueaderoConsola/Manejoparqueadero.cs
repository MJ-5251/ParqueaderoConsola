using System;
using System.Collections.Generic;
using System.Text;

namespace ParqueaderoConsola
{
    public class ManejoParqueadero{
            public static void factura()
            {
                Vehiculo v = GeneralES.lea();
                GeneralES.imp(v);
            }
        }
}

