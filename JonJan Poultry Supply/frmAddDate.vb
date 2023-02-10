Imports System.Data.OleDb
Public Class frmAddDate
    Public cn As New OleDbConnection
    Public cm As New OleDbCommand
    Public dr As OleDbDataReader
    Public isUpdate As Boolean

    Private Sub frmAddDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cn = New OleDbConnection()
        cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\jjpsdatabase.accdb"

        With frmMain
            txtClientsUsername.Text = .username
            txtClientsName.Text = .clientName

        End With

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'Declaring a string to set the data of colDate in a specific format
        Dim datePicker, datePicker2 As String
        Dim dateUpdate As Date
        datePicker = Format(txtDate.Value, "yyyy-MM-dd: dddd")
        datePicker2 = Format(txtDate.Value, "MMMM dd, yyyy")
        dateUpdate = Format(txtDate.Value, "yyyy-MM-dd")

        'Condition for the texts
        If txtClientsUsername.Text = "" Or txtClientsName.Text = "" Then
            MsgBox("Please supply required fields", vbCritical + vbOKOnly, "Message Prompt")
            Return
        End If

        cn.Open()

                cm = New OleDbCommand("Select colDate from tblHome WHERE colDate = '" & datePicker & "'", cn)
                dr = cm.ExecuteReader()

                'Checker for duplications of inputted date
                If dr.Read = True Then
            MsgBox("DUPLICATE ENTRY: The Date has been already saved to the system", vbExclamation + vbOKOnly, "Message Prompt")
            dr.Close()
                    cn.Close()
                    Return
                End If

                dr.Close()
        cn.Close()

        cn.Open()

        cm = New OleDbCommand("INSERT INTO tblHome (colDate, colClientsUsername, colClientsName, colLastUpdatedOn, colLastUpdatedBy, colDate2, colDate3) VALUES(@colDate, @colClientsUsername, @colClientsName, @colLastUpdatedOn, @colLastUpdatedBy, @colDate2, @colDate3 )", cn)

        With cm

            'Saving inputted data from the textbox

            .Parameters.AddWithValue("@colDate", datePicker)
            .Parameters.AddWithValue("@colClientsUsername", txtClientsUsername.Text)
            .Parameters.AddWithValue("@colClientsName", txtClientsName.Text)
            .Parameters.AddWithValue("@colLastUpdatedOn", "None")
            .Parameters.AddWithValue("@colLastUpdatedBy", "None")
            .Parameters.AddWithValue("@colDate2", datePicker2)
            .Parameters.AddWithValue("@colDate3", dateUpdate)

            .ExecuteNonQuery()
        End With
        cn.Close()

        isUpdate = True

        If isUpdate = True Then
            cn.Open()
            cm = New OleDbCommand("INSERT INTO tblSum (colDateID, colDate, totalQTY, totalSales) 
                               VALUES(@colDateID, @colDate, @totalQTY, @totalSales)", cn)
            With cm
                .Parameters.AddWithValue("@colDateID", datePicker)
                .Parameters.AddWithValue("@colDate", dateUpdate)
                .Parameters.AddWithValue("@totalQTY", 0)
                .Parameters.AddWithValue("@totalSales", 0)
                .ExecuteNonQuery()
            End With
            cn.Close()

        End If

        MsgBox("New Report has been successfully added to our database", vbInformation + vbOKOnly, "Message Prompt")
        frmHome.Close()

        txtClientsUsername.Text = ""
        txtClientsName.Text = ""

        'Refreshing the childform after filling up the form to make the table updates
        Dim mForm As New frmMain
        Dim formHome As New frmHome
        mForm = frmMain
        formHome = frmHome
        mForm.reloadHome()
        formHome.dateOrder()
        Me.Close()


    End Sub

End Class