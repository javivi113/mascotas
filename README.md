Realiza un mini proyecto de tres capas. Incluye dos modelos de negocio relacionados. (ej: mascotas, dueños). Los casos de usos que programarás son listar las mascotas perros con dueño chicos, y crear una mascota al mismo tiempo que asignas su dueño.

Ejemplo de datos en archivos CSV:
```
Max, perro, 17
Bruno, gato, 12
Toby, perro, 13
Minni, gato, 13

----

17, Luis. H
12, Marta, M
13, Anne, M
```

Es un ejemplo. Puedes hacerlo con cualquier otro modelo de datos, respetando que el listado junta los dos modelos, y un modelo hace referencia al otro.
NOTA:  
¿Cómo planteas la estructura de datos en memoria que va a almacenar la entidades/modelos?
Esta decisión es importante para luego, enlazar los datos en un nuevo modelo de datos (o no) para enviarlos a la vista.


Linq; de aquí puedes obtener pistas:  

https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries
https://docs.microsoft.com/es-es/dotnet/csharp/linq/perform-inner-joins
