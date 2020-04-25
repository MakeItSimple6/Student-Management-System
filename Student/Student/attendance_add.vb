Imports System.Data.OleDb

Public Class attendance_add
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim get_date As Date
    Private Sub attendance_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Attendance Form Load
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

                .Close()
                command.Dispose()
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
        'refresh current time'
        gettime()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Attendance Add'
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    'Getting date from particular Student'  
                    get_date = "01-01-2000"
                    .CommandText = "Select [date_] from attendance where [student_id]=" + ComboBox1.Text + " and [date_] like '%" + DateTimePicker1.Value + "%'"
                    Dim date_reader = .ExecuteReader
                    While date_reader.Read
                        get_date = date_reader("date_")
                    End While
                    date_reader.Close()
                    If DateTimePicker1.Value.Date <> get_date Then
                        .Connection = con
                        .CommandText = "insert into attendance([student_id],[status],[date_],[time_in],[time_out],[course])
                                            values(@student_id,@status,@date,@time_in,@time_out,@course)"

                        .Parameters.AddWithValue("@student_id", ComboBox1.Text)
                        .Parameters.AddWithValue("@status", ComboBox2.Text)
                        .Parameters.AddWithValue("@date", DateTimePicker1.Value)
                        .Parameters.AddWithValue("@time_in", TextBox1.Text)
                        .Parameters.AddWithValue("@time_out", TextBox2.Text)
                        .Parameters.AddWithValue("@course", Label7.Text)

                        .ExecuteNonQuery()
                        MsgBox("Attendance addED for Student Id : " & ComboBox1.Text & " successfully!")
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
    Private Sub course_value(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        'Course Name' 
        'This block is for selected the specific student course using hie student id.
        With con
            .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
            .Open()

            With command
                .Connection = con
                'Finding the Course for particular student
                Label7.Text = ""
                .CommandText = "Select [course] from student where id=" + ComboBox1.Text + ""
                Dim reader2 = .ExecuteReader
                While reader2.Read
                    Label7.Text = reader2("course")
                End While
                reader2.Close()
            End With
            .Close()
            command.Dispose()
        End With
    End Sub
    Sub gettime()
        'This gettime() is used for form load and refresh timein
        TextBox1.Text = Format(Now, "hh:mm:ss")
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Refresh current time'
        gettime()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Refresh timeout
        TextBox2.Text = Format(Now, "hh:mm:ss")
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Reset'
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        DateTimePicker1.Value = "01-01-1990"
        TextBox1.Text = "00:00:00"
        TextBox2.Text = "00:00:00"
        Label7.Text = ""
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Close'
        Me.Close()
    End Sub
End Class