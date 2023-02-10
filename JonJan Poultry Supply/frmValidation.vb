Imports System.Data.OleDb
Public Class frmValidation
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Public condition As String

    Private Sub frmValidation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Dim user As String
        With frmMain
            user = .username
        End With
        If condition = "client" Then

            cn.Open()
            cm = New OleDbCommand("SELECT Password FROM tblAccounts WHERE Username = '" & user & "' AND Password = '" & TextBox1.Text & "'", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                cm = New OleDbCommand("UPDATE [tblAccounts] SET [Password] = @PassChange WHERE Position = 'Client'", cn)
                With cm
                    .Parameters.AddWithValue("@PassChange", "client123")
                    .ExecuteNonQuery()
                End With
                cn.Close()
                MsgBox("Passwords set to client123")
                TextBox1.Text = ""
                Me.Close()
                With frmMain
                    .openChildForm(New frmSettings())
                End With
            Else
                MsgBox("Wrong Password! Try Again")
                TextBox1.Text = ""
                cn.Close()

            End If
        ElseIf condition = "all" Then
            cn.Open()
            cm = New OleDbCommand("SELECT Password FROM tblAccounts WHERE Username = '" & user & "' AND Password = '" & TextBox1.Text & "'", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                cn.Open()
                cm = New OleDbCommand("UPDATE [tblAccounts] SET [Password] = @PassChange WHERE Position = 'Client'", cn)
                With cm
                    .Parameters.AddWithValue("@PassChange", "client123")
                    .ExecuteNonQuery()
                End With
                cn.Close()

                cn.Open()
                cm = New OleDbCommand("UPDATE [tblAccounts] SET [Password] = @PassChange WHERE ID = 'MAINADMINISTRATOR'", cn)
                With cm
                    .Parameters.AddWithValue("@PassChange", "admin123")
                    .ExecuteNonQuery()
                End With

                MsgBox("All passwords are set to default")
                TextBox1.Text = ""
                Me.Close()

                cn.Close()
                With frmMain
                    .openChildForm(New frmSettings())
                End With

            Else
                MsgBox("Wrong Password! Try Again")
                TextBox1.Text = ""
                cn.Close()

            End If
        ElseIf condition = "allclient" Then
            cn.Open()
            cm = New OleDbCommand("SELECT Password FROM tblAccounts WHERE Username = '" & user & "' AND Password = '" & TextBox1.Text & "'", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                cn.Close()
                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblAccounts WHERE Position LIKE '%client%'", cn)
                cm.ExecuteNonQuery()
                MsgBox("All clients account has been successfully removed in our database", vbInformation + vbOKOnly, "Message Prompt")
                cn.Close()
                TextBox1.Text = ""
                Me.Close()

                With frmMain
                    .openChildForm(New frmSettings())
                End With

            Else
                MsgBox("Wrong Password! Try Again")
                TextBox1.Text = ""
                cn.Close()
            End If

        ElseIf condition = "deleteall" Then
            cn.Close()
            cn.Open()
            cm = New OleDbCommand("SELECT Password FROM tblAccounts WHERE Username = '" & user & "' AND Password = '" & TextBox1.Text & "'", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                cn.Close()
                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblHome", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblManageInventory", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblReport", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblSoldOverStocks", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblSum", cn)
                cm.ExecuteNonQuery()
                cn.Close()

                MsgBox("All Product Information has been successfully deleted to the system!")
                TextBox1.Text = ""
                Me.Close()

                With frmMain
                    .openChildForm(New frmSettings())
                End With

            Else
                MsgBox("Wrong Password! Try Again")
                TextBox1.Text = ""
                cn.Close()
            End If



        End If


    End Sub
End Class