<?php
ini_set('display_errors', 1);
error_reporting(E_ALL);

$servidor = "localhost\\SQLEXPRESS";
$baseDatos = "GestorAlmacen";

$productos = []; 
$errorConexion = "";

try {
    $conexion = new PDO("sqlsrv:Server=$servidor;Database=$baseDatos", "", "", [
        PDO::SQLSRV_ATTR_DIRECT_QUERY => true
    ]);
    $conexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    // Consulta parametrizada no hace falta aquí porque no hay input del usuario
    $sql = "SELECT Codigo, Nombre, Categoria, Stock, Precio FROM Productos ORDER BY Nombre";
    $stmt = $conexion->query($sql);
    $productos = $stmt->fetchAll(PDO::FETCH_ASSOC);

} catch (PDOException $e) {
    $errorConexion = $e->getMessage();
}

?>


<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>InventTrack - Catálogo de productos</title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }

        body 
        {
            font-family: 'Segoe UI', Arial, sans-serif;
            background-color: #f8f9fa;
            color: #212529;
            padding: 30px;
        }

        .contenedor 
        {
            max-width: 1000px;
            margin: 0 auto;
            background: white;
            border-radius: 10px;
            box-shadow: 0 2px 12px rgba(0,0,0,0.08);
            overflow: hidden;
        }

        .cabecera 
        {
            background-color: #212529;
            color: white;
            padding: 25px 30px;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .cabecera h1 
        {
            font-size: 24px;
            font-style: italic;
        }

        .cabecera h1 span 
        { 
        color: #009688; 
        }

        .buscador 
        {
            padding: 20px 30px;
            border-bottom: 1px solid #eee;
        }

        .buscador input 
        {
            width: 100%;
            padding: 12px 15px;
            border: 1px solid #ddd;
            border-radius: 6px;
            font-size: 15px;
            outline: none;
        }

        .buscador input:focus 
        { 
        border-color: #009688; 
        }

        table 
        {
            width: 100%;
            border-collapse: collapse;
        }

        thead 
        {
            background-color: #212529;
            color: white;
        }

        th 
        {
            padding: 14px 20px;
            text-align: left;
            font-size: 14px;
        }

        td 
        {
            padding: 12px 20px;
            border-bottom: 1px solid #f0f0f0;
            font-size: 14px;
        }

        tbody tr:nth-child(even) 
        { background-color: #f5f5f5; 
        }

        tbody tr:hover 
        { background-color: #e0f2f0; 
        }

        .stock-bajo 
        { color: #dc3545; font-weight: bold; 
        }

        .pie 
        {
            padding: 15px 30px;
            color: #888;
            font-size: 13px;
            text-align: center;
        }

    </style>

</head>

<body>

    <div class="contenedor">

        <div class="cabecera">

            <h1>Invent<span>Track</span></h1>

            <div>Catálogo de productos</div>

        </div>


        <div class="buscador">


            <input type="text" id="buscador" placeholder="Buscar producto por nombre, código o categoría...">


        </div>

        <?php if ($errorConexion): ?>

            <p style="padding:30px; color:#dc3545;">Error: <?php echo htmlspecialchars($errorConexion); ?></p>

        <?php else: ?>

            <table id="tablaProductos">

                <thead>

                    <tr>

                        <th>Código</th>
                        <th>Nombre</th>
                        <th>Categoría</th>
                        <th>Stock</th>
                        <th>Precio</th>

                    </tr>

                </thead>

                <tbody>

                    <?php foreach ($productos as $p): ?>

                        <tr>

                            <td><?php echo htmlspecialchars($p['Codigo']); ?></td>
                            <td><?php echo htmlspecialchars($p['Nombre']); ?></td>
                            <td><?php echo htmlspecialchars($p['Categoria']); ?></td>
                            <td class="<?php echo $p['Stock'] < 200 ? 'stock-bajo' : ''; ?>">
                                <?php echo htmlspecialchars($p['Stock']); ?>
                            </td>
                            <td><?php echo number_format($p['Precio'], 2); ?> €</td>

                        </tr>

                    <?php endforeach; ?>

                </tbody>

            </table>

            <div class="pie"><?php echo count($productos); ?> productos en el catálogo</div>

        <?php endif; ?>

    </div>

    <script>

        // Buscador en tiempo real con JavaScript
        const buscador = document.getElementById('buscador');

        const filas = document.querySelectorAll('#tablaProductos tbody tr');

        buscador.addEventListener('input', function() {

            const texto = this.value.toLowerCase();

            filas.forEach(fila => {

                const contenido = fila.textContent.toLowerCase();

                fila.style.display = contenido.includes(texto) ? '' : 'none';

            });

        });

    </script>

</body>

</html>