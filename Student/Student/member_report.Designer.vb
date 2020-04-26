<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class member_report
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
        Me.studentDataSet3 = New Student.studentDataSet3()
        Me.member_cardBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.member_cardTableAdapter = New Student.studentDataSet3TableAdapters.member_cardTableAdapter()
        Me.MembercardBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.studentDataSet3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.member_cardBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MembercardBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.MembercardBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Student.member_report.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(803, 488)
        Me.ReportViewer1.TabIndex = 0
        '
        'studentDataSet3
        '
        Me.studentDataSet3.DataSetName = "studentDataSet3"
        Me.studentDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'member_cardBindingSource
        '
        Me.member_cardBindingSource.DataMember = "member_card"
        Me.member_cardBindingSource.DataSource = Me.studentDataSet3
        '
        'member_cardTableAdapter
        '
        Me.member_cardTableAdapter.ClearBeforeFill = True
        '
        'MembercardBindingSource
        '
        Me.MembercardBindingSource.DataMember = "member_card"
        Me.MembercardBindingSource.DataSource = Me.studentDataSet3
        '
        'member_report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 488)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "member_report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member Report"
        CType(Me.studentDataSet3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.member_cardBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MembercardBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents member_cardBindingSource As BindingSource
    Friend WithEvents studentDataSet3 As studentDataSet3
    Friend WithEvents member_cardTableAdapter As studentDataSet3TableAdapters.member_cardTableAdapter
    Friend WithEvents MembercardBindingSource As BindingSource
End Class
