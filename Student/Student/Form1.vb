Public Class Form1
    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        'Add Student'
        add_student.Show()
    End Sub

    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        'View Student'
        view_student.Show()
    End Sub

    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click
        'Manage Student'
        manage_student.Show()
    End Sub
End Class
