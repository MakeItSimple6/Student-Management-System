Imports System.IO
Imports System.Data.OleDb

Public Class add_student
    Dim bytImage() As Byte
    Private abyt As Byte()
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim Imagepath As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Image Upload'
        'Small Change'
        Try
            With OpenFileDialog1
                .Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All Files (*.*)|*.*"
                .FileName = ""
                .Title = "Choose a Picture..."
                .AddExtension = True
                .FilterIndex = 1
                .Multiselect = False
                .ValidateNames = True
                .RestoreDirectory = True

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim fs As New FileStream(.FileName, FileMode.Open)
                    Dim br As New BinaryReader(fs)
                    abyt = br.ReadBytes(CInt(fs.Length))
                    br.Close()
                    Dim ms As New MemoryStream(abyt)
                    PictureBox1.Image = Image.FromStream(ms)
                End If
            End With
        Catch ex As Exception
            'Added MessageBox.icon as Error'
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Clear'
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Close
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Reset
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        DateTimePicker1.Value = "01-01-1990"
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Add'
        'Small change'
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()

                With command
                    .Connection = con
                    .CommandText = "Insert into student([ID],[student_name],[course],[dob],[gender],[phone_no],[address],[image])
                                    Values(@id,@name,@course,@dob,@gender,@phone,@address,@image)"
                End With

                command.Parameters.AddWithValue("@id", TextBox1.Text)
                command.Parameters.AddWithValue("@name", TextBox2.Text)
                command.Parameters.AddWithValue("@course", ComboBox2.Text)
                command.Parameters.AddWithValue("@dob", DateTimePicker1.Value.Date)
                command.Parameters.AddWithValue("@gender", ComboBox1.Text)
                command.Parameters.AddWithValue("@phone", TextBox3.Text)
                command.Parameters.AddWithValue("@address", TextBox4.Text)
                command.Parameters.AddWithValue("@image", abyt)

                command.ExecuteNonQuery()
                MsgBox("Student Details Saved Successfully!")
                con.Close()
                command.Dispose()
            End With
        Catch ex As Exception
            'Added MessageBox.icon as Error'
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub add_student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Student Form Load
        With con
            .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
            .Open()

            With command
                .Connection = con
                'Finding the Course for particular student
                Label7.Text = ""
                .CommandText = "Select [course] from student"
                Dim reader_course = .ExecuteReader
                While reader_course.Read
                    ComboBox2.Items.Add(reader_course("course"))
                End While
                reader_course.Close()

            End With
            .Close()
            command.Dispose()
        End With
    End Sub
End Class