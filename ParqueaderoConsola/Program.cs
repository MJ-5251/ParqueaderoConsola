using System;

namespace ParqueaderoConsola
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GeneralES.imp("Programa de Parqueadero");
            int op = 0;
            do
            {
                op = GeneralES.leaInt("\nMenu principal\n" + " 1. Calcular Factura\n" + " 2. Salir");
                switch (op)
                {
                    case 1:
                        ManejoParqueadero.factura();
                        break;
                    case 2:
                        GeneralES.imp("Hasta luego!");
                        break;
                    default:
                        GeneralES.imp("Opcion Invalida");
                        break;
                }
            } while (op != 2);
        }
    }
}

