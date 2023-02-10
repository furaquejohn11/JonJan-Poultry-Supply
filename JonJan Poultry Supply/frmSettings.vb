Imports System.Data.OleDb
Public Class frmSettings
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        LoadNow()


    End Sub
    Private Sub LoadNow()
        cn.Open()
        dgvClient.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblAccounts WHERE [Position] LIKE '%client%'", cn)
        dr = cm.ExecuteReader
        Dim i As Integer
        While dr.Read
            i += 1
            dgvClient.Rows.Add(i, dr.Item("colID"), dr.Item("ClientsName").ToString, dr.Item("Username").ToString, dr.Item("Password").ToString, "EDIT", "DELETE")
        End While

        dr.Close()
        cn.Close()
    End Sub
    Private Sub SearchNow()
        cn.Open()
        dgvClient.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblAccounts WHERE ClientsName LIKE '%" + txtSearchBar.Text + "%' AND [Position] LIKE '%client%'", cn)
        dr = cm.ExecuteReader
        Dim i As Integer
        While dr.Read
            i += 1
            dgvClient.Rows.Add(i, dr.Item("colID"), dr.Item("ClientsName").ToString, dr.Item("Username").ToString, dr.Item("Password").ToString, "EDIT", "DELETE")
        End While

        dr.Close()
        cn.Close()
    End Sub

    Private Sub txtSearchBar_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBar.TextChanged
        SearchNow()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        cn.Open()
        cm = New OleDbCommand("SELECT Password FROM tblAccounts WHERE Username = 'admin' AND Password = '" & txtOld.Text & "'", cn)
        dr = cm.ExecuteReader
        If dr.Read = True Then
            If cn.State = ConnectionState.Open Then
                cn.Close()

                cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
            cn.Open()

                cm = New OleDbCommand("UPDATE [tblAccounts] SET [Password] = @PassChange WHERE colID = 'MAINADMINISTRATOR'", cn)
                With cm
                    .Parameters.AddWithValue("@PassChange", txtPN.Text)
                    .ExecuteNonQuery()
            End With
            cn.Close()
                MsgBox("Password has successfully changed to: " + txtPN.Text + "!")
                LoadNow()
                txtOld.Text = ""
                txtPN.Text = ""
            End if
            Else
            MsgBox("Wrong Password")
        End If
        cn.Close()
    End Sub

    Private Sub btnClientDefault_Click(sender As Object, e As EventArgs) Handles btnClientDefault.Click
        If MsgBox("Are you sure you want to set the Password into default?",
        vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
            With frmValidation
                .condition = "client"
            End With
            frmValidation.ShowDialog()
        End If

    End Sub

    Private Sub btnAllDefault_Click(sender As Object, e As EventArgs) Handles btnAllDefault.Click
        If MsgBox("Are you sure you want to set the Password into default?",
        vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
            With frmValidation
                .condition = "all"

            End With
            frmValidation.ShowDialog()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frmAddAccount.bool = True
        frmAddAccount.ShowDialog()
    End Sub

    Private Sub dgvClient_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvClient.CellContentClick
        Dim colname As String = dgvClient.Columns(e.ColumnIndex).Name

        If colname = "edit" Then
            With frmAddAccount
                .bool = False
                .id = dgvClient.Rows(e.RowIndex).Cells(1).Value.ToString
                .txtName.Text = dgvClient.Rows(e.RowIndex).Cells(2).Value.ToString
                .txtUser.Text = dgvClient.Rows(e.RowIndex).Cells(3).Value.ToString
                .txtPass.Text = dgvClient.Rows(e.RowIndex).Cells(4).Value.ToString
                .ShowDialog()
            End With
        ElseIf colname = "delete" Then
            If MsgBox("Are you sure you want to delete this product?" & vbNewLine & "NOTE: This will be permanently removed to our database",
            vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblAccounts WHERE colID = '" & dgvClient.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                cm.ExecuteNonQuery()
                MsgBox("Selected account has been successfully removed in our database", vbInformation + vbOKOnly, "Message Prompt")
                cn.Close()
                LoadNow()

            End If
        End If
    End Sub

    Private Sub btnDLTC_Click(sender As Object, e As EventArgs) Handles btnDLTC.Click
        If MsgBox("Are you sure you want to delete all Client's Account?",
        vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
            With frmValidation
                .condition = "allclient"

            End With
            frmValidation.ShowDialog()
        End If
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click
        If MsgBox("Are you sure you want to delete all Client's Account?",
        vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
            With frmValidation
                .condition = "deleteall"

            End With
            frmValidation.ShowDialog()
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Try
            'set the destination and a file name with the date and time
            Dim backupfiledestination As String = Application.StartupPath & "\BackupSys\backupdbs" & "-" & Format(Now(), "yyyy-MM-dd HH-mm-ss") & "-" & "jjpsdatabase.accdb"
            'location of the database file that you want to backup
            Dim databaseFile As String = Application.StartupPath & "\BackupSys\backupdbs.accdb"

            'create a backup by using Filecopy Command to copy the file from  location to destination
            FileCopy(databaseFile, backupfiledestination)
            MsgBox("Database Backup has been Created Successfully!")
        Catch ex As Exception
            'catch an error  
            MsgBox(ex.Message)

        End Try
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Try
            'set a your database file
            Dim restorefile As String = Application.StartupPath & "\jjpsdatabase.accdb"
            'declare a variable for storing the text message.
            Dim msgText As String
            'filtering the file
            OpenFileDialog1.Filter = "Access | *.accdb"
            'open the file directory
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                'set a text message
                msgText = "Are you sure you want to restore your database? It will overwite your database since the backup have made."
                'validate if you want to restore or not
                If MessageBox.Show(msgText, "Restore", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
                    'restore your database
                    FileCopy(OpenFileDialog1.FileName, restorefile)
                    MsgBox("Database has been restore")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class