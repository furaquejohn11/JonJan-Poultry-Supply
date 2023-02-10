Imports System.Data.OleDb
Public Class frmMain
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public currentUser As String
    Public username, password, clientName, position, id As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        openChildForm(New frmSalesInfo())
        customBtn()

        Dim b, good As String
        b = DateTime.Now.ToString("HH")

        If CInt(b) < 12 Then
            good = "Good Morning, "
        ElseIf CInt(b) >= 18 Then
            good = "Good Evening, "
        Else
            good = "Good Afternoon, "

        End If
        btnEnableBack(btnSalesInfo)
        Dim arrLines() As String
        arrLines = clientName.Split(New Char() {" "c})
        'now if you need to get the first line
        Label1.Text = good + (arrLines(0)) + "!"

        With frmManageInventory
            .totalSoldQTY()
        End With

    End Sub
    Private Sub btnEnable()
        btnHome.Enabled = True
        btnHome.BackColor = Color.MediumTurquoise
        btnSalesInfo.Enabled = True
        btnSalesInfo.BackColor = Color.MediumTurquoise
        btnSuppliersContacts.Enabled = True
        btnSuppliersContacts.BackColor = Color.MediumTurquoise
        btnManage.Enabled = True
        btnManage.BackColor = Color.MediumTurquoise
        btnSettings.Enabled = True
        btnSettings.BackColor = Color.MediumTurquoise
        btnTodaysLog.Enabled = True
        btnTodaysLog.BackColor = Color.MediumTurquoise
        btnLogOut.Enabled = True
        btnLogOut.BackColor = Color.MediumTurquoise
        btnChangePass.Enabled = True
        btnChangePass.BackColor = Color.MediumTurquoise
    End Sub
    Private Sub btnEnableBack(btnBack As Button) 'set button to disable and change its color to green
        If btnBack.Enabled = True Then
            btnEnable()

            btnBack.BackColor = Color.FromArgb(49, 130, 127)

        Else

            btnBack.BackColor = Color.MediumTurquoise

        End If

    End Sub
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            frmLoading.Close() 'Name of the first form
        End If

    End Sub


    'Sub for displaying selected form into the child form panel
    Public currentForm As Form = Nothing
    Public Sub openChildForm(childForm As Form)
        Try
            If currentForm IsNot Nothing Then currentForm.Close()
            currentForm = childForm
            childForm.TopLevel = False
            childForm.FormBorderStyle = False
            childForm.Dock = DockStyle.Fill
            pnlChildForm.Controls.Add(childForm)
            pnlChildForm.Tag = childForm
            childForm.BringToFront()
            childForm.Show()

        Catch ex As Exception
            todayslog()

        End Try

    End Sub

    Public Sub reloadHome()
        openChildForm(New frmHome())

    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        openChildForm(New frmHome())
        btnEnableBack(btnHome)
    End Sub

    Private Sub btnSalesInfo_Click(sender As Object, e As EventArgs) Handles btnSalesInfo.Click
        openChildForm(New frmSalesInfo())
        btnEnableBack(btnSalesInfo)
    End Sub

    Private Sub btnSuppliersContacts_Click(sender As Object, e As EventArgs) Handles btnSuppliersContacts.Click
        openChildForm(New frmSuppliersContact())
        btnEnableBack(btnSuppliersContacts)
    End Sub
    Private Sub btnManage_Click(sender As Object, e As EventArgs) Handles btnManage.Click
        openChildForm(New frmManageInventory())
        btnEnableBack(btnManage)
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        openChildForm(New frmSettings())
        btnEnableBack(btnSettings)

    End Sub
    Private Sub btnTodaysLog_Click(sender As Object, e As EventArgs) Handles btnTodaysLog.Click
        todayslog()
        btnEnableBack(btnTodaysLog)
    End Sub
    Private Sub btnMenu_Click(sender As Object, e As EventArgs)
        'If pnlSideBar.Width = 240 Then
        'imer2.Enabled = True
        ' ElseIf pnlSideBar.Width = 60 Then
        ' Timer1.Enabled = True
        ' End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DoubleBuffered = True
        If pnlSideBar.Width >= 240 Then
            Me.Timer1.Enabled = False
            pnlBtn.Visible = True
            pnlSideBar.BackgroundImage = My.Resources.ResourceManager.GetObject("bg")
        Else
            Me.pnlSideBar.Width = pnlSideBar.Width + 30
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        DoubleBuffered = True
        If pnlSideBar.Width <= 60 Then
            Me.Timer2.Enabled = False
            pnlBtn.Visible = False
            pnlSideBar.BackgroundImage = Nothing
            pnlSideBar.BackColor = Color.Transparent
        Else
            Me.pnlSideBar.Width = pnlSideBar.Width - 30
        End If
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        btnEnableBack(btnLogOut)
        If MsgBox("Are you sure you want to Log Out?",
        vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
            frmLoading.Close() 'Name of the first form
        End If
    End Sub


    Private Sub pnlChildForm_Paint(sender As Object, e As PaintEventArgs) Handles pnlChildForm.Paint

    End Sub

    Private Sub customBtn()
        If currentUser = "admin" Then
            btnSettings.Visible = True
            btnChangePass.Visible = False
        Else
            btnSettings.Visible = False
            btnChangePass.Visible = True
        End If
    End Sub

    Private Sub btnChangePass_Click(sender As Object, e As EventArgs) Handles btnChangePass.Click
        btnEnableBack(btnChangePass)
        With frmSettingsClient
            .txtCurrent.Text = ""
            .txtPass.Text = ""
            .txtNew.Text = ""
            .username = username
        End With
        frmSettingsClient.ShowDialog()

    End Sub

    Public Sub todayslog()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Dim formManageProducts As New frmManageProducts
        formManageProducts = frmManageProducts
        formManageProducts.curDate.Text = DateTime.Now.ToString("yyyy-MM-dd: dddd")
        formManageProducts.setDate = DateTime.Now.ToString("yyyy-MM-dd: dddd")
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"

        cn.Open()
        cm = New OleDbCommand("SELECT colDate From tblHome WHERE colDate = '" & DateTime.Now.ToString("yyyy-MM-dd: dddd") & "'", cn)
        dr = cm.ExecuteReader
        If dr.Read = True Then
            openChildForm(formManageProducts)
        Else
            MsgBox("No created report for Today's Date! Please Create one on Logs to proceed.", vbCritical + vbOKOnly, "Message Prompt")

        End If
        cn.Close()

    End Sub


End Class
