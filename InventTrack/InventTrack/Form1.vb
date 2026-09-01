Imports System.Data.SqlClient


Public Class GestionAlmacen


    Private Sub GestionAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
        EstilizarTabla()
    End Sub

    Private Sub CargarProductos()
        Try
            Using conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                conexion.Open()

                Dim sql As String = "SELECT Id, Codigo, Nombre, Categoria, Stock, Precio FROM Productos"
                Dim comando As New SqlCommand(sql, conexion)

                Dim adaptador As New SqlDataAdapter(comando)
                Dim tabla As New DataTable()
                adaptador.Fill(tabla)

                dvgProductos.DataSource = tabla
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar productos: " & ex.Message)
        End Try
    End Sub

    'Mejorar la parte visual de la tabla 

    Private Sub EstilizarTabla()
        With dvgProductos
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

    ' Menú Nuevo: abre el formulario para crear un producto
    Private Sub mNuevo_Click(sender As Object, e As EventArgs) Handles mNuevo.Click
        Dim ventana As New Nuevovb()
        If ventana.ShowDialog() = DialogResult.OK Then
            CargarProductos()   ' recargo la tabla para ver el nuevo producto
        End If
    End Sub

    ' Menú Eliminar: borra el producto seleccionado
    Private Sub mEliminar_Click(sender As Object, e As EventArgs) Handles mEliminar.Click

        ' 1. Comprobar que hay una fila seleccionada
        If dvgProductos.CurrentRow Is Nothing Then
            MessageBox.Show("Selecciona un producto para eliminar.")
            Return
        End If

        ' 2. Coger el Id del producto seleccionado
        Dim id As Integer = Convert.ToInt32(dvgProductos.CurrentRow.Cells("Id").Value)
        Dim nombre As String = dvgProductos.CurrentRow.Cells("Nombre").Value.ToString()

        ' 3. Pedir confirmación
        Dim respuesta As DialogResult = MessageBox.Show(
            "¿Seguro que quieres eliminar '" & nombre & "'?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If respuesta = DialogResult.No Then
            Return
        End If

        ' 4. Eliminar de la base de datos (parametrizado)
        Try
            Using conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                conexion.Open()

                Dim sql As String = "DELETE FROM Productos WHERE Id = @id"
                Dim comando As New SqlCommand(sql, conexion)
                comando.Parameters.AddWithValue("@id", id)

                comando.ExecuteNonQuery()
            End Using

            MessageBox.Show("Producto eliminado.")
            CargarProductos()   ' recargar la tabla

        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message)
        End Try
    End Sub

    ' Menú Editar: abre el formulario con el producto seleccionado
    Private Sub mEditar_Click(sender As Object, e As EventArgs) Handles mEditar.Click

        If dvgProductos.CurrentRow Is Nothing Then
            MessageBox.Show("Selecciona un producto para editar.")
            Return
        End If

        Dim id As Integer = Convert.ToInt32(dvgProductos.CurrentRow.Cells("Id").Value)

        Dim ventana As New Nuevovb()
        ventana.ProductoId = id          ' le paso el Id → el formulario sabe que es edición
        If ventana.ShowDialog() = DialogResult.OK Then
            CargarProductos()
        End If
    End Sub

    '------------------------------------------------------------------------------------------
    'Ahora el buscador de productos

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        buscarProductos(txtBuscar.Text.Trim())
    End Sub

    'Filtramos la tabla según el texto del buscador

    Private Sub buscarProductos(texto As String)
        Try
            Using Conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                Conexion.Open()

                Dim sql As String = "SELECT Id, Codigo, Nombre, Categoria, Stock, Precio FROM Productos" &
                                    " WHERE Nombre LIKE @texto OR Codigo LIKE @texto OR Categoria LIKE @texto"


                Dim comando As New SqlCommand(Sql, Conexion)
                comando.Parameters.AddWithValue("@texto", "%" & texto & "%")

                Dim adaptador As New SqlDataAdapter(comando)
                Dim tabla As New DataTable()
                adaptador.Fill(tabla)

                dvgProductos.DataSource = tabla
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message)
        End Try
    End Sub

    ' Menú Movimientos: abre la ventana de movimientos de stock
    Private Sub mMovimientos_Click(sender As Object, e As EventArgs) Handles mMovimientos.Click
        Dim ventana As New Movimientos()
        ventana.ShowDialog()
        CargarProductos()   ' recargo por si cambió el stock
    End Sub

End Class

