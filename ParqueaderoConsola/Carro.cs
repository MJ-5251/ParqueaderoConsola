using System;
using System.Collections.Generic;
using System.Text;

namespace ParqueaderoConsola
{
    public class Carro : Vehiculo
    {
        private string tipoCarro; 

        public Carro(string nombre, string cedula, string placa, int hrEnt, int minEnt, int hrSal, int minSal, string tipoCarro) :
                base(nombre, cedula, placa, hrEnt, minEnt, hrSal, minSal)
        {
            this.tipoCarro = tipoCarro;
        }

        public override double tarifa()
        {
            switch (tipoCarro)
            {
                case "taxi":
                    return 3500;
                case "automovil":
                    return 4000;
                case "campero":
                    return 4500;
                case "camioneta":
                    return 5000;
                default:
                    return 4000;
            }
        }

        public override double ahorro()
        {
            int extra = cuartos() - 4;
            if (extra <= 0)
            {
                return 0;
            }
            return extra * (tarifa() / 4) * 0.10;
        }

        public override string tipo()
        {
            return tipoCarro;
        }
    }
}