Public Class fee_report
    Private Sub fee_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StudentDataSet.fee' table. You can move, or remove it, as needed.
        Me.FeeTableAdapter.Fill(Me.StudentDataSet.fee)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class