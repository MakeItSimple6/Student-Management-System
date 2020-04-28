Imports System.Data.OleDb
Public Class Form2
    Public AppID As Integer = 0
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim get_date As Date
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Reminder Form Load
        'To display the Delete button, in order to delete the reminder
        If AppID <> 0 Then
            Button1.Visible = True
            DateTimePicker1.Enabled = False
        ElseIf AppID = 0 Then
            Try
                'This try is for addeding the student id into the student comboBox1
                With con
                    .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                    .Open()
                    ComboBox1.Items.Clear()
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
                con.Close()
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If String.IsNullOrWhiteSpace(ComboBox1.Text) Then
            MsgBox("Field is empty.")
            Return
        End If
        With con
            .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
            .Open()
            With command
                Try
                    If AppID = 0 Then

                        .Connection = con
                        .CommandText = "insert into calendar([student_id],[title],[details],[date_])
                                            values(@student_id,@title,@details,@date_)"

                        .Parameters.AddWithValue("@student_id", ComboBox1.Text)
                        .Parameters.AddWithValue("@title", TextBox1.Text)
                        .Parameters.AddWithValue("@details", TextBox2.Text)
                        .Parameters.AddWithValue("@date_", DateTimePicker1.Text)

                        .ExecuteNonQuery()
                        MsgBox("Reminder added for successfully", MessageBoxIcon.Information)
                        con.Close()
                        .Dispose()
                        Me.Close()
                    Else
                        .Connection = con
                        .CommandText = "update calendar set details='" & TextBox2.Text & "' where student_id=" & ComboBox1.Text & " and date_ like '%" & DateTimePicker1.Value & "%'"

                        .Parameters.AddWithValue("@student_id", ComboBox1.Text)
                        .Parameters.AddWithValue("@title", TextBox1.Text)
                        .Parameters.AddWithValue("@details", TextBox2.Text)
                        .Parameters.AddWithValue("@date_", DateTimePicker1.Text)

                        .ExecuteNonQuery()
                        MsgBox("Reminder updated successfully")
                        con.Close()
                        .Dispose()
                        Me.Close()
                    End If
                Catch ex As Exception
                    MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
                    con.Close()
                End Try
            End With
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Delete
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Delete from calendar where student_id=" & ComboBox1.Text & " and date_ like '%" & DateTimePicker1.Value & "%'"
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Deleted Successfully!  " & AppID)
                    Me.Close()
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
            con.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Close
        Me.Close()
    End Sub
End Class