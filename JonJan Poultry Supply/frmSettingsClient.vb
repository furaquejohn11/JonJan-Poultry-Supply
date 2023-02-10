Imports System.Data.OleDb
Public Class frmSettingsClient
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public username, id As String
    Private Sub frmSettingsClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
    End Sub
    Private Sub ChangePass()
        If txtCurrent.Text = "" Or txtNew.Text = "" Or txtPass.Text = "" Then
            MsgBox("Please supply required fields", vbCritical + vbOKOnly, "Message Prompt")
            Return
        End If
        cn.Open()
        cm = New OleDbCommand("SELECT Password FROM tblAccounts WHERE Username = '" & username & "' AND Password = '" & txtCurrent.Text & "'", cn)
        dr = cm.ExecuteReader
        If dr.Read = True Then
            With frmMain
                id = .id
            End With

            If txtNew.Text = txtPass.Text Then

                If cn.State = ConnectionState.Open Then
                    cn.Close()

                    cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
                    cn.Open()

                    cm = New OleDbCommand("UPDATE [tblAccounts] SET [Password] = @PassChange WHERE colID = '" & id & "'", cn)
                    With cm
                        .Parameters.AddWithValue("@PassChange", txtPass.Text)
                        .ExecuteNonQuery()
                    End With
                    cn.Close()
                    MsgBox("Password has successfully changed!")
                    txtCurrent.Text = ""
                    txtPass.Text = ""
                    txtNew.Text = ""
                End If
            Else
                MsgBox("Password Mismatched!")
            End If
        Else
            MsgBox("Wrong Password")
        End If

        cn.Close()
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ChangePass()
    End Sub
End Class