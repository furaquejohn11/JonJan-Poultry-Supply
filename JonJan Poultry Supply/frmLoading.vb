Public Class frmLoading

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.ProgressBar1.Value = ProgressBar1.Value + 5
        Dim load As String
        load = ProgressBar1.Value
        Label1.Text = "Loading: " + load + "%"

        If ProgressBar1.Value >= 100 Then
            Timer1.Stop()
            frmLogIn.Show()
            ProgressBar1.ForeColor = Color.FromArgb(64, 58, 123)
            Me.Hide()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class