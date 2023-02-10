Imports System.Data.OleDb

Public Class frmAddSupplier
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Public bool As Boolean

    Public ID As String


    Private Sub frmAddSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"
        If bool = True Then
            btnAdd.Text = "Save"
            txtProduct.Text = ""
            txtName.Text = ""
            txtNumber.Text = ""
            txtAddress.Text = ""
        ElseIf bool = False Then
            btnAdd.Text = "Update"

        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtAddress.Text = "" Or txtName.Text = "" Or txtNumber.Text = "" Or txtProduct.Text = "" Then
            MsgBox("Please supply required fields", vbCritical + vbOKOnly, "Message Prompt")
            Return
        End If

        If btnAdd.Text = "Save" Then
            cn.Open()
            cm = New OleDbCommand("INSERT INTO tblContacts (ID, _Name, Address, Contact, Product) 
                                            VALUES(@ID, @_Name, @Address, @Contact, @Product)", cn)

            With cm


                .Parameters.AddWithValue("@ID", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Parameters.AddWithValue("@_Name", txtName.Text)
                .Parameters.AddWithValue("@Address", txtAddress.Text)
                .Parameters.AddWithValue("@Contact", txtNumber.Text)
                .Parameters.AddWithValue("@Product", txtProduct.Text)
                .ExecuteNonQuery()

            End With
            cn.Close()


            MsgBox("New client has been successfully added to our database", vbInformation + vbOKOnly, "Message Prompt")


        ElseIf btnAdd.Text = "Update" Then



            cn.Open()
            cm = New OleDbCommand("UPDATE tblContacts SET _Name = @_Name, Address = @Address, Contact = @Contact, Product = @Product  WHERE ID = '" & ID & "'", cn)
            With cm
                .Parameters.AddWithValue("@_Name", txtName.Text)
                .Parameters.AddWithValue("@Address", txtAddress.Text)
                .Parameters.AddWithValue("@Contact", txtNumber.Text)
                .Parameters.AddWithValue("@Product", txtProduct.Text)
                .ExecuteNonQuery()
            End With
            MsgBox("New client has been successfully updated to our database")
            cn.Close()



        End If


        Me.Close()

        With frmMain
            .openChildForm(New frmSuppliersContact())
        End With
    End Sub
End Class