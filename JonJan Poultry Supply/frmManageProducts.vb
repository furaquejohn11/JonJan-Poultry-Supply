Imports System.Data.OleDb
Public Class frmManageProducts
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Dim editRemaining, editSold, editEarned, editColID, editTotal As String
    Dim OverallCapital, OverallQuantity, OverallSold, OverallSales As Double
    Dim OverallSoldPercentage, OverallSalesPercentage As Double
    Public isUpdate As Boolean
    Public setDate, setUser As String
    Public dateupdate As Date
    Public d1, d2 As Double

    Private Sub frmManageProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        LoadCurrentDate()



    End Sub
    Private Sub LoadCurrentDate()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        cn.Open()
        Dim i As Integer

        dgvManageProduct.Rows.Clear()

        cm = New OleDbCommand("SELECT * FROM tblManageInventory WHERE Status LIKE '%INSTOCK%'", cn)
        dr = cm.ExecuteReader

        While dr.Read
            i += 1
            dgvManageProduct.Rows.Add(i, dr.Item("colID").ToString, dr.Item("ProductsName").ToString,
                                      Format(dr.Item("ProductsCapital"), "#,##0.00").ToString, Format(dr.Item("ProductsPricePerQTY"), "#,##0.00").ToString,
                                      dr.Item("ProductsTotalQTY").ToString, dr.Item("ProductsRemainingQTY").ToString,
                                      "SOLD", dr.Item("Input").ToString, "DEDUCT", dr.Item("ProductsEarned").ToString, dr.Item("ProductsTotalSoldQTY"))
        End While


        dr.Close()
        cn.Close()
        isUpdate = True
        If isUpdate = True Then
            cn.Open()
            dgvTable2.Rows.Clear()
            cm = New OleDbCommand("SELECT * FROM tblReport WHERE colID = '" & curDate.Text & "'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                dgvTable2.Rows.Add(i, dr.Item("colID"), dr.Item("ProductsName").ToString,
                                          dr.Item("ProductsQuantitySold").ToString, Format(dr.Item("ProductsEarns"), "#,##0.00").ToString)
            End While


            dr.Close()
            cn.Close()

            dgvManageProduct.Sort(dgvManageProduct.Columns("ProductsName"), System.ComponentModel.ListSortDirection.Ascending)
            dgvTable2.Sort(dgvTable2.Columns("DataGridViewTextBoxColumn4"), System.ComponentModel.ListSortDirection.Ascending)

        End If


        'SUMMING OF ALL INFORMATION
        If dgvTable2.Rows.Count = 0 Then
            lblTotalEarned.Text = "0.00"
            lblTotalSales.Text = "0"

        Else
            TableReportsSum()

        End If

        cn.Open()
        cm = New OleDbCommand("SELECT colDate2, colDate3 from tblHome where colDate = '" & curDate.Text & "'", cn)
        dr = cm.ExecuteReader

        If dr.Read = True Then

            Label4.Text = "As of: " + dr("colDate2").ToString
            dateupdate = dr("colDate3")

        End If
        cn.Close()
        Label2.Text = curDate.Text
    End Sub
    Private Sub dgvManageProduct_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManageProduct.CellContentClick
        Dim colname As String = dgvManageProduct.Columns(e.ColumnIndex).Name
        Dim colID, name As String
        Dim productPQTY, totalQTY, remainingQTY, soldQTY, inputCell, productEarned, val As Double



        If colname = "colAdd" Then
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            If Double.TryParse(dgvManageProduct.Rows(e.RowIndex).Cells(8).Value.ToString, val) Then
                colID = dgvManageProduct.Rows(e.RowIndex).Cells(1).Value.ToString
                name = dgvManageProduct.Rows(e.RowIndex).Cells(2).Value.ToString

                inputCell = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(8).Value.ToString) 'INPUT

                productPQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(4).Value.ToString) 'PRICE PER QTY
                totalQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(5).Value.ToString)
                remainingQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(6).Value.ToString)
                productEarned = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(10).Value.ToString)
                soldQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(11).Value.ToString)


                'FORMULA ON GETTING THE PRODUCT'S EARNED
                Dim product As Double
                product = productPQTY * inputCell
                productEarned = productEarned + product

                'FORMULA ON GETTING THE PRODUCT'S SOLD
                soldQTY = soldQTY + inputCell

                'FORMULA ON GETTING THE REMAINING QUANTITY
                remainingQTY = remainingQTY - inputCell

                If remainingQTY < 0 Then
                    MsgBox("No stocks available")
                    LoadCurrentDate()
                    Return
                End If

                'CHECKING IF THE STATUS IS INSTOCK OR OUT OF STOCK
                Dim status, datePicker2 As String
                datePicker2 = DateTime.Now.ToString("MMMM dd, yyyy")
                If remainingQTY = 0 Then
                    status = "Out of Stock - " + datePicker2
                Else
                    status = "INSTOCK"
                End If

                cn.Open()
                cm = New OleDbCommand("UPDATE tblManageInventory set Status = @Status, ProductsRemainingQTY = @ProductsRemainingQTY, ProductsEarned = @ProductsEarned, ProductsTotalSoldQTY = @ProductsTotalSoldQTY WHERE colID = '" & colID & "'", cn)

                With cm
                    .Parameters.AddWithValue("@Status", status)
                    .Parameters.AddWithValue("@ProductsRemainingQTY", remainingQTY)
                    .Parameters.AddWithValue("@ProductsEarned", Format(productEarned, "#,##0.00"))
                    .Parameters.AddWithValue("@ProductsTotalSoldQTY", soldQTY)

                    .ExecuteNonQuery()
                End With
                cn.Close()

                isUpdate = True
                If isUpdate = True Then
                    cn.Open()

                    cm = New OleDbCommand("SELECT * FROM tblReport WHERE ProductsName = '" & name & "' AND colID = '" & curDate.Text & "'", cn)
                    dr = cm.ExecuteReader

                    If dr.Read = True Then
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If

                        Dim reportSum, prodEarns As Double
                        Dim dailySum, dailyEarns As String


                        cn.Open()
                        cm = New OleDbCommand("SELECT * from tblReport where ProductsName = '" & name & "' AND colID = '" & curDate.Text & "'", cn)
                        dr = cm.ExecuteReader

                        If dr.Read = True Then
                            dailySum = dr("ProductsQuantitySold").ToString
                            reportSum = CDbl(dailySum) + CDbl(inputCell)

                            dailyEarns = dr("ProductsEarns").ToString
                            prodEarns = (productPQTY * CDbl(inputCell)) + dailyEarns
                        End If
                        cn.Close()

                        cn.Open()
                        cm = New OleDbCommand("UPDATE tblReport set ProductsQuantitySold = @ProductsQuantitySold, ProductsEarns = @ProductsEarns WHERE ProductsName = '" & name & "' AND colID = '" & curDate.Text & "'", cn)
                        With cm
                            .Parameters.AddWithValue("@ProductsQuantitySold", reportSum)
                            .Parameters.AddWithValue("@ProductsEarns", Format(prodEarns, "#,##0.00"))
                            .ExecuteNonQuery()
                        End With
                        cn.Close()
                    Else
                        If cn.State = ConnectionState.Open Then
                            cn.Close()
                        End If

                        Dim prodEarns As Double

                        prodEarns = productPQTY * inputCell


                        cn.Open()
                        cm = New OleDbCommand("INSERT INTO tblReport (colDate, colID, ProductsName, ProductsQuantitySold, ProductsEarns) VALUES (@colDate, @colID, @ProductsName, @ProductsQuantitySold, @ProductsEarns)", cn)
                        With cm
                            .Parameters.AddWithValue("@colDate", dateUpdate)
                            .Parameters.AddWithValue("@colID", curDate.Text)
                            .Parameters.AddWithValue("@ProductsName", name)
                            .Parameters.AddWithValue("@ProductsQuantitySold", inputCell)
                            .Parameters.AddWithValue("@ProductsEarns", Format(prodEarns, "#,##0.00"))

                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                    End If

                    cn.Close()
                End If

                MsgBox(dgvManageProduct.Rows(e.RowIndex).Cells(2).Value.ToString + " solds quantity increased by " + CStr(inputCell))

                LoadCurrentDate()
                updator()
                gettingSum()

                With frmManageInventory
                    .totalSoldQTY()
                End With

            Else
                MsgBox("INVALID CHARACTERS")
            End If


        End If
        If colname = "colSub" Then
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            If Double.TryParse(dgvManageProduct.Rows(e.RowIndex).Cells(8).Value.ToString, val) Then
                colID = dgvManageProduct.Rows(e.RowIndex).Cells(1).Value.ToString
                name = dgvManageProduct.Rows(e.RowIndex).Cells(2).Value.ToString

                inputCell = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(8).Value.ToString) 'INPUT

                productPQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(4).Value.ToString) 'PRICE PER QTY
                totalQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(5).Value.ToString)
                remainingQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(6).Value.ToString)
                productEarned = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(10).Value.ToString)
                soldQTY = CDbl(dgvManageProduct.Rows(e.RowIndex).Cells(11).Value.ToString)



                'FORMULA ON GETTING THE PRODUCT'S EARNED
                Dim product As Double
                product = productPQTY * inputCell
                productEarned = productEarned - product

                'FORMULA ON GETTING THE PRODUCT'S SOLD
                soldQTY = soldQTY + inputCell

                'FORMULA ON GETTING THE REMAINING QUANTITY
                remainingQTY = remainingQTY + inputCell

                If soldQTY < 0 Then
                    MsgBox("No stocks available")
                    LoadCurrentDate()
                    Return
                End If



                cn.Open()
                cm = New OleDbCommand("SELECT * from tblReport where ProductsName = '" & name & "' AND colID = '" & curDate.Text & "'", cn)
                dr = cm.ExecuteReader

                If dr.Read = True Then
                    Dim reportSum As Double
                    Dim dailySum As String

                    dailySum = dr("ProductsQuantitySold").ToString

                    reportSum = CDbl(dailySum) - CDbl(inputCell)

                    If reportSum < 0 Then
                        MsgBox("Not Enough Stocks Available")
                        LoadCurrentDate()
                        Return
                    End If
                ElseIf dr.Read = False Then
                    MsgBox("No available today's product sold!")
                    Return
                End If

                cn.Close()

                cn.Open()
                cm = New OleDbCommand("UPDATE tblManageInventory Set ProductsRemainingQTY = @ProductsRemainingQTY, ProductsEarned = @ProductsEarned, ProductsTotalSoldQTY = @ProductsTotalSoldQTY WHERE colID = '" & colID & "'", cn)

                With cm
                            .Parameters.AddWithValue("@ProductsRemainingQTY", remainingQTY)
                            .Parameters.AddWithValue("@ProductsEarned", Format(productEarned, "#,##0.00"))
                            .Parameters.AddWithValue("@ProductsTotalSoldQTY", soldQTY)

                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                        isUpdate = True
                        If isUpdate = True Then
                            cn.Open()

                            cm = New OleDbCommand("SELECT * FROM tblReport WHERE ProductsName = '" & name & "' AND colID = '" & curDate.Text & "'", cn)
                            dr = cm.ExecuteReader

                            If dr.Read = True Then
                                If cn.State = ConnectionState.Open Then
                                    cn.Close()
                                End If

                                Dim reportSum, prodEarns As Double
                                Dim dailySum, dailyEarns As String


                                cn.Open()
                                cm = New OleDbCommand("SELECT * from tblReport where ProductsName = '" & name & "' AND colID = '" & curDate.Text & "'", cn)
                                dr = cm.ExecuteReader

                                If dr.Read = True Then
                                    dailySum = dr("ProductsQuantitySold").ToString
                                    reportSum = CDbl(dailySum) - CDbl(inputCell)

                                    dailyEarns = dr("ProductsEarns").ToString
                                    prodEarns = dailyEarns - (productPQTY * CDbl(inputCell))
                                End If
                                cn.Close()

                                cn.Open()
                                cm = New OleDbCommand("UPDATE tblReport set ProductsQuantitySold = @ProductsQuantitySold, ProductsEarns = @ProductsEarns WHERE ProductsName = '" & name & "' AND colID = '" & curDate.Text & "'", cn)
                                With cm
                                    .Parameters.AddWithValue("@ProductsQuantitySold", reportSum)
                                    .Parameters.AddWithValue("@ProductsEarns", Format(prodEarns, "#,##0.00"))
                                    .ExecuteNonQuery()
                                End With
                                cn.Close()
                            Else
                                If cn.State = ConnectionState.Open Then
                                    cn.Close()
                                End If

                                Dim prodEarns As Double

                                prodEarns = productPQTY * inputCell

                                cn.Open()
                                cm = New OleDbCommand("INSERT INTO tblReport (colID, ProductsName, ProductsQuantitySold, ProductsEarns) VALUES (@colID, @ProductsName, @ProductsQuantitySold, @ProductsEarns)", cn)
                                With cm
                                    .Parameters.AddWithValue("@colID", curDate.Text)
                                    .Parameters.AddWithValue("@ProductsName", name)
                                    .Parameters.AddWithValue("@ProductsQuantitySold", inputCell)
                                    .Parameters.AddWithValue("@ProductsEarns", Format(prodEarns, "#,##0.00"))

                                    .ExecuteNonQuery()
                                End With
                                cn.Close()

                            End If

                            cn.Close()
                        End If

                        MsgBox(dgvManageProduct.Rows(e.RowIndex).Cells(2).Value.ToString + " solds quantity decrease by " + CStr(inputCell))

                LoadCurrentDate()
                updator()
                gettingSum()

            Else
                        MsgBox("INVALID CHARACTERS")
            End If
            With frmManageInventory
                .totalSoldQTY()
            End With

        End If


        If colname = "colDelete" Then

            'DELETING PRODUCT INFORMATION
            If MsgBox("Are you sure you want to delete this student?" & vbNewLine & "NOTE: This will be permanently removed to our database",
            vbQuestion + vbYesNo, "Message Prompt") = MsgBoxResult.Yes Then
                cn.Open()
                cm = New OleDbCommand("DELETE FROM tblManageProducts WHERE colDateID = '" & DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString & "'", cn)
                cm.ExecuteNonQuery()
                MsgBox("Selected product have successfully removed in our database", vbInformation + vbOKOnly, "Message Prompt")
                cn.Close()

                LoadCurrentDate()

            End If
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub lblTotalSales_Click(sender As Object, e As EventArgs) Handles lblTotalSales.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    'Displaying data from the database that is based on the curDate.text



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        searchFunction()
    End Sub



    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadCurrentDate()
        txtSearchBar.Text = ""

    End Sub


    Private Sub txtSearchBar_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBar.TextChanged
        searchFunction()
    End Sub
    Private Sub searchFunction()
        Dim searchID As String
        searchID = curDate.Text + "-" + txtSearchBar.Text
        If txtSearchBar.Text <> "" Then
            cn.Open()
            Dim i As Integer

            dgvManageProduct.Rows.Clear()

            cm = New OleDbCommand("SELECT * FROM tblManageInventory WHERE ProductsName LIKE '%" + txtSearchBar.Text + "%' AND Status LIKE '%INSTOCK%'", cn)
            dr = cm.ExecuteReader

            While dr.Read
                i += 1
                dgvManageProduct.Rows.Add(i, dr.Item("colID").ToString, dr.Item("ProductsName").ToString,
                                      dr.Item("ProductsCapital").ToString, dr.Item("ProductsPricePerQTY").ToString,
                                      dr.Item("ProductsTotalQTY").ToString, dr.Item("ProductsRemainingQTY").ToString,
                                      "+", dr.Item("Input").ToString, "-", dr.Item("ProductsEarned").ToString, dr.Item("ProductsTotalSoldQTY"))
            End While

            dr.Close()
            cn.Close()



        Else
            If txtSearchBar.Text = "" Then
                LoadCurrentDate()
            End If

        End If
    End Sub
    ' Private Sub OverAllSum()
    ' If cn.State = ConnectionState.Open Then
    'cn.Close()
    ' End If

    '  Dim colsumForOverallCapital, colsumForOverallQuantity, colsumForOverallSold, colsumForOverallSales As Double
    ' For Each i As DataGridViewRow In DataGridView1.Rows

    'colsumForOverallCapital += i.Cells(3).Value
    'colsumForOverallQuantity += i.Cells(6).Value
    'colsumForOverallSold += i.Cells(11).Value
    'colsumForOverallSales += i.Cells(12).Value

    'Next
    'OverallCapital = Format(colsumForOverallCapital, "#,##0.00")
    ' 'OverallQuantity = colsumForOverallQuantity
    '  OverallSold = colsumForOverallSold
    'MsgBox(OverallSold)
    'OverallSales = Format(colsumForOverallSales, "#,##0.00")

    'Dim PercentSold, PercentSales As Double


    'PercentSold = (OverallSold / OverallQuantity) * 100
    'OverallSoldPercentage = Format(PercentSold, "#,##00.00")


    'PercentSales = (OverallSales / OverallCapital) * 100
    'OverallSalesPercentage = Format(PercentSales, "#,##00.00")


    'gettingSum()

    ' End Sub

    Private Sub gettingSum()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        cn.Open()
        cm = New OleDbCommand("UPDATE tblSum SET totalQTY = @totalQTY, totalSales = @totalSales WHERE colDateID = '" & curDate.Text & "'", cn)

        With cm
            .Parameters.AddWithValue("@totalQTY", d1)
            .Parameters.AddWithValue("@totalSales", d2)
            .ExecuteNonQuery()

        End With
        cn.Close()

    End Sub
    Public Sub highestLowestValue()
        Dim abcd As Integer
        For x As Integer = 0 To DataGridView1.Rows.Count - 1
            If abcd = 0 Then
                abcd = DataGridView1.Rows(x).Cells(12).Value

            Else
                If abcd < DataGridView1.Rows(x).Cells(12).Value Then
                    abcd = DataGridView1.Rows(x).Cells(12).Value

                End If
            End If
        Next
        With frmViewInformation
            .HighestSales = abcd
        End With


        'Sum of all products quantity sold
    End Sub

    Public Sub updator()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Dim nameUser As String
        With frmMain
            nameUser = .clientName
        End With

        cn.Open()
        cm = New OleDbCommand("UPDATE tblHome set colLastUpdatedBy = @colLastUpdatedBy, colLastUpdatedOn = @colLastUpdatedOn WHERE colDate = '" & setDate & "'", cn)

        With cm
            .Parameters.AddWithValue("@colLastUpdatedBy", nameUser)
            .Parameters.AddWithValue("@ProductsEarned", DateTime.Now.ToString("yyyy-MM-dd: HH:mm"))
            .ExecuteNonQuery()
        End With
        cn.Close()
    End Sub

    Private Sub TableReportsSum()

        'SALES SUM
        cn.Open()
        cm = New OleDbCommand("SELECT SUM(ProductsQuantitySold) AS ProductsQuantitySold from tblReport WHERE colID = '" & curDate.Text & "'", cn)
        dr = cm.ExecuteReader
        If dr.Read = True Then
            lblTotalSales.Text = dr.Item("ProductsQuantitySold")
            d1 = dr.Item("ProductsQuantitySold")
        End If
        cn.Close()

        'EARNED SUM
        cn.Open()
        cm = New OleDbCommand("SELECT SUM(ProductsEarns) AS ProductsEarns from tblReport WHERE colID = '" & curDate.Text & "'", cn)
        dr = cm.ExecuteReader
        If dr.Read = True Then
            lblTotalEarned.Text = Format(dr.Item("ProductsEarns"), "#,##0.00")
            d2 = Format(dr.Item("ProductsEarns"), "#,##0.00")
        End If
        cn.Close()
    End Sub

End Class