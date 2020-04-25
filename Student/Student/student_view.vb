'Some changes has done in Form Load'

Public Class student_view
    Private Sub view_student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Student View Form Load'
        Try
            Me.StudentTableAdapter.Fill(Me.StudentDataSet1.student)

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

        'This one is add new to DataGridView show that the image now will be visible to full size'
        DirectCast(DataGridView1.Columns(7), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Stretch
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
End Class