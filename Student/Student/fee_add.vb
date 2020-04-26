Imports System.Data.OleDb
Public Class fee_add
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim student_id As Int32
    Private Sub fee_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Fee Add Form Load
        Try
            ' This try is for added the student id into the student comboBox1 and
            ' course name to course name to ComboBox3
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Select [id] from student"
                    Dim reader1 = .ExecuteReader
                    While reader1.Read
                        ComboBox1.Items.Add(reader1("id"))
                    End While
                    reader1.Close()
                End With
                command.Dispose()
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub course_name(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        'Course And Degree
        'This block is for selected the specific student course using the student id.
        With con
            .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
            .Open()
            With command
                .Connection = con
                'Finding the Course for particular student
                TextBox1.Text = ""
                .CommandText = "Select [course] from student where id=" + ComboBox1.Text
                Dim reader2 = .ExecuteReader
                While reader2.Read
                    TextBox1.Text = reader2("course")
                End While
                reader2.Close()
                'Finding the degree 
                TextBox2.Text = ""
                .CommandText = "Select [degree] from course where course='" + TextBox1.Text + "'"
                Dim reader_degree = .ExecuteReader
                While reader_degree.Read
                    TextBox2.Text = reader_degree("degree")
                End While
                reader_degree.Close()
            End With
            .Close()
            command.Dispose()
        End With
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Fee Add
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    'Getting studentid
                    .CommandText = "Select [student_id] from fee where [student_id]=" + ComboBox1.Text
                    Dim date_reader = .ExecuteReader
                    While date_reader.Read
                        student_id = date_reader("student_id")
                    End While
                    date_reader.Close()

                    If ComboBox1.Text <> student_id Then
                        .Connection = con
                        .CommandText = "insert into fee([student_id],[course],[price],[degree])
                                            values(@student_id,@course,@price,@degree)"

                        .Parameters.AddWithValue("@student_id", ComboBox1.Text)
                        .Parameters.AddWithValue("@course", TextBox1.Text)
                        .Parameters.AddWithValue("@price", FormatCurrency(TextBox3.Text))
                        .Parameters.AddWithValue("@degree", TextBox2.Text)

                        .ExecuteNonQuery()
                        MsgBox("Feed added for Student Id : " & ComboBox1.Text & " successfully!")
                        con.Close()
                        .Dispose()
                    Else
                        MsgBox("You already completed for Student Id : " & ComboBox1.Text, MessageBoxIcon.Information)
                        con.Close()
                    End If
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
            con.Close()
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Close
        Me.Close()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Reset
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class