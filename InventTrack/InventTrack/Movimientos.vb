Imports System.Data.SqlClient

Public Class Movimientos

    ' Al abrir la ventana: cargar productos en el combo, tipos, y el historial
    Private Sub Movimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductosCombo()
        CargarTipos()
        CargarMovimientos()
        EstilizarTabla()
    End Sub

    ' Rellena el ComboBox de productos con los de la BD
    Private Sub CargarProductosCombo()
        Try
            Using conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                conexion.Open()

                Dim sql As String = "SELECT Id, Nombre FROM Productos ORDER BY Nombre"
                Dim comando As New SqlCommand(sql, conexion)

                Dim adaptador As New SqlDataAdapter(comando)
                Dim tabla As New DataTable()
                adaptador.Fill(tabla)

                cmbProducto.DataSource = tabla
                cmbProducto.DisplayMember = "Nombre"   ' lo que ve el usuario
                cmbProducto.ValueMember = "Id"          ' el valor real que usamos
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message)
        End Try
    End Sub

    ' Rellena el ComboBox de tipo con Entrada/Salida
    Private Sub CargarTipos()
        cmbTipo.Items.Clear()
        cmbTipo.Items.Add("Entrada")
        cmbTipo.Items.Add("Salida")
        cmbTipo.SelectedIndex = 0   ' seleccionar "Entrada" por defecto
    End Sub

    ' Carga el historial de movimientos CON JOIN (muestra el nombre del producto)
    Private Sub CargarMovimientos()
        Try
            Using conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                conexion.Open()

                Dim sql As String =
                    "SELECT m.Id, p.Nombre AS Producto, m.Tipo, m.Cantidad, m.Fecha " &
                    "FROM Movimientos m " &
                    "INNER JOIN Productos p ON m.ProductoId = p.Id " &
                    "ORDER BY m.Fecha DESC"

                Dim comando As New SqlCommand(sql, conexion)
                Dim adaptador As New SqlDataAdapter(comando)
                Dim tabla As New DataTable()
                adaptador.Fill(tabla)

                dgvMovimientos.DataSource = tabla
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar movimientos: " & ex.Message)
        End Try
    End Sub

    ' Botón Registrar: inserta el movimiento Y actualiza el stock del producto
    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click

        ' Validar que hay producto seleccionado
        If cmbProducto.SelectedValue Is Nothing Then
            MessageBox.Show("Selecciona un producto.")
            Return
        End If

        ' Validar cantidad
        Dim cantidad As Integer
        If Not Integer.TryParse(txtCantidad.Text, cantidad) OrElse cantidad <= 0 Then
            MessageBox.Show("La cantidad debe ser un número mayor que 0.")
            Return
        End If

        Dim productoId As Integer = Convert.ToInt32(cmbProducto.SelectedValue)
        Dim tipo As String = cmbTipo.SelectedItem.ToString()

        Try
            Using conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                conexion.Open()

                ' 1. Insertar el movimiento
                Dim sqlMov As String =
                    "INSERT INTO Movimientos (ProductoId, Tipo, Cantidad) " &
                    "VALUES (@productoId, @tipo, @cantidad)"
                Dim cmdMov As New SqlCommand(sqlMov, conexion)
                cmdMov.Parameters.AddWithValue("@productoId", productoId)
                cmdMov.Parameters.AddWithValue("@tipo", tipo)
                cmdMov.Parameters.AddWithValue("@cantidad", cantidad)
                cmdMov.ExecuteNonQuery()

                ' 2. Actualizar el stock: sumar si es entrada, restar si es salida
                Dim signo As String = If(tipo = "Entrada", "+", "-")
                Dim sqlStock As String =
                    "UPDATE Productos SET Stock = Stock " & signo & " @cantidad " &
                    "WHERE Id = @productoId"
                Dim cmdStock As New SqlCommand(sqlStock, conexion)
                cmdStock.Parameters.AddWithValue("@cantidad", cantidad)
                cmdStock.Parameters.AddWithValue("@productoId", productoId)
                cmdStock.ExecuteNonQuery()
            End Using

            MessageBox.Show("Movimiento registrado y stock actualizado.")
            txtCantidad.Clear()
            CargarMovimientos()   ' recargar el historial

        Catch ex As Exception
            MessageBox.Show("Error al registrar: " & ex.Message)
        End Try
    End Sub

    Private Sub EstilizarTabla()
        With dgvMovimientos
            ' Sin bordes feos, plano y moderno
            .BorderStyle = BorderStyle.None
            .BackgroundColor = Color.White
            .EnableHeadersVisualStyles = False

            ' Cabecera gris oscuro con texto blanco
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 37, 41)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersHeight = 38
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None

            ' Filas: fuente y altura
            .DefaultCellStyle.Font = New Font("Segoe UI", 9.5)
            .RowTemplate.Height = 32
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 136) ' turquesa al seleccionar
            .DefaultCellStyle.SelectionForeColor = Color.White

            ' Filas alternas en gris muy claro (se lee mejor)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)

            ' Líneas de rejilla suaves
            .GridColor = Color.FromArgb(230, 230, 230)

            ' Que las columnas ocupen todo el ancho
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .AllowUserToAddRows = False

        End With
    End Sub

End Class