Imports System.Data.OleDb
Public Class frmSuppliersContact
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addcontact As New frmAddSupplier
        addcontact = frmAddSupplier
        addcontact.bool = True
        addcontact.ShowDialog()

    End Sub

    Private Sub frmSuppliersContact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        LoadNow()

    End Sub

    Private Sub dgvContact_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContact.CellContentClick
        Dim colname As String = dgvContact.Columns(e.ColumnIndex).Name
        If colname = "Edit" Then
            Dim addcontact As New frmAddSupplier
            addcontact = frmAddSupplier
            With addcontact
                .bool = False
                .ID = dgvContact.Rows(e.RowIndex).Cells(1).Value.ToString
                .txtName.Text = dgvContact.Rows(e.RowIndex).Cells(2).Value.ToString
                .txtAddress.Text = dgvContact.Rows(e.RowIndex).Cells(3).Value.ToString
                .txtNumber.Text = dgvContact.Rows(e.RowIndex).Cells(4).Value.ToString
                .txtProduct.Text = dgvContact.Rows(e.RowIndex).Cells(5).Value.ToString
                .ShowDialog()
            End With
        ElseIf colname = "Column4" Then
            Clipboard.SetText(dgvContact.Rows(e.RowIndex).Cells(4).Value.ToString)
            MsgBox("Copied to Clipboard!")
        ElseIf colname = "Delete" Then
            If MsgBox("Are you sure you want to delete this product?" & vbNewLine & "NOTE: This will be permanently removed to our database",
            vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblContacts WHERE ID = '" & dgvContact.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                cm.ExecuteNonQuery()
                MsgBox("Selected product have successfully removed in our database", vbInformation + vbOKOnly, "Message Prompt")
                cn.Close()

                LoadNow()

            End If

        End If
    End Sub
    Public Sub LoadNow()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        cn.Open()
        dgvContact.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblContacts", cn)
        dr = cm.ExecuteReader
        Dim i As Integer
        While dr.Read
            i += 1
            dgvContact.Rows.Add(i, dr.Item("ID").ToString, dr.Item("_Name").ToString,
                                      dr.Item("Address").ToString, dr.Item("Contact").ToString,
                                      dr.Item("Product").ToString, "EDIT", "DELETE")
        End While
        dr.Close()
        cn.Close()

        With frmMain
            If .position <> "main-admin" Then
                Delete.Visible = False
            End If
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtSearchBar_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBar.TextChanged
        cn.Open()
        dgvContact.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM [tblContacts] WHERE [_Name] LIKE '%" + txtSearchBar.Text + "%'", cn)
        dr = cm.ExecuteReader
        Dim i As Integer
        While dr.Read
            i += 1
            dgvContact.Rows.Add(i, dr.Item("ID").ToString, dr.Item("_Name").ToString,
                                      dr.Item("Address").ToString, dr.Item("Contact").ToString,
                                      dr.Item("Product").ToString, "EDIT", "DELETE")
        End While

        dr.Close()
        cn.Close()
        dgvContact.Sort(dgvContact.Columns("Column2"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
End Class