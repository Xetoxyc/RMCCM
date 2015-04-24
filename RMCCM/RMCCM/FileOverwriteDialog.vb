Public Class FileOverwriteDialog
    Public Sub New(ByVal strFile As String)
        InitializeComponent()

        lblInfo.Text = "Data """ & strFile & """ already exists." & vbCrLf & "Should it be overwritten?"
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnYesAll_Click(sender As Object, e As EventArgs) Handles btnYesAll.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnNoAll_Click(sender As Object, e As EventArgs) Handles btnNoAll.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub
End Class