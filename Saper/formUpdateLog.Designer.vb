<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formUpdateLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formUpdateLog))
        Me.txtBoxUpdates = New System.Windows.Forms.TextBox()
        Me.btnCloseUpdates = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtBoxUpdates
        '
        Me.txtBoxUpdates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBoxUpdates.Location = New System.Drawing.Point(0, 0)
        Me.txtBoxUpdates.Multiline = True
        Me.txtBoxUpdates.Name = "txtBoxUpdates"
        Me.txtBoxUpdates.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBoxUpdates.Size = New System.Drawing.Size(630, 414)
        Me.txtBoxUpdates.TabIndex = 0
        '
        'btnCloseUpdates
        '
        Me.btnCloseUpdates.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseUpdates.Location = New System.Drawing.Point(750, 312)
        Me.btnCloseUpdates.Name = "btnCloseUpdates"
        Me.btnCloseUpdates.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseUpdates.TabIndex = 1
        Me.btnCloseUpdates.Text = "Close"
        Me.btnCloseUpdates.UseVisualStyleBackColor = True
        '
        'formUpdateLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 414)
        Me.Controls.Add(Me.btnCloseUpdates)
        Me.Controls.Add(Me.txtBoxUpdates)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formUpdateLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Log..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBoxUpdates As System.Windows.Forms.TextBox
    Friend WithEvents btnCloseUpdates As System.Windows.Forms.Button
End Class
