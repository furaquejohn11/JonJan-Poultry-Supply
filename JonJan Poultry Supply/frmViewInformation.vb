Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmViewInformation
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public isUpdate As Boolean

    Public HighestSales As Double
    Private Sub frmViewInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        viewInformation()
        loadChart()

    End Sub
    Private Sub viewInformation()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        cn.Open()

        Dim i As Integer
        dgvViewInfo.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblManageProducts WHERE coldate LIKE '%" + curDate.Text + "%'  AND colProductsEarned = '564.00'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dgvViewInfo.Rows.Add(i, dr.Item("colProductsName").ToString, dr.Item("colProductsQuantitySold"),
                                 dr.Item("colProductsQuantitySold"), dr.Item("colPercentageOfSold"), dr.Item("colPercentageOfSold"),
                                 dr.Item("colProductsEarned"), dr.Item("colProductsEarned"), dr.Item("colPercentageOfSales"),
                                 dr.Item("colPercentageOfSales"))
        End While
        dr.Close()
        cn.Close()

        isUpdate = True
        statusVisible(colHQS)
        cbHighestQuantitySold.CheckState = CheckState.Checked

    End Sub

    Private Sub visibleInfo()
        colHQS.Visible = False
        colHAE.Visible = False
        colHPE.Visible = False
        colHPS.Visible = False
        colLAE.Visible = False
        colLPE.Visible = False
        colLPS.Visible = False
        colLQS.Visible = False


    End Sub

    Private Sub statusVisible(sv As DataGridViewTextBoxColumn)
        If isUpdate = True Then
            visibleInfo()
            sv.Visible = True
        Else
            sv.Visible = False

        End If
    End Sub

    Private Sub cbHighestQuantitySold_CheckedChanged(sender As Object, e As EventArgs) Handles cbHighestQuantitySold.CheckedChanged
        If cbHighestQuantitySold.CheckState = CheckState.Checked Then
            cbHighestAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestAmount.CheckState = CheckState.Unchecked
            cbLowestPercentageEarnings.CheckState = CheckState.Unchecked
            cbLowestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestQuantitySold.CheckState = CheckState.Unchecked



            isUpdate = True
            statusVisible(colHQS)


        Else
            colHQS.Visible = False

        End If
    End Sub

    Private Sub cbLowestQuantitySold_CheckedChanged(sender As Object, e As EventArgs) Handles cbLowestQuantitySold.CheckedChanged
        If cbLowestQuantitySold.CheckState = CheckState.Checked Then

            cbHighestQuantitySold.CheckState = CheckState.Unchecked
            cbHighestAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestAmount.CheckState = CheckState.Unchecked
            cbLowestPercentageEarnings.CheckState = CheckState.Unchecked
            cbLowestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestQuantitySold.CheckState = CheckState.Checked

            isUpdate = True
            statusVisible(colLQS)



        End If
    End Sub


    Private Sub cbHighestPercentageSold_CheckedChanged(sender As Object, e As EventArgs) Handles cbHighestPercentageSold.CheckedChanged
        If cbHighestPercentageSold.CheckState = CheckState.Checked Then
            cbHighestQuantitySold.CheckState = CheckState.Unchecked
            cbHighestAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageSold.CheckState = CheckState.Checked
            cbLowestAmount.CheckState = CheckState.Unchecked
            cbLowestPercentageEarnings.CheckState = CheckState.Unchecked
            cbLowestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestQuantitySold.CheckState = CheckState.Unchecked
        End If

        isUpdate = True
        statusVisible(colHPS)

    End Sub

    Private Sub cbLowestPercentageSold_CheckedChanged(sender As Object, e As EventArgs) Handles cbLowestPercentageSold.CheckedChanged
        If cbLowestPercentageSold.CheckState = CheckState.Checked Then
            cbHighestQuantitySold.CheckState = CheckState.Unchecked
            cbHighestAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestAmount.CheckState = CheckState.Unchecked
            cbLowestPercentageEarnings.CheckState = CheckState.Unchecked
            cbLowestPercentageSold.CheckState = CheckState.Checked
            cbLowestQuantitySold.CheckState = CheckState.Unchecked
        End If

        isUpdate = True
        statusVisible(colLPS)

    End Sub

    Private Sub cbHighestAmount_CheckedChanged(sender As Object, e As EventArgs) Handles cbHighestAmount.CheckedChanged
        If cbHighestAmount.CheckState = CheckState.Checked Then
            cbHighestQuantitySold.CheckState = CheckState.Unchecked
            cbHighestAmount.CheckState = CheckState.Checked
            cbHighestPercentageAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestAmount.CheckState = CheckState.Unchecked
            cbLowestPercentageEarnings.CheckState = CheckState.Unchecked
            cbLowestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestQuantitySold.CheckState = CheckState.Unchecked
        End If

        isUpdate = True
        statusVisible(colHAE)

    End Sub

    Private Sub cbLowestAmount_CheckedChanged(sender As Object, e As EventArgs) Handles cbLowestAmount.CheckedChanged
        If cbLowestAmount.CheckState = CheckState.Checked Then
            cbHighestQuantitySold.CheckState = CheckState.Unchecked
            cbHighestAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestAmount.CheckState = CheckState.Checked
            cbLowestPercentageEarnings.CheckState = CheckState.Unchecked
            cbLowestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestQuantitySold.CheckState = CheckState.Unchecked
        End If

        isUpdate = True
        statusVisible(colLAE)

    End Sub

    Private Sub cbHighestPercentageAmount_CheckedChanged(sender As Object, e As EventArgs) Handles cbHighestPercentageAmount.CheckedChanged
        If cbHighestPercentageAmount.CheckState = CheckState.Checked Then
            cbHighestQuantitySold.CheckState = CheckState.Unchecked
            cbHighestAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageAmount.CheckState = CheckState.Checked
            cbHighestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestAmount.CheckState = CheckState.Unchecked
            cbLowestPercentageEarnings.CheckState = CheckState.Unchecked
            cbLowestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestQuantitySold.CheckState = CheckState.Unchecked
        End If

        isUpdate = True
        statusVisible(colHPE)
        dgvViewInfo.Sort(dgvViewInfo.Columns("colHPE"), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub cbLowestPercentageEarnings_CheckedChanged(sender As Object, e As EventArgs) Handles cbLowestPercentageEarnings.CheckedChanged
        If cbLowestPercentageEarnings.CheckState = CheckState.Checked Then
            cbHighestQuantitySold.CheckState = CheckState.Unchecked
            cbHighestAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageAmount.CheckState = CheckState.Unchecked
            cbHighestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestAmount.CheckState = CheckState.Unchecked
            cbLowestPercentageEarnings.CheckState = CheckState.Checked
            cbLowestPercentageSold.CheckState = CheckState.Unchecked
            cbLowestQuantitySold.CheckState = CheckState.Unchecked
        End If

        isUpdate = True
        statusVisible(colLPE)
        dgvViewInfo.Sort(dgvViewInfo.Columns("colLPE"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Public Sub loadChart()
        With Chart1
            .Series.Clear()
            .Series.Add("Series1")
        End With

        Dim da As New OleDbDataAdapter("SELECT colProductsName, SUM(colProductsQuantitySold) AS TOTAL FROM tblManageProducts WHERE colDate = '123' GROUP BY colProductsName  ", cn)
        Dim ds As New DataSet

        da.Fill(ds, "colProductsName")
        Chart1.DataSource = ds.Tables("colProductsName")
        Dim series1 As Series = Chart1.Series("Series1")
        series1.ChartType = SeriesChartType.Pie
        series1.Name = "colProductsName"

        With Chart1
            .Series(series1.Name).XValueMember = "colProductsName"
            .Series(series1.Name).YValueMembers = "TOTAL"
        End With
    End Sub
    Private Sub summs()
        With frmManageProducts

        End With
    End Sub


End Class