<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class attendance_report
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.attendanceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.studentDataSet1 = New Student.studentDataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.attendanceTableAdapter = New Student.studentDataSet1TableAdapters.attendanceTableAdapter()
        CType(Me.attendanceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.studentDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'attendanceBindingSource
        '
        Me.attendanceBindingSource.DataMember = "attendance"
        Me.attendanceBindingSource.DataSource = Me.studentDataSet1
        '
        'studentDataSet1
        '
        Me.studentDataSet1.DataSetName = "studentDataSet1"
        Me.studentDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.attendanceBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Student.attendance_report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1078, 585)
        Me.ReportViewer1.TabIndex = 0
        '
        'attendanceTableAdapter
        '
        Me.attendanceTableAdapter.ClearBeforeFill = True
        '
        'attendance_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 585)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "attendance_report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendance Report"
        CType(Me.attendanceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.studentDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents attendanceBindingSource As BindingSource
    Friend WithEvents studentDataSet1 As studentDataSet1
    Friend WithEvents attendanceTableAdapter As studentDataSet1TableAdapters.attendanceTableAdapter
End Class
