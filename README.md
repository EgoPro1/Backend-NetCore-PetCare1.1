# PetCare-Backend-NetCore

### Usando Entity FrameworkCore con MySQL
--------------------------

![consola_paquetes_Nuget](https://user-images.githubusercontent.com/34387852/81117133-391f4c80-8eec-11ea-8867-76b900cc5d8b.png)

**PM> add-migration [nombre de la migración]**

> ejemplo: add-migration customer

**PM> update-database**


--------------------------------------
![posible_fallo](https://user-images.githubusercontent.com/34387852/81116460-0759b600-8eeb-11ea-8142-a7be52bea5cb.png)

### Si sale este error al "update-database" se tiene que crear manualmente esa tabla faltante de la siguiente manera en el MySQL:
![table_MigrationHistory](https://user-images.githubusercontent.com/34387852/81116814-a7174400-8eeb-11ea-9ef9-0798ef93129f.png)

### Al crear la tabla se escribe nuevamente el comando "update-database" y se crearán las tablas normalmente
