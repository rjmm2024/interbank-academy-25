using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Transacciones_Bancarias__CLI_;

class Transaccion
{
    static void Main(string[] args)
    {
        //Define el nombre del archivo CSV que será procesado
        string filePath = "transacciones.csv"; 
        
        LogicaTransaccion transaccion = new LogicaTransaccion();

        //Llama al método ValidarArchivo de la clase LogicaTransaccion
        if (transaccion.ValidarArchivo(filePath)) 
        {
            //Llama al método LeerArchivo de la clase LogicaTransaccion
            List<Datos> listaTransacciones = transaccion.LearArchivo(filePath); 

            if (listaTransacciones != null && listaTransacciones.Count > 0)
                transaccion.MostrarTransacciones(transaccion.CalcularBalanceFinal(listaTransacciones), transaccion.DevolverTransaccionMayor(listaTransacciones), transaccion.DevolverCatidadPorTipo(listaTransacciones));
        }
        else
        {
            Console.WriteLine("Error Archivo no existe, o el fromato es incorrecto");
        }
    }

}


