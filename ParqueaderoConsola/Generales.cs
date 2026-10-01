using System;
using System.Collections.Generic;
using System.Text;

namespace ParqueaderoConsola
{
    public class GeneralES
    {
        public static void imp(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public static void imp(Vehiculo v)
        {
            imp("\nFactura parqueadero");
            imp("\nCliente: " + v.Nombre);
            imp("Cedula: " + v.Cedula);
            imp("\nPlaca: " + v.Placa);
            imp("Vehiculo: " + v.tipo());
            imp("Hora de entrada: " + v.HREnt.ToString("00") + ":" + v.MINEnt.ToString("00"));
            imp("Hora de salida: " + v.HRSal.ToString("00") + ":" + v.MINSal.ToString("00"));
            imp("Tiempo de estadia: " + v.tiempo());
            imp("\nSubtotal (sin IVA): $" + v.subtotal());
            imp("Ahorro: $" + v.ahorro());
            imp("IVA (19%): $" + v.iva());
            imp("TOTAL A PAGAR: $" + v.total());
        }

        public static string lea(string mensaje)
        {
            string dato;
            do
            {
                imp(mensaje);
                dato = Console.ReadLine() ?? "";
                dato = dato.Trim();
            } while (string.IsNullOrEmpty(dato));
            return dato;
        }
        public static int leaInt(string mensaje)
        {
            int dato = 0;
            bool valido = false;
            do
            {
                try
                {
                    dato = Int32.Parse(lea(mensaje));
                    valido = true;
                }
                catch (Exception)
                {
                    imp("Error, debe ingresar un numero valido ");
                }
            } while (!valido);
            return dato;
        }

        public static int leaIntRango(string mensaje, int min, int max)
        {
            int dato;
            do
            {
                dato = leaInt(mensaje);
                if (dato < min || dato > max)
                {
                    imp("El valor debe estar entre " + min + " y " + max);
                }
            } while (dato < min || dato > max);
            return dato;
        }

        public static string leaOpcion(string mensaje, string[] opciones)
        {
            string dato;
            bool valido;
            do
            {
                dato = lea(mensaje);
                valido = false;
                for (int i = 0; i < opciones.Length; i++)
                {
                    if (dato.ToLower() == opciones[i].ToLower())
                    {
                        valido = true;
                    }
                }
                if (!valido)
                {
                    imp("Opcion invalida");
                }
            } while (!valido);
            return dato;
        }


        public static Vehiculo lea()
        {
            string nombre = lea("\nDigite el nombre del cliente");
            string cedula = leaCedula("Digite la cedula del cliente");
            string placa = leaPlaca("Digite la placa del vehiculo");

            int hrEnt = leaIntRango("\nDigite la hora de entrada (0-23)", 0, 23);
            int minEnt = leaIntRango("Digite los minutos de entrada (0-59)", 0, 59);
            int hrSal = leaIntRango("Digite la hora de salida (0-23)", 0, 23);
            int minSal = leaIntRango("Digite los minutos de salida (0-59)", 0, 59);

            string esCarro = leaOpcion("\nEl vehiculo es carro?\n [s] si\n [n] no", new string[] { "s", "n" });

            if (esCarro == "s")
            {
                string op = leaOpcion("\nDigite el tipo de carro\n [1] Taxi\n [2] Automovil\n [3] Campero\n [4] Camioneta", new string[] { "1", "2", "3", "4" });
                string tipoCarro;
                switch (op)
                {

                    case "1":
                        tipoCarro = "taxi";
                        break;
                    case "2":
                        tipoCarro = "automovil";
                        break;
                    case "3":
                        tipoCarro = "campero";
                        break;
                    case "4":
                        tipoCarro = "camioneta";
                        break;
                    default:
                        tipoCarro = "automovil";
                        break;
                }
                return new Carro(nombre, cedula, placa, hrEnt, minEnt, hrSal, minSal, tipoCarro);
            }
            else
            {
                return new Moto(nombre, cedula, placa, hrEnt, minEnt, hrSal, minSal);
            }
        }
        public static string leaCedula(string mensaje)
        {
            string dato;
            bool valido;
            do
            {
                dato = lea(mensaje);
                valido = true;
                for (int i = 0; i < dato.Length; i++)
                {
                    if (!char.IsDigit(dato[i]))
                    {
                        valido = false;
                    }
                }
                if (!valido)
                {
                    imp("La cedula solo debe contener numeros");
                }
            } while (!valido);
            return dato;
        }
        public static string leaPlaca(string mensaje)
        {
            string dato;
            bool valido;
            do
            {
                dato = lea(mensaje);
                valido = dato.Length == 6;
                if (valido)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (!char.IsLetter(dato[i]))
                        {
                            valido = false;
                        }
                    }
                    for (int i = 3; i < 6; i++)
                    {
                        if (!char.IsDigit(dato[i]))
                        {
                            valido = false;
                        }
                    }
                }
                if (!valido)
                {
                    imp("La placa debe tener 3 letras y 3 numeros; ejemplo ABC123");
                }
            } while (!valido);
            return dato;
        }
    }
}