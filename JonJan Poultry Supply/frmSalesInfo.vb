'Dear developers:
'
'When I wrote this code, only I and God 
'knew what it was.
'Now, only God knows!
'
'So, if you are done trying to 'optimize'
'this system (and failed)

'please wag mo na subukan ulit
'masisira lang buhay mo

Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmSalesInfo
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Public isUpdate As Boolean

    Public bool, boolUpLow As Boolean
    Public graphOperations As Boolean
    Private Sub frmSalesInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"

        bool = True
        boolUpLow = True
        'LoadChart1()
        'LoadEarnedChart()
        LoadCJ()
        dash()
        cbQTY.CheckState = CheckState.Checked
        cbHighSales.CheckState = CheckState.Checked

        Dim today = DateTime.Now
        Dim todaysDate = today.AddDays(-7)

        DateTimePicker1.Value = todaysDate

    End Sub


    Private Sub LineQTY()

        Try
            With chartLine
                .Series.Clear()
                .Series.Add("Series1")
            End With


            Dim cm As New OleDbCommand("SELECT colDateID, colDate, totalQTY FROM tblSum WHERE colDate BETWEEN @d1 AND @d2", cn)
            cm.Parameters.Add("@d1", OleDbType.Date).Value = DateTimePicker1.Value
            cm.Parameters.Add("@d2", OleDbType.Date).Value = DateTimePicker2.Value

            Dim da As New OleDbDataAdapter
            Dim ds As New DataSet
            da.SelectCommand = cm
            da.Fill(ds, "colDate")
            chartLine.DataSource = ds.Tables("colDate")
            Dim series2 As Series = chartLine.Series("Series1")
            series2.ChartType = SeriesChartType.Line
            series2.Name = "colDate"

            chartLine.Series(series2.Name).XValueMember = "colDate"
            chartLine.Series(series2.Name).YValueMembers = "totalqty"

            With chartLine
                .Series(0).LabelForeColor = Color.White
                .Series(0).LabelFormat = "{#,##0.00}"
                .Series(0).IsVisibleInLegend = False
                .Series(0).IsValueShownAsLabel = True
                .Series(0).Palette = ChartColorPalette.SeaGreen
                .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
                .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.White
                '.Series(0).LegendText = "#VALX (#PERCENT)"
                .ChartAreas(0).BackColor = Color.Transparent
                .Legends(0).BackColor = Color.Transparent
            End With

            cn.Close()
        Catch ex As Exception

        End Try




    End Sub
    Private Sub LineSales()

        Try
            With chartLine
                .Series.Clear()
                .Series.Add("Series1")
            End With


            Dim cm As New OleDbCommand("SELECT colDateID, colDate, totalSales FROM tblSum WHERE colDate BETWEEN @d1 AND @d2", cn)
            cm.Parameters.Add("@d1", OleDbType.Date).Value = DateTimePicker1.Value
            cm.Parameters.Add("@d2", OleDbType.Date).Value = DateTimePicker2.Value

            Dim da As New OleDbDataAdapter
            Dim ds As New DataSet
            da.SelectCommand = cm
            da.Fill(ds, "colDate")
            chartLine.DataSource = ds.Tables("colDate")
            Dim series2 As Series = chartLine.Series("Series1")
            series2.ChartType = SeriesChartType.Line
            series2.Name = "colDate"

            chartLine.Series(series2.Name).XValueMember = "colDate"
            chartLine.Series(series2.Name).YValueMembers = "totalSales"

            With chartLine
                .Series(0).LabelForeColor = Color.White
                .Series(0).LabelFormat = "{#,##0.00}"
                .Series(0).IsVisibleInLegend = False
                .Series(0).IsValueShownAsLabel = True
                .Series(0).Palette = ChartColorPalette.SeaGreen
                .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
                .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.White
                '.Series(0).LegendText = "#VALX (#PERCENT)"
                .ChartAreas(0).BackColor = Color.Transparent
                .Legends(0).BackColor = Color.Transparent
            End With

            cn.Close()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadCJ()
        Try
            With barChart
                .Series.Clear()
                .Series.Add("Series1")
            End With

            Dim da As New OleDbDataAdapter("SELECT TOP 5 ProductsName, ProductsTotalSoldQTY FROM tblManageInventory ORDER BY ProductsTotalSoldQTY  ", cn)
            Dim ds As New DataSet

            da.Fill(ds, "ProductsTotalSoldQTY")
            barChart.DataSource = ds.Tables("ProductsTotalSoldQTY")
            Dim series2 As Series = barChart.Series("Series1")
            series2.ChartType = SeriesChartType.Bar



            With barChart
                .Series(series2.Name).XValueMember = "ProductsName"
                .Series(series2.Name).YValueMembers = "ProductsTotalSoldQTY"

                .Series(0).LabelForeColor = Color.White
                .Series(0)("BarLabelStyle") = "inside"
                .Series(0).IsVisibleInLegend = False
                .Series(0).Sort(PointSortOrder.Ascending, "X")
                .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
                .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.White
                .Series(0).LabelFormat = "{#,##0.00}"
                .Series(0).Palette = ChartColorPalette.SeaGreen
                .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                .Series(0).IsValueShownAsLabel = True

                .ChartAreas(0).BackColor = Color.Transparent

                .Legends(0).BackColor = Color.Transparent

            End With
        Catch ex As Exception

        End Try



    End Sub
    Private Sub LowCJ()

        Try
            With barChart
                .Series.Clear()
                .Series.Add("Series1")
            End With

            Dim da As New OleDbDataAdapter("SELECT TOP 5 ProductsName, ProductsTotalSoldQTY FROM tblManageInventory ORDER BY ProductsTotalSoldQTY  DESC  ", cn)
            Dim ds As New DataSet

            da.Fill(ds, "ProductsTotalSoldQTY")
            barChart.DataSource = ds.Tables("ProductsTotalSoldQTY")
            Dim series2 As Series = barChart.Series("Series1")
            series2.ChartType = SeriesChartType.Bar
            series2.Name = "Number of Quantities Sold"

            With barChart
                .Series(series2.Name).XValueMember = "ProductsName"
                .Series(series2.Name).YValueMembers = "ProductsTotalSoldQTY"

                .Series(0).LabelForeColor = Color.White
                .Series(0)("BarLabelStyle") = "inside"
                .Series(0).IsVisibleInLegend = False
                .Series(0).Sort(PointSortOrder.Descending, "X")
                .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
                .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.White
                .Series(0).LabelFormat = "{#,##0.00}"
                .Series(0).Palette = ChartColorPalette.SeaGreen
                .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                .Series(0).IsValueShownAsLabel = True

                .ChartAreas(0).BackColor = Color.Transparent

                .Legends(0).BackColor = Color.Transparent
            End With
        Catch ex As Exception

        End Try



    End Sub
    Private Sub Sales()

        Try
            If cbSales.CheckState = CheckState.Checked Then
                cbQTY.CheckState = CheckState.Unchecked


                With barChart
                    .Series.Clear()
                    .Series.Add("Series1")
                End With

                Dim da As New OleDbDataAdapter("SELECT TOP 5 ProductsName, ProductsEarned FROM tblManageInventory ORDER BY ProductsEarned    ", cn)
                Dim ds As New DataSet

                da.Fill(ds, "ProductsEarned")
                barChart.DataSource = ds.Tables("ProductsEarned")
                Dim series2 As Series = barChart.Series("Series1")
                series2.ChartType = SeriesChartType.Bar
                series2.Name = "Total Products Earnings"

                With barChart
                    .Series(series2.Name).XValueMember = "ProductsName"
                    .Series(series2.Name).YValueMembers = "ProductsEarned"

                    .Series(0).LabelForeColor = Color.White
                    .Series(0)("BarLabelStyle") = "inside"
                    .Series(0).LabelFormat = "{#,##0.00}"
                    .Series(0).IsVisibleInLegend = False
                    .Series(0).Sort(PointSortOrder.Ascending, "X")
                    .Series(0).Palette = ChartColorPalette.SeaGreen
                    .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
                    .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.White
                    .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                    .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                    .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                    .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                    .Series(0).IsValueShownAsLabel = True

                    .ChartAreas(0).BackColor = Color.Transparent

                    .Legends(0).BackColor = Color.Transparent
                End With

            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LowSales()

        Try
            If cbSales.CheckState = CheckState.Checked Then
                cbQTY.CheckState = CheckState.Unchecked


                With barChart
                    .Series.Clear()
                    .Series.Add("Series1")
                End With

                Dim da As New OleDbDataAdapter("SELECT TOP 5 ProductsName, ProductsEarned FROM tblManageInventory ORDER BY ProductsEarned desc ", cn)
                Dim ds As New DataSet

                da.Fill(ds, "ProductsEarned")
                barChart.DataSource = ds.Tables("ProductsEarned")
                Dim series2 As Series = barChart.Series("Series1")
                series2.ChartType = SeriesChartType.Bar
                series2.Name = "Total Products Earnings"

                With barChart
                    .Series(series2.Name).XValueMember = "ProductsName"
                    .Series(series2.Name).YValueMembers = "ProductsEarned"

                    .Series(0).LabelForeColor = Color.White
                    .Series(0)("BarLabelStyle") = "inside"
                    .Series(0).LabelFormat = "{#,##0.00}"
                    .Series(0).IsVisibleInLegend = False
                    .Series(0).Sort(PointSortOrder.Descending, "X")
                    .Series(0).Palette = ChartColorPalette.SeaGreen
                    .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.White
                    .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.White
                    .ChartAreas(0).AxisX.MajorGrid.Enabled = False
                    .ChartAreas(0).AxisY.MajorGrid.Enabled = False
                    .ChartAreas(0).AxisX.MinorGrid.Enabled = False
                    .ChartAreas(0).AxisY.MinorGrid.Enabled = False

                    .Series(0).IsValueShownAsLabel = True

                    .ChartAreas(0).BackColor = Color.Transparent

                    .Legends(0).BackColor = Color.Transparent
                End With

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dash()
        Try
            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsTotalQTY) AS ProductsTotalQTY from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                lblTotalQ.Text = dr.Item("ProductsTotalQTY")
                'value1 = dr.Item("ProductsTotalQTY")
            End If
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsTotalSoldQTY) AS ProductsTotalSoldQTY from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                lblSoldQ.Text = dr.Item("ProductsTotalSoldQTY")
                'value1 = dr.Item("ProductsTotalQTY")
            End If
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsCapital) AS ProductsCapital from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                lblCapital.Text = Format(dr.Item("ProductsCapital"), "#,##0.00")
                'value1 = dr.Item("ProductsTotalQTY")
            End If
            cn.Close()

            cn.Open()
            cm = New OleDbCommand("SELECT SUM(ProductsEarned) AS ProductsEarned from tblManageInventory", cn)
            dr = cm.ExecuteReader
            If dr.Read = True Then
                lblSoldPrice.Text = Format(dr.Item("ProductsEarned"), "#,##0.00")
                'value1 = dr.Item("ProductsTotalQTY")
            End If
            cn.Close()
        Catch ex As Exception

        End Try




    End Sub

    Private Sub cbQTY_CheckedChanged(sender As Object, e As EventArgs) Handles cbQTY.CheckedChanged
        If cbQTY.CheckState = CheckState.Checked Then
            cbSales.CheckState = CheckState.Unchecked

            LineQTY()
            bool = True

            If bool = True And boolUpLow = True Then
                LoadCJ()
            ElseIf bool = True And boolUpLow = False Then
                LowCJ()

            End If
        End If
    End Sub

    Private Sub cbSales_CheckedChanged(sender As Object, e As EventArgs) Handles cbSales.CheckedChanged
        If cbSales.CheckState = CheckState.Checked Then
            cbQTY.CheckState = CheckState.Unchecked

            bool = False
            LineSales()

            If bool = False And boolUpLow = True Then
                Sales()
            ElseIf bool = False And boolUpLow = False Then
                LowSales()
            End If
        End If
    End Sub
    Private Sub cbHighSales_CheckedChanged(sender As Object, e As EventArgs) Handles cbHighSales.CheckedChanged
        If cbHighSales.CheckState = CheckState.Checked Then
            cbLowSales.CheckState = CheckState.Unchecked
            boolUpLow = True

            If boolUpLow = True And bool = True Then
                LoadCJ()
            ElseIf boolUpLow = True And bool = False Then
                Sales()
            End If

        End If

    End Sub


    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If bool = True Then
            LineQTY()
        Else
            LineSales()
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        If bool = True Then
            LineQTY()
        Else
            LineSales()
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub cbLowSales_CheckedChanged(sender As Object, e As EventArgs) Handles cbLowSales.CheckedChanged
        If cbLowSales.CheckState = CheckState.Checked Then
            cbHighSales.CheckState = CheckState.Unchecked
            boolUpLow = False

            If boolUpLow = False And bool = False Then
                LowSales()
            ElseIf boolUpLow = False And bool = True Then
                LowCJ()
            End If
        End If
    End Sub

    'Functions on filtering with date
End Class