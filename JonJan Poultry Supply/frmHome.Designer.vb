<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        Me.dgvHome = New System.Windows.Forms.DataGridView()
        Me.col1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPubUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPubName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colManageProducts = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSearchBar = New System.Windows.Forms.TextBox()
        Me.dtpDay = New System.Windows.Forms.DateTimePicker()
        Me.cbDate = New System.Windows.Forms.CheckBox()
        Me.cbMonth = New System.Windows.Forms.CheckBox()
        Me.dtpMonth = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dgvHome, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHome
        '
        Me.dgvHome.AllowUserToAddRows = False
        Me.dgvHome.AllowUserToDeleteRows = False
        Me.dgvHome.AllowUserToResizeColumns = False
        Me.dgvHome.AllowUserToResizeRows = False
        Me.dgvHome.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvHome.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvHome.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.dgvHome.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvHome.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(253, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(10)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHome.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHome.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col1, Me.colDate, Me.colPubUser, Me.colPubName, Me.Column2, Me.Column1, Me.colManageProducts, Me.colDelete})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(123, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHome.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvHome.EnableHeadersVisualStyles = False
        Me.dgvHome.Location = New System.Drawing.Point(12, 53)
        Me.dgvHome.Name = "dgvHome"
        Me.dgvHome.ReadOnly = True
        Me.dgvHome.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvHome.RowHeadersVisible = False
        Me.dgvHome.Size = New System.Drawing.Size(1130, 560)
        Me.dgvHome.TabIndex = 2
        '
        'col1
        '
        Me.col1.HeaderText = "#"
        Me.col1.Name = "col1"
        Me.col1.ReadOnly = True
        Me.col1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.col1.Visible = False
        '
        'colDate
        '
        Me.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colDate.HeaderText = "Date"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.Width = 200
        '
        'colPubUser
        '
        Me.colPubUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPubUser.HeaderText = "Client's Username"
        Me.colPubUser.Name = "colPubUser"
        Me.colPubUser.ReadOnly = True
        Me.colPubUser.Width = 200
        '
        'colPubName
        '
        Me.colPubName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPubName.HeaderText = "Client's Name"
        Me.colPubName.Name = "colPubName"
        Me.colPubName.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.HeaderText = "Last Updated On:"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.HeaderText = "Last Updated By:"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'colManageProducts
        '
        Me.colManageProducts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.MediumTurquoise
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.colManageProducts.DefaultCellStyle = DataGridViewCellStyle2
        Me.colManageProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.colManageProducts.HeaderText = ""
        Me.colManageProducts.Name = "colManageProducts"
        Me.colManageProducts.ReadOnly = True
        Me.colManageProducts.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colManageProducts.Width = 90
        '
        'colDelete
        '
        Me.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(7, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.colDelete.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.colDelete.HeaderText = ""
        Me.colDelete.Name = "colDelete"
        Me.colDelete.ReadOnly = True
        Me.colDelete.Visible = False
        Me.colDelete.Width = 90
        '
        'btnNew
        '
        Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNew.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnNew.FlatAppearance.BorderSize = 0
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNew.ForeColor = System.Drawing.Color.Black
        Me.btnNew.Location = New System.Drawing.Point(1024, 24)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(116, 23)
        Me.btnNew.TabIndex = 3
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.Width = 90
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(17, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Search by Name:"
        '
        'txtSearchBar
        '
        Me.txtSearchBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(123, Byte), Integer))
        Me.txtSearchBar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearchBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.txtSearchBar.ForeColor = System.Drawing.Color.White
        Me.txtSearchBar.Location = New System.Drawing.Point(140, 20)
        Me.txtSearchBar.Name = "txtSearchBar"
        Me.txtSearchBar.Size = New System.Drawing.Size(220, 23)
        Me.txtSearchBar.TabIndex = 16
        '
        'dtpDay
        '
        Me.dtpDay.Cursor = System.Windows.Forms.Cursors.Default
        Me.dtpDay.CustomFormat = "yyyy-MM-dd: dddd"
        Me.dtpDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDay.Location = New System.Drawing.Point(465, 22)
        Me.dtpDay.Name = "dtpDay"
        Me.dtpDay.Size = New System.Drawing.Size(161, 25)
        Me.dtpDay.TabIndex = 17
        '
        'cbDate
        '
        Me.cbDate.AutoSize = True
        Me.cbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbDate.ForeColor = System.Drawing.Color.White
        Me.cbDate.Location = New System.Drawing.Point(378, 22)
        Me.cbDate.Name = "cbDate"
        Me.cbDate.Size = New System.Drawing.Size(76, 21)
        Me.cbDate.TabIndex = 48
        Me.cbDate.Text = "By Day:"
        Me.cbDate.UseVisualStyleBackColor = True
        '
        'cbMonth
        '
        Me.cbMonth.AutoSize = True
        Me.cbMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbMonth.ForeColor = System.Drawing.Color.White
        Me.cbMonth.Location = New System.Drawing.Point(658, 20)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(90, 21)
        Me.cbMonth.TabIndex = 50
        Me.cbMonth.Text = "By Month:"
        Me.cbMonth.UseVisualStyleBackColor = True
        '
        'dtpMonth
        '
        Me.dtpMonth.CustomFormat = "MMMM yyyy"
        Me.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMonth.Location = New System.Drawing.Point(754, 19)
        Me.dtpMonth.Name = "dtpMonth"
        Me.dtpMonth.ShowUpDown = True
        Me.dtpMonth.Size = New System.Drawing.Size(123, 25)
        Me.dtpMonth.TabIndex = 49
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbMonth)
        Me.GroupBox1.Controls.Add(Me.dtpMonth)
        Me.GroupBox1.Controls.Add(Me.cbDate)
        Me.GroupBox1.Controls.Add(Me.dtpDay)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtSearchBar)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.dgvHome)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(23, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1154, 625)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "JonJan Poultry Supply Logs"
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1189, 707)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmHome"
        Me.Text = "frmHome"
        CType(Me.dgvHome, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents dgvHome As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents DataGridViewImageColumn1 As DataGridViewImageColumn
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSearchBar As TextBox
    Friend WithEvents dtpDay As DateTimePicker
    Friend WithEvents cbDate As CheckBox
    Friend WithEvents cbMonth As CheckBox
    Friend WithEvents dtpMonth As DateTimePicker
    Friend WithEvents col1 As DataGridViewTextBoxColumn
    Friend WithEvents colDate As DataGridViewTextBoxColumn
    Friend WithEvents colPubUser As DataGridViewTextBoxColumn
    Friend WithEvents colPubName As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents colManageProducts As DataGridViewButtonColumn
    Friend WithEvents colDelete As DataGridViewButtonColumn
    Friend WithEvents GroupBox1 As GroupBox
End Class
