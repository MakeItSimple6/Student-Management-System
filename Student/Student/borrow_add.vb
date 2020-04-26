Imports System.Data.OleDb
Public Class borrow_add
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim student_id As Int32
    Dim total_books As Int32
    Dim available_books As Int32
    Private Sub borrow_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Borrow Add Form Load
        Try
            ' This try is for added the student id into the student comboBox2 and
            ' book name to course name to ComboBox1
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    'For Adding Name of the Book
                    .CommandText = "Select [book_name] from books"
                    Dim reader_book = .ExecuteReader
                    While reader_book.Read
                        ComboBox1.Items.Add(reader_book("book_name"))
                    End While
                    reader_book.Close()
                    'For adding Student Id
                    .CommandText = "Select [id] from student"
                    Dim reader_student = .ExecuteReader
                    While reader_student.Read
                        ComboBox2.Items.Add(reader_student("id"))
                    End While
                    reader_student.Close()
                End With
                Command.Dispose()
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub student_name(sender As Object, e As EventArgs) Handles ComboBox2.SelectedValueChanged
        'Finding student name
        'This block is for displaying the specific Student Name using the student id.
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    'Finding the Course for particular student
                    TextBox1.Text = ""
                    .CommandText = "Select [student_name] from student where id=" + ComboBox2.Text
                    Dim reader_stu_name = .ExecuteReader
                    While reader_stu_name.Read
                        TextBox1.Text = reader_stu_name("student_name")
                    End While
                    reader_stu_name.Close()
                End With
                command.Dispose()
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Borrow Add
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    'Getting available_books and total_books
                    .CommandText = "Select [total],[available] from books where [book_name] like '%" + ComboBox1.Text + "%'"
                    Dim book_reader = .ExecuteReader
                    While book_reader.Read
                        total_books = book_reader("total")
                        available_books = book_reader("available")
                    End While
                    book_reader.Close()

                    If total_books >= available_books And available_books <> 0 Then

                        .CommandText = "insert into booked([book_name],[student_id],[student_name],[date_taken],[due_date])
                                            values(@book_name,@student_id,@student_name,@degree,@due_date)"

                        .Parameters.AddWithValue("@book_name", ComboBox1.Text)
                        .Parameters.AddWithValue("@student_id", ComboBox2.Text)
                        .Parameters.AddWithValue("@student_name", TextBox1.Text)
                        .Parameters.AddWithValue("@date_taken", DateTimePicker1.Text)
                        .Parameters.AddWithValue("@ude_date", DateTimePicker2.Text)

                        .ExecuteNonQuery()
                        MsgBox("Borrowed book added for Student Id : " & ComboBox1.Text & " successfully!")
                        .Dispose()
                        con.Close()
                        'Decreasing available_book, which is booked
                        If available_books > 0 Then
                            available_books -= 1
                            con.Open()
                            .Connection = con
                            .CommandText = "Update books set available=" & available_books & " where book_name like '%" & ComboBox1.Text & "%'"
                            .ExecuteNonQuery()
                            con.Close()
                            .Dispose()
                        End If
                    Else
                        MsgBox("The Book you requested is not available now!!" & Environment.NewLine & "Please check back later...", MessageBoxIcon.Information)
                        con.Close()
                    End If
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Generating Due Date
        Try
            Dim datex As DateTime = DateTimePicker2.Value
            If TextBox2.Text <> "" And TextBox2.Text <> "-" Then
                DateTimePicker2.Value = datex.AddDays(TextBox2.Text)
            End If
        Catch ex As Exception
            MsgBox("Check Your Value!!!" & Environment.NewLine & "Can Increase and Decrease the Date only", MessageBoxIcon.Error)
        End Try
    End Sub
End Class