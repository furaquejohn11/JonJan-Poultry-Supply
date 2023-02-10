Imports System.Data.OleDb
Public Class frmHome
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public isUpdate As Boolean
    Public bool As Boolean
    Public search As String

    Public currentUser As String

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'System connection to the database
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        LoadProductData()
        dateOrder()
        bool = True
        dtpDay.Enabled = False
        dtpMonth.Enabled = False
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        frmAddDate.ShowDialog()
    End Sub
    Private Sub LoadProductData()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        cn.Open()

        Dim i As Integer
        dgvHome.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblHome", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dgvHome.Rows.Add(i, dr.Item("colDate").ToString, dr.Item("colClientsUsername").ToString, dr.Item("colClientsNAME").ToString, dr.Item("colLastUpdatedOn").ToString, dr.Item("colLastUpdatedBy").ToString,
                             "MANAGE", "DELETE")
        End While
        dr.Close()
        cn.Close()
        userIdentity()

        If currentUser <> "admin" Then
            colDelete.Visible = False
        End If
        dgvHome.Sort(dgvHome.Columns("colDate"), System.ComponentModel.ListSortDirection.Ascending)
        dtpDay.Enabled = False
        dtpMonth.Enabled = False

    End Sub

    Private Sub dgvHome_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHome.CellContentClick
        Dim colname As String = dgvHome.Columns(e.ColumnIndex).Name


        'Functions where the user will direct to the manage products page
        'Sending information of row cell 1 and 2 to the textbox in manage products form
        If colname = "colManageProducts" Then

            If dgvHome.Rows(e.RowIndex).Cells(1).Value.ToString = DateTime.Now.ToString("yyyy-MM-dd: dddd") Then
                With frmMain

                End With
            End If

            Dim formManageProducts As New frmManageProducts
            formManageProducts = frmManageProducts

            formManageProducts.curDate.Text = dgvHome.Rows(e.RowIndex).Cells(1).Value.ToString
            'formManageProducts.curUser.Text = dgvHome.Rows(e.RowIndex).Cells(2).Value.ToString

            formManageProducts.setDate = dgvHome.Rows(e.RowIndex).Cells(1).Value.ToString
            formManageProducts.setUser = dgvHome.Rows(e.RowIndex).Cells(2).Value.ToString
            'frmManageProducts.ShowDialog()

            With frmMain
                .openChildForm(formManageProducts)
            End With


            'Function where the user will delete the selected data
        ElseIf colname = "colDelete" Then
            Dim currentDateID As String


            'The deletion of the data will start on cell 1 so the cell must contain unique phrases
            currentDateID = dgvHome.Rows(e.RowIndex).Cells(1).Value.ToString


            If MsgBox("Are you sure you want to delete this product?" & vbNewLine & "NOTE: This will be permanently removed to our database",
        vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblHome WHERE colDate = '" & dgvHome.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                cm.ExecuteNonQuery()
                MsgBox("Selected product have successfully removed in our database", vbInformation + vbOKOnly, "Message Prompt")
                isUpdate = True


                'Function where the information of the selected data will deleted too
                If isUpdate = True Then

                    cm = New OleDbCommand("DELETE FROM tblManageProducts WHERE colDate like '" & currentDateID & "'", cn)
                    cm.ExecuteNonQuery()

                    cn.Close()


                End If

                If isUpdate = True Then

                    cn.Open()

                    cm = New OleDbCommand("DELETE FROM tblSalesInformation WHERE colDate like '" & currentDateID & "'", cn)
                    cm.ExecuteNonQuery()

                    cn.Close()

                    cn.Open()

                    cm = New OleDbCommand("DELETE FROM tblReport WHERE colID like '" & currentDateID & "'", cn)
                    cm.ExecuteNonQuery()

                    cn.Close()


                    LoadProductData()

                End If
            End If
        End If
    End Sub

    Public Sub dateOrder()

        'Sub where the data in the table will set into ascending listing
        dgvHome.Sort(dgvHome.Columns("colDate"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Public Sub userIdentity()
        With frmMain
            currentUser = .currentUser
        End With

    End Sub
    Private Sub txtSearchBar_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBar.TextChanged

        If bool = True Then
            cn.Open()
            dgvHome.Rows.Clear()

            cm = New OleDbCommand("SELECT * FROM tblHome WHERE colClientsName LIKE '%" + txtSearchBar.Text + "%'", cn)
            dr = cm.ExecuteReader
            Dim i As Integer
            While dr.Read
                i += 1
                dgvHome.Rows.Add(i, dr.Item("colDate").ToString, dr.Item("colClientsUsername").ToString, dr.Item("colClientsNAME").ToString, dr.Item("colLastUpdatedOn").ToString, dr.Item("colLastUpdatedBy").ToString,
                             "MANAGE", "DELETE")
            End While

            dr.Close()
            cn.Close()
            dgvHome.Sort(dgvHome.Columns("colDate"), System.ComponentModel.ListSortDirection.Ascending)

        End If

    End Sub

    Private Sub cbDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbDate.CheckedChanged
        If cbDate.CheckState = CheckState.Checked Then
            cbMonth.CheckState = CheckState.Unchecked
            bool = False
            txtSearchBar.Text = ""
            dtpDay.Enabled = True
            dtpMonth.Enabled = False

            search = Format(dtpDay.Value, "yyyy-MM-dd: dddd")
            searchDay()
        Else
            bool = True
            LoadProductData()

        End If
    End Sub

    Private Sub txtSearchBar_Click(sender As Object, e As EventArgs) Handles txtSearchBar.Click
        bool = True
        LoadProductData()
        cbDate.CheckState = CheckState.Unchecked
        cbMonth.CheckState = CheckState.Unchecked
        dtpDay.Enabled = False
        dtpMonth.Enabled = False

    End Sub

    Private Sub dtpDay_ValueChanged(sender As Object, e As EventArgs) Handles dtpDay.ValueChanged
        search = Format(dtpDay.Value, "yyyy-MM-dd: dddd")
        searchDay()
    End Sub
    Private Sub searchDay()
        cn.Open()
        dgvHome.Rows.Clear()
        cm = New OleDbCommand("SELECT * FROM tblHome WHERE colDate LIKE '%" + search + "%'", cn)
        dr = cm.ExecuteReader
        Dim i As Integer
        While dr.Read
            i += 1
            dgvHome.Rows.Add(i, dr.Item("colDate").ToString, dr.Item("colClientsUsername").ToString, dr.Item("colClientsNAME").ToString, dr.Item("colLastUpdatedOn").ToString, dr.Item("colLastUpdatedBy").ToString,
                         "MANAGE", "DELETE")
        End While

        dr.Close()
        cn.Close()
    End Sub

    Private Sub cbMonth_CheckedChanged(sender As Object, e As EventArgs) Handles cbMonth.CheckedChanged
        If cbMonth.CheckState = CheckState.Checked Then
            cbDate.CheckState = CheckState.Unchecked
            bool = False
            txtSearchBar.Text = ""
            dtpDay.Enabled = False
            dtpMonth.Enabled = True

            search = Format(dtpMonth.Value, "yyyy-MM")
            searchDay()
        Else
            bool = True
            LoadProductData()

        End If
    End Sub

    Private Sub dtpMonth_ValueChanged(sender As Object, e As EventArgs) Handles dtpMonth.ValueChanged
        search = Format(dtpMonth.Value, "yyyy-MM")
        searchDay()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class