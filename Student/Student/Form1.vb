Imports System.Data.OleDb
Public Class Form1
    Dim con As New OleDbConnection
    Dim constr As String
    Dim command As New OleDbCommand
    Dim get_date As Date
    Dim hour As Int32 = 0
    Dim minute As Int32 = 0
    Private listFlDay As New List(Of FlowLayoutPanel)
    Private currentDate As DateTime = DateTime.Today
    Private Sub AddNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem.Click
        'Student Add 
        student_add.Show()
    End Sub
    Private Sub ViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem.Click
        'Student View 
        student_view.Show()
    End Sub
    Private Sub ManageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem.Click
        'Student Manage 
        student_manage.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem.Click
        'Student Report
        student_report.Show()
    End Sub
    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        'Attendace add 
        attendance_add.Show()
    End Sub
    Private Sub ViewToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem3.Click
        'Attendace View'
        attendance_view.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem3.Click
        'Attendace Report
        attendance_report.Show()
    End Sub
    Private Sub ManageToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem3.Click
        'Attendance Report
        attendance_manage.Show()
    End Sub
    Private Sub AddNewToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem2.Click
        'Fee add
        fee_add.Show()
    End Sub
    Private Sub ViewToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem2.Click
        'Fee View
        fee_view.Show()
    End Sub
    Private Sub ManageToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem2.Click
        'Fee Manage
        fee_manage.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem2.Click
        'Fee Report
        fee_report.Show()
    End Sub
    Private Sub AddToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem1.Click
        'Borrowed Book Add
        borrow_add.Show()
    End Sub
    Private Sub ViewToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem4.Click
        'Borrowed Book View
        borrow_view.Show()
    End Sub
    Private Sub ManageToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem4.Click
        'Borrowed Book Manage
        borrow_manage.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem4.Click
        'Borrowed Book Report
        borrow_report.Show()
    End Sub
    Private Sub AddNewToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AddNewToolStripMenuItem3.Click
        'Membership Add
        member_add.Show()
    End Sub
    Private Sub ViewToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ViewToolStripMenuItem5.Click
        'Membership View
        member_view.Show()
    End Sub
    Private Sub ManageToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ManageToolStripMenuItem5.Click
        'Membership Manage
        member_manage.Show()
    End Sub
    Private Sub PrintReportToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles PrintReportToolStripMenuItem5.Click
        'Membership Report
        member_report.Show()
    End Sub
    Private Sub HistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoryToolStripMenuItem.Click
        'History
        history.Show()
    End Sub

    '
    'From here onwards, Calender Coding started
    '
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Main Form Load
        GenerateDayPanel(42)
        DisplayCurrentDate()
        'To Generate Report
        Report()
    End Sub

    Private Sub Report()
        Try
            Dim count_student As Int32 = 0
            Dim cs As Int32 = 0
            Dim ct As Int32 = 0
            Dim ca As Int32 = 0
            Dim it As Int32 = 0
            Dim se As Int32 = 0
            Dim present As Int32 = 0
            Dim absent As Int32 = 0
            Dim late As Int32 = 0
            Dim sick As Int32 = 0
            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()

                With command
                    'Getting Total number of Student and per course
                    .Connection = con
                    .CommandText = "Select [id],[course] from student"
                    Dim reader1 = .ExecuteReader
                    While reader1.Read
                        If reader1("id") Then
                            count_student += 1
                        End If
                        If reader1("course").ToString = "Computer Science" Then
                            cs += 1
                        End If
                        If reader1("course").ToString = "Computer Technology" Then
                            ct += 1
                        End If
                        If reader1("course").ToString = "Computer Application" Then
                            ca += 1
                        End If
                        If reader1("course").ToString = "Information Technology" Then
                            it += 1
                        End If
                        If reader1("course").ToString = "Software Engineering" Then
                            se += 1
                        End If
                    End While
                    reader1.Close()
                    con.Close()
                    command.Dispose()

                    'Finding Status(Present/Absent....) for total class
                    Dim startDate As DateTime = New Date(currentDate.Year, currentDate.Month, currentDate.Day)

                    con.Open
                    .Connection = con
                    .CommandText = "SELECT * from attendance where date_ like '%" & startDate & "'"
                    Dim reader2 = .ExecuteReader
                    While reader2.Read
                        If reader2("status").ToString = "Present" Then
                            present += 1
                        End If
                        If reader2("status").ToString = "Absent" Then
                            absent += 1
                        End If
                        If reader2("status").ToString = "Sick" Then
                            sick += 1
                        End If
                        If reader2("status").ToString = "Late" Then
                            late += 1
                        End If
                    End While
                    reader2.Close()
                    con.Close()
                    command.Dispose()
                End With
                'Generating the Totals of attendance, student & per course...
                Label8.Text = "Present : " & present
                Label9.Text = "Absent : " & absent
                Label10.Text = "Late : " & late
                Label11.Text = "Sick : " & sick
                Label12.Text = "Total Number of Student : " & count_student
                Label13.Text = "Computer Science : " & cs & Environment.NewLine &
                                "Computer Technology : " & ct & Environment.NewLine &
                                "Computer Application : " & ca & Environment.NewLine &
                                "Information Technology : " & it & Environment.NewLine &
                                "Software Engineering : " & se & Environment.NewLine
            End With
        Catch ex As Exception
            MsgBox("Error : " + ex.Message.ToString(), MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateDayPanel(ByVal totalDays As Integer)
        'Allocating space for Days Slot
        FlowLayoutPanel1.Controls.Clear()
        listFlDay.Clear()
        For i As Integer = 1 To totalDays
            Dim flow As New FlowLayoutPanel
            flow.Name = $"FlowLayoutPanel{i}"
            flow.Size = New Size(128, 99)
            flow.BackColor = Color.White
            flow.BorderStyle = BorderStyle.Fixed3D
            flow.Cursor = Cursors.Hand
            flow.AutoScroll = True

            'Calling New Appointment Window
            AddHandler flow.Click, AddressOf AddNewReminder
            FlowLayoutPanel1.Controls.Add(flow)
            listFlDay.Add(flow)
        Next
    End Sub

    Private Sub AddNewReminder(ByVal sender As Object, e As EventArgs)
        'Going to Form2 to collect details of the event
        Dim day As Integer = CType(sender, FlowLayoutPanel).Tag
        If day <> 0 Then
            With Form2
                .AppID = 0
                .TextBox1.Text = ""
                .TextBox2.Text = ""
                .ComboBox1.Text = ""
                .DateTimePicker1.Value = New Date(currentDate.Year, currentDate.Month, day)
                .ShowDialog()
            End With
            DisplayCurrentDate()
        End If
    End Sub

    Private Sub DisplayCurrentDate()
        'Displaying the current month date
        lblMonthAndYear.Text = currentDate.ToString("MMMM, yyyy")
        Dim firstDayAtFlowNumber As Integer = GetFirstDayOfWeekOfCurrentDate()
        Dim totalDay As Integer = GetTotalDaysOfCurrentDate()
        AddLabelDayToFlDay(firstDayAtFlowNumber, totalDay)
        AddReminderToFlDay(firstDayAtFlowNumber)
    End Sub

    Private Function GetFirstDayOfWeekOfCurrentDate() As Integer
        'Getting 1st day of the Week of current Date
        Dim firstDayOfMonth As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstDayOfMonth.DayOfWeek + 1
    End Function

    Private Function GetTotalDaysOfCurrentDate() As Integer
        'Getting total number day of the Week of current Date
        Dim firstDayOfCurrentDate As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstDayOfCurrentDate.AddMonths(1).AddDays(-1).Day
    End Function

    Private Sub AddLabelDayToFlDay(ByVal startDayAtFlNumber As Integer, ByVal totalDaysInMonth As Integer)
        'Adding Date of the Month to every label
        For Each fl As FlowLayoutPanel In listFlDay
            fl.Controls.Clear()
            fl.Tag = 0
            fl.BackColor = Color.White
        Next

        For i As Integer = 1 To totalDaysInMonth
            Dim lbl As New Label
            lbl.Name = $"lblDay{i}"
            lbl.AutoSize = False
            lbl.TextAlign = ContentAlignment.MiddleRight
            lbl.Size = New Size(110, 22)
            lbl.Text = i
            lbl.Font = New Font("Microsoft Sans Serif", 12)
            listFlDay((i - 1) + (startDayAtFlNumber - 1)).Tag = i
            listFlDay((i - 1) + (startDayAtFlNumber - 1)).Controls.Add(lbl)

            'Higlighting the current Day
            If New Date(currentDate.Year, currentDate.Month, i) = Date.Today Then
                listFlDay((i - 1) + (startDayAtFlNumber - 1)).BackColor = Color.Gray
            End If
        Next
    End Sub

    Private Sub AddReminderToFlDay(ByVal startDayAtFlNumber As Integer)
        'Displaying already stored reminders
        Try

            Dim startDate As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
            Dim endDate As DateTime = startDate.AddMonths(1).AddDays(-1)

            With con
                .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Kamar\Desktop\Student Management System\student.accdb"
                .Open()

                With command
                    .Connection = con
                    .CommandText = "SELECT * from calendar where date_ Between #" &
                                            startDate.ToString("MM/dd/yyyy") & "# And #" &
                                            endDate.ToString("MM/dd/yyyy") & "#"
                    Dim reader1 = .ExecuteReader

                    While reader1.Read
                        Dim appDay As DateTime = DateTime.Parse(reader1("date_"))
                        Dim link As New LinkLabel
                        link.Tag = reader1("ID")
                        link.Name = $"link{reader1("ID")}"
                        link.Text = reader1("title")
                        'When clicking text of message we can edit that message
                        AddHandler link.Click, AddressOf ShowAppointmentDetail
                        listFlDay((appDay.Day - 1) + (startDayAtFlNumber - 1)).Controls.Add(link)
                    End While
                    reader1.Close()
                End With
                .Close()
                command.Dispose()
            End With
        Catch ex As Exception
            MsgBox("Error:" + ex.Message.ToString, MessageBoxIcon.Error)
            con.Close()
            Me.Close
        End Try
    End Sub

    Private Sub ShowAppointmentDetail(sender As Object, e As EventArgs)
        'This will allow you to edit the existing data by
        'display it to the Form2
        Dim appID As Integer = CType(sender, LinkLabel).Tag
        Dim sql As String = $"select * from calendar where ID = {appID}"
        Dim da As New OleDbDataAdapter(sql, con)
        Dim ds As New DataSet
        da.Fill(ds, "result")
        Dim dt As DataTable = ds.Tables("result")

        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            With Form2
                .AppID = appID
                .TextBox1.Text = row("title")
                .TextBox2.Text = row("details")
                .ComboBox1.Text = row("student_id")
                .DateTimePicker1.Value = row("date_")
                .ShowDialog()
            End With
            DisplayCurrentDate()
        End If
    End Sub

    Private Sub btnPrevMonth_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Refreshing The display for Previous Month
        currentDate = currentDate.AddMonths(-1)
        DisplayCurrentDate()
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Refreshing The display for Next Month
        currentDate = currentDate.AddMonths(1)
        DisplayCurrentDate()
    End Sub

    Private Sub btnToday_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Refreshing The display for Today
        currentDate = DateTime.Today
        DisplayCurrentDate()
    End Sub

End Class
