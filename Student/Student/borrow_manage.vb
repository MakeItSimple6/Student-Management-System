Imports System.Data.OleDb
Public Class borrow_manage
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim total_books As Int32
    Dim available_books As Int32
    Private Sub borrow_manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Borrowed_Book Manage Form Load
        Try
            Me.BookedTableAdapter.Fill(Me.StudentDataSet2.booked)
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
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'DataGridView'
        'This part of code for when clicking the name of the student that will automatically
        'appear in Textboxes....
        Dim Index As Integer
        Try
            With DataGridView1
                If e.RowIndex >= 0 And e.ColumnIndex = 3 Then
                    Index = .CurrentRow.Index
                    TextBox1.Text = .Rows(Index).Cells(0).Value
                    TextBox2.Text = .Rows(Index).Cells(1).Value
                    TextBox3.Text = .Rows(Index).Cells(2).Value
                    TextBox4.Text = .Rows(Index).Cells(3).Value
                    DateTimePicker1.Value = .Rows(Index).Cells(4).Value
                    DateTimePicker2.Value = .Rows(Index).Cells(5).Value
                End If
            End With
        Catch ex As Exception
            MsgBox("Selected Row is Empty", MessageBoxIcon.Information, "Warning!!")
        End Try
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Save or Update'
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Update booked set date_taken='" + DateTimePicker1.Value.Date +
                                   "',due_date='" + DateTimePicker2.Value.Date +
                                   "' where booked_id=" + TextBox1.Text
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Updated Successfully!")
                    'Refreshing DataGridView After updateing each student borrowed'
                    Me.BookedTableAdapter.Fill(Me.StudentDataSet2.booked)
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
            con.Close()
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
                    'Getting available_books and total_books
                    .CommandText = "Select [total],[available] from books where [book_name] like '%" + TextBox2.Text + "%'"
                    Dim book_reader = .ExecuteReader
                    While book_reader.Read
                        total_books = book_reader("total")
                        available_books = book_reader("available")
                    End While
                    book_reader.Close()
                    'Delete the borrowed book
                    .CommandText = "Delete from booked where booked_id=" & TextBox1.Text
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Deleted Successfully!")
                    'Increasing available_book, which is now available
                    If available_books < total_books Then
                        available_books += 1
                        con.Open()
                        .Connection = con
                        .CommandText = "Update books set available=" & available_books & " where book_name like '%" & TextBox2.Text & "%'"
                        .ExecuteNonQuery()
                        con.Close()
                        .Dispose()
                    End If
                    'Refreshing DataGridView After Deleting each student attendance'
                    Me.BookedTableAdapter.Fill(Me.StudentDataSet2.booked)
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
            con.Close()
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Reset
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.Value = "01-01-2020"
        DateTimePicker2.Value = "01-01-2020"
    End Sub
End Class