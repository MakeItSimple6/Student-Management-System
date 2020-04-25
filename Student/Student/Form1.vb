Public Class Form1
    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        'Student Add 
        student_add.Show()
    End Sub
    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        'Student View 
        student_view.Show()
    End Sub
    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click
        'Student Manage 
        student_manage.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem.Click
        'Student Report
        student_report.Show()
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        'Attendace add 
        attendance_add.Show()
    End Sub
    Private Sub ViewToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem3.Click
        'Attendace View'
        attendance_view.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem3.Click
        'Attendace Report
        attendance_report.Show()
    End Sub
    Private Sub ManageToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem3.Click
        'Attendance Report
        attendance_manage.Show()
    End Sub
    Private Sub AddNewToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem2.Click
        'Fee add
        fee_add.Show()
    End Sub

    Private Sub ViewToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem2.Click
        'Fee View
        fee_view.Show()
    End Sub
    Private Sub ManageToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem2.Click
        'Fee Manage
        fee_manage.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem2.Click
        'Fee Report
        fee_report.Show()
    End Sub
End Class
