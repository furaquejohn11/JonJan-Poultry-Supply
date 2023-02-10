Imports System.Data.OleDb
Public Class frmManageInventory
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public isUpdate As Boolean
    Public currentUser As String
    Private Sub frmManageInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        manage()
        totalSoldQTY()
        cbAll.CheckState = CheckState.Checked

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        frmAddProduct.ShowDialog()
    End Sub
    Public Sub manage()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        dgvInventory.Rows.Clear()

        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        cn.Open()
        Dim i As Integer
        cm = New OleDbCommand("SELECT * FROM tblManageInventory", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dgvInventory.Rows.Add(i, dr.Item("colID"), dr.Item("Status").ToString, dr.Item("ProductsName").ToString,
                                      Format(dr.Item("ProductsCapital"), "#,##0.00").ToString, Format(dr.Item("ProductsPricePerQTY"), "#,##0.00").ToString,
                                      dr.Item("ProductsTotalQTY").ToString, dr.Item("ProductsTotalSoldQTY").ToString,
                                      dr.Item("ProductsRemainingQTY").ToString,
                                      Format(dr.Item("ProductsEarned"), "#,##0.00").ToString, "EDIT", "DELETE")
        End While

        dr.Close()
        cn.Close()

        dgvInventory.Sort(dgvInventory.Columns("Column2"), System.ComponentModel.ListSortDirection.Ascending)

        Dim currentUser As String
        With frmMain
            currentUser = .currentUser
        End With

        If currentUser <> "admin" Then
            colDelete.Visible = False
        End If


        totalSoldQTY()


    End Sub

    Private Sub dgvInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellContentClick
        Dim colname As String = dgvInventory.Columns(e.ColumnIndex).Name

        If colname = "colEdit" Then

            With frmEdit1
                .statusLabel.Text = "Current Status: " + dgvInventory.Rows(e.RowIndex).Cells(2).Value.ToString
                .colID = dgvInventory.Rows(e.RowIndex).Cells(1).Value.ToString
                .txtPN.Text = dgvInventory.Rows(e.RowIndex).Cells(3).Value.ToString 'cell prod name
                .txtPC.Text = dgvInventory.Rows(e.RowIndex).Cells(4).Value.ToString 'cell prod capital
                .txtIPC.Text = ""
                .txtPPQ.Text = dgvInventory.Rows(e.RowIndex).Cells(5).Value.ToString 'cell price per quantity
                .txtIPPQ.Text = ""
                .txtPTQ.Text = dgvInventory.Rows(e.RowIndex).Cells(6).Value.ToString 'cell total quantity
                .txtIPTQ.Text = ""
            End With
            frmEdit1.ShowDialog()


        ElseIf colname = "colDelete" Then
            If MsgBox("Are you sure you want to delete this product?" & vbNewLine & "NOTE: This will be permanently removed to our database",
            vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblManageInventory WHERE colID = '" & dgvInventory.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                cm.ExecuteNonQuery()
                MsgBox("Selected product have successfully removed in our database", vbInformation + vbOKOnly, "Message Prompt")
                cn.Close()

                manage()

            End If
        End If

    End Sub
    Public Sub totalSoldQTY()

        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
            'GETTING THE SUM OF THE TABLES
            Dim value1, value2, val1, val2 As Double
            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsTotalQTY) AS ProductsTotalQTY from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                value1 = dr.Item("ProductsTotalQTY")
            End If
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("UPDATE tblSoldOverStocks set QTY = @QTY WHERE colID = 'Total Number'", cn)

            With cm
                .Parameters.AddWithValue("@QTY", value1)
                .ExecuteNonQuery()
            End With
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsTotalSoldQTY) AS ProductsTotalSoldQTY from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then

                value2 = Format(dr.Item("ProductsTotalSoldQTY"), "#,##0.00")
            End If
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("UPDATE tblSoldOverStocks set QTY = @QTY WHERE colID = 'Total Sold'", cn)

            With cm
                .Parameters.AddWithValue("@QTY", value2)
                .ExecuteNonQuery()
            End With
            cn.Close()



            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsCapital) AS ProductsCapital from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                val1 = dr.Item("ProductsCapital")
            End If
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("UPDATE tblSoldOverStocks set Pricing = @Pricing WHERE colID = 'Total Number'", cn)

            With cm
                .Parameters.AddWithValue("@Pricing", val1)
                .ExecuteNonQuery()
            End With
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsEarned) AS ProductsEarned from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                val2 = dr.Item("ProductsEarned")
            End If
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("UPDATE tblSoldOverStocks set Pricing = @Pricing WHERE colID = 'Total Sold'", cn)

            With cm
                .Parameters.AddWithValue("@Pricing", val2)
                .ExecuteNonQuery()
            End With
            cn.Close()
        Catch ex As Exception

        End Try


    End Sub


    Private Sub txtSearchBar_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBar.TextChanged
        searchFunction()
    End Sub
    Private Sub searchFunction()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Dim i As Integer
        If txtSearchBar.Text <> "" Then

            If cbAll.CheckState = CheckState.Checked Then
                checkAll()
            ElseIf cbInstock.CheckState = CheckState.Checked Then
                checkIn()

            ElseIf cbOut.CheckState = CheckState.Checked Then
                checkOut()
            ElseIf cbInstock.CheckState = CheckState.Unchecked And cbAll.CheckState = CheckState.Unchecked And cbOut.CheckState = CheckState.Unchecked Then
                cn.Open()
                dgvInventory.Rows.Clear()

                cm = New OleDbCommand("SELECT * FROM tblManageInventory WHERE ProductsName LIKE '%" + txtSearchBar.Text + "%'", cn)
                dr = cm.ExecuteReader
                While dr.Read
                    i += 1
                    dgvInventory.Rows.Add(i, dr.Item("colID"), dr.Item("Status").ToString, dr.Item("ProductsName").ToString,
                                      Format(dr.Item("ProductsCapital"), "#,##0.00").ToString, Format(dr.Item("ProductsPricePerQTY"), "#,##0.00").ToString,
                                      dr.Item("ProductsTotalQTY").ToString, dr.Item("ProductsTotalSoldQTY").ToString,
                                      dr.Item("ProductsRemainingQTY").ToString,
                                      Format(dr.Item("ProductsEarned"), "#,##0.00").ToString, "EDIT", "DELETE")
                End While

                dr.Close()
                cn.Close()

            End If
        Else
            If txtSearchBar.Text = "" Then
                If cbAll.CheckState = CheckState.Checked Then
                    checkAll()
                ElseIf cbInstock.CheckState = CheckState.Checked Then
                    checkIn()

                ElseIf cbOut.CheckState = CheckState.Checked Then
                    checkOut()
                ElseIf cbInstock.CheckState = CheckState.Unchecked And cbAll.CheckState = CheckState.Unchecked And cbOut.CheckState = CheckState.Unchecked Then
                    manage()
                End If
            End If
        End If

    End Sub

    Private Sub checkAll()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        cbInstock.CheckState = CheckState.Unchecked
        cbOut.CheckState = CheckState.Unchecked
        Dim i As Integer
        cn.Open()
        dgvInventory.Rows.Clear()


        cm = New OleDbCommand("SELECT * FROM tblManageInventory WHERE ProductsName LIKE '%" + txtSearchBar.Text + "%'", cn)
        dr = cm.ExecuteReader
        While dr.Read
            i += 1
            dgvInventory.Rows.Add(i, dr.Item("colID"), dr.Item("Status").ToString, dr.Item("ProductsName").ToString,
                                      Format(dr.Item("ProductsCapital"), "#,##0.00").ToString, Format(dr.Item("ProductsPricePerQTY"), "#,##0.00").ToString,
                                      dr.Item("ProductsTotalQTY").ToString, dr.Item("ProductsTotalSoldQTY").ToString,
                                      dr.Item("ProductsRemainingQTY").ToString,
                                      Format(dr.Item("ProductsEarned"), "#,##0.00").ToString, "EDIT", "DELETE")
        End While

        dr.Close()
        cn.Close()
    End Sub
    Private Sub checkIn()
        cbAll.CheckState = CheckState.Unchecked
        cbOut.CheckState = CheckState.Unchecked

        Dim i As Integer
        cn.Open()
        dgvInventory.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblManageInventory WHERE ProductsName LIKE '%" + txtSearchBar.Text + "%' AND Status LIKE '%INSTOCK%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dgvInventory.Rows.Add(i, dr.Item("colID"), dr.Item("Status").ToString, dr.Item("ProductsName").ToString,
                                      Format(dr.Item("ProductsCapital"), "#,##0.00").ToString, Format(dr.Item("ProductsPricePerQTY"), "#,##0.00").ToString,
                                      dr.Item("ProductsTotalQTY").ToString, dr.Item("ProductsTotalSoldQTY").ToString,
                                      dr.Item("ProductsRemainingQTY").ToString,
                                      Format(dr.Item("ProductsEarned"), "#,##0.00").ToString, "EDIT", "DELETE")
        End While

        dr.Close()
        cn.Close()
    End Sub
    Private Sub checkOut()
        cbAll.CheckState = CheckState.Unchecked
        cbInstock.CheckState = CheckState.Unchecked
        Dim i As Integer
        cn.Open()
        dgvInventory.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblManageInventory WHERE ProductsName LIKE '%" + txtSearchBar.Text + "%' AND Status LIKE '%Out%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dgvInventory.Rows.Add(i, dr.Item("colID"), dr.Item("Status").ToString, dr.Item("ProductsName").ToString,
                                      Format(dr.Item("ProductsCapital"), "#,##0.00").ToString, Format(dr.Item("ProductsPricePerQTY"), "#,##0.00").ToString,
                                      dr.Item("ProductsTotalQTY").ToString, dr.Item("ProductsTotalSoldQTY").ToString,
                                      dr.Item("ProductsRemainingQTY").ToString,
                                      Format(dr.Item("ProductsEarned"), "#,##0.00").ToString, "EDIT", "DELETE")
        End While
        dr.Close()
        cn.Close()

    End Sub

    Private Sub cbAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbAll.CheckedChanged
        If cbAll.CheckState = CheckState.Checked Then
            checkAll()
        End If

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbInstock.CheckedChanged
        If cbInstock.CheckState = CheckState.Checked Then
            checkIn()
        Else
            manage()
        End If
    End Sub
    Private Sub cbOut_CheckedChanged(sender As Object, e As EventArgs) Handles cbOut.CheckedChanged
        If cbOut.CheckState = CheckState.Checked Then
            checkOut()
        Else
            manage()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class