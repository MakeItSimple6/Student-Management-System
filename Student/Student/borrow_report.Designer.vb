<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class borrow_report
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.studentDataSet2 = New Student.studentDataSet2()
        Me.bookedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.bookedTableAdapter = New Student.studentDataSet2TableAdapters.bookedTableAdapter()
        CType(Me.studentDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bookedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet"
        ReportDataSource1.Value = Me.bookedBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Student.borrow_report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'studentDataSet2
        '
        Me.studentDataSet2.DataSetName = "studentDataSet2"
        Me.studentDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'bookedBindingSource
        '
        Me.bookedBindingSource.DataMember = "booked"
        Me.bookedBindingSource.DataSource = Me.studentDataSet2
        '
        'bookedTableAdapter
        '
        Me.bookedTableAdapter.ClearBeforeFill = True
        '
        'borrow_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "borrow_report"
        Me.Text = "borrow_report"
        CType(Me.studentDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bookedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents bookedBindingSource As BindingSource
    Friend WithEvents studentDataSet2 As studentDataSet2
    Friend WithEvents bookedTableAdapter As studentDataSet2TableAdapters.bookedTableAdapter
End Class
