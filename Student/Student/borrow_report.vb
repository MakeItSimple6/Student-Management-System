Public Class borrow_report
    Private Sub borrow_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'studentDataSet2.booked' table. You can move, or remove it, as needed.
        Me.bookedTableAdapter.Fill(Me.studentDataSet2.booked)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class