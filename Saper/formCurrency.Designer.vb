<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCurrency
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formCurrency))
        Me.lblDollarCheck = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCheckCurrency = New System.Windows.Forms.Button()
        Me.txtBoxDecimal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPoundCheck = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDollarCheck
        '
        Me.lblDollarCheck.AutoSize = True
        Me.lblDollarCheck.Location = New System.Drawing.Point(16, 26)
        Me.lblDollarCheck.Name = "lblDollarCheck"
        Me.lblDollarCheck.Size = New System.Drawing.Size(16, 15)
        Me.lblDollarCheck.TabIndex = 0
        Me.lblDollarCheck.Text = "..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnCheckCurrency)
        Me.GroupBox1.Controls.Add(Me.txtBoxDecimal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblPoundCheck)
        Me.GroupBox1.Controls.Add(Me.lblDollarCheck)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(383, 150)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Currency Rates:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(192, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Rubles."
        '
        'btnCheckCurrency
        '
        Me.btnCheckCurrency.Image = Global.Saper.My.Resources.Resources.ico_calculator
        Me.btnCheckCurrency.Location = New System.Drawing.Point(318, 62)
        Me.btnCheckCurrency.Name = "btnCheckCurrency"
        Me.btnCheckCurrency.Size = New System.Drawing.Size(59, 76)
        Me.btnCheckCurrency.TabIndex = 4
        Me.btnCheckCurrency.UseVisualStyleBackColor = True
        '
        'txtBoxDecimal
        '
        Me.txtBoxDecimal.Location = New System.Drawing.Point(132, 115)
        Me.txtBoxDecimal.Name = "txtBoxDecimal"
        Me.txtBoxDecimal.Size = New System.Drawing.Size(58, 23)
        Me.txtBoxDecimal.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Amount to convert:"
        '
        'lblPoundCheck
        '
        Me.lblPoundCheck.AutoSize = True
        Me.lblPoundCheck.Location = New System.Drawing.Point(16, 41)
        Me.lblPoundCheck.Name = "lblPoundCheck"
        Me.lblPoundCheck.Size = New System.Drawing.Size(16, 15)
        Me.lblPoundCheck.TabIndex = 1
        Me.lblPoundCheck.Text = "..."
        '
        'formCurrency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 180)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formCurrency"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Real Time Currency Check/Calculator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDollarCheck As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPoundCheck As System.Windows.Forms.Label
    Friend WithEvents btnCheckCurrency As System.Windows.Forms.Button
    Friend WithEvents txtBoxDecimal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
