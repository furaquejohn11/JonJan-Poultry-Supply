Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmView
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Public isUpdate As Boolean
    Private Sub frmView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LoadSalesInfo()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        cn.Open()

        Dim i As Integer
        dgvSalesInfo.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblSalesInformation", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dgvSalesInfo.Rows.Add(i, dr.Item("colDate").ToString, dr.Item("OverallProductsQuantity").ToString, dr.Item("OverallProductsQuantitySold").ToString,
                             dr.Item("TotalQuantitySoldPercentage").ToString, dr.Item("OverallProductsCapital").ToString,
                             dr.Item("OverallProductsEarned").ToString, dr.Item("OverallProductsEarnedPercentage").ToString, "VIEW INFORMATION")
        End While
        dr.Close()
        cn.Close()
    End Sub

    Private Sub dgvSalesInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Dim colname As String = dgvSalesInfo.Columns(e.ColumnIndex).Name

        If colname = "ViewInformation" Then
            Dim formViewInformation As New frmViewInformation
            formViewInformation = frmViewInformation

            formViewInformation.curDate.Text = dgvSalesInfo.Rows(e.RowIndex).Cells(1).Value.ToString
            formViewInformation.curUser.Text = dgvSalesInfo.Rows(e.RowIndex).Cells(2).Value.ToString
            'frmManageProducts.ShowDialog()

            With frmMain
                .openChildForm(formViewInformation)
            End With
        End If
    End Sub
End Class