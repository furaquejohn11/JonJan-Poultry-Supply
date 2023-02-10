Imports System.Data.OleDb
Public Class frmEdit1
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Dim val, value As Double
    Public isUpdate As Boolean
    Public colID As String
    Public diffOfTotal, remainingQ As Double
    Private Sub frmEdit1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
    End Sub
    Private Sub frmEdit1_FormClosing(sender As Object, e As FormClosingEventArgs)

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Dim dateID As String
        dateID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")


        If txtPN.Text = "" Or txtPC.Text = "" Or txtPPQ.Text = "" Or txtPTQ.Text = "" Then
            MsgBox("Please supply required fields", vbCritical + vbOKOnly, "Message Prompt")
            Return
        End If


        If Double.TryParse(txtPTQ.Text, val And Double.TryParse(txtPPQ.Text, val) And Double.TryParse(txtPC.Text, val)) Then


            cn.Open()
            cm = New OleDbCommand("UPDATE tblManageInventory SET ProductsName = @ProductsName WHERE colID = '" & colID & "'", cn)

            cm.Parameters.AddWithValue("@ProductsName", txtPN.Text)

            cm.ExecuteNonQuery()
            cn.Close()


            MsgBox("Selected product has been successfully updated to our database", vbInformation + vbOKOnly, "Message Prompt")

            txtPC.Text = ""
            txtPN.Text = ""
            txtPTQ.Text = ""
            txtPPQ.Text = ""

            Me.Close()
            With frmMain
                .openChildForm(New frmManageInventory())
            End With
        Else
            MsgBox("invalid")
        End If
    End Sub

    Private Sub pcSub_Click(sender As Object, e As EventArgs) Handles pcSub.Click
        If Double.TryParse(txtIPC.Text, val) Then
            value = CDbl(txtPC.Text) - (CDbl(txtIPC.Text))
            If value < 0 Then
                MsgBox("INVALID")
                txtIPTQ.Text = ""
                Return
            End If

            cn.Open()
            cm = New OleDbCommand("SELECT * from tblManageInventory where colID = '" & colID & "'", cn)
            dr = cm.ExecuteReader

            If dr.Read = True Then
                Dim dailySum As Double
                dailySum = dr("ProductsCapital").ToString
                remainingQ = dailySum + CDbl(txtIPC.Text)
                isUpdate = True

                If isUpdate = True Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()

                        cn.Open()
                        cm = New OleDbCommand("UPDATE tblManageInventory SET ProductsCapital = @ProductsCapital WHERE colID = '" & colID & "'", cn)
                        With cm
                            .Parameters.AddWithValue("@ProductsCapital", Format(CDbl(value), "#,##0.00"))
                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                    End If
                End If

            End If
            cn.Close()

            MsgBox("Product's Capital Decreased by " + txtIPC.Text)
            txtPC.Text = Format(CDbl(value), "#,##0.00")
            txtIPC.Text = ""

        Else
            MsgBox("Please input valid numbers")
        End If

    End Sub

    Private Sub ptAdd_Click(sender As Object, e As EventArgs) Handles ptAdd.Click
        If Double.TryParse(txtIPTQ.Text, val) Then
            value = CDbl(txtPTQ.Text) + (CDbl(txtIPTQ.Text))

            cn.Open()
            cm = New OleDbCommand("SELECT * from tblManageInventory where colID = '" & colID & "'", cn)
            dr = cm.ExecuteReader

            If dr.Read = True Then
                Dim dailySum As Double
                dailySum = dr("ProductsRemainingQTY").ToString
                remainingQ = dailySum + CDbl(txtIPTQ.Text)
                isUpdate = True

                If isUpdate = True Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()

                        Dim status, datePicker2 As String
                        datePicker2 = DateTime.Now.ToString("MMMM dd, yyyy")
                        status = "INSTOCK - " + datePicker2
                        cn.Open()
                        cm = New OleDbCommand("UPDATE tblManageInventory SET Status = @Status, ProductsTotalQTY = @ProductsTotalQTY, ProductsRemainingQTY = @ProductsRemainingQTY WHERE colID = '" & colID & "'", cn)
                        With cm
                            .Parameters.AddWithValue("@Status", status)
                            .Parameters.AddWithValue("@ProductsTotalQTY", value)
                            .Parameters.AddWithValue("@ProductsRemainingQTY ", remainingQ)
                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                    End If
                End If

            End If
            cn.Close()
            MsgBox("Product's Total Quantity Increased by " + txtIPTQ.Text)
            txtPTQ.Text = value
            txtIPTQ.Text = ""
        Else
            MsgBox("Please input valid numbers")
        End If
    End Sub

    Private Sub ppAdd_Click(sender As Object, e As EventArgs) Handles ppAdd.Click
        If Double.TryParse(txtIPPQ.Text, val) Then
            value = CDbl(txtPPQ.Text) + (CDbl(txtIPPQ.Text))

            cn.Open()
            cm = New OleDbCommand("SELECT * from tblManageInventory where colID = '" & colID & "'", cn)
            dr = cm.ExecuteReader

            If dr.Read = True Then
                Dim dailySum As Double
                dailySum = dr("ProductsPricePerQTY").ToString
                remainingQ = dailySum + CDbl(txtIPPQ.Text)
                isUpdate = True

                If isUpdate = True Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()

                        cn.Open()
                        cm = New OleDbCommand("UPDATE tblManageInventory SET ProductsPricePerQTY = @ProductsPricePerQTY WHERE colID = '" & colID & "'", cn)
                        With cm
                            .Parameters.AddWithValue("@ProductsPricePerQTY", Format(CDbl(value), "#,##0.00"))
                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                    End If
                End If

            End If
            cn.Close()

            MsgBox("Product's Price Per Quantity Increased by " + txtIPPQ.Text)
            txtPPQ.Text = Format(CDbl(value), "#,##0.00")
            txtIPPQ.Text = ""

        Else
            MsgBox("Please input valid numbers")
        End If
    End Sub

    Private Sub pcAdd_Click(sender As Object, e As EventArgs) Handles pcAdd.Click
        If Double.TryParse(txtIPC.Text, val) Then
            value = CDbl(txtPC.Text) + (CDbl(txtIPC.Text))

            cn.Open()
            cm = New OleDbCommand("SELECT * from tblManageInventory where colID = '" & colID & "'", cn)
            dr = cm.ExecuteReader

            If dr.Read = True Then
                Dim dailySum As Double
                dailySum = dr("ProductsCapital").ToString
                remainingQ = dailySum + CDbl(txtIPC.Text)
                isUpdate = True

                If isUpdate = True Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()

                        cn.Open()
                        cm = New OleDbCommand("UPDATE tblManageInventory SET ProductsCapital = @ProductsCapital WHERE colID = '" & colID & "'", cn)
                        With cm
                            .Parameters.AddWithValue("@ProductsCapital", Format(CDbl(value), "#,##0.00"))
                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                    End If
                End If

            End If
            cn.Close()


            MsgBox("Product's Capital Increased by " + txtIPC.Text)
            txtPC.Text = Format(CDbl(value), "#,##0.00")
            txtIPC.Text = ""

        Else
            MsgBox("Please input valid numbers")
        End If
    End Sub

    Private Sub frmEdit1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        With frmMain
            .openChildForm(New frmManageInventory())
        End With
    End Sub

    Private Sub ptSub_Click(sender As Object, e As EventArgs) Handles ptSub.Click
        If Double.TryParse(txtIPTQ.Text, val) Then
            value = CDbl(txtPTQ.Text) - (CDbl(txtIPTQ.Text))
            If value < 0 Then
                MsgBox("Not enough stocks")
                txtIPTQ.Text = ""
                Return
            End If

            cn.Open()
            cm = New OleDbCommand("SELECT * from tblManageInventory where colID = '" & colID & "'", cn)
            dr = cm.ExecuteReader


            Dim status, datePicker2 As String
            Dim result As Double
            If dr.Read = True Then
                Dim dailySum As Double
                dailySum = dr("ProductsRemainingQTY").ToString
                result = dailySum - CDbl(txtIPTQ.Text)
                isUpdate = True


                If result <= 0 Then
                    datePicker2 = DateTime.Now.ToString("MMMM dd, yyyy")
                    status = "Out of Stock - " + datePicker2
                    remainingQ = 0
                Else
                    datePicker2 = DateTime.Now.ToString("MMMM dd, yyyy")
                    status = "INSTOCK - " + datePicker2
                    remainingQ = result
                End If



                If isUpdate = True Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()

                        cn.Open()
                        cm = New OleDbCommand("UPDATE tblManageInventory SET Status = @Status, ProductsTotalQTY = @ProductsTotalQTY, ProductsRemainingQTY = @ProductsRemainingQTY WHERE colID = '" & colID & "'", cn)
                        With cm
                            .Parameters.AddWithValue("@Status", status)
                            .Parameters.AddWithValue("@ProductsTotalQTY", value)
                            .Parameters.AddWithValue("@ProductsRemainingQTY ", remainingQ)
                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                    End If
                End If

            End If
            cn.Close()

            MsgBox("Product's Total Quantity Inreased by " + txtIPTQ.Text)
            txtPTQ.Text = value


            txtIPTQ.Text = ""
        Else
            MsgBox("Please input valid numbers")
        End If
    End Sub

    Private Sub ppSub_Click(sender As Object, e As EventArgs) Handles ppSub.Click
        If Double.TryParse(txtIPPQ.Text, val) Then
            value = CDbl(txtPPQ.Text) - (CDbl(txtIPPQ.Text))
            If value < 0 Then
                MsgBox("INVALID")
                txtIPPQ.Text = ""
                Return
            End If

            cn.Open()
            cm = New OleDbCommand("SELECT * from tblManageInventory where colID = '" & colID & "'", cn)
            dr = cm.ExecuteReader

            If dr.Read = True Then
                Dim dailySum As Double
                dailySum = dr("ProductsPricePerQTY").ToString
                remainingQ = dailySum - CDbl(txtIPPQ.Text)
                isUpdate = True

                If isUpdate = True Then
                    If cn.State = ConnectionState.Open Then
                        cn.Close()

                        cn.Open()
                        cm = New OleDbCommand("UPDATE tblManageInventory SET ProductsPricePerQTY = @ProductsPricePerQTY WHERE colID = '" & colID & "'", cn)
                        With cm
                            .Parameters.AddWithValue("@ProductsPricePerQTY", Format(CDbl(value), "#,##0.00"))
                            .ExecuteNonQuery()
                        End With
                        cn.Close()

                    End If
                End If

            End If
            cn.Close()

            MsgBox("Product's Price Per Quantity Decreased by " + txtIPPQ.Text)
            txtPPQ.Text = Format(CDbl(value), "#,##0.00")
            txtIPPQ.Text = ""

        Else
            MsgBox("Please input valid numbers")
        End If
    End Sub
End Class