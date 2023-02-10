Imports System.Data.OleDb
Public Class frmAddAccount
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public id As String
    Public bool As Boolean

    Private Sub frmAddAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text = "" Or txtPass.Text = "" Or txtPass.Text = "" Then
            MsgBox("Please supply required fields", vbCritical + vbOKOnly, "Message Prompt")
            Return
        End If
        Dim datePicker As String
        If bool = True Then
            datePicker = DateTime.Now.ToString("yyyy-MM-dd: HH:mm")

            cn.Open()
            cm = New OleDbCommand("INSERT INTO tblAccounts (colID, [position], ClientsName, username, [password]) VALUES(@colID,[@position], @ClientsName, @username, [@eepassword])", cn)
            With cm
                .Parameters.AddWithValue("@colID", datePicker)
                .Parameters.AddWithValue("[@position]", "client")
                .Parameters.AddWithValue("@ClientsName", txtName.Text)
                .Parameters.AddWithValue("@username", txtUser.Text)
                .Parameters.AddWithValue("[@eepassword]", txtPass.Text)

                .ExecuteNonQuery()
            End With
            txtName.Text = ""
            txtPass.Text = ""
            txtUser.Text = ""
            cn.Close()



            MsgBox("New client has been successfully added to the system!")
            Me.Close()
            With frmMain
                .openChildForm(New frmSettings())
            End With
        Else
            cn.Open()
            cm = New OleDbCommand("UPDATE tblAccounts SET ClientsName = @ClientsName, username = @username, [password] = [@eepassword] WHERE colID = '" & id & "'", cn)

            With cm
                .Parameters.AddWithValue("@ClientsName", txtName.Text)
                .Parameters.AddWithValue("@username", txtUser.Text)
                .Parameters.AddWithValue("[@eepassword]", txtPass.Text)

                .ExecuteNonQuery()
            End With
            cn.Close()


            MsgBox("Selected client has been successfully updated to our database", vbInformation + vbOKOnly, "Message Prompt")


            txtName.Text = ""
            txtPass.Text = ""
            txtUser.Text = ""
            Me.Close()
            With frmMain
                .openChildForm(New frmSettings())
            End With
        End If
    End Sub
End Class