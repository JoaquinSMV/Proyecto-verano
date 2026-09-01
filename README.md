# InventTrack — Gestor de almacén

InventTrack es un proyecto que hice para gestionar el almacén de una empresa: llevar el control de los productos que hay, cuántas unidades quedan de cada uno y registrar las entradas y salidas de mercancía. La idea es tener siempre claro qué hay en el almacén y cómo va cambiando el stock con el día a día.

El proyecto está formado por dos partes que trabajan sobre la misma base de datos: una aplicación de escritorio y una web.

## Qué hace

- Da de alta productos nuevos, con su nombre, categoría, stock y precio.
- Permite editar los productos ya existentes o eliminarlos.
- Lleva un buscador para encontrar cualquier producto al momento por su nombre, código o categoría.
- Registra los movimientos del almacén (entradas y salidas), y cada vez que se registra uno, el stock del producto se actualiza solo.
- Muestra un historial de todos los movimientos, indicando a qué producto pertenece cada uno.
- El código de cada producto se genera automáticamente, para que nunca haya dos iguales y no dependa de que alguien lo escriba a mano.

## Cómo está construido

El proyecto tiene dos partes:

**La aplicación de escritorio** está hecha en VB.NET. Es la parte principal, desde la que se gestiona todo el almacén: crear, editar y borrar productos, buscar, y registrar los movimientos de stock. Tiene una interfaz sencilla y cuidada para que sea cómoda de usar.

**La web** está hecha en PHP, junto con HTML, CSS y JavaScript. Muestra el catálogo de productos de una forma visual y permite buscar entre ellos en tiempo real. Sirve como una forma rápida de consultar el almacén desde el navegador, sin necesidad de abrir la aplicación.

Las dos partes se conectan a la misma base de datos, hecha en SQL Server, donde se guarda toda la información de los productos y los movimientos. De esta forma, sea cual sea la parte que uses, siempre estás trabajando con los mismos datos.

## Tecnologías utilizadas

- **VB.NET** para la aplicación de escritorio
- **PHP, HTML, CSS y JavaScript** para la web
- **SQL Server** para la base de datos

## Estructura del proyecto

- **InventTrack** — la aplicación de escritorio en VB.NET
- **InventTrackWeb** — la web en PHP

## Sobre el proyecto

Este proyecto lo desarrollé para practicar y demostrar el trabajo con distintas tecnologías a la vez, viendo cómo una misma base de datos se puede gestionar tanto desde una aplicación de escritorio como desde una web, que es una situación muy habitual en una empresa real.
