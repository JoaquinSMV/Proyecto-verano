Imports System.Data.SqlClient

Public Class Nuevovb

    ' Id del producto que estamos editando. Si es 0, estamos creando uno nuevo.
    Public ProductoId As Integer = 0

    ' Al abrir el formulario, si es edición, cargo los datos del producto
    Private Sub Nuevovb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ProductoId > 0 Then
            Me.Text = "Editar producto"
            CargarDatosProducto()
        Else
            Me.Text = "Nuevo producto"
        End If
    End Sub

    ' Trae los datos del producto y los pone en las cajas de texto
    Private Sub CargarDatosProducto()
        Try
            Using conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                conexion.Open()

                Dim sql As String = "SELECT Nombre, Categoria, Stock, Precio FROM Productos WHERE Id = @id"
                Dim comando As New SqlCommand(sql, conexion)
                comando.Parameters.AddWithValue("@id", ProductoId)

                Dim lector As SqlDataReader = comando.ExecuteReader()
                If lector.Read() Then
                    txtNombre.Text = lector("Nombre").ToString()
                    txtCategoria.Text = lector("Categoria").ToString()
                    txtStock.Text = lector("Stock").ToString()
                    txtPrecio.Text = lector("Precio").ToString()
                End If
                lector.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar el producto: " & ex.Message)
        End Try
    End Sub

    ' Botón Guardar: inserta (nuevo) o actualiza (edición)
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ' Validaciones
        If txtNombre.Text.Trim() = "" Then
            MessageBox.Show("El nombre es obligatorio.")
            Return
        End If

        Dim stock As Integer
        If Not Integer.TryParse(txtStock.Text, stock) Then
            MessageBox.Show("El stock debe ser un número entero.")
            Return
        End If

        Dim precio As Decimal
        If Not Decimal.TryParse(txtPrecio.Text, precio) Then
            MessageBox.Show("El precio debe ser un número (ej: 1.50).")
            Return
        End If

        Try
            Using conexion As SqlConnection = InventTrack.Conexion.ObtenerConexion()
                conexion.Open()

                Dim sql As String
                If ProductoId > 0 Then
                    ' EDICIÓN: actualizar el producto existente
                    sql = "UPDATE Productos SET Nombre = @nombre, Categoria = @categoria, " &
                          "Stock = @stock, Precio = @precio WHERE Id = @id"
                Else
                    ' NUEVO: insertar
                    sql = "INSERT INTO Productos (Nombre, Categoria, Stock, Precio) " &
                          "VALUES (@nombre, @categoria, @stock, @precio)"
                End If

                Dim comando As New SqlCommand(sql, conexion)
                comando.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim())
                comando.Parameters.AddWithValue("@categoria", txtCategoria.Text.Trim())
                comando.Parameters.AddWithValue("@stock", stock)
                comando.Parameters.AddWithValue("@precio", precio)

                ' El parámetro @id solo hace falta en la edición
                If ProductoId > 0 Then
                    comando.Parameters.AddWithValue("@id", ProductoId)
                End If

                comando.ExecuteNonQuery()
            End Using

            MessageBox.Show("Guardado correctamente.")
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class