Public Class member_report
    Private Sub member_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'studentDataSet3.member_card' table. You can move, or remove it, as needed.
        Me.member_cardTableAdapter.Fill(Me.studentDataSet3.member_card)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class