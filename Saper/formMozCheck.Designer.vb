<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMozCheck
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formMozCheck))
        Me.listViewMoz = New System.Windows.Forms.ListView()
        Me.colMozURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMozPA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMozDA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMajTF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMajCF = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPR = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSR = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colScore = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCloseMoz = New System.Windows.Forms.Button()
        Me.btnBuySelectedLinks = New System.Windows.Forms.Button()
        Me.btnCancelMozCheck = New System.Windows.Forms.Button()
        Me.btnSelectNoneLinks = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listViewMoz
        '
        Me.listViewMoz.CheckBoxes = True
        Me.listViewMoz.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMozURL, Me.colMozPA, Me.colMozDA, Me.colMajTF, Me.colMajCF, Me.colPR, Me.colSR, Me.colScore})
        Me.listViewMoz.Dock = System.Windows.Forms.DockStyle.Top
        Me.listViewMoz.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listViewMoz.Location = New System.Drawing.Point(0, 0)
        Me.listViewMoz.Name = "listViewMoz"
        Me.listViewMoz.Size = New System.Drawing.Size(787, 433)
        Me.listViewMoz.TabIndex = 0
        Me.listViewMoz.UseCompatibleStateImageBehavior = False
        Me.listViewMoz.View = System.Windows.Forms.View.Details
        '
        'colMozURL
        '
        Me.colMozURL.Text = "URL"
        Me.colMozURL.Width = 200
        '
        'colMozPA
        '
        Me.colMozPA.Text = "DA"
        '
        'colMozDA
        '
        Me.colMozDA.Text = "PA"
        '
        'colMajTF
        '
        Me.colMajTF.Text = "TF"
        '
        'colMajCF
        '
        Me.colMajCF.Text = "CF"
        '
        'colPR
        '
        Me.colPR.Text = "PR"
        '
        'colSR
        '
        Me.colSR.Text = "SR"
        '
        'colScore
        '
        Me.colScore.Text = "SCORE"
        '
        'btnCloseMoz
        '
        Me.btnCloseMoz.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseMoz.Location = New System.Drawing.Point(703, 439)
        Me.btnCloseMoz.Name = "btnCloseMoz"
        Me.btnCloseMoz.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseMoz.TabIndex = 1
        Me.btnCloseMoz.Text = "Close"
        Me.btnCloseMoz.UseVisualStyleBackColor = True
        '
        'btnBuySelectedLinks
        '
        Me.btnBuySelectedLinks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuySelectedLinks.Location = New System.Drawing.Point(88, 439)
        Me.btnBuySelectedLinks.Name = "btnBuySelectedLinks"
        Me.btnBuySelectedLinks.Size = New System.Drawing.Size(206, 23)
        Me.btnBuySelectedLinks.TabIndex = 2
        Me.btnBuySelectedLinks.Text = "Select Checked Links For Buying!"
        Me.btnBuySelectedLinks.UseVisualStyleBackColor = True
        '
        'btnCancelMozCheck
        '
        Me.btnCancelMozCheck.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelMozCheck.Location = New System.Drawing.Point(628, 439)
        Me.btnCancelMozCheck.Name = "btnCancelMozCheck"
        Me.btnCancelMozCheck.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelMozCheck.TabIndex = 4
        Me.btnCancelMozCheck.Text = "Cancel"
        Me.btnCancelMozCheck.UseVisualStyleBackColor = True
        '
        'btnSelectNoneLinks
        '
        Me.btnSelectNoneLinks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectNoneLinks.Image = CType(resources.GetObject("btnSelectNoneLinks.Image"), System.Drawing.Image)
        Me.btnSelectNoneLinks.Location = New System.Drawing.Point(607, 440)
        Me.btnSelectNoneLinks.Name = "btnSelectNoneLinks"
        Me.btnSelectNoneLinks.Size = New System.Drawing.Size(21, 21)
        Me.btnSelectNoneLinks.TabIndex = 39
        Me.btnSelectNoneLinks.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectAll.Image = CType(resources.GetObject("btnSelectAll.Image"), System.Drawing.Image)
        Me.btnSelectAll.Location = New System.Drawing.Point(586, 440)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(21, 21)
        Me.btnSelectAll.TabIndex = 38
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.Location = New System.Drawing.Point(12, 439)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 40
        Me.btnGo.Text = "ANALYZE"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'formMozCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(787, 470)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.btnSelectNoneLinks)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnCancelMozCheck)
        Me.Controls.Add(Me.btnBuySelectedLinks)
        Me.Controls.Add(Me.btnCloseMoz)
        Me.Controls.Add(Me.listViewMoz)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formMozCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Links Analysis"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listViewMoz As System.Windows.Forms.ListView
    Friend WithEvents colMozURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMozPA As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMozDA As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCloseMoz As System.Windows.Forms.Button
    Friend WithEvents btnBuySelectedLinks As System.Windows.Forms.Button
    Friend WithEvents btnCancelMozCheck As System.Windows.Forms.Button
    Friend WithEvents btnSelectNoneLinks As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents colMajTF As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMajCF As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents colPR As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSR As System.Windows.Forms.ColumnHeader
    Friend WithEvents colScore As System.Windows.Forms.ColumnHeader
End Class
