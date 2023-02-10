<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddProduct
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPTQ = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPPQ = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(63, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product's Name:"
        '
        'txtPN
        '
        Me.txtPN.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.txtPN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPN.ForeColor = System.Drawing.Color.White
        Me.txtPN.Location = New System.Drawing.Point(66, 55)
        Me.txtPN.Name = "txtPN"
        Me.txtPN.Size = New System.Drawing.Size(222, 19)
        Me.txtPN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(63, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Product's Capital:"
        '
        'txtPC
        '
        Me.txtPC.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.txtPC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPC.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPC.ForeColor = System.Drawing.Color.White
        Me.txtPC.Location = New System.Drawing.Point(66, 98)
        Me.txtPC.Name = "txtPC"
        Me.txtPC.Size = New System.Drawing.Size(222, 19)
        Me.txtPC.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(63, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Product's  Total Qty:"
        '
        'txtPTQ
        '
        Me.txtPTQ.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.txtPTQ.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPTQ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPTQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPTQ.ForeColor = System.Drawing.Color.White
        Me.txtPTQ.Location = New System.Drawing.Point(66, 141)
        Me.txtPTQ.Name = "txtPTQ"
        Me.txtPTQ.Size = New System.Drawing.Size(222, 19)
        Me.txtPTQ.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(63, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Product's Price Per Qty:"
        '
        'txtPPQ
        '
        Me.txtPPQ.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.txtPPQ.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPPQ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPPQ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPQ.ForeColor = System.Drawing.Color.White
        Me.txtPPQ.Location = New System.Drawing.Point(66, 184)
        Me.txtPPQ.Name = "txtPPQ"
        Me.txtPPQ.Size = New System.Drawing.Size(222, 19)
        Me.txtPPQ.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(66, 222)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(222, 30)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'frmAddProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(356, 308)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPPQ)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPTQ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPN)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddProduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Product"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPN As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPC As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPTQ As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPPQ As TextBox
    Friend WithEvents btnSave As Button
End Class
