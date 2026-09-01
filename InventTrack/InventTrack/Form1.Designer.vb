<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GestionAlmacen
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dvgProductos = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.mMovimientos = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dvgProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Myanmar Text", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 50)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 48)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "InventTrack"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(991, 60)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(299, 22)
        Me.txtBuscar.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Myanmar Text", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(915, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 27)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Buscar :"
        '
        'dvgProductos
        '
        Me.dvgProductos.AllowUserToResizeRows = False
        Me.dvgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvgProductos.Location = New System.Drawing.Point(16, 113)
        Me.dvgProductos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dvgProductos.Name = "dvgProductos"
        Me.dvgProductos.ReadOnly = True
        Me.dvgProductos.RowHeadersVisible = False
        Me.dvgProductos.RowHeadersWidth = 51
        Me.dvgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dvgProductos.Size = New System.Drawing.Size(1275, 624)
        Me.dvgProductos.TabIndex = 3
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mNuevo, Me.mEditar, Me.mEliminar, Me.mMovimientos})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1312, 28)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mNuevo
        '
        Me.mNuevo.Name = "mNuevo"
        Me.mNuevo.Size = New System.Drawing.Size(66, 24)
        Me.mNuevo.Text = "Nuevo"
        '
        'mEditar
        '
        Me.mEditar.Name = "mEditar"
        Me.mEditar.Size = New System.Drawing.Size(62, 24)
        Me.mEditar.Text = "Editar"
        '
        'mEliminar
        '
        Me.mEliminar.Name = "mEliminar"
        Me.mEliminar.Size = New System.Drawing.Size(77, 24)
        Me.mEliminar.Text = "Eliminar"
        '
        'mMovimientos
        '
        Me.mMovimientos.Name = "mMovimientos"
        Me.mMovimientos.Size = New System.Drawing.Size(109, 24)
        Me.mMovimientos.Text = "Movimientos"
        '
        'GestionAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1312, 752)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dvgProductos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "GestionAlmacen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InventTrack"
        CType(Me.dvgProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtBuscar As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dvgProductos As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mNuevo As ToolStripMenuItem
    Friend WithEvents mEditar As ToolStripMenuItem
    Friend WithEvents mEliminar As ToolStripMenuItem
    Friend WithEvents mMovimientos As ToolStripMenuItem
End Class
