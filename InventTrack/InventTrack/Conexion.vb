Imports System.Data.SqlClient

Public Class Conexion
    ' Cadena de conexión a SQL Server.
    Private Shared ReadOnly cadena As String =
        "Server=localhost\SQLEXPRESS;Database=GestorAlmacen;Integrated Security=True;TrustServerCertificate=True;"

    ' Devuelvo una conexión nueva lista para abrir.
    Public Shared Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(cadena)
    End Function
End Class