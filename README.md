# Descripcion

Projecto para NexoCorp, usando clean architecture (divido en capas), cada projecto
es una capa dentro de la solucion. Ademas que se utilizo entity framerwork core, dependency
injection, la solucion esta totalmente desacoplada ya que las interfaces se lo utilizan
en cada capa y no asi las clases concretas.


La estructura de la solucion se divide es las siguientes capas:

- Domain: Se encuentran todas las clases a ser utilizadas en las otras capas.
- Repository: Se encuentra la logica para la base de datos, es decir las consultas, migraciones, etc.
- Services: los servicios que llaman al repository
- PruebaNexoCorp: Capa de presentacion, que llama a los servicios y por ende aqui se inyectan las dependencias.

## Ejecucion del proyecto
Cabe recalcar que dentro del proyecto de PruebaNexoCorp, se encuentra las preguntas tanto
del "Sistema de Farmacorp POS Express" y asi mismo las de "Estrategia ganamax",
para usarlas cada uno hay que introducir 1 en la consola para ejecutar las preguntas de Farmacorp
Pos Express o si no 2 para las de Estrategia ganamax.

En la clase de **"ServicePosExpress"** se encuentran las preguntas con las reglas
de negocio y asi mismo para la **"Estrategia ganamax"**

Para ejecutar las preguntas de **"PruebaNexoCorp2"** y ejecute dotnet run e intruzca el valor
deseado 1 o 2.

## Migraciones
Se encuentra dentro del proyecto de migraciones, se esta utilizando SQL Server, para agregar
su conexion vaya a la lase de **ApplicationDbContext**, al metodo **OnConfiguring** y agrege su conexion.

y para ejecutarlas permanezca de la misma carpeta de **Repositories** utilice su IDE o
los siguientes comandos:
 - dotnet ef migrations list
 - dotnet ef database update