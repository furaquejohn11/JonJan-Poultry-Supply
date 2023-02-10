Imports System.Data.OleDb
Public Class frmLogIn
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public isUpdate As Boolean
    Public username As String
    Public user, pass, clientName, position, id As String
    Private Sub frmLogIn_FormClosing(sender As Object, e As FormClosingEventArgs) _
        Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            frmLoading.Close()
        End If
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        LogInInfo()
    End Sub

    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
    End Sub

    Private Sub LogInInfo()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If


        cn.Open()

            cm = New OleDbCommand("SELECT * FROM tblAccounts WHERE Username = '" & txtUsername.Text & "' AND Password = '" & txtPass.Text & "'", cn)
            dr = cm.ExecuteReader


            If dr.Read = True Then

                user = dr.Item("Username")
                pass = dr.Item("Password")
                clientName = dr.Item("clientsName")
                position = dr.Item("Position")
                id = dr.Item("colID")


                If txtUsername.Text = "admin" And txtPass.Text = "admin123" Or txtPass.Text = "client123" Then
                    acc()
                    MsgBox("We highly recommend to change your password immediately because it is currently set as default", vbInformation + vbOKOnly, "Message Prompt")
                    Me.Hide()

                Else
                    acc()
                    Me.Hide()
                End If



            Else
                MsgBox("Either your username or password is incorrect. Please Try Again.", vbCritical + vbOKOnly, "Message Prompt")
                txtPass.Text = ""
                txtUsername.Select()
            End If

            dr.Close()
            cn.Close()

    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress, txtPass.KeyPress
        If Asc(e.KeyChar) = 13 Then 'ASCII of Backspace
            e.Handled = True
            LogInInfo()
        End If
    End Sub

    Private Sub acc()
        Dim formMain As New frmMain
        formMain = frmMain
        formMain.currentUser = txtUsername.Text
        formMain.username = user
        formMain.password = pass
        formMain.clientName = clientName
        formMain.position = position
        formMain.id = id
        formMain.Show()
        'formMain.WindowState = FormWindowState.Maximized
    End Sub
End Class