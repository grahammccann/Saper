<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStats
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formStats))
        Me.gbStats = New System.Windows.Forms.GroupBox()
        Me.txtBoxStats = New System.Windows.Forms.TextBox()
        Me.gbStats.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbStats
        '
        Me.gbStats.Controls.Add(Me.txtBoxStats)
        Me.gbStats.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStats.Location = New System.Drawing.Point(12, 5)
        Me.gbStats.Name = "gbStats"
        Me.gbStats.Size = New System.Drawing.Size(213, 364)
        Me.gbStats.TabIndex = 0
        Me.gbStats.TabStop = False
        Me.gbStats.Text = "Sape Statistics"
        '
        'txtBoxStats
        '
        Me.txtBoxStats.BackColor = System.Drawing.SystemColors.MenuText
        Me.txtBoxStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBoxStats.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtBoxStats.Location = New System.Drawing.Point(3, 19)
        Me.txtBoxStats.Multiline = True
        Me.txtBoxStats.Name = "txtBoxStats"
        Me.txtBoxStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBoxStats.Size = New System.Drawing.Size(207, 342)
        Me.txtBoxStats.TabIndex = 1
        '
        'formStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(235, 381)
        Me.Controls.Add(Me.gbStats)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formStats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sape Statistics"
        Me.gbStats.ResumeLayout(False)
        Me.gbStats.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbStats As System.Windows.Forms.GroupBox
    Friend WithEvents txtBoxStats As System.Windows.Forms.TextBox
End Class
