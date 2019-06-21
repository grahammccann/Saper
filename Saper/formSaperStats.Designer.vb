<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formSaperStats
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formSaperStats))
        Me.listViewSaperStats = New System.Windows.Forms.ListView()
        Me.colSSID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnPurchaseSSLinks = New System.Windows.Forms.Button()
        Me.lblLinksCountSS = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'listViewSaperStats
        '
        Me.listViewSaperStats.CheckBoxes = True
        Me.listViewSaperStats.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSSID})
        Me.listViewSaperStats.Dock = System.Windows.Forms.DockStyle.Top
        Me.listViewSaperStats.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listViewSaperStats.GridLines = True
        Me.listViewSaperStats.Location = New System.Drawing.Point(0, 0)
        Me.listViewSaperStats.Name = "listViewSaperStats"
        Me.listViewSaperStats.Size = New System.Drawing.Size(715, 321)
        Me.listViewSaperStats.TabIndex = 0
        Me.listViewSaperStats.UseCompatibleStateImageBehavior = False
        Me.listViewSaperStats.View = System.Windows.Forms.View.Details
        '
        'colSSID
        '
        Me.colSSID.Text = "SAPERSTATS.COM ID > SAPE URL ID > SAPE URL > PR > DA > PA > PRICE (RUBLES) > SITE" & _
    "/PAGE LEVEL"
        Me.colSSID.Width = 650
        '
        'btnPurchaseSSLinks
        '
        Me.btnPurchaseSSLinks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchaseSSLinks.Location = New System.Drawing.Point(8, 327)
        Me.btnPurchaseSSLinks.Name = "btnPurchaseSSLinks"
        Me.btnPurchaseSSLinks.Size = New System.Drawing.Size(62, 23)
        Me.btnPurchaseSSLinks.TabIndex = 1
        Me.btnPurchaseSSLinks.Text = "Buy!"
        Me.btnPurchaseSSLinks.UseVisualStyleBackColor = True
        '
        'lblLinksCountSS
        '
        Me.lblLinksCountSS.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLinksCountSS.AutoSize = True
        Me.lblLinksCountSS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLinksCountSS.ForeColor = System.Drawing.Color.Red
        Me.lblLinksCountSS.Location = New System.Drawing.Point(76, 330)
        Me.lblLinksCountSS.Name = "lblLinksCountSS"
        Me.lblLinksCountSS.Size = New System.Drawing.Size(82, 15)
        Me.lblLinksCountSS.TabIndex = 34
        Me.lblLinksCountSS.Text = "0 Links found."
        '
        'formSaperStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 357)
        Me.Controls.Add(Me.lblLinksCountSS)
        Me.Controls.Add(Me.btnPurchaseSSLinks)
        Me.Controls.Add(Me.listViewSaperStats)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "formSaperStats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SaperStats.com Results..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listViewSaperStats As System.Windows.Forms.ListView
    Friend WithEvents colSSID As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPurchaseSSLinks As System.Windows.Forms.Button
    Friend WithEvents lblLinksCountSS As System.Windows.Forms.Label
End Class
