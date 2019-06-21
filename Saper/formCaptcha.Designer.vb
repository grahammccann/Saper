<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCaptcha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formCaptcha))
        Me.txtBoxCaptchaReply = New System.Windows.Forms.TextBox()
        Me.btnSubmitCaptcha = New System.Windows.Forms.Button()
        Me.picBoxCaptcha = New System.Windows.Forms.PictureBox()
        CType(Me.picBoxCaptcha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBoxCaptchaReply
        '
        Me.txtBoxCaptchaReply.Location = New System.Drawing.Point(30, 42)
        Me.txtBoxCaptchaReply.Name = "txtBoxCaptchaReply"
        Me.txtBoxCaptchaReply.Size = New System.Drawing.Size(48, 20)
        Me.txtBoxCaptchaReply.TabIndex = 0
        '
        'btnSubmitCaptcha
        '
        Me.btnSubmitCaptcha.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitCaptcha.Location = New System.Drawing.Point(84, 39)
        Me.btnSubmitCaptcha.Name = "btnSubmitCaptcha"
        Me.btnSubmitCaptcha.Size = New System.Drawing.Size(35, 23)
        Me.btnSubmitCaptcha.TabIndex = 1
        Me.btnSubmitCaptcha.Text = "OK"
        Me.btnSubmitCaptcha.UseVisualStyleBackColor = True
        '
        'picBoxCaptcha
        '
        Me.picBoxCaptcha.Location = New System.Drawing.Point(30, 7)
        Me.picBoxCaptcha.Name = "picBoxCaptcha"
        Me.picBoxCaptcha.Size = New System.Drawing.Size(89, 30)
        Me.picBoxCaptcha.TabIndex = 2
        Me.picBoxCaptcha.TabStop = False
        '
        'formCaptcha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(145, 80)
        Me.Controls.Add(Me.picBoxCaptcha)
        Me.Controls.Add(Me.btnSubmitCaptcha)
        Me.Controls.Add(Me.txtBoxCaptchaReply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formCaptcha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captcha"
        CType(Me.picBoxCaptcha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBoxCaptchaReply As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmitCaptcha As System.Windows.Forms.Button
    Friend WithEvents picBoxCaptcha As System.Windows.Forms.PictureBox
End Class
