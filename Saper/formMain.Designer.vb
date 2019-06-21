<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.comboBoxAccounts = New System.Windows.Forms.ComboBox()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.lblLoginStatus = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkBoxDebug = New System.Windows.Forms.CheckBox()
        Me.mainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkBoxSaveHTMLDebug = New System.Windows.Forms.CheckBox()
        Me.chkBoxHidePass = New System.Windows.Forms.CheckBox()
        Me.radioSockets = New System.Windows.Forms.RadioButton()
        Me.radioXMLRPC = New System.Windows.Forms.RadioButton()
        Me.btnFirstTimeSetup = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteProjectMain = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dataGridProjects = New System.Windows.Forms.DataGridView()
        Me.columnProjectID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnProject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnActionButton = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colDelete = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dataGridProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.comboBoxAccounts)
        Me.GroupBox1.Controls.Add(Me.btnLogOut)
        Me.GroupBox1.Controls.Add(Me.lblLoginStatus)
        Me.GroupBox1.Controls.Add(Me.btnLogin)
        Me.GroupBox1.Controls.Add(Me.txtPass)
        Me.GroupBox1.Controls.Add(Me.txtUser)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 107)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sape Credentials:"
        '
        'comboBoxAccounts
        '
        Me.comboBoxAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBoxAccounts.FormattingEnabled = True
        Me.comboBoxAccounts.Location = New System.Drawing.Point(82, 74)
        Me.comboBoxAccounts.Name = "comboBoxAccounts"
        Me.comboBoxAccounts.Size = New System.Drawing.Size(168, 23)
        Me.comboBoxAccounts.TabIndex = 8
        '
        'btnLogOut
        '
        Me.btnLogOut.Image = Global.Saper.My.Resources.Resources.ico_logout
        Me.btnLogOut.Location = New System.Drawing.Point(226, 45)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(24, 24)
        Me.btnLogOut.TabIndex = 7
        Me.btnLogOut.UseVisualStyleBackColor = True
        '
        'lblLoginStatus
        '
        Me.lblLoginStatus.AutoSize = True
        Me.lblLoginStatus.Location = New System.Drawing.Point(7, 79)
        Me.lblLoginStatus.Name = "lblLoginStatus"
        Me.lblLoginStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblLoginStatus.TabIndex = 6
        '
        'btnLogin
        '
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Image = Global.Saper.My.Resources.Resources.ico_login_new
        Me.btnLogin.Location = New System.Drawing.Point(226, 18)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(24, 24)
        Me.btnLogin.TabIndex = 4
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(47, 45)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(173, 23)
        Me.txtPass.TabIndex = 3
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(47, 19)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(173, 23)
        Me.txtUser.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pass:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User:"
        '
        'chkBoxDebug
        '
        Me.chkBoxDebug.AutoSize = True
        Me.chkBoxDebug.Location = New System.Drawing.Point(7, 76)
        Me.chkBoxDebug.Name = "chkBoxDebug"
        Me.chkBoxDebug.Size = New System.Drawing.Size(131, 19)
        Me.chkBoxDebug.TabIndex = 3
        Me.chkBoxDebug.Text = "Show HTML Debug."
        Me.chkBoxDebug.UseVisualStyleBackColor = True
        '
        'mainMenu
        '
        Me.mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem3, Me.MenuItem6})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        Me.MenuItem1.Text = "File"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Exit"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem5})
        Me.MenuItem3.Text = "Options"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 0
        Me.MenuItem4.Text = "Clear Projects"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.Text = "API Settings"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 2
        Me.MenuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.MenuItem8})
        Me.MenuItem6.Text = "Updates"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 0
        Me.MenuItem7.Text = "Check for updates..."
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 1
        Me.MenuItem8.Text = "Check the update log..."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkBoxSaveHTMLDebug)
        Me.GroupBox2.Controls.Add(Me.chkBoxHidePass)
        Me.GroupBox2.Controls.Add(Me.chkBoxDebug)
        Me.GroupBox2.Controls.Add(Me.radioSockets)
        Me.GroupBox2.Controls.Add(Me.radioXMLRPC)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(271, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(387, 107)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sape Settings:"
        '
        'chkBoxSaveHTMLDebug
        '
        Me.chkBoxSaveHTMLDebug.AutoSize = True
        Me.chkBoxSaveHTMLDebug.Location = New System.Drawing.Point(138, 76)
        Me.chkBoxSaveHTMLDebug.Name = "chkBoxSaveHTMLDebug"
        Me.chkBoxSaveHTMLDebug.Size = New System.Drawing.Size(186, 19)
        Me.chkBoxSaveHTMLDebug.TabIndex = 9
        Me.chkBoxSaveHTMLDebug.Text = "Save HTML in ""Debug"" folder."
        Me.chkBoxSaveHTMLDebug.UseVisualStyleBackColor = True
        '
        'chkBoxHidePass
        '
        Me.chkBoxHidePass.AutoSize = True
        Me.chkBoxHidePass.Checked = True
        Me.chkBoxHidePass.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBoxHidePass.Location = New System.Drawing.Point(7, 57)
        Me.chkBoxHidePass.Name = "chkBoxHidePass"
        Me.chkBoxHidePass.Size = New System.Drawing.Size(109, 19)
        Me.chkBoxHidePass.TabIndex = 7
        Me.chkBoxHidePass.Text = "Hide Password."
        Me.chkBoxHidePass.UseVisualStyleBackColor = True
        '
        'radioSockets
        '
        Me.radioSockets.AutoSize = True
        Me.radioSockets.Checked = True
        Me.radioSockets.Location = New System.Drawing.Point(7, 14)
        Me.radioSockets.Name = "radioSockets"
        Me.radioSockets.Size = New System.Drawing.Size(226, 19)
        Me.radioSockets.TabIndex = 1
        Me.radioSockets.TabStop = True
        Me.radioSockets.Text = "Step 1 > Login And Retrieve Projects."
        Me.radioSockets.UseVisualStyleBackColor = True
        '
        'radioXMLRPC
        '
        Me.radioXMLRPC.AutoSize = True
        Me.radioXMLRPC.Location = New System.Drawing.Point(7, 35)
        Me.radioXMLRPC.Name = "radioXMLRPC"
        Me.radioXMLRPC.Size = New System.Drawing.Size(229, 19)
        Me.radioXMLRPC.TabIndex = 0
        Me.radioXMLRPC.Text = "Step 2 > Manage Your Projects Below."
        Me.radioXMLRPC.UseVisualStyleBackColor = True
        '
        'btnFirstTimeSetup
        '
        Me.btnFirstTimeSetup.Location = New System.Drawing.Point(7, 243)
        Me.btnFirstTimeSetup.Name = "btnFirstTimeSetup"
        Me.btnFirstTimeSetup.Size = New System.Drawing.Size(126, 34)
        Me.btnFirstTimeSetup.TabIndex = 8
        Me.btnFirstTimeSetup.Text = "FIRST TIME SETUP!"
        Me.btnFirstTimeSetup.UseVisualStyleBackColor = True
        Me.btnFirstTimeSetup.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnDeleteProjectMain)
        Me.GroupBox3.Controls.Add(Me.TabControl1)
        Me.GroupBox3.Controls.Add(Me.btnFirstTimeSetup)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(13, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(645, 287)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sape Projects:"
        '
        'btnDeleteProjectMain
        '
        Me.btnDeleteProjectMain.Image = Global.Saper.My.Resources.Resources.ico_logout
        Me.btnDeleteProjectMain.Location = New System.Drawing.Point(595, 242)
        Me.btnDeleteProjectMain.Name = "btnDeleteProjectMain"
        Me.btnDeleteProjectMain.Size = New System.Drawing.Size(43, 40)
        Me.btnDeleteProjectMain.TabIndex = 5
        Me.btnDeleteProjectMain.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(8, 23)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(630, 218)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dataGridProjects)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(622, 190)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "   CURRENT PROJECTS   "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dataGridProjects
        '
        Me.dataGridProjects.AllowUserToAddRows = False
        Me.dataGridProjects.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dataGridProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridProjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnProjectID, Me.columnProject, Me.columnDate, Me.columnActionButton, Me.colDelete})
        Me.dataGridProjects.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridProjects.Location = New System.Drawing.Point(3, 3)
        Me.dataGridProjects.Name = "dataGridProjects"
        Me.dataGridProjects.RowHeadersVisible = False
        Me.dataGridProjects.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dataGridProjects.Size = New System.Drawing.Size(616, 184)
        Me.dataGridProjects.TabIndex = 0
        '
        'columnProjectID
        '
        Me.columnProjectID.HeaderText = "Project ID"
        Me.columnProjectID.Name = "columnProjectID"
        '
        'columnProject
        '
        Me.columnProject.HeaderText = "Project Name"
        Me.columnProject.Name = "columnProject"
        Me.columnProject.Width = 220
        '
        'columnDate
        '
        Me.columnDate.HeaderText = "Date"
        Me.columnDate.Name = "columnDate"
        '
        'columnActionButton
        '
        Me.columnActionButton.HeaderText = "Manage"
        Me.columnActionButton.Name = "columnActionButton"
        Me.columnActionButton.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.columnActionButton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.columnActionButton.Text = "Manage"
        Me.columnActionButton.UseColumnTextForButtonValue = True
        '
        'colDelete
        '
        Me.colDelete.HeaderText = "Delete"
        Me.colDelete.Name = "colDelete"
        Me.colDelete.Width = 65
        '
        'formMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 421)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mainMenu
        Me.Name = "formMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saper (Optimizer Edition) - graham23s@Hotmail.com"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dataGridProjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents mainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents chkBoxDebug As System.Windows.Forms.CheckBox
    Friend WithEvents lblLoginStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dataGridProjects As System.Windows.Forms.DataGridView
    Friend WithEvents radioSockets As System.Windows.Forms.RadioButton
    Friend WithEvents radioXMLRPC As System.Windows.Forms.RadioButton
    Friend WithEvents chkBoxHidePass As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents btnLogOut As System.Windows.Forms.Button
    Friend WithEvents comboBoxAccounts As System.Windows.Forms.ComboBox
    Friend WithEvents btnFirstTimeSetup As System.Windows.Forms.Button
    Friend WithEvents chkBoxSaveHTMLDebug As System.Windows.Forms.CheckBox
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents btnDeleteProjectMain As System.Windows.Forms.Button
    Friend WithEvents columnProjectID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnProject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnActionButton As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colDelete As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
