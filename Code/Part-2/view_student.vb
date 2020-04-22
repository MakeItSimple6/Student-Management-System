Public Class view_student
    Private Sub view_student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form Load'
        Try
            Me.StudentTableAdapter.Fill(Me.StudentDataSet.student)

            For i As Integer = 0 To DataGridView1.RowCount - 1
                If i Mod 2 = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                Else
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message.ToString())
        End Try

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
End Class