Imports System.Data.OleDb
Public Class fee_manage
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Private Sub fee_manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Fee Manage Load
        Try
            Me.FeeTableAdapter.Fill(Me.StudentDataSet.fee)
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
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Save'
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Update fee set price='" + FormatCurrency(TextBox5.Text) + "' where fee_id=" + TextBox1.Text + " and student_id=" + TextBox2.Text
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Updated Successfully!")
                    'Refreshing DataGridView After Deleting each student attendance'
                    Me.FeeTableAdapter.Fill(Me.StudentDataSet.fee)
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Delete
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Delete from fee where fee_id=" & TextBox1.Text
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Deleted Successfully!")

                    'Refreshing DataGridView After Deleting each student attendance'
                    Me.FeeTableAdapter.Fill(Me.StudentDataSet.fee)
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'DataGridView'
        'This part of code for when clicking the date of the student that will automatically
        'appear in Textboxes and comboBox....
        Dim Index As Integer
        Try
            With DataGridView1
                If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
                    Index = .CurrentRow.Index
                    TextBox1.Text = .Rows(Index).Cells(0).Value
                    TextBox2.Text = .Rows(Index).Cells(1).Value
                    TextBox3.Text = .Rows(Index).Cells(2).Value
                    TextBox4.Text = .Rows(Index).Cells(3).Value
                    TextBox5.Text = .Rows(Index).Cells(4).Value
                End If
            End With
        Catch ex As Exception
            MsgBox("Selected Row is Empty", MessageBoxIcon.Information, "Warning!!")
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Reset'
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub
End Class