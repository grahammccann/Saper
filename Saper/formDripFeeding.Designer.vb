<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formDripFeeding
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formDripFeeding))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCountDown = New System.Windows.Forms.Label()
        Me.lvDripFeed = New System.Windows.Forms.ListView()
        Me.URL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UniqueID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SEARCHID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PGEXID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MSID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AnchorID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Snippet = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LinkID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dataGridDripFeed_1 = New System.Windows.Forms.DataGridView()
        Me.columnDripFeed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnUniqueID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnSID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPGEXID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnMSID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnAnchorTextID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnAnchorText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnLinkID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDelLink = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comboBoxDripFeed = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnHideDripFeed = New System.Windows.Forms.Button()
        Me.btnEnableTimer = New System.Windows.Forms.Button()
        Me.btnDeleteDripFeedLink = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dataGridDripFeed_1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblCountDown)
        Me.GroupBox1.Controls.Add(Me.lvDripFeed)
        Me.GroupBox1.Controls.Add(Me.dataGridDripFeed_1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.comboBoxDripFeed)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(939, 440)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DripFeed Setup:"
        '
        'lblCountDown
        '
        Me.lblCountDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountDown.AutoSize = True
        Me.lblCountDown.Location = New System.Drawing.Point(879, 413)
        Me.lblCountDown.Name = "lblCountDown"
        Me.lblCountDown.Size = New System.Drawing.Size(16, 15)
        Me.lblCountDown.TabIndex = 6
        Me.lblCountDown.Text = "..."
        '
        'lvDripFeed
        '
        Me.lvDripFeed.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDripFeed.CheckBoxes = True
        Me.lvDripFeed.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.URL, Me.UniqueID, Me.SEARCHID, Me.PGEXID, Me.MSID, Me.AnchorID, Me.Snippet, Me.LinkID})
        Me.lvDripFeed.Location = New System.Drawing.Point(7, 58)
        Me.lvDripFeed.Name = "lvDripFeed"
        Me.lvDripFeed.Size = New System.Drawing.Size(927, 347)
        Me.lvDripFeed.TabIndex = 5
        Me.lvDripFeed.UseCompatibleStateImageBehavior = False
        Me.lvDripFeed.View = System.Windows.Forms.View.Details
        '
        'URL
        '
        Me.URL.Text = "URL"
        Me.URL.Width = 134
        '
        'UniqueID
        '
        Me.UniqueID.Text = "Unique ID"
        Me.UniqueID.Width = 114
        '
        'SEARCHID
        '
        Me.SEARCHID.Text = "SEARCH ID"
        Me.SEARCHID.Width = 112
        '
        'PGEXID
        '
        Me.PGEXID.Text = "PGEXID"
        Me.PGEXID.Width = 114
        '
        'MSID
        '
        Me.MSID.Text = "MSID"
        Me.MSID.Width = 95
        '
        'AnchorID
        '
        Me.AnchorID.Text = "Anchor ID"
        Me.AnchorID.Width = 117
        '
        'Snippet
        '
        Me.Snippet.Text = "Snippet"
        '
        'LinkID
        '
        Me.LinkID.Text = "Link ID"
        Me.LinkID.Width = 173
        '
        'dataGridDripFeed_1
        '
        Me.dataGridDripFeed_1.AllowUserToAddRows = False
        Me.dataGridDripFeed_1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dataGridDripFeed_1.BackgroundColor = System.Drawing.Color.Black
        Me.dataGridDripFeed_1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dataGridDripFeed_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridDripFeed_1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnDripFeed, Me.columnUniqueID, Me.columnSID, Me.columnPGEXID, Me.columnMSID, Me.columnAnchorTextID, Me.columnAnchorText, Me.columnLinkID, Me.columnDelLink})
        Me.dataGridDripFeed_1.Location = New System.Drawing.Point(7, 58)
        Me.dataGridDripFeed_1.Name = "dataGridDripFeed_1"
        Me.dataGridDripFeed_1.RowHeadersVisible = False
        Me.dataGridDripFeed_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dataGridDripFeed_1.Size = New System.Drawing.Size(926, 347)
        Me.dataGridDripFeed_1.TabIndex = 3
        '
        'columnDripFeed
        '
        Me.columnDripFeed.HeaderText = "URL"
        Me.columnDripFeed.Name = "columnDripFeed"
        '
        'columnUniqueID
        '
        Me.columnUniqueID.HeaderText = "Unique ID"
        Me.columnUniqueID.Name = "columnUniqueID"
        '
        'columnSID
        '
        Me.columnSID.HeaderText = "SEARCH ID"
        Me.columnSID.Name = "columnSID"
        '
        'columnPGEXID
        '
        Me.columnPGEXID.HeaderText = "PGEXID"
        Me.columnPGEXID.Name = "columnPGEXID"
        '
        'columnMSID
        '
        Me.columnMSID.HeaderText = "MSID"
        Me.columnMSID.MaxInputLength = 100000
        Me.columnMSID.Name = "columnMSID"
        '
        'columnAnchorTextID
        '
        Me.columnAnchorTextID.HeaderText = "Anchor ID"
        Me.columnAnchorTextID.Name = "columnAnchorTextID"
        '
        'columnAnchorText
        '
        Me.columnAnchorText.HeaderText = "Snippet"
        Me.columnAnchorText.Name = "columnAnchorText"
        '
        'columnLinkID
        '
        Me.columnLinkID.HeaderText = "Link ID"
        Me.columnLinkID.Name = "columnLinkID"
        '
        'columnDelLink
        '
        Me.columnDelLink.HeaderText = "Delete"
        Me.columnDelLink.Name = "columnDelLink"
        Me.columnDelLink.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.columnDelLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(175, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hour(s)."
        '
        'comboBoxDripFeed
        '
        Me.comboBoxDripFeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxDripFeed.FormattingEnabled = True
        Me.comboBoxDripFeed.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24"})
        Me.comboBoxDripFeed.Location = New System.Drawing.Point(110, 25)
        Me.comboBoxDripFeed.Name = "comboBoxDripFeed"
        Me.comboBoxDripFeed.Size = New System.Drawing.Size(62, 23)
        Me.comboBoxDripFeed.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Post A Link Every:"
        '
        'btnHideDripFeed
        '
        Me.btnHideDripFeed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHideDripFeed.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHideDripFeed.Location = New System.Drawing.Point(870, 448)
        Me.btnHideDripFeed.Name = "btnHideDripFeed"
        Me.btnHideDripFeed.Size = New System.Drawing.Size(82, 32)
        Me.btnHideDripFeed.TabIndex = 1
        Me.btnHideDripFeed.Text = "HIDE"
        Me.btnHideDripFeed.UseVisualStyleBackColor = True
        '
        'btnEnableTimer
        '
        Me.btnEnableTimer.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnableTimer.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnableTimer.Location = New System.Drawing.Point(653, 448)
        Me.btnEnableTimer.Name = "btnEnableTimer"
        Me.btnEnableTimer.Size = New System.Drawing.Size(135, 32)
        Me.btnEnableTimer.TabIndex = 2
        Me.btnEnableTimer.Text = "START DRIPPING!"
        Me.btnEnableTimer.UseVisualStyleBackColor = True
        '
        'btnDeleteDripFeedLink
        '
        Me.btnDeleteDripFeedLink.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteDripFeedLink.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteDripFeedLink.Location = New System.Drawing.Point(788, 448)
        Me.btnDeleteDripFeedLink.Name = "btnDeleteDripFeedLink"
        Me.btnDeleteDripFeedLink.Size = New System.Drawing.Size(82, 32)
        Me.btnDeleteDripFeedLink.TabIndex = 3
        Me.btnDeleteDripFeedLink.Text = "DELETE"
        Me.btnDeleteDripFeedLink.UseVisualStyleBackColor = True
        '
        'formDripFeeding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 492)
        Me.Controls.Add(Me.btnDeleteDripFeedLink)
        Me.Controls.Add(Me.btnEnableTimer)
        Me.Controls.Add(Me.btnHideDripFeed)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formDripFeeding"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DripFeed Your Links"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dataGridDripFeed_1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents comboBoxDripFeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnHideDripFeed As System.Windows.Forms.Button
    Friend WithEvents btnEnableTimer As System.Windows.Forms.Button
    Friend WithEvents btnDeleteDripFeedLink As System.Windows.Forms.Button
    Friend WithEvents lvDripFeed As System.Windows.Forms.ListView
    Friend WithEvents URL As System.Windows.Forms.ColumnHeader
    Friend WithEvents UniqueID As System.Windows.Forms.ColumnHeader
    Friend WithEvents SEARCHID As System.Windows.Forms.ColumnHeader
    Friend WithEvents PGEXID As System.Windows.Forms.ColumnHeader
    Friend WithEvents MSID As System.Windows.Forms.ColumnHeader
    Friend WithEvents AnchorID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Snippet As System.Windows.Forms.ColumnHeader
    Friend WithEvents LinkID As System.Windows.Forms.ColumnHeader
    Friend WithEvents dataGridDripFeed_1 As System.Windows.Forms.DataGridView
    Friend WithEvents columnDripFeed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnUniqueID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnSID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPGEXID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnMSID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnAnchorTextID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnAnchorText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnLinkID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDelLink As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblCountDown As System.Windows.Forms.Label
End Class
