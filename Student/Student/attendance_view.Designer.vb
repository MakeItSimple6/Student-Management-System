<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class attendance_view
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.StudentDataSet1 = New Student.studentDataSet1()
        Me.AttendanceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AttendanceTableAdapter = New Student.studentDataSet1TableAdapters.attendanceTableAdapter()
        Me.AttenidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StudentidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeinDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TimeoutDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CourseDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StudentDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttendanceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.GrayText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeight = 40
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AttenidDataGridViewTextBoxColumn, Me.StudentidDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.DateDataGridViewTextBoxColumn, Me.TimeinDataGridViewTextBoxColumn, Me.TimeoutDataGridViewTextBoxColumn, Me.CourseDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.AttendanceBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 170
        Me.DataGridView1.Size = New System.Drawing.Size(1148, 822)
        Me.DataGridView1.TabIndex = 1
        '
        'StudentDataSet1
        '
        Me.StudentDataSet1.DataSetName = "studentDataSet1"
        Me.StudentDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AttendanceBindingSource
        '
        Me.AttendanceBindingSource.DataMember = "attendance"
        Me.AttendanceBindingSource.DataSource = Me.StudentDataSet1
        '
        'AttendanceTableAdapter
        '
        Me.AttendanceTableAdapter.ClearBeforeFill = True
        '
        'AttenidDataGridViewTextBoxColumn
        '
        Me.AttenidDataGridViewTextBoxColumn.DataPropertyName = "atten_id"
        Me.AttenidDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.AttenidDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.AttenidDataGridViewTextBoxColumn.Name = "AttenidDataGridViewTextBoxColumn"
        '
        'StudentidDataGridViewTextBoxColumn
        '
        Me.StudentidDataGridViewTextBoxColumn.DataPropertyName = "student_id"
        Me.StudentidDataGridViewTextBoxColumn.HeaderText = "STUDENT ID"
        Me.StudentidDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.StudentidDataGridViewTextBoxColumn.Name = "StudentidDataGridViewTextBoxColumn"
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "STATUS"
        Me.StatusDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "date_"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "DATE"
        Me.DateDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        '
        'TimeinDataGridViewTextBoxColumn
        '
        Me.TimeinDataGridViewTextBoxColumn.DataPropertyName = "time_in"
        Me.TimeinDataGridViewTextBoxColumn.HeaderText = "TIME IN"
        Me.TimeinDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.TimeinDataGridViewTextBoxColumn.Name = "TimeinDataGridViewTextBoxColumn"
        '
        'TimeoutDataGridViewTextBoxColumn
        '
        Me.TimeoutDataGridViewTextBoxColumn.DataPropertyName = "time_out"
        Me.TimeoutDataGridViewTextBoxColumn.HeaderText = "TIME OUT"
        Me.TimeoutDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.TimeoutDataGridViewTextBoxColumn.Name = "TimeoutDataGridViewTextBoxColumn"
        '
        'CourseDataGridViewTextBoxColumn
        '
        Me.CourseDataGridViewTextBoxColumn.DataPropertyName = "course"
        Me.CourseDataGridViewTextBoxColumn.HeaderText = "COURSE"
        Me.CourseDataGridViewTextBoxColumn.MinimumWidth = 6
        Me.CourseDataGridViewTextBoxColumn.Name = "CourseDataGridViewTextBoxColumn"
        '
        'attendance_view
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1148, 822)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "attendance_view"
        Me.Text = "Attendance View"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StudentDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttendanceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents StudentDataSet1 As studentDataSet1
    Friend WithEvents AttendanceBindingSource As BindingSource
    Friend WithEvents AttendanceTableAdapter As studentDataSet1TableAdapters.attendanceTableAdapter
    Friend WithEvents AttenidDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StudentidDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TimeinDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TimeoutDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CourseDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
