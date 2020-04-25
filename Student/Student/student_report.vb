Public Class student_report
    Private Sub student_report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Student form load
        Me.StudentTableAdapter.Fill(Me.StudentDataSet1.student)

        'Report Viewer'
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class