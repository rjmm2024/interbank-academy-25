//Listamos los archivos del directorio
let listaTransacciones = [];
let MontoBalanceFinal = 0;
let CantidadCreditos = 0;
let CantidadDebitos = 0;
let datoMontoMayor;
let rutaarchivo;

const fs = require("fs");
let filenames = fs.readdirSync('Input'); //Se obtiene la lista de archivo
filenames.forEach((file) => {       // Se recorre los archivos y se llama al metodo leerArchivo
    rutaarchivo = `Input/${file}`;
    leerArchivo(rutaarchivo);


});

function leerArchivo(nombrearchivo) {
    // validamos que exista el archivo
    fs.stat(nombrearchivo, function(error) {
        if (error) {
            console.log("El archivo no existe");
            throw error;
        }
    });

   
    //Leemos el archivo
    fs.readFile(nombrearchivo, 'utf8', (error, datos) => {
        if (error) throw error;

        //Generamos la matriz con los datos del archivo
        let datosFila = datos.split('\n');
        if (datosFila != undefined && datosFila !== null && datosFila.length > 0) {
            let contador = 0;
            datosFila.forEach(item => {
                let datos = item.split(';');
                if (datos !== undefined && datos !== null && datos.length > 0 && contador > 0) {
                    listaTransacciones.push({ "id": parseInt(datos[0]), "tipo": datos[1], "monto": parseFloat(datos[2]),  });
                }
                contador++;
            });
            fnCalcularBalanceFinal();
            fnCalcularCatidadTipo();
            fnCalularDatoMayorValor();
            fnMonstrarDatos();
        }
    });
}

function fnCalcularBalanceFinal() {
    if (listaTransacciones !== undefined && listaTransacciones !== null && listaTransacciones.length > 1) {
        let totalCredito = listaTransacciones
            .filter(dato => dato.tipo == 'Crédito') // Filtra solo los creditos
            .reduce(function(acumulador, dato) {
                return acumulador + dato.monto; // Suma los montos de credito
            }, 0);


        let totaldevito = listaTransacciones
            .filter(dato => dato.tipo == 'Débito') // Filtra solo los debitos
            .reduce(function(acumulador, dato) {
                return acumulador + dato.monto; // Suma los montos de debito
            }, 0);

        MontoBalanceFinal = totalCredito - totaldevito;
    }
}

function fnCalcularCatidadTipo() {
    if (listaTransacciones !== undefined && listaTransacciones !== null && listaTransacciones.length > 1) {
        CantidadCreditos = listaTransacciones
            .filter(function(dato) {
                return dato.tipo === 'Crédito'; // Filtra los datos de tipo credito
            }).length;

        CantidadDebitos = listaTransacciones
            .filter(function(dato) {
                return dato.tipo === 'Débito'; // Filtra los datos de tipo debito
            }).length;

    }
}

function fnCalularDatoMayorValor() {

    if (listaTransacciones !== undefined && listaTransacciones !== null && listaTransacciones.length > 1) {
        datoMontoMayor = listaTransacciones
            .reduce(function(maxdato, datoActual) {
                return datoActual.monto > maxdato.monto ? datoActual : maxdato;
            });
    }
}

function fnMonstrarDatos() {

    //Impresion de resultados
    console.log("Reporte de Transacciones");
    console.log("---------------------------------------------");
    console.log("Balance Final  => : ", MontoBalanceFinal);
    console.log("Transacción de Mayor Monto =>  ID:", datoMontoMayor.id + " MONTO: " + datoMontoMayor.monto);
    console.log("Conteo de Transacciones => Crédito:", CantidadCreditos + " Dédito: " + CantidadDebitos);
}