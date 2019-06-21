<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formZones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formZones))
        Me.listBoxTLDExtensions = New System.Windows.Forms.ListView()
        Me.colTLDs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSelectTLDs = New System.Windows.Forms.Button()
        Me.txtBoxZonesPostString = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listBoxTLDExtensions
        '
        Me.listBoxTLDExtensions.CheckBoxes = True
        Me.listBoxTLDExtensions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTLDs})
        Me.listBoxTLDExtensions.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listBoxTLDExtensions.Location = New System.Drawing.Point(13, 13)
        Me.listBoxTLDExtensions.Name = "listBoxTLDExtensions"
        Me.listBoxTLDExtensions.Size = New System.Drawing.Size(249, 370)
        Me.listBoxTLDExtensions.TabIndex = 0
        Me.listBoxTLDExtensions.UseCompatibleStateImageBehavior = False
        Me.listBoxTLDExtensions.View = System.Windows.Forms.View.Details
        '
        'colTLDs
        '
        Me.colTLDs.Text = "TLDs"
        Me.colTLDs.Width = 200
        '
        'btnSelectTLDs
        '
        Me.btnSelectTLDs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectTLDs.Location = New System.Drawing.Point(187, 416)
        Me.btnSelectTLDs.Name = "btnSelectTLDs"
        Me.btnSelectTLDs.Size = New System.Drawing.Size(75, 40)
        Me.btnSelectTLDs.TabIndex = 1
        Me.btnSelectTLDs.Text = "Select"
        Me.btnSelectTLDs.UseVisualStyleBackColor = True
        '
        'txtBoxZonesPostString
        '
        Me.txtBoxZonesPostString.Location = New System.Drawing.Point(13, 390)
        Me.txtBoxZonesPostString.Name = "txtBoxZonesPostString"
        Me.txtBoxZonesPostString.Size = New System.Drawing.Size(249, 20)
        Me.txtBoxZonesPostString.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Image = Global.Saper.My.Resources.Resources.ico_arrow_up_new
        Me.Button1.Location = New System.Drawing.Point(13, 416)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 40)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.Saper.My.Resources.Resources.ico_arrow_down
        Me.Button2.Location = New System.Drawing.Point(53, 416)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 40)
        Me.Button2.TabIndex = 4
        Me.Button2.UseVisualStyleBackColor = True
        '
        'formZones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 467)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtBoxZonesPostString)
        Me.Controls.Add(Me.btnSelectTLDs)
        Me.Controls.Add(Me.listBoxTLDExtensions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "formZones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TLD Extensions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listBoxTLDExtensions As System.Windows.Forms.ListView
    Friend WithEvents colTLDs As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSelectTLDs As System.Windows.Forms.Button
    Friend WithEvents txtBoxZonesPostString As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
