Imports System.Data.OleDb
Public Class frmAddProduct
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader

    Public isUpdate As Boolean
    Public currentUser As String
    Private Sub frmAddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Dim dateID As String
        dateID = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim Val As Double
        If txtPN.Text = "" Or txtPC.Text = "" Or txtPPQ.Text = "" Or txtPTQ.Text = "" Then
            MsgBox("Please supply required fields", vbCritical + vbOKOnly, "Message Prompt")
            Return
        End If

        cn.Open()

        cm = New OleDbCommand("Select ProductsName from tblManageInventory WHERE ProductsName = '" & txtPN.Text & "'", cn)
        dr = cm.ExecuteReader()

        'Checker for duplications of inputted date
        If dr.Read = True Then
            MsgBox("DUPLICATE ENTRY OF PRODUCT: The product is already existing on the system ", vbExclamation + vbOKOnly, "Message Prompt")
            txtPN.Text = ""
            txtPC.Text = ""
            txtPPQ.Text = ""
            txtPTQ.Text = ""
            dr.Close()
            cn.Close()
            Return
        End If

        dr.Close()
        cn.Close()

        If Double.TryParse(txtPTQ.Text, Val) And Double.TryParse(txtPPQ.Text, Val) And Double.TryParse(txtPC.Text, Val) Then

            Dim status, datePicker2 As String
            datePicker2 = DateTime.Now.ToString("MMMM dd, yyyy")
            status = "INSTOCK - " + datePicker2

            cn.Open()
            cm = New OleDbCommand("INSERT INTO tblManageInventory (colID, Status, ProductsName, ProductsCapital, ProductsPricePerQTY, ProductsTotalQTY, ProductsTotalSoldQTY, ProductsRemainingQTY, ProductsEarned ) 
                                            VALUES(@colID, @Status, @ProductsName, @ProductsCapital, @ProductsPricePerQTY, @ProductsTotalQTY, @ProductsTotalSoldQTY, @ProductsRemainingQTY, @ProductsEarned)", cn)

            With cm


                .Parameters.AddWithValue("@colID", dateID)
                .Parameters.AddWithValue("@Status", status)
                .Parameters.AddWithValue("@ProductsName", txtPN.Text)
                .Parameters.AddWithValue("@ProductsCapital", Format(CDbl(txtPC.Text), "#,##0.00"))
                .Parameters.AddWithValue("@ProductsPricePerQTY", Format(CDbl(txtPPQ.Text), "#,##0.00"))
                .Parameters.AddWithValue("@ProductsTotalQTY", CDbl(txtPTQ.Text))
                .Parameters.AddWithValue("@ProductsTotalSoldQTY", "0")
                .Parameters.AddWithValue("@ProductsRemainingQTY", CDbl(txtPTQ.Text))
                .Parameters.AddWithValue("@ProductsEarned", "0")

                cm.ExecuteNonQuery()

            End With
            cn.Close()


            MsgBox("New product has been successfully added to our database", vbInformation + vbOKOnly, "Message Prompt")

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


End Class