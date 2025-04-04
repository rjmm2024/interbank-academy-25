# Reto Técnico: Procesamiento de Transacciones Bancarias (CLI)

# PRIMERA SOLUCIÓN - Lenguaje de Programación C#

* INTRODUCCIÓN: 

El reto de este proyecto de programación de línea de comandos consiste en desarrollar una 
aplicación que se ejecuta directamente en la consola, sin interfaz gráfica de usuario. 
Su propósito es gestionar el procesamiento de transacciones bancarias, para lo cual se lee
los datos desde un archivo CSV y se procesa la información para hacer cálculos y dar como resultado: 
El Balance Final, la transacción de Mayor Monto y el Conteo de Transacciones.
Para el desarrollo de esta aplicación se eligió el lenguaje de programación C# ya que es robusto con 
una sintaxis limpia y clara, lo que facilita el desarrollo y mantenimiento del código.


* INSTRUCCIONES DE EJECUCIÓN:

1. Entorno de Ejecución
   - Instalar .NET Runtime
2. Compilador
   - SDK 8
3. Sistema Operativo
   Windows, Linux, MacOS
4. Ejecutar
   EN caso de Windows, en la aplicación se adjunta con la aplicación ya compilada en la cual se 
   ejecuta el archivo Transacciones Bancarias (CLI).exe

* ENFOQUE Y SOLUCIÓN:

Para entender nuestro enfoque inicial lo plasmamos mediante un pequeño diagrama de flujo:

1. Inicio
2. Definir archivo CSV
3. Crear instancia de LogicaTransaccion
4. ¿Archivo válido?
   4.1. Sí -> Leer archivo
   4.2. ¿Lista contiene datos válidos?
	    4.2.1. Sí -> Calcular y mostrar resultados
   4.3. No → Mostrar error y Fin
   
- Para implementar nuestra lógica se usó la estructuras IF, asi como la instrucción FOREACH.
- Tambien se creó varios métodos para poder reutilizar el código y no haya redundancias.
- En la gestión de excepciones usamos TRY-CATCH para el manejo de errores.
- Para una mayor eficiencia y reducción de código se usó LINQ en las principales operaciones.

En la desición de diseño se hizo la implementación utilizando los patrones de diseño de N capas en las cuales 
se implementan el uso decisiones, tambien se usa los principios de SOLID, para que la aplicación sea sincilla 
de entender, facil de mantener, escalable y fácil de desacoplar las funcionalidades.
En este caso como la aplicacion requiere leer archivos, se implementa una clase lógica para las validaciones,
lecturas y demás operaciones, de tal manera que la aplicación pueda consumir las funcionalidades las cuales están 
separadas para un mejor control de errores.
Tambien se usa la programación orientada a objetos.

* ESTRUCTURA DEL PROYECTO:

Se ha creado una aplicación de consola en la cual se implementan 3 capas:
- DATOS
  Para el manejo de la estructura de los datos que se cargarán del archivo (Datos.cs)
- LÓGICA
  Tambien se incluye una capa para el manejo de la logica de la aplicacion (LogicaTransaccion.cs) con el fin de centralizar todas
  las operaciones necesarias para las validaciones, cálculos, se puedan reutilizar en cualquier tipo de aplicacion
  y se tenga una correcta gestión de los errores.
- APLICACION
  Finalmente la capa de la aplicacion (Transacción.cs) en la que se crea el componente que será encargado
  de ejecutar las operaciones creadas en la capa lógica. Se mostrará los resultados según el formato que se solicitó 
  en el ejercicio


# SEGUNDA SOLUCIÓN - Lenguaje de Programación JavaScript

* INTRODUCCIÓN: 

El reto de este proyecto de programación de línea de comandos consiste en desarrollar una 
aplicación que se ejecuta directamente en la consola, sin interfaz gráfica de usuario. 
Su propósito es gestionar el procesamiento de transacciones bancarias, para lo cual se lee
los datos desde un archivo CSV y se procesa la información para hacer cálculos y dar como resultado: 
El Balance Final, la transacción de Mayor Monto y el Conteo de Transacciones.
Otra opción para el desarrollo se consideró el lenguaje de programación JavaScript .


* INSTRUCCIONES DE EJECUCIÓN:

1.- verificar previamente tener instalado node js <br />
2.- clonar repositorio de la rama main <br />
3.- ejecutar el comando => npm intall <br />
4.- ejecutar el comando => node ./Transacciones/TransaccionesApp.js <br />

* ENFOQUE Y SOLUCIÓN:

Para entender nuestro enfoque inicial lo plasmamos mediante un pequeño diagrama de flujo:

1. Inicio
2. Definir archivo CSV
3. Crear instancia de LogicaTransaccion
4. ¿Archivo válido?
   4.1. Sí -> Leer archivo
   4.2. ¿Lista contiene datos válidos?
	    4.2.1. Sí -> Calcular y mostrar resultados
   4.3. No → Mostrar error y Fin
   
- Para implementar nuestra lógica se usó funciones de callback para leer archivos de manera asíncrona.
- Se hace uso de forEach() para recorrer archivos y procesar cada línea de datos.
- Se hace el uso de métodos para filtrar, recorrer y calcular valores de las listas.
- Se hace la validación de datos antes de su procesamiento
- Cada transacción se almacena como un objeto, mejorando la estructura y accesibilidad de datos.

En la desición de diseño se divide la funcionalidad en distintas funciones 
(leerArchivo(), fnCalcularBalanceFinal(), fnCalcularCatidadTipo, fnCalularDatoMayorValor(), fnMonstrarDatos()), 
lo que facilita el mantenimiento y la reutilización del código.
Se usó programación secuencial mediante la cual se detalla la ejecución paso a paso.

* ESTRUCTURA DEL PROYECTO:
- Lectura y carga de datos en un solo componente
- La lógica de los cálculos se implementaron en funciones separadas
- No se creó una aplicacion adicional ya que los resultados se mostraron solo en consola.



