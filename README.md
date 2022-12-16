![image](https://user-images.githubusercontent.com/89231768/208024694-e00351e2-7f9b-406a-87b1-951027a3d0b7.png)


T![](RackMultipart20221216-1-6c8yxt_html_62081cb157ec52e4.png)aller de Programación II

Desarrollo de Software

IES Coviello

![](RackMultipart20221216-1-6c8yxt_html_8d658ee63faf28dd.png)

**Trabajo final**

**Materia:** Taller de Programación II.

**Carrera:** Desarrollo de software.

**Instituto:** Alfredo Coviello.

**Año** : 2022

**Profesor:** Gabriela Cecilia Burgos.

**Alumno:** Santiago David Viva.

ÍNDICE

# Contenido

[**Descripción de Proyecto** 3](#_Toc110823567)

[Información General: 3](#_Toc110823568)

[Descripción General del Proyecto: 3](#_Toc110823569)

[Objetivos del Sistema de Información: 3](#_Toc110823570)

[Alcance del Sistema de Información: 3](#_Toc110823571)

[Funcionalidades: 3](#_Toc110823572)

[**DISEÑO DE LA BASE DE DATOS** 4](#_Toc110823573)

[Modelo relacional: 4](#_Toc110823574)

[Tablas y campos: 6](#_Toc110823575)

[_Empleados:_ 6](#_Toc110823576)

[_Usuarios:_ 6](#_Toc110823577)

[_Vehículos:_ 7](#_Toc110823578)

[_Planes:_ 7](#_Toc110823579)

[_Tarifas:_ 7](#_Toc110823580)

[_Patentes:_ 8](#_Toc110823581)

[_Clientes:_ 8](#_Toc110823582)

[_Factura:_ 9](#_Toc110823583)

[_Ingreso y Salida:_ 9](#_Toc110823584)

[**FORMULARIOS DEL SISTEMA** 10](#_Toc110823585)

# **Descripción de Proyecto**

## Información General:

  - Nombre: ParKing.
  - Alumno: Santiago David Viva.

## Descripción General del Proyecto:

Programa para gestión de playas de estacionamientos.

## Objetivos del Sistema de Información:

Gestión de una playa de estacionamiento.

## Alcance del Sistema de Información:

El software permitirá gestionar que cada cliente pueda configurar sus tarifas diferenciadas según el tipo de vehículo y la modalidad horaria.

Carga manual del usuario del horario de entrada y salida.

Cierre de caja diario y mensual.

## Funcionalidades:

**Tomar datos del vehículo**** :**

  - Patente, el software buscara si tiene una tarifa mensual y si tiene saldo pendiente. De no ser cliente mensual se generará un ingreso normal.
  - Hora de ingrese.
  - Tipo de vehículo.
  - Hora de egreso.
  - Cálculo de tarifa.
  - Cierre de caja diario y mensual.

# **DISEÑO DE LA BASE DE DATOS**

Una de las primeras etapas para lograr un buen software de aplicación, que logre cubrir las necesidades del usuario, es el diseño de la base de datos.

Una base de datos con un diseño sólido es fundamental para el buen funcionamiento del programa, ya que el mismo se apoya en ésta.

Para crear una base de datos hay que entender las relaciones entre la información, el tipo de datos que se mantendrán en la base y cómo se utilizarán.

## Modelo relacional:

Para el caso particular de ParKing se diseñó una base de datos con un modelo relacional, buscando cumplir con la integridad referencial.

Lo que se busca con este modelo es evitar inconsistencias como datos redundantes, que se repitan en varias bases de datos sin relacionarse. Así, cuando existe un campo con una clave foránea en una tabla, no es posible agregar un registro a menos que ya exista uno en la tabla correspondiente.

Es por esto que todas las relaciones de la base de datos de ParKing cumplen con el modelo de "uno a varios".

A continuación, se muestra una vista general, con todas las tablas con sus respectivos campos y relaciones.


![image](https://user-images.githubusercontent.com/89231768/208025099-d8ba5162-c1bb-42ea-82c5-c908222027d5.png)

## Tablas y campos:

### _Empleados:_

![](RackMultipart20221216-1-6c8yxt_html_df203941a378b767.png)
La tabla **"empleados"** contiene los datos personales referentes a los empleados, para su identificación y contacto.

Su clave primaria es **"idEmpleado"** , un campo numérico, autoincrementable, para que sea única para cada empleado que se registra.

Además, contiene el campo **"usuario"** , una clave foránea del tipo numérico, la cual permite asignar a cada empleado un usuario para el ingreso a la aplicación. Esto facilita llevar un control tanto de las gestiones que realiza cada empleado como de los permisos que se pueden conceder al mismo.

###


### _Usuarios:_

![image](https://user-images.githubusercontent.com/89231768/208025200-d289d653-b3f8-45bd-8434-4fe9b3d083fc.png)
La tabla **"usuarios"** contiene los datos de ingreso de los usuarios que se registran en la aplicación y sus limitaciones de acceso dentro de la misma.

Los campos **"usuario"** y **"pass"** contienen el nombre de usuario y su clave para el ingreso, respectivamente.

El campo **"tipoUsuario"** asigna a cada usuario una condición o jerarquía, que según el caso, le restringe ciertas funciones.

Además, como se explicó, permite llevar un registro de las gestiones que realiza cada uno.

### _Vehículos:_

![image](https://user-images.githubusercontent.com/89231768/208025229-34f62ff0-a674-485c-b3df-ef29eea1afbe.png)
La tabla **"vehículos"** registra los tipos de vehículos que admite la playa de estacionamiento.

El campo **"idVehiculo"** es su campo llave.

El campo **"vehiculo"** registra el tipo de vehículo, lo que permite asignar tarifas según el vehículo.

### _Planes:_

![image](https://user-images.githubusercontent.com/89231768/208025292-455760b3-2a0e-40b6-8c7c-bfb4e1710b92.png)
La tabla **"planes"** registra los distintitos tipos de planes posibles a contratar, por ejemplo, si es un cliente que usará el servicio "por hora" o pagará "mensual".

### _Tarifas:_

![image](https://user-images.githubusercontent.com/89231768/208025440-9f41b122-1d5e-431d-9dd6-41bdebe06cac.png)
La tabla **"tarifas"** permite definir las distintas tarifas según el tipo de vehículo que se trate y el tipo de plan. Por ejemplo determina la tarifa para motos por hora, o para autos por mes.

Tiene dos claves foráneas: **"tipoVehiculo"** , tomada del campo clave de la tabla **"vehículos"** y **"plan"** , relacionada con el campo clave de la tabla **"planes".**

Por último registra la tarifa asignada, en el campo **"tarifas".**

### _Patentes:_

![image](https://user-images.githubusercontent.com/89231768/208025465-6b715c7f-6bae-4c92-947a-78d6296d2ba2.png)
La tabla **"patentes"** registra las patentes de todos los clientes que contratan el servicio y la tarifa que le corresponde.

Es la única tabla cuya clave primaria no es numérica y autoincrementable, sino del tipo VARCHAR y corresponde a la patente de cada vehículo.

Tiene dos claves foráneas: **"tarifa"** y **"cliente"** , campos claves de las tablas **"tarifas"** y **"clientes"** , respectivamente.

Además, para el caso de los clientes que contratan un servicio periódico (por ej. mensual) pueden registrarse la Fecha de inicio en la cual se contrata el servicio y la fecha de vencimiento, para un control de cuándo tiene que renovar.

### _Clientes:_

![image](https://user-images.githubusercontent.com/89231768/208025499-a1617c27-489e-465e-93f1-fb900f2780dd.png)

La tabla **"clientes"** lleva un registro de todos los clientes, con sus datos personales y de contacto

Está relacionado con la tabla **"usuarios"** por medio de la clave foránea **"usuario"** con el fin de llevar un registro de qué usuario registró al cliente.

Su clave primaria **"idCliente"** sirve de clave foránea en las tablas **"patentes"** y **"factura"**.

El primer cliente es el consumidor final, es decir el que usa la tarifa horaria.

### _Factura:_

![image](https://user-images.githubusercontent.com/89231768/208025511-d3e13072-5fb9-4d93-b5c5-550b2add5b51.png)
La tabla **"factura"** hace una enumeración correlativa de todos los cobros que se realizan, en forma automática.

Contiene la fecha del pago y el importe total recibido por operación, ya sea de un ticket generado por un vehículo que sólo estuvo unas horas o un cliente que vino a hacer un pago mensual.

Su clave foránea **"idCliente"** de la tabla **"clientes"** referencia el cliente que realizó el pago.

### _Ingreso y Salida:_

![image](https://user-images.githubusercontent.com/89231768/208025549-db792597-a85b-4e2d-97a9-4ef517df43cd.png)
La tabla **"ingresoysalida"** lleva el registro de todos los movimientos de vehículos que ingresan y salen del estacionamiento.

Sus campos **"horaIngreso"** y **"horaSalida"** permiten asentar la hora en la que un vehículo entra y sale del estacionamiento, que para el caso de los que tienen una tarifa horaria, es fundamental para determinar el total a cobrar, que se calcula en el campo **"total"**.

Sus claves foráneas **"patente"** y **"vehículo"** se relacionan con las tablas del mismo nombre.

Las claves **"ingresoUsuario"** y **"egresoUsuario"** referencian al usuario que registró la entrada y salida de un vehículo.

# **FORMULARIOS DEL SISTEMA**

Los formularios facilitan el uso del software de aplicación, están destinados para el usuario final y se busca que su uso sea intuitivo y dé la información relevante.

Los formularios del software ParKing son:

## Formulario para ingresar al sistema:

![image](https://user-images.githubusercontent.com/89231768/208025576-fd4c572c-2980-44d6-a964-16f5302b77d1.png)
Con el podemos ingresar al sistema ingresando nuestro usuario y contraseña asignados.

Los datos serán validados, permitiendo ingresar solo caracteres alfanúmeros, de lo contrario nos mostrará un error de pantalla ya sea por usuario o contraseña incorrecto o por ingresar caracteres no permitidos.

## Vista principal:

![image](https://user-images.githubusercontent.com/89231768/208025627-0e13009f-6345-4231-9b88-b975f7d11729.png)

##

El formulario principal nos permitirá gestionar por completo el ingreso y salida de cada vehículo de clientes sin registrar. Con ingresar la patente y el tipo de vehículo, este se asignará automáticamente en el datagrid presentado en pantalla. Si el vehículo ya esta ingresado, el sistema nos lo dira.

Para realizar el egreso de un vehículo solo presionamos el botón "sale", el mismo nos genera el ticket con la patente, las horas de estadía y el monto total a pagar. Al cliente se le brinda un tiempo de "gracia" de diez minutos donde no se contará ningún montón a pagar, tanto cuando ingresa como al haber pasado la hora de estadía.

El panel superior al datagrid nos permite:

- Realizar la búsqueda de un vehículo ingresado, tanto por su número de ticket como por su patente.
- Nos muestra un contador de vehículos y la cantidad máxima de ingresos.
- Podemos visualizar el usuario del playero que actualmente se encuentra trabajando. Este mismo es el usuario que queda registrado en nuestra BD

## Historial:

![image](https://user-images.githubusercontent.com/89231768/208025653-d464b560-099a-4b38-86c1-ec2045b8b903.png)

El historial nos detalla el ingreso y egreso de la totalidad de vehículos, ya sea que estén estacionados o ya no estén en el estacionamiento.

## Clientes:

![image](https://user-images.githubusercontent.com/89231768/208025703-4db30839-a826-4f59-8870-ca6ee334767f.png)

El formulario "Clientes" nos permite realizar el registro, actualizar los datos, agregar un vehículo y eliminar el mismo. Al ingresar también nos mostrara un datagrid con todos los clientes registrados hasta el momento, también con sus datos vamos a encontrar la fecha en la que vence su plan.

## Empleados:

![image](https://user-images.githubusercontent.com/89231768/208025722-5d69a8ce-f467-4ec2-8eab-25be993e0e4e.png)

Desde este formulario gestionamos los datos por completo de cualquier empleado, desde sus datos personales hasta su usuario y contraseña. Formulario solo disponible para usuario administrador.

## Facturación:

![image](https://user-images.githubusercontent.com/89231768/208025797-8580df5c-8214-4729-ab47-e571743c416f.png)
El formulario nos presenta al ingresar el resumen completo de la facturación de egresos en el sistema.

También nos permite elegir un rango de fecha deseado.

Como se muestra en la siguiente imagen. Al seleccionar el botón "resumen", se realiza el calculo por separado de clientes y consumidores finales.

![](RackMultipart20221216-1-6c8yxt_html_a6261d0c29bfa29b.png)

## Configuración:

![image](https://user-images.githubusercontent.com/89231768/208025807-37fd1a7e-464e-4a6d-aeed-7426590c3876.png)
Formulario que nos permite establecer la capacidad máxima de vehículos para nuestros estacionamiento.

Esta opción solo esta disponible para el usuario con categoría de administrador.

