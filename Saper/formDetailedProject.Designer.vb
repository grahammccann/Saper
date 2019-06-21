<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formDetailedProject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formDetailedProject))
        Me.listViewDetailed = New System.Windows.Forms.ListView()
        Me.colDID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDAmountToday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDYesterday = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDSpentTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDKeyword = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSelectProject = New System.Windows.Forms.Button()
        Me.btnCloseProjectSelection = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'listViewDetailed
        '
        Me.listViewDetailed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listViewDetailed.CheckBoxes = True
        Me.listViewDetailed.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDID, Me.colPID, Me.colDURL, Me.colDName, Me.colDAmountToday, Me.colDYesterday, Me.colDSpentTotal, Me.colDNumber, Me.colDKeyword})
        Me.listViewDetailed.Location = New System.Drawing.Point(0, 0)
        Me.listViewDetailed.Name = "listViewDetailed"
        Me.listViewDetailed.Size = New System.Drawing.Size(1070, 398)
        Me.listViewDetailed.TabIndex = 0
        Me.listViewDetailed.UseCompatibleStateImageBehavior = False
        Me.listViewDetailed.View = System.Windows.Forms.View.Details
        '
        'colDID
        '
        Me.colDID.Text = "Link ID"
        Me.colDID.Width = 85
        '
        'colPID
        '
        Me.colPID.Text = "Project ID"
        Me.colPID.Width = 85
        '
        'colDURL
        '
        Me.colDURL.Text = "URL"
        Me.colDURL.Width = 178
        '
        'colDName
        '
        Me.colDName.Text = "Project Alias"
        Me.colDName.Width = 190
        '
        'colDAmountToday
        '
        Me.colDAmountToday.Text = "$ Today"
        Me.colDAmountToday.Width = 83
        '
        'colDYesterday
        '
        Me.colDYesterday.Text = "$ Yesterday"
        Me.colDYesterday.Width = 110
        '
        'colDSpentTotal
        '
        Me.colDSpentTotal.Text = "$ Total"
        Me.colDSpentTotal.Width = 80
        '
        'colDNumber
        '
        Me.colDNumber.Text = "# Anchors"
        Me.colDNumber.Width = 78
        '
        'colDKeyword
        '
        Me.colDKeyword.Text = "Keyword"
        Me.colDKeyword.Width = 100
        '
        'btnSelectProject
        '
        Me.btnSelectProject.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectProject.Location = New System.Drawing.Point(12, 404)
        Me.btnSelectProject.Name = "btnSelectProject"
        Me.btnSelectProject.Size = New System.Drawing.Size(113, 23)
        Me.btnSelectProject.TabIndex = 1
        Me.btnSelectProject.Text = "Select Project"
        Me.btnSelectProject.UseVisualStyleBackColor = True
        '
        'btnCloseProjectSelection
        '
        Me.btnCloseProjectSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCloseProjectSelection.Location = New System.Drawing.Point(982, 404)
        Me.btnCloseProjectSelection.Name = "btnCloseProjectSelection"
        Me.btnCloseProjectSelection.Size = New System.Drawing.Size(75, 23)
        Me.btnCloseProjectSelection.TabIndex = 2
        Me.btnCloseProjectSelection.Text = "Close"
        Me.btnCloseProjectSelection.UseVisualStyleBackColor = True
        '
        'formDetailedProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 436)
        Me.Controls.Add(Me.btnCloseProjectSelection)
        Me.Controls.Add(Me.btnSelectProject)
        Me.Controls.Add(Me.listViewDetailed)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formDetailedProject"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Link Details"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listViewDetailed As System.Windows.Forms.ListView
    Friend WithEvents colDID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDAmountToday As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDYesterday As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDSpentTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDNumber As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDKeyword As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSelectProject As System.Windows.Forms.Button
    Friend WithEvents btnCloseProjectSelection As System.Windows.Forms.Button
End Class
