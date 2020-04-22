Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
'Note'
'Change in add_student.vb'

'There are some little changes in add_student.vb go and see...'
'add new error message in catch block'

'Change to view_student.vb'

'Add new this to view_student.vb also go and see and '
'also go to datagridview property change "EnableHeadersVisualStyle = 'False' "'


'In manage_student.vb
'You can edit the student by search their student_name (in TextBox) or just click particular student_name in datagridview
'you can permanently delete the data from the database using delete button
'other parts are common..

Public Class manage_student
    Dim img As Byte()
    Dim bytImage() As Byte
    Private abyt As Byte()
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim Imagepath As String
    Private Sub manage_student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Form Load'

        'This one is add new to DataGridView show that the image now will be visible to full size'
        DirectCast(DataGridView1.Columns(6), DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Stretch
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

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
            'Added MessageBox.icon as Error'
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Search'
        Try
            With DataGridView1
                For index As Integer = 0 To .RowCount - 1
                    If .Rows(index).Cells(1).Value = TextBox5.Text Then
                        TextBox1.Text = .Rows(index).Cells(0).Value
                        TextBox2.Text = .Rows(index).Cells(1).Value
                        DateTimePicker1.Value = .Rows(index).Cells(2).Value
                        ComboBox1.Text = .Rows(index).Cells(3).Value
                        TextBox3.Text = .Rows(index).Cells(4).Value
                        TextBox4.Text = .Rows(index).Cells(5).Value

                        img = .Rows(index).Cells(6).Value

                        Dim ms As New MemoryStream(img)
                        PictureBox1.Image = Image.FromStream(ms)
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'In DataGridView
        'This part of code for when clicking the name of the student that will automatically
        'appear in Textboxes and comboBox....
        Dim Index As Integer
        Try
            With DataGridView1
                If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
                    Index = .CurrentRow.Index
                    TextBox1.Text = .Rows(Index).Cells(0).Value
                    TextBox2.Text = .Rows(Index).Cells(1).Value
                    DateTimePicker1.Value = .Rows(Index).Cells(2).Value
                    ComboBox1.Text = .Rows(Index).Cells(3).Value
                    TextBox3.Text = .Rows(Index).Cells(4).Value
                    TextBox4.Text = .Rows(Index).Cells(5).Value

                    img = .Rows(Index).Cells(6).Value

                    Dim ms As New MemoryStream(img)
                    PictureBox1.Image = Image.FromStream(ms)
                End If
            End With

        Catch ex As Exception
            MsgBox("Selected Row is Empty", MessageBoxIcon.Information, "Warning!!")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Image Upload'
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
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Clear Picture'
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Reset'
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        DateTimePicker1.Value = "01-01-1990"
        PictureBox1.Image = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Save or Update'
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Update student set student_name='" & TextBox2.Text & "' where id=" & TextBox1.Text & ""
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Updated Successfully!")

                    'Refreshing DataGridView After Deleting each student'
                    Me.StudentTableAdapter.Fill(Me.StudentDataSet.student)
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Delete'
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Delete from student where id=" & TextBox1.Text & ""
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Deleted Successfully!")

                    'Refreshing DataGridView After Deleting each student'
                    Me.StudentTableAdapter.Fill(Me.StudentDataSet.student)
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

End Class