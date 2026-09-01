<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Movimientos
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
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.btnRegistrar = New System.Windows.Forms.Button()
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbProducto
        '
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(43, 63)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(166, 24)
        Me.cmbProducto.TabIndex = 1
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(232, 62)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(166, 24)
        Me.cmbTipo.TabIndex = 2
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(529, 63)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(148, 22)
        Me.txtCantidad.TabIndex = 3
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Location = New System.Drawing.Point(679, 60)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Size = New System.Drawing.Size(79, 31)
        Me.btnRegistrar.TabIndex = 4
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.UseVisualStyleBackColor = True
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowUserToResizeRows = False
        Me.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientos.Location = New System.Drawing.Point(31, 104)
        Me.dgvMovimientos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.ReadOnly = True
        Me.dgvMovimientos.RowHeadersVisible = False
        Me.dgvMovimientos.RowHeadersWidth = 51
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(727, 443)
        Me.dgvMovimientos.TabIndex = 5
        '
        'Movimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 560)
        Me.Controls.Add(Me.dgvMovimientos)
        Me.Controls.Add(Me.btnRegistrar)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.cmbProducto)
        Me.Name = "Movimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Movimientos"
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents dgvMovimientos As DataGridView
End Class
