Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports CookComputing.XmlRpc
Imports Newtonsoft.Json.Linq
Imports System.Web
Imports System.Net.NetworkInformation

Public Class formMain

    ' constants
    Const appTitle = "Saper"

    ' cookie container
    Public varCookieJar As New CookieContainer()

    ' subs keep them in the main directory
    Public Sub returnMessage(ByVal message As String)
        MessageBox.Show(message, appTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' for the JSON responses
    Public Class sapeJsonResponse
        <JsonProperty("error")>
        Public Property JError As Integer
        Public Property done As Boolean
        Public Property message As String
        Public Property data() As Object
    End Class

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' close software
        Me.Close()
    End Sub

    Private Sub checkForUpdates()
        Dim wc As New WebClient()
        Try
            Dim newV As String = wc.DownloadString("http://www.camnevsoftware.com/saper/v.txt")
            If (My.Application.Info.Version.ToString <> newV) Then
                If MsgBox("A new update is available! latest version is: " + newV + vbCrLf + vbCrLf + "Would you like to update now?", MsgBoxStyle.YesNo, "Saper Update Ready...") = MsgBoxResult.Yes Then
                    wc.DownloadFile("http://www.camnevsoftware.com/saper/dl/saper.rar", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\saper.rar")
                    ' check if file exists
                    If (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\saper.rar")) Then
                        returnMessage("Update saved to: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\saper.rar")
                    End If
                End If
            Else
                returnMessage("No new updates yet!")
            End If
        Catch ex As Exception
            returnMessage(ex.ToString)
        End Try
    End Sub

    Private Sub formMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' license check
        'Dim isActive As Boolean
        'Dim isExceed As Boolean
        'Dim serverResp As String = String.Empty
        'Dim strHostName As String = String.Empty
        'Dim keyToCheck As String = String.Empty
        'If File.Exists("key.lic") Then
        '    strHostName = System.Net.Dns.GetHostName()
        '    Using sw As New StreamReader("key.lic")
        '        keyToCheck = sw.ReadLine().Trim()
        '        serverResp = saperFunctions.getURL("http://www.camnevsoftware.com/lic/key.php?k=" & HttpUtility.UrlEncode(keyToCheck).Trim().ToLower() & "&product=saper&h=" & HttpUtility.UrlEncode(strHostName).Trim().ToLower(), varCookieJar)
        '        '// active = 1
        '        If (serverResp.Contains("License is active!")) Then
        '            isActive = True
        '        End If
        '        '// active = 0
        '        If (serverResp.Contains("License not found!")) Then
        '            isActive = False
        '        End If
        '        '// exceeded = 1
        '        If (serverResp.Contains("exceeded")) Then
        '            isExceed = True
        '        End If
        '    End Using
        'End If
        '' if true
        'If (isExceed) Then
        '    Me.returnMessage(serverResp)
        '    Close()
        'End If
        '' if true
        'If (isActive) Then
        '    ' display version.
        '    Dim softVersion = My.Application.Info.Version.ToString
        '    Me.Text = "Saper (Optimizer Edition) v" + softVersion + " - http://www.camnevsoftware.com/ - graham23s@Hotmail.com"
        '    ' ini file
        '    If (File.Exists("LogicFiles/Saper.ini")) Then
        '        ' read the ini file
        '        Dim ini As New saperINI("LogicFiles/Saper.ini")
        '        Dim apiSM = ini.ReadValue("seomoz", "key")
        '        Dim apiMJ = ini.ReadValue("majesticseo", "key")
        '        Dim smSplit As String() = apiSM.Split("|"c)
        '        formSettings.txtBoxAI.Text = smSplit(0).ToString.Trim()
        '        formSettings.txtBoxKY.Text = smSplit(1).ToString.Trim()
        '        formSettings.txtBoxMajesticAPI.Text = apiMJ
        '    Else
        '        Me.returnMessage("The 'LogicFiles/Saper.ini' file is missing! please download the latest version.")
        '        Close()
        '    End If
        '    ' load if file exists
        If (File.Exists("Accounts/accounts.acc")) Then
            Dim objReader As New StreamReader("Accounts/accounts.acc")
            Do While objReader.Peek() <> -1
                comboBoxAccounts.Items.Add(objReader.ReadLine())
            Loop
            objReader.Close()
        End If
        '    ' check for update on load.
        '    checkForUpdates()
        'Else
        '    My.Computer.Clipboard.SetText("http://www.camnevsoftware.com/lic/key.php?k=" & HttpUtility.UrlEncode(keyToCheck).Trim().ToLower() & "&product=saper&h=" & HttpUtility.UrlEncode(strHostName).Trim().ToLower())
        '    Me.returnMessage("No license found! email us on graham23s@Hotmail.com with the paypal email you used to purchase for your key.")
        '    Close()
        'End If
        ' license check
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        ' Validation.
        If (txtUser.Text = "" Or txtPass.Text = "") Then
            returnMessage("You need to enter both your Sape username and password before logging in.")
            Exit Sub
        End If

        If (radioSockets.Checked = True) Then
            'act=login&r=https%3A%2F%2Fwww.sape.ru&username=graham23s&password=boggynigger&bindip=0&submit=%D0%92%D0%BE%D0%B9%D1%82%D0%B8
            'Dim HTML = saperFunctions.postURL("https://auth.sape.ru/login/", "username=" & txtUser.Text.Trim() & "&password=" & txtPass.Text.Trim() & "&__checkbox_bindip=true")
            Dim HTML = saperFunctions.postURL("https://auth.sape.ru/login/", "r=https%3A%2F%2Fwww.sape.ru&username=" & txtUser.Text.Trim() & "&password=" & txtPass.Text.Trim() & "&bindip=0&submit=%D0%92%D0%BE%D0%B9%D1%82%D0%B8", varCookieJar)
            If (HTML.Contains("name=""checkCode""")) Then
                Me.returnMessage("You have been temporarily banned for 10 minutes from logging in!")
                formCaptcha.Show()
                Exit Sub
            End If

            ' deal with captchas
            If (HTML.Contains("captcha[id]")) Then
                returnMessage("Captcha has been triggered! wait 30 minutes before retrying!")
                Exit Sub
            End If

            If (HTML.Contains("/logout/")) Then
                ' get the balance and clean the string
                Dim stringReplaced As String = String.Empty
                Dim balanceHTML = saperFunctions.getURL("http://widget.sape.ru/balance/?alt=html&tpl=balance_main&container_id=balance_widget_src&charset=windows-1251", varCookieJar)
                Dim token As Match = Regex.Match(balanceHTML, "<td colspan=""2"">        <b>            (.*?)        </b>    </td>", RegexOptions.IgnoreCase)
                If token.Success Then
                    stringReplaced = token.Groups(1).Value.Replace(",", ".").Replace("&nbsp;", "").Replace("&#8399;", "").Trim()
                    lblLoginStatus.Text = "$" & stringReplaced.Trim()
                    lblLoginStatus.ForeColor = Color.Green
                End If

                ' we are logged in so disable the login button
                btnLogin.Enabled = False
                radioXMLRPC.Checked = True
                Dim projectHTML = saperFunctions.getURL("http://www.sape.ru/projects.php", varCookieJar)
                Dim projectFlag = saperFunctions.returnProjects(projectHTML)

                ' check for sub projects
                ' TODO:
                ' check for sub projects

                ' get twitter projects
                Dim projectTW = saperFunctions.getURL("http://pr2.sape.ru/project/index/section_id/0", varCookieJar)

                ' regex values (project, id, project name, etc)
                Dim networks_m As MatchCollection = Regex.Matches(projectTW, "<option value=""(.*?)"".*?>(.*?)<\/option>", RegexOptions.IgnoreCase)
                For Each network_m As Match In networks_m
                    Dim value As String = network_m.Groups(1).Value
                    If value.Length < 1 Then
                        Continue For
                    End If
                    Dim name As String = network_m.Groups(2).Value

                    ' ignore the first value: Все проекты
                    If (name = "Все проекты") Then

                    Else
                        ' do some splits/fixing
                        Dim newString As String() = Split(name, "№")
                        'MessageBox.Show(newString(0).ToString())
                        'dataGridProjectsTwitter.Rows.Add(newString(1).ToString().Trim(), newString(0).ToString())
                        'dataGridProjectsTwitter.Rows(dataGridProjectsTwitter.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightBlue
                    End If
                    'If Not networks_from_values.ContainsKey(name) Then
                    '    networks_from_values.Add(name, value)
                    'End If
                Next

                ' enough money in sape to continue?
                If (stringReplaced.ToString = "0.00") Then
                    returnMessage("You don't have any funds in Sape, you must top up your account before you can go to work.")
                    Return
                End If

                ' first time setup
                If (dataGridProjects.Rows.Count < 1) Then
                    btnFirstTimeSetup.Visible = True
                End If
            Else
                ' show an error
                lblLoginStatus.Text = "Error..."
                lblLoginStatus.ForeColor = Color.Red
            End If
        Else
            ' do we need this? TODO:
            Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
            Dim userId As Integer = proxy.SapeLogin(txtUser.Text.Trim(), txtPass.Text.Trim())
            If (userId > 0) Then
                Dim userBalance As XmlRpcStruct = proxy.SapeGetRealBalance()
                lblLoginStatus.Text = "$ " & userBalance("balanceTotal").ToString
                lblLoginStatus.ForeColor = Color.Green
            End If
            btnLogin.Enabled = False
        End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Close()
    End Sub

    Private Sub btnLogout_Click(ByVal sender As Object, ByVal e As EventArgs)
        btnLogin.Enabled = True
    End Sub

    Private Sub radioXMLRPC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioXMLRPC.CheckedChanged
        If (radioXMLRPC.Checked = True) Then
            txtUser.Enabled = False
            txtPass.Enabled = False
        End If
    End Sub

    Private Sub radioSockets_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioSockets.CheckedChanged
        If (radioSockets.Checked = True) Then
            txtUser.Enabled = True
            txtPass.Enabled = True
        End If
    End Sub

    Private Sub btnStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (lblLoginStatus.Text.Contains("Balance:")) Then
            formStats.Show()
        Else
            returnMessage("You need to do ""Step 1"" first, login and retrieve project data.")
            Exit Sub
        End If
    End Sub

    Private Sub chkBoxHidePass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxHidePass.CheckedChanged
        txtPass.UseSystemPasswordChar = chkBoxHidePass.Checked
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        dataGridProjects.Rows.Clear()
    End Sub

    Private Sub dataGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridProjects.CellContentClick
        ' Check if the window is already open.
        If (formProject.IsHandleCreated) Then
            returnMessage("You already have a window open, please close it first before viewing another project.")
            Exit Sub
        Else
            Dim colName As String = dataGridProjects.Columns(e.ColumnIndex).Name
            If (colName = "columnActionButton") Then
                Dim rowName As String = dataGridProjects.Rows(e.RowIndex).Cells(0).Value.ToString
                'MessageBox.Show(rowName)
                Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
                Dim userId As Integer = proxy.SapeLogin(txtUser.Text.Trim(), txtPass.Text.Trim())
                If (userId > 0) Then
                    Try
                        Dim project As SapeGetProject = proxy.SapeGetProject(Convert.ToInt32(rowName))
                        formProject.Text = project.id.ToString()
                        formProject.txtBoxProjectName.Text = project.name
                        'formProject.comboBoxErrorsInDays.Items.Add(project.nof_days_to_keep_errors.ToString)
                        formProject.lblSpentToday.Text = project.amount_today.ToString
                        formProject.lblSpentYesterday.Text = project.amount_yesterday.ToString
                        formProject.lblSpentTotal.Text = project.amount_total.ToString
                        formProject.lblDateCreated.Text = project.date_created.ToString
                        formProject.lblURLsProject.Text = project.nof_urls.ToString
                        formProject.lblLinksOK.Text = project.nof_pls.ToString
                        formProject.lblDays.Text = "Currently set at (" + project.nof_days_to_keep_errors.ToString + ") days."
                        'TODO: Select proper errors in days in combobox 
                        'If (project.nof_days_to_keep_errors.ToString) Then
                        'End If
                        formProject.comboBoxErrorsInDays.SelectedIndex = project.nof_days_to_keep_errors - 7
                        formProject.Show()
                    Catch ex As Exception
                        returnMessage("XML-RPC ERROR!" & vbCrLf & vbCrLf & ex.ToString)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub comboBoxAccounts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBoxAccounts.SelectedIndexChanged
        If (File.Exists("Accounts/accounts.acc")) Then
            Dim accountAuth As String() = Split(comboBoxAccounts.SelectedItem.ToString, "|")
            txtUser.Text = accountAuth(0)
            txtPass.Text = accountAuth(1)
        Else
            returnMessage("You don't have any accounts saved yet.")
        End If
    End Sub

    Private Sub btnLogOut_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogOut.Click
        Dim H = saperFunctions.getURL("https://auth.sape.ru/logout/?r=https%3A%2F%2Fwww.sape.ru", varCookieJar)
        If (H.Contains("https://auth.sape.ru/login/")) Then
            btnLogin.Enabled = True
            radioSockets.Checked = True
            dataGridProjects.Rows.Clear()
            'dataGridProjectsTwitter.Rows.Clear()
            lblLoginStatus.Text = ""
            formProject.Close()
        End If
    End Sub

    Private Sub btnFirstTimeSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstTimeSetup.Click
        ' Validation.
        If (lblLoginStatus.Text = "") Then
            Me.returnMessage("You need to login first.")
            Exit Sub
        End If
        formProject.Show()
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        formSettings.Show()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        'formUpdateLog.Show()
    End Sub

    Private Sub btnDeleteProject_Click(sender As System.Object, e As System.EventArgs)
        'Dim r As Boolean
        'Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        'Dim userId As Integer = proxy.SapeLogin(txtUser.Text.Trim(), txtPass.Text.Trim())
        'r = proxy.SapeDeleteProject(Convert.ToInt32("2246822"))
        'If (userId > 0) Then
        '    'For Each xmlRpcStruct As XmlRpcStruct In r
        '    '    For Each s As String In xmlRpcStruct.Keys
        '    '        MessageBox.Show("Key: " + s + " Value: " + xmlRpcStruct.Item(s).ToString())
        '    '    Next
        '    'Next
        'End If
        'For Each xmlRpcStruct As XmlRpcStruct In project
        '    For Each s As String In xmlRpcStruct.Keys
        '        MessageBox.Show("Key: " + s + " Value: " + xmlRpcStruct.Item(s).ToString())
        '    Next
        'Next
    End Sub

    Private Sub MenuItem8_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem8.Click
        formUpdateLog.Show()
    End Sub

    Private Sub btnDeleteProjectMain_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteProjectMain.Click
        Dim delPro As String
        Dim resPro As String
        Dim sB As New StringBuilder()
        For Each row As DataGridViewRow In dataGridProjects.Rows
            If (row.Cells(4).Value IsNot Nothing) Then
                ' JSON
                delPro = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=add&task=projectDelete", "project_ids=" + row.Cells(0).Value.ToString(), varCookieJar)
                resPro = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=status&task=projectDelete", "", varCookieJar)

                ' purely for debugging
                sB.Append("1: " + delPro)
                sB.Append(Environment.NewLine + "----------------------------------------------------------------" + Environment.NewLine)
                sB.Append("2: " + resPro)
                sB.Append(Environment.NewLine + "----------------------------------------------------------------" + Environment.NewLine)

                ' responses
                Dim tempPost = New With {Key .message = "", Key .error = 0, Key .done = False, Key .jsdata = ""}
                Dim obj1 = JsonConvert.DeserializeAnonymousType(resPro, tempPost)
                Dim com As String = obj1.message
                Dim obj2 = JsonConvert.DeserializeObject(Of saperJsonObject)(resPro)

                ' new way to read responses
                ' using the short one:
                'Dim jstr = resPro
                'Dim jobj = JsonConvert.DeserializeObject(Of sapeJsonResponse)(jstr)
                'MessageBox.Show(CStr(jobj.done))

                If CBool((CStr(obj2.done))) Then
                    dataGridProjects.Rows.Remove(row)
                    Me.returnMessage("Project has been deleted!")
                Else
                    dataGridProjects.Rows.Remove(row)
                    Me.returnMessage("Project has been deleted!")
                End If
            End If
        Next
    End Sub

    Private Sub MenuItem7_Click(sender As System.Object, e As System.EventArgs) Handles MenuItem7.Click
        ' Check for updates.
        checkForUpdates()
    End Sub

    Private Sub dataGridProjectsTwitter_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        '' check if the window is already open.
        'If (formTwitter.IsHandleCreated) Then
        '    returnMessage("You already have a window open, please close it first before posting a tweet.")
        '    Exit Sub
        'Else
        '    'Dim colName As String = dataGridProjectsTwitter.Columns(e.ColumnIndex).Name
        '    If (colName = "columnTweetButton") Then
        '        'Dim rowName As String = dataGridProjectsTwitter.Rows(e.RowIndex).Cells(0).Value.ToString
        '        'MessageBox.Show(rowName)
        '        Try
        '            'formTwitter.Text = rowName
        '            ' navigate to tweets page
        '            'http://pr2.sape.ru/twaccount/search/project_id/1268140
        '            'MessageBox.Show("http://pr2.sape.ru/twaccount/search/project_id/" & formTwitter.Text)
        '            'Dim tweetHTML As String = saperFunctions.getURL("http://pr2.sape.ru/twaccount/search/project_id/" & formTwitter.Text, Me.varCookieJar)
        '            'POST http://pr2.sape.ru/twadvert/new HTTP/1.1
        '            'Host:               pr2.sape.ru()
        '            'Connection:         keep -alive
        '            'Content-Length: 71
        '            'Cache -Control : max -age = 0
        '            'Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
        '            'Origin: http://pr2.sape.ru
        '            'Upgrade-Insecure-Requests: 1
        '            'User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36
        '            'Content-Type: application/x-www-form-urlencoded
        '            'Referer: http://pr2.sape.ru/twaccount/search/project_id/1268140
        '            'Accept -Encoding : gzip, deflate
        '            'Accept-Language: en-US,en;q=0.8
        '            'Cookie: sape_tips=%7B%22excludedIdx%22%3A%5B%5D%2C%22currentIdx%22%3A16%2C%22isClosed%22%3Atrue%7D; pr_v2_beta=[1135778]; bb0lastvisit=1437392395; bb0lastactivity=0; SAPE=4CPNNZafH8J-0SMtYJ3Tae1Dy1d; AUTH_TICKET=caf0319fd29225cc916e4773a0175e5e; PR2=88e954097c87e1667b00eefab2752333:ebeaa518e7ac9563a59e16e481ba98c9306415a8; jv_enter_ts_yeKRzktijd=1440319437098; jv_refer_yeKRzktijd=http%3A%2F%2Fwww.sape.ru%2F; jv_visits_count_yeKRzktijd=2; pr2_is_projects={"1135778":1}; __utmt=1; _ym_visorc_28733991=w; __utma=261317330.566004734.1437217907.1440281313.1440319419.9; __utmb=261317330.64.9.1440324321957; __utmc=261317330; __utmz=261317330.1437217907.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)
        '            'project_id=1268140&type=link&twaccount%5B%5D=97408&twaccount%5B%5D=5044
        '            'Dim postTweetHTML As String = saperFunctions.postURL("http://pr2.sape.ru/twadvert/new", "project_id=" & formTwitter.Text & "&type=link&twaccount%5B%5D=97408&twaccount%5B%5D=5044", Me.varCookieJar)
        '            formTwitter.Show()
        '            ' Regex values
        '            'var data = File.ReadAllText("page.htm");
        '            'Dim htmlDoc = New HtmlAgilityPack.HtmlDocument()
        '            'htmlDoc.OptionFixNestedTags = True
        '            'htmlDoc.LoadHtml(tweetHTML)
        '            'Dim ulNode = htmlDoc.DocumentNode.SelectNode("//tr[@class = 'link' or @class = 'font']"))
        '            'MessageBox.Show(ulNode)

        '            'Dim arr As New ArrayList
        '            'arr.Add("1000000")
        '            'arr.Add("2000000")
        '            'arr.Add("3000000")
        '            'Dim acc As String = String.Empty
        '            'For i As Integer = 0 To arr.Count - 1
        '            '    acc += "twaccount%5B%5D=" & arr(i).ToString()
        '            'Next
        '            'MessageBox.Show(acc)

        '        Catch ex As Exception
        '            returnMessage("TWITTER ERROR!" & vbCrLf & vbCrLf & ex.ToString)
        '        End Try
        '    End If
        'End If
    End Sub
End Class
