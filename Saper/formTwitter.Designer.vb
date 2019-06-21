<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formTwitter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formTwitter))
        Me.listViewTwitter = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnParsePosted = New System.Windows.Forms.Button()
        Me.txtBoxTwitterPriceTo = New System.Windows.Forms.TextBox()
        Me.txtBoxTwitterPriceFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnTwitterSearch = New System.Windows.Forms.Button()
        Me.btnPostTweets = New System.Windows.Forms.Button()
        Me.txtBoxFollowingTo = New System.Windows.Forms.TextBox()
        Me.txtBoxFollowingFrom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBoxFollowersTo = New System.Windows.Forms.TextBox()
        Me.txtBoxFollowersFrom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBoxTwitterPRTo = New System.Windows.Forms.TextBox()
        Me.txtBoxTwitterPRFrom = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBoxTwitterBody = New System.Windows.Forms.TextBox()
        Me.txtBoxTwitterURL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNumberOfTwitterAccounts = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnParseTwitterers = New System.Windows.Forms.Button()
        Me.btnCloseTwitter = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.listViewTwitterPosted = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'listViewTwitter
        '
        Me.listViewTwitter.CheckBoxes = True
        Me.listViewTwitter.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.listViewTwitter.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewTwitter.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listViewTwitter.Location = New System.Drawing.Point(3, 3)
        Me.listViewTwitter.Name = "listViewTwitter"
        Me.listViewTwitter.Size = New System.Drawing.Size(729, 290)
        Me.listViewTwitter.TabIndex = 0
        Me.listViewTwitter.UseCompatibleStateImageBehavior = False
        Me.listViewTwitter.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Twitter ID"
        Me.ColumnHeader7.Width = 84
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Twitter User"
        Me.ColumnHeader8.Width = 122
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Followers"
        Me.ColumnHeader1.Width = 87
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Following"
        Me.ColumnHeader2.Width = 97
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "# Of Tweets"
        Me.ColumnHeader3.Width = 107
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "PageRank"
        Me.ColumnHeader4.Width = 83
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Price (Rubles)"
        Me.ColumnHeader5.Width = 99
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnParsePosted)
        Me.GroupBox1.Controls.Add(Me.txtBoxTwitterPriceTo)
        Me.GroupBox1.Controls.Add(Me.txtBoxTwitterPriceFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnTwitterSearch)
        Me.GroupBox1.Controls.Add(Me.btnPostTweets)
        Me.GroupBox1.Controls.Add(Me.txtBoxFollowingTo)
        Me.GroupBox1.Controls.Add(Me.txtBoxFollowingFrom)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtBoxFollowersTo)
        Me.GroupBox1.Controls.Add(Me.txtBoxFollowersFrom)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtBoxTwitterPRTo)
        Me.GroupBox1.Controls.Add(Me.txtBoxTwitterPRFrom)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtBoxTwitterBody)
        Me.GroupBox1.Controls.Add(Me.txtBoxTwitterURL)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblNumberOfTwitterAccounts)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 330)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(730, 127)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filters:"
        '
        'btnParsePosted
        '
        Me.btnParsePosted.Location = New System.Drawing.Point(642, 49)
        Me.btnParsePosted.Name = "btnParsePosted"
        Me.btnParsePosted.Size = New System.Drawing.Size(82, 26)
        Me.btnParsePosted.TabIndex = 57
        Me.btnParsePosted.Text = "PARSE"
        Me.btnParsePosted.UseVisualStyleBackColor = True
        '
        'txtBoxTwitterPriceTo
        '
        Me.txtBoxTwitterPriceTo.Location = New System.Drawing.Point(583, 93)
        Me.txtBoxTwitterPriceTo.Name = "txtBoxTwitterPriceTo"
        Me.txtBoxTwitterPriceTo.Size = New System.Drawing.Size(53, 23)
        Me.txtBoxTwitterPriceTo.TabIndex = 56
        Me.txtBoxTwitterPriceTo.Text = "300"
        '
        'txtBoxTwitterPriceFrom
        '
        Me.txtBoxTwitterPriceFrom.Location = New System.Drawing.Point(520, 93)
        Me.txtBoxTwitterPriceFrom.Name = "txtBoxTwitterPriceFrom"
        Me.txtBoxTwitterPriceFrom.Size = New System.Drawing.Size(30, 23)
        Me.txtBoxTwitterPriceFrom.TabIndex = 55
        Me.txtBoxTwitterPriceFrom.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(554, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 15)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "To:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(482, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Price:"
        '
        'btnTwitterSearch
        '
        Me.btnTwitterSearch.Image = Global.Saper.My.Resources.Resources.ico_twitter_search
        Me.btnTwitterSearch.Location = New System.Drawing.Point(642, 20)
        Me.btnTwitterSearch.Name = "btnTwitterSearch"
        Me.btnTwitterSearch.Size = New System.Drawing.Size(82, 26)
        Me.btnTwitterSearch.TabIndex = 52
        Me.btnTwitterSearch.Text = "SEARCH!"
        Me.btnTwitterSearch.UseVisualStyleBackColor = True
        '
        'btnPostTweets
        '
        Me.btnPostTweets.Enabled = False
        Me.btnPostTweets.Location = New System.Drawing.Point(318, 38)
        Me.btnPostTweets.Name = "btnPostTweets"
        Me.btnPostTweets.Size = New System.Drawing.Size(134, 23)
        Me.btnPostTweets.TabIndex = 51
        Me.btnPostTweets.Text = "POST TWEETS!"
        Me.btnPostTweets.UseVisualStyleBackColor = True
        '
        'txtBoxFollowingTo
        '
        Me.txtBoxFollowingTo.Location = New System.Drawing.Point(583, 69)
        Me.txtBoxFollowingTo.Name = "txtBoxFollowingTo"
        Me.txtBoxFollowingTo.Size = New System.Drawing.Size(53, 23)
        Me.txtBoxFollowingTo.TabIndex = 50
        Me.txtBoxFollowingTo.Text = "1000"
        '
        'txtBoxFollowingFrom
        '
        Me.txtBoxFollowingFrom.Location = New System.Drawing.Point(520, 69)
        Me.txtBoxFollowingFrom.Name = "txtBoxFollowingFrom"
        Me.txtBoxFollowingFrom.Size = New System.Drawing.Size(30, 23)
        Me.txtBoxFollowingFrom.TabIndex = 49
        Me.txtBoxFollowingFrom.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(554, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 15)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "To:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(457, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Following:"
        '
        'txtBoxFollowersTo
        '
        Me.txtBoxFollowersTo.Location = New System.Drawing.Point(583, 46)
        Me.txtBoxFollowersTo.Name = "txtBoxFollowersTo"
        Me.txtBoxFollowersTo.Size = New System.Drawing.Size(53, 23)
        Me.txtBoxFollowersTo.TabIndex = 46
        Me.txtBoxFollowersTo.Text = "1000"
        '
        'txtBoxFollowersFrom
        '
        Me.txtBoxFollowersFrom.Location = New System.Drawing.Point(520, 46)
        Me.txtBoxFollowersFrom.Name = "txtBoxFollowersFrom"
        Me.txtBoxFollowersFrom.Size = New System.Drawing.Size(30, 23)
        Me.txtBoxFollowersFrom.TabIndex = 45
        Me.txtBoxFollowersFrom.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(554, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 15)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "To:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(457, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Followers:"
        '
        'txtBoxTwitterPRTo
        '
        Me.txtBoxTwitterPRTo.Location = New System.Drawing.Point(583, 22)
        Me.txtBoxTwitterPRTo.Name = "txtBoxTwitterPRTo"
        Me.txtBoxTwitterPRTo.Size = New System.Drawing.Size(30, 23)
        Me.txtBoxTwitterPRTo.TabIndex = 42
        Me.txtBoxTwitterPRTo.Text = "7"
        '
        'txtBoxTwitterPRFrom
        '
        Me.txtBoxTwitterPRFrom.Location = New System.Drawing.Point(520, 23)
        Me.txtBoxTwitterPRFrom.Name = "txtBoxTwitterPRFrom"
        Me.txtBoxTwitterPRFrom.Size = New System.Drawing.Size(30, 23)
        Me.txtBoxTwitterPRFrom.TabIndex = 41
        Me.txtBoxTwitterPRFrom.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(554, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 15)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "To:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(457, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 15)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "PageRank:"
        '
        'txtBoxTwitterBody
        '
        Me.txtBoxTwitterBody.Enabled = False
        Me.txtBoxTwitterBody.Location = New System.Drawing.Point(128, 64)
        Me.txtBoxTwitterBody.Multiline = True
        Me.txtBoxTwitterBody.Name = "txtBoxTwitterBody"
        Me.txtBoxTwitterBody.Size = New System.Drawing.Size(325, 44)
        Me.txtBoxTwitterBody.TabIndex = 6
        Me.txtBoxTwitterBody.Text = "no more than 140 characters remember!"
        '
        'txtBoxTwitterURL
        '
        Me.txtBoxTwitterURL.Enabled = False
        Me.txtBoxTwitterURL.Location = New System.Drawing.Point(128, 39)
        Me.txtBoxTwitterURL.Name = "txtBoxTwitterURL"
        Me.txtBoxTwitterURL.Size = New System.Drawing.Size(188, 23)
        Me.txtBoxTwitterURL.TabIndex = 5
        Me.txtBoxTwitterURL.Text = "http://www.moneysite.com/"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tweet:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "URL to Tweet:"
        '
        'lblNumberOfTwitterAccounts
        '
        Me.lblNumberOfTwitterAccounts.AutoSize = True
        Me.lblNumberOfTwitterAccounts.ForeColor = System.Drawing.Color.Red
        Me.lblNumberOfTwitterAccounts.Location = New System.Drawing.Point(125, 22)
        Me.lblNumberOfTwitterAccounts.Name = "lblNumberOfTwitterAccounts"
        Me.lblNumberOfTwitterAccounts.Size = New System.Drawing.Size(14, 15)
        Me.lblNumberOfTwitterAccounts.TabIndex = 2
        Me.lblNumberOfTwitterAccounts.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Twitter Accounts:"
        '
        'btnParseTwitterers
        '
        Me.btnParseTwitterers.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParseTwitterers.Location = New System.Drawing.Point(8, 463)
        Me.btnParseTwitterers.Name = "btnParseTwitterers"
        Me.btnParseTwitterers.Size = New System.Drawing.Size(125, 33)
        Me.btnParseTwitterers.TabIndex = 0
        Me.btnParseTwitterers.Text = "CALCULATOR"
        Me.btnParseTwitterers.UseVisualStyleBackColor = True
        '
        'btnCloseTwitter
        '
        Me.btnCloseTwitter.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseTwitter.Image = Global.Saper.My.Resources.Resources.ico_close
        Me.btnCloseTwitter.Location = New System.Drawing.Point(139, 463)
        Me.btnCloseTwitter.Name = "btnCloseTwitter"
        Me.btnCloseTwitter.Size = New System.Drawing.Size(597, 33)
        Me.btnCloseTwitter.TabIndex = 2
        Me.btnCloseTwitter.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(743, 324)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.listViewTwitter)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(735, 296)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "   SEARCH FOR TWEETS   "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.listViewTwitterPosted)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(735, 296)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "   TWEETS POSTED   "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'listViewTwitterPosted
        '
        Me.listViewTwitterPosted.CheckBoxes = True
        Me.listViewTwitterPosted.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.listViewTwitterPosted.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewTwitterPosted.Location = New System.Drawing.Point(3, 3)
        Me.listViewTwitterPosted.Name = "listViewTwitterPosted"
        Me.listViewTwitterPosted.Size = New System.Drawing.Size(729, 290)
        Me.listViewTwitterPosted.TabIndex = 0
        Me.listViewTwitterPosted.UseCompatibleStateImageBehavior = False
        Me.listViewTwitterPosted.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Twitter ID"
        Me.ColumnHeader6.Width = 96
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "URL Posted"
        Me.ColumnHeader9.Width = 150
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Tweet Body"
        Me.ColumnHeader10.Width = 171
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Twitter User"
        Me.ColumnHeader11.Width = 99
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Price"
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Posted"
        Me.ColumnHeader13.Width = 97
        '
        'formTwitter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 504)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnCloseTwitter)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnParseTwitterers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "formTwitter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listViewTwitter As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCloseTwitter As System.Windows.Forms.Button
    Friend WithEvents btnParseTwitterers As System.Windows.Forms.Button
    Friend WithEvents lblNumberOfTwitterAccounts As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBoxTwitterBody As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxTwitterURL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBoxTwitterPRTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxTwitterPRFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtBoxFollowingTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxFollowingFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBoxFollowersTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxFollowersFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPostTweets As System.Windows.Forms.Button
    Friend WithEvents btnTwitterSearch As System.Windows.Forms.Button
    Friend WithEvents txtBoxTwitterPriceTo As System.Windows.Forms.TextBox
    Friend WithEvents txtBoxTwitterPriceFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnParsePosted As System.Windows.Forms.Button
    Friend WithEvents listViewTwitterPosted As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
End Class
