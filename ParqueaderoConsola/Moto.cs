using System;
using System.Collections.Generic;
using System.Text;

namespace ParqueaderoConsola
{
    public class Moto : Vehiculo
    {
        public Moto(string nombre, string cedula, string placa, int hrEnt, int minEnt, int hrSal, int minSal) :
            base(nombre, cedula, placa, hrEnt, minEnt, hrSal, minSal)
        {
        }

        public override double tarifa()
        {
            return 600;
        }

        public override double ahorro()
        {
            return 0;
        }

        public override string tipo()
        {
            return "Moto";
        }
    }
}