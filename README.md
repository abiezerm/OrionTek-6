# OrionTek
Proyecto para tener el control de todos los clientes pertenecientes a la empresa X, donde cada cliente puede tener N cantidad de direcciones.

### Herramientas utilizadas

* [ASP.NET](https://dotnet.microsoft.com/en-us/apps/aspnet)
* [Patrón MVC Core](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-6.0)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [JQuery](https://jquery.com/)
* [JQuery DataTable](https://datatables.net/)
* [Bootstrap](https://getbootstrap.com)
* [Patrón Repositorio](https://www.linkedin.com/pulse/repository-pattern-c-pawan-verma/)

# Getting Started
## Requisitos
* Debes tener instalado una instanci de SQL Server, en este caso, el sistema usa la instancia predeterminada.
* Descarga el código y ejecuta la migración
* Ejecuta el sistema y verás la pantalla principal.

## Instrucciones
* En la página principal se encuentra el menú de opsiones en la parte superior, asegurate de haber creado la base de datos.
* Menú "Crear" en el formulario para crear nuevo clientes con una sola línea en la dirección.
* Menú "Listado" encontraremos todos los clientes creados. En este mismo formulario, podremos editar cualquier información del cliente, solo hacemos clic en el campo que deseamos editar y al finalizar los cambios pulsamos la tecla Enter, tomar cuenta que al editar la dirección, ésta será creada como un nuevo registro almacenando la anterior en un estado de no activa.
* Menú "Histórico de Direcciones" aquí vamos a ver el listado de los clientes donde podremos consultar sus direcciones.
