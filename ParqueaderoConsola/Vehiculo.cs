using System;
using System.Collections.Generic;
using System.Text;

namespace ParqueaderoConsola
{
    public abstract class Vehiculo
    {
        private string nombre;
        private string cedula;
        private string placa;
        private int hrEnt;
        private int minEnt;
        private int hrSal;
        private int minSal;
        private const double IVA = 0.19; 

        public string Nombre { get => nombre; }
        public string Cedula { get => cedula; }
        public string Placa { get => placa; }
        public int HREnt { get => hrEnt; }
        public int MINEnt { get => minEnt; }
        public int HRSal { get => hrSal; }
        public int MINSal { get => minSal; }

        public Vehiculo(string nombre, string cedula, string placa, int hrEnt, int minEnt, int hrSal, int minSal)
        {
            this.nombre = nombre;
            this.cedula = cedula;
            this.placa = placa;
            this.hrEnt = hrEnt;
            this.minEnt = minEnt;
            this.hrSal = hrSal;
            this.minSal = minSal;
        }

        public int minutos()
        {
            int entrada = hrEnt * 60 + minEnt;
            int salida = hrSal * 60 + minSal;
            if (salida < entrada)
            {
                return (1440 - entrada) + salida;
            }
            return salida - entrada;
        }

        public int cuartos()
        {
            return (int)Math.Ceiling(minutos() / 15.0);
        }

        public string tiempo()
        {
            int min = minutos();
            return (min / 60) + " horas " + (min % 60) + " minutos";
        }

        public double subtotal()
        {
            return cuartos() * (tarifa() / 4);
        }

        public double iva()
        {
            return (subtotal() - ahorro()) * IVA;
        }

        public double total()
        {
            return (subtotal() - ahorro()) + iva();
        }

        public abstract double tarifa();
        public abstract double ahorro();
        public abstract string tipo();
    }
}