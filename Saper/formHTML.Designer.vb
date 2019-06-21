<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formHTML
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formHTML))
        Me.txtBoxDebugHTML = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtBoxDebugHTML
        '
        Me.txtBoxDebugHTML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtBoxDebugHTML.Location = New System.Drawing.Point(0, 0)
        Me.txtBoxDebugHTML.Multiline = True
        Me.txtBoxDebugHTML.Name = "txtBoxDebugHTML"
        Me.txtBoxDebugHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBoxDebugHTML.Size = New System.Drawing.Size(783, 493)
        Me.txtBoxDebugHTML.TabIndex = 0
        '
        'formHTML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 493)
        Me.Controls.Add(Me.txtBoxDebugHTML)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formHTML"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HTML Debugging..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBoxDebugHTML As System.Windows.Forms.TextBox
End Class
