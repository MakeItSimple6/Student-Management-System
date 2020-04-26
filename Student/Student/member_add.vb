Imports System.Data.OleDb
Public Class member_add
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim student_id As Int32
    Private Sub member_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Membership Add Form Load
        Try
            ' This try is for added the student id into the student comboBox1
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
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Add Member
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    'Getting date from particular Student'  
                    student_id = 0
                    .CommandText = "Select [student_id] from member_card where [student_id]=" + ComboBox1.Text
                    Dim date_reader = .ExecuteReader
                    While date_reader.Read
                        student_id = date_reader("student_id")
                    End While
                    date_reader.Close()
                    If ComboBox1.Text <> student_id Then
                        .Connection = con
                        .CommandText = "insert into member_card([student_id],[amount])
                                            values(@student_id,@amount)"

                        .Parameters.AddWithValue("@student_id", ComboBox1.Text)
                        .Parameters.AddWithValue("@amount", FormatCurrency(TextBox2.Text))

                        .ExecuteNonQuery()
                        MsgBox("Student Id : " & ComboBox1.Text & Environment.NewLine & "Your Membership Card is activated successfully!")
                        con.Close()
                        .Dispose()

                        'Add this value to transaction
                        con.Open()
                        .Connection = con
                        .CommandText = "Insert into transac([student_id],[description],[deposit]) values(@student_id,@description,@deposit)"

                        .Parameters.AddWithValue("@student_id", ComboBox1.Text)
                        .Parameters.AddWithValue("@description", "Initial Amount paid")
                        .Parameters.AddWithValue("@deposit", TextBox2.Text)

                        .ExecuteNonQuery()
                        con.Close()
                        .Dispose()
                    Else
                        MsgBox("You have already registered for Student Id : " & ComboBox1.Text, MessageBoxIcon.Information)
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
        TextBox2.Text = ""
    End Sub
End Class