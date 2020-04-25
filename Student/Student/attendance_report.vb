Public Class attendance_report
    Private Sub attendance_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'studentDataSet1.attendance' table. You can move, or remove it, as needed.
        Me.attendanceTableAdapter.Fill(Me.studentDataSet1.attendance)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class