Imports System.Data.OleDb
Public Class member_manage
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim amount As Int32
    Private Sub member_manage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Membership Manage Form Load
        Try
            Me.Member_cardTableAdapter2.Fill(Me.StudentDataSet4.member_card)
            For i As Integer = 0 To DataGridView1.RowCount - 1
                If i Mod 2 = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.AliceBlue
                Else
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'DataGridView
        'This part of code for when clicking the date of the student that will automatically
        'appear in Textboxes....
        Dim Index As Integer
        Try
            With DataGridView1
                If e.RowIndex >= 0 And e.ColumnIndex = 1 Then
                    Index = .CurrentRow.Index
                    TextBox1.Text = .Rows(Index).Cells(0).Value
                    TextBox2.Text = .Rows(Index).Cells(1).Value
                    TextBox3.Text = .Rows(Index).Cells(2).Value
                End If
            End With
        Catch ex As Exception
            MsgBox("Selected Row is Empty", MessageBoxIcon.Information, "Warning!!")
        End Try
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Save
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    'Adding Deposit to transaction                    
                    .Connection = con
                    'Getting total amount before transaction
                    .CommandText = "Select [amount] from member_card where [mem_id]=" + TextBox1.Text + "and [student_id]=" + TextBox2.Text + ""
                    Dim amount_reader = .ExecuteReader
                    While amount_reader.Read
                        amount = amount_reader("amount")
                        amount = FormatCurrency(TextBox3.Text) - amount
                    End While
                    amount_reader.Close()

                    .CommandText = "Insert into transac([student_id],[description],[deposit]) values(@student_id,@description,@deposit)"

                    .Parameters.AddWithValue("@student_id", TextBox2.Text)
                    .Parameters.AddWithValue("@description", "Total amount has been updated..")
                    .Parameters.AddWithValue("@deposit", amount)

                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()

                    con.Open()
                    .Connection = con
                    'Updating amount
                    .CommandText = "Update member_card set amount='" + FormatCurrency(TextBox3.Text) + "' where mem_id=" + TextBox1.Text + " and student_id=" + TextBox2.Text
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Updated Successfully!")

                    'Refreshing DataGridView After updating each student membership'
                    Me.Member_cardTableAdapter2.Fill(Me.StudentDataSet4.member_card)
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
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Delete
        Try
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()
                With command
                    .Connection = con
                    .CommandText = "Delete from member_card where student_id=" & TextBox2.Text
                    .ExecuteNonQuery()
                    con.Close()
                    .Dispose()
                    MsgBox("Deleted Successfully!")
                    'Refreshing DataGridView After Deleting each student membership'
                    Me.Member_cardTableAdapter2.Fill(Me.StudentDataSet4.member_card)
                End With
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
            con.Close()
        End Try
    End Sub
End Class