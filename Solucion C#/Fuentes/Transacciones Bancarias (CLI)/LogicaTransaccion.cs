using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transacciones_Bancarias__CLI_
{
    public class LogicaTransaccion
    {
        public bool ValidarArchivo(string filePath)
        {
            try
            {
                //Verifica si el archivo existe.
                bool bvalidar = true;
                if (!File.Exists(filePath)) 
                {
                    bvalidar = false;
                }

                //Verifica que exista un archivo con la extension csv.
                if (!Path.GetExtension(filePath).ToLower().Equals(".csv")) 
                {
                    bvalidar = false;
                }
                return bvalidar;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
           
        }

        public List<Datos> LearArchivo(string filePath)
        {
            try
            {
                List<Datos> transacciones = new List<Datos>();

                //Lee todas las líneas del archivo CSV y salta la primera que es el encabezado
                var lineas = File.ReadAllLines(filePath, System.Text.Encoding.UTF8).Skip(1); 
                foreach (var linea in lineas)
                {
                    if (!string.IsNullOrEmpty(linea))
                    {
                        //Dividimos cada línea en partes
                        string[] datos = linea.Split(';'); 
                        int id = Convert.ToInt32(datos[0]);
                        string tipo = datos[1];
                        decimal monto = Convert.ToDecimal(datos[2]);

                        transacciones.Add(new Datos { Id = id, Tipo = tipo, Monto = monto });
                    }
                }
                //Devuelve la lista de transacciones procesadas.
                return transacciones;  
            }
            //Atrapa cualquier error que ocurra al procesar el archivo y muestra un mensaje de error en la consola.
            catch (Exception ex) 
            {
                throw (ex);
            }
           
        }

        public decimal CalcularBalanceFinal(List<Datos> transacciones)
        {
            try
            {
                //Calcular la suma total de los Créditos
                var sumaCreditos = transacciones
                    .Where(t => t.Tipo.Equals("Crédito", StringComparison.OrdinalIgnoreCase))
                    .Sum(t => t.Monto);

                //Calcular la suma total de los Débitos
                var sumalDebitos = transacciones
                    .Where(t => t.Tipo.Equals("Débito", StringComparison.OrdinalIgnoreCase))
                    .Sum(t => t.Monto);

                //Calcular el balance final
                var balanceFinal = sumaCreditos - sumalDebitos;

                return balanceFinal;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
          
        }

        public Datos DevolverTransaccionMayor(List<Datos> transacciones)
        {
            try
            {
                //Ordena en orden descendente y Obtiene el primer elemento de la lista ordenada (que será la transacción con el mayor monto).
                
                var datoMayor = transacciones
                .OrderByDescending(t => t.Monto)
                .First();

                return datoMayor;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
           
        }

        public Tuple<int,int> DevolverCatidadPorTipo(List<Datos> transacciones)
        {
            try
            {
                //Cantidad de transacciones de tipo "Crédito"
                int cantidadCreditos = transacciones
                    .Where(t => t.Tipo.Equals("Crédito", StringComparison.OrdinalIgnoreCase)).Count();

                //Cantidad de transacciones de tipo "Débito"
                int cantidadDebitos = transacciones
                    .Where(t => t.Tipo.Equals("Débito", StringComparison.OrdinalIgnoreCase)).Count();

                Tuple<int, int> totales = new Tuple<int, int> (cantidadCreditos, cantidadDebitos);
                return totales;
            }
            catch (Exception ex)
            {
                throw(ex);
            }

        }

        //Método para mostrar los resultados en consola
        public void MostrarTransacciones(decimal montoBalanceFInal, Datos datoMayor, Tuple<int,int> totalesTipo)
        {
            Console.WriteLine("Reporte de Transacciones");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Balance Final => " + montoBalanceFInal.ToString("F2"));
            Console.WriteLine("Transacción de Mayor Monto => ID: " + datoMayor.Id + "  Monto: " + datoMayor.Monto.ToString("F2"));
            Console.WriteLine("Conteo de Transacciones => Crédito: " + totalesTipo.Item1 + " Débito: " + totalesTipo.Item2);
            Console.ReadKey();
        }
    }
}
