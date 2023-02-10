<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlChildForm = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlSideBar = New System.Windows.Forms.Panel()
        Me.pnlBtn = New System.Windows.Forms.Panel()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.btnChangePass = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnSuppliersContacts = New System.Windows.Forms.Button()
        Me.btnManage = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnTodaysLog = New System.Windows.Forms.Button()
        Me.btnSalesInfo = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlSideBar.SuspendLayout()
        Me.pnlBtn.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlChildForm
        '
        Me.pnlChildForm.BackColor = System.Drawing.Color.Transparent
        Me.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlChildForm.Location = New System.Drawing.Point(243, 3)
        Me.pnlChildForm.Margin = New System.Windows.Forms.Padding(7, 3, 3, 3)
        Me.pnlChildForm.Name = "pnlChildForm"
        Me.pnlChildForm.Padding = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.pnlChildForm.Size = New System.Drawing.Size(1189, 707)
        Me.pnlChildForm.TabIndex = 1
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'pnlSideBar
        '
        Me.pnlSideBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.pnlSideBar.Controls.Add(Me.pnlBtn)
        Me.pnlSideBar.Controls.Add(Me.Panel1)
        Me.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSideBar.Location = New System.Drawing.Point(3, 3)
        Me.pnlSideBar.Margin = New System.Windows.Forms.Padding(3, 3, 7, 3)
        Me.pnlSideBar.Name = "pnlSideBar"
        Me.pnlSideBar.Size = New System.Drawing.Size(240, 707)
        Me.pnlSideBar.TabIndex = 0
        '
        'pnlBtn
        '
        Me.pnlBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlBtn.BackColor = System.Drawing.Color.Transparent
        Me.pnlBtn.Controls.Add(Me.btnLogOut)
        Me.pnlBtn.Controls.Add(Me.btnChangePass)
        Me.pnlBtn.Controls.Add(Me.btnSettings)
        Me.pnlBtn.Controls.Add(Me.btnSuppliersContacts)
        Me.pnlBtn.Controls.Add(Me.btnManage)
        Me.pnlBtn.Controls.Add(Me.btnHome)
        Me.pnlBtn.Controls.Add(Me.btnTodaysLog)
        Me.pnlBtn.Controls.Add(Me.btnSalesInfo)
        Me.pnlBtn.Location = New System.Drawing.Point(0, 282)
        Me.pnlBtn.Name = "pnlBtn"
        Me.pnlBtn.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlBtn.Size = New System.Drawing.Size(240, 425)
        Me.pnlBtn.TabIndex = 1
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnLogOut.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnLogOut.FlatAppearance.BorderSize = 0
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLogOut.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.logout
        Me.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogOut.Location = New System.Drawing.Point(12, 358)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(216, 55)
        Me.btnLogOut.TabIndex = 5
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'btnChangePass
        '
        Me.btnChangePass.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnChangePass.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnChangePass.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnChangePass.FlatAppearance.BorderSize = 0
        Me.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnChangePass.ForeColor = System.Drawing.Color.Black
        Me.btnChangePass.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.rotation_lock
        Me.btnChangePass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnChangePass.Location = New System.Drawing.Point(12, 342)
        Me.btnChangePass.MinimumSize = New System.Drawing.Size(216, 55)
        Me.btnChangePass.Name = "btnChangePass"
        Me.btnChangePass.Size = New System.Drawing.Size(216, 55)
        Me.btnChangePass.TabIndex = 5
        Me.btnChangePass.Text = "Change Password"
        Me.btnChangePass.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnSettings.FlatAppearance.BorderSize = 0
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSettings.ForeColor = System.Drawing.Color.Black
        Me.btnSettings.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.setting_lines
        Me.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSettings.Location = New System.Drawing.Point(12, 287)
        Me.btnSettings.MinimumSize = New System.Drawing.Size(216, 55)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(216, 55)
        Me.btnSettings.TabIndex = 4
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnSuppliersContacts
        '
        Me.btnSuppliersContacts.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnSuppliersContacts.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSuppliersContacts.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnSuppliersContacts.FlatAppearance.BorderSize = 0
        Me.btnSuppliersContacts.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSuppliersContacts.ForeColor = System.Drawing.Color.Black
        Me.btnSuppliersContacts.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.contact
        Me.btnSuppliersContacts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSuppliersContacts.Location = New System.Drawing.Point(12, 232)
        Me.btnSuppliersContacts.MinimumSize = New System.Drawing.Size(216, 55)
        Me.btnSuppliersContacts.Name = "btnSuppliersContacts"
        Me.btnSuppliersContacts.Size = New System.Drawing.Size(216, 55)
        Me.btnSuppliersContacts.TabIndex = 3
        Me.btnSuppliersContacts.Text = "Supplier's Contacts"
        Me.btnSuppliersContacts.UseVisualStyleBackColor = False
        '
        'btnManage
        '
        Me.btnManage.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnManage.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnManage.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnManage.FlatAppearance.BorderSize = 0
        Me.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManage.ForeColor = System.Drawing.Color.Black
        Me.btnManage.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.inventory
        Me.btnManage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnManage.Location = New System.Drawing.Point(12, 177)
        Me.btnManage.MinimumSize = New System.Drawing.Size(216, 55)
        Me.btnManage.Name = "btnManage"
        Me.btnManage.Size = New System.Drawing.Size(216, 55)
        Me.btnManage.TabIndex = 3
        Me.btnManage.Text = "Manage Inventory"
        Me.btnManage.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnHome.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHome.ForeColor = System.Drawing.Color.Black
        Me.btnHome.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.log_file_format
        Me.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHome.Location = New System.Drawing.Point(12, 122)
        Me.btnHome.MinimumSize = New System.Drawing.Size(216, 55)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(216, 55)
        Me.btnHome.TabIndex = 0
        Me.btnHome.Text = "Logs"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnTodaysLog
        '
        Me.btnTodaysLog.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnTodaysLog.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnTodaysLog.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnTodaysLog.FlatAppearance.BorderSize = 0
        Me.btnTodaysLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTodaysLog.ForeColor = System.Drawing.Color.Black
        Me.btnTodaysLog.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.only_today
        Me.btnTodaysLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodaysLog.Location = New System.Drawing.Point(12, 67)
        Me.btnTodaysLog.MinimumSize = New System.Drawing.Size(216, 55)
        Me.btnTodaysLog.Name = "btnTodaysLog"
        Me.btnTodaysLog.Size = New System.Drawing.Size(216, 55)
        Me.btnTodaysLog.TabIndex = 1
        Me.btnTodaysLog.Text = "Today's Log"
        Me.btnTodaysLog.UseVisualStyleBackColor = False
        '
        'btnSalesInfo
        '
        Me.btnSalesInfo.BackColor = System.Drawing.Color.MediumTurquoise
        Me.btnSalesInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSalesInfo.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.btnSalesInfo.FlatAppearance.BorderSize = 0
        Me.btnSalesInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalesInfo.ForeColor = System.Drawing.Color.Black
        Me.btnSalesInfo.Image = Global.JonJan_Poultry_Supply.My.Resources.Resources.monitor__2_
        Me.btnSalesInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalesInfo.Location = New System.Drawing.Point(12, 12)
        Me.btnSalesInfo.MinimumSize = New System.Drawing.Size(216, 55)
        Me.btnSalesInfo.Name = "btnSalesInfo"
        Me.btnSalesInfo.Size = New System.Drawing.Size(216, 55)
        Me.btnSalesInfo.TabIndex = 4
        Me.btnSalesInfo.Text = "Dashboard"
        Me.btnSalesInfo.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(240, 282)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.JonJan_Poultry_Supply.My.Resources.Resources.logo_blue
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(10, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(220, 222)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.JonJan_Poultry_Supply.My.Resources.Resources.home__2_
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1435, 713)
        Me.Controls.Add(Me.pnlChildForm)
        Me.Controls.Add(Me.pnlSideBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1451, 752)
        Me.MinimumSize = New System.Drawing.Size(1451, 752)
        Me.Name = "frmMain"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JonJan Poultry Supplies"
        Me.pnlSideBar.ResumeLayout(False)
        Me.pnlBtn.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSideBar As Panel
    Friend WithEvents pnlBtn As Panel
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnSuppliersContacts As Button
    Friend WithEvents btnSalesInfo As Button
    Friend WithEvents btnTodaysLog As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnlChildForm As Panel
    Friend WithEvents btnLogOut As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnManage As Button
    Friend WithEvents btnChangePass As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
