Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports CookComputing.XmlRpc
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports HtmlAgilityPack
Imports System.Xml

Public Class formProject

    ' MYSQL parameters...
    Dim myConn As MySqlConnection
    Dim myQery As String = ""
    Dim mySqlC As MySqlCommand
    Dim mySqDr As MySqlDataReader

    ' make searching the listview easier
    Dim listCopy As New List(Of ListViewItem)

    Private Sub btnUpdateProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateProject.Click
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        If (userId > 0) Then
            Try
                Dim daysInNumber As Integer = CInt(comboBoxErrorsInDays.SelectedItem)
                Dim projectUpdate As SapeProjectUpdateStruct = proxy.SapeGetProject(Convert.ToInt32(Me.Text))
                projectUpdate.name = txtBoxProjectName.Text
                projectUpdate.nof_days_to_keep_errors = daysInNumber
                Dim result As Boolean = proxy.SapeUpdateProject(Convert.ToInt32(Me.Text), projectUpdate)
                If (result) Then
                    formMain.returnMessage("Project data updated successfully!")
                End If
            Catch ex As Exception
                formMain.returnMessage("XML-RPC ERROR!" & vbCrLf & vbCrLf & ex.ToString)
            End Try
        End If
    End Sub

    Private Sub listViewMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewMain.SelectedIndexChanged

    End Sub

    Private Sub btnDownloadProjectData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownloadProjectData.Click
        listViewMain.Items.Clear()
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        'proxy.UseIntTag = True
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        If (userId > 0) Then
            Try
                Dim projectSites As XmlRpcStruct() = proxy.SapeGetProjectLinks(Convert.ToInt32(Me.Text))
                If (projectSites.Count > 0) Then
                    Dim index As Integer = 0
                    Dim TotalValue As Double
                    For Each item In projectSites
                        Dim sapeID = projectSites(index)("id").ToString
                        Dim sapeStatus = projectSites(index)("status").ToString
                        Dim sapeSiteID = projectSites(index)("site_id").ToString
                        Dim sapeURLID = projectSites(index)("url_id").ToString
                        Dim sapeURL = projectSites(index)("site_url").ToString()
                        Dim sapePage = projectSites(index)("page_uri").ToString()
                        Dim sapePageID = projectSites(index)("page_id").ToString()
                        Dim sapePagePR = projectSites(index)("page_pr").ToString()
                        Dim sapePageLevel = projectSites(index)("page_level").ToString()
                        Dim sapePageExternalLinks = projectSites(index)("page_nof_ext_links").ToString()
                        Dim sapePageAnchorText = projectSites(index)("txt").ToString()
                        Dim sapePrice = projectSites(index)("price").ToString()
                        Dim sapeCatID = projectSites(index)("category_id").ToString()
                        Dim lv As ListViewItem = listViewMain.Items.Add(sapeID)

                        ' Colour the OK.
                        If (sapeStatus = "OK") Then
                            lv.UseItemStyleForSubItems = False
                            lv.SubItems.Add(sapeStatus).ForeColor = Color.Green
                        Else
                            lv.UseItemStyleForSubItems = False
                            lv.SubItems.Add(sapeStatus).ForeColor = Color.Red
                        End If

                        lv.SubItems.Add(sapeSiteID)
                        lv.SubItems.Add(sapeURLID)
                        lv.SubItems.Add(sapeURL)
                        lv.SubItems.Add(sapePage)
                        lv.SubItems.Add(sapePageID)
                        lv.SubItems.Add(sapePagePR)

                        ' Colour page level.
                        If (sapePageLevel = "1") Then
                            lv.SubItems.Add(sapePageLevel).BackColor = Color.LightGreen
                        ElseIf (sapePageLevel = "2") Then
                            lv.SubItems.Add(sapePageLevel).BackColor = Color.LightPink
                        ElseIf (sapePageLevel = "3") Then
                            lv.SubItems.Add(sapePageLevel).BackColor = Color.LightGray
                        Else
                            lv.SubItems.Add(sapePageLevel)
                        End If

                        lv.SubItems.Add(sapePageExternalLinks)
                        lv.SubItems.Add(sapePageAnchorText)
                        lv.SubItems.Add(sapePrice)
                        lv.SubItems.Add(sapeCatID)
                        index += 1

                        TotalValue += CDbl(sapePrice)
                        'TotalValue += X
                    Next
                    ' price conversion needed to USD
                    Dim amount As Double = CDbl(TotalValue)
                    Dim dollars As Double = Double.Parse(CStr(MoneyConverter.RubbleToUsd(CDbl(amount))))
                    Dim newPrice = Convert.ToDecimal(dollars).ToString("c")
                    lblTotalSpentUSD.Text = newPrice.Replace("£", "$")
                    ' update
                    formMain.returnMessage("Your bought links can be seen on the ""MANAGE LINKS PURCHASED"" tab.")
                Else
                    formMain.returnMessage("There is no links to show, have you bought any on Sape yet?")
                End If
            Catch ex As Exception
                formMain.returnMessage("XML-RPC ERROR!" & vbCrLf & vbCrLf & ex.ToString)
            End Try
        End If
    End Sub

    Private Sub btnCheckLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckLinks.Click
        ' validation
        ' incase of import, check the fields are filled
        If (Information.IsNothing(Me.comboBoxLinkType.SelectedItem)) Then
            formMain.returnMessage("You need to select the link type!")
            Return
        End If
        If (Information.IsNothing(Me.comboBoxSearchLinkID.SelectedItem)) Then
            formMain.returnMessage("You need to select the link ID! Press the green arrow button above to load it.")
            Return
        End If
        If (Information.IsNothing(Me.comboBoxText.SelectedItem)) Then
            formMain.returnMessage("You need to select the text ID to post!")
            Return
        End If

        ' count 
        If (listViewShowLinks.Items.Count < 1) Then
            formMain.returnMessage("The links tab is empty! you need to search for links first.")
            Exit Sub
        Else
            'http://www.sape.ru/ajax_task.php?act=add&task=placementCreate 
            'http://www.sape.ru/ajax_task.php?act=status&task=placementCreate
            Dim buyHTML As String = String.Empty
            Dim resHTML As String = String.Empty
            Dim sB As New StringBuilder()
            For Each itm As ListViewItem In listViewShowLinks.CheckedItems
                ' is choose random text selected
                Dim splitVal As String()
                If (chkBoxPostRandomLink.Checked = True) Then
                    Dim r As New Random
                    Dim g As Integer
                    Do
                        g = r.Next(comboBoxText.Items.Count)
                    Loop While g = comboBoxText.SelectedIndex
                    splitVal = comboBoxText.Items(g).ToString().Split("-"c)
                Else
                    splitVal = comboBoxText.SelectedItem.ToString().Split("-"c)
                End If
                'MessageBox.Show(itm.SubItems(4).Text.Substring(0, 1000))
                ' JSON
                buyHTML = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=add&task=placementCreate", "p%5B%5D=" + itm.SubItems(7).Text.Trim() + "&url_text_id%5B" + itm.SubItems(7).Text.Trim() + "%5D=" + splitVal(1).ToString().Trim() + "&forceSeoWait=0&link_id=" + comboBoxSearchLinkID.SelectedItem.ToString() + "&filter_mode=0&ms=" + itm.SubItems(4).Text.Trim() + "&pgex=" + itm.SubItems(3).Text.Trim() + "&searchId=" + itm.SubItems(2).Text.Trim() + "&price_2=0", formMain.varCookieJar)
                resHTML = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=status&task=placementCreate", "", formMain.varCookieJar)
                itm.Checked = False
            Next

            ' responses
            Dim tempPost = New With {Key .message = "", Key .error = 0, Key .done = False, Key .jsdata = ""}
            Dim obj = JsonConvert.DeserializeAnonymousType(resHTML, tempPost)
            Dim com As String = obj.message
            Dim obj2 = JsonConvert.DeserializeObject(Of saperJsonObject)(resHTML)

            ' success flags
            If CBool((CStr(obj2.done))) Then
                formMain.returnMessage("Link successfully purchased!")
            Else
                formMain.returnMessage("Link successfully purchased!")
            End If
        End If
    End Sub

    Private Sub btnCreateProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Validation.
        If (txtBoxCreateProjectName.Text = "" Or txtBoxProjectURL.Text = "" Or txtBoxProjectAnchors.Text = "" Or txtBoxProjectAlias.Text = "" Or txtBoxProjectkeywords.Text = "") Then
            formMain.returnMessage("You must fill in all project fields.")
            Exit Sub
        End If
        ' Character count check.
        For Each line As String In txtBoxProjectAnchors.Lines
            If (line.Count > 100) Then
                formMain.returnMessage("One of your anchor text lines is over 100 characters.")
                Exit Sub
            End If
        Next
        Dim addHTL = saperFunctions.getURL("http://www.sape.ru/project.php?act=add", formMain.varCookieJar)
        ' Regex to get the folder ID.
        Dim addFID = saperFunctions.returnFolderID(addHTL)
        '//MessageBox.Show("Folder ID: " + addFID)
        Dim addPFG = saperFunctions.postURL("http://www.sape.ru/project.php?act=add", "name=" & txtBoxCreateProjectName.Text & "&folder_id=" & addFID & "&domain=" & "http%3A%2F%2F" & "&region=%CC%EE%F1%EA%E2%E0&type=normal", formMain.varCookieJar)

        'name=name&folder_id=1471962&domain=http%3A%2F%2F&region=%CC%EE%F1%EA%E2%E0&type=normal
        If (addPFG.Contains("Проект добавлен в систему. Сейчас Вы можете сделать тонкую настройку.")) Then
            formMain.returnMessage("Project (" + txtBoxCreateProjectName.Text + ") has been created successfully. Now adding URL/Keywords then we are done. Logout and log back in to view your newly created project.")
            Dim addProjectID As String = saperFunctions.returnProjectsID(addPFG)
            Dim addProjectPT = saperFunctions.postURL("http://www.sape.ru/project.php?act=add_url&id=" & addProjectID.Trim() & "&add_mode=simple", "url=" & txtBoxProjectURL.Text & "&name=" & txtBoxProjectAlias.Text & "&keyword=" & txtBoxProjectkeywords.Text, formMain.varCookieJar)

            If (addProjectPT.Contains("Неверный формат URL!")) Then
                formMain.returnMessage("Sape reports that your URL is in an incorrect format!")
                Exit Sub
            End If

            If (addProjectPT.Contains("Ключевое слово заданное для вашего URL")) Then
                Dim returnLinkID = saperFunctions.returnLinkID(addProjectPT)
                Dim addLinkPST = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=add&task=projectUrlTextAdd", "link_id=" + returnLinkID + "&query=" + txtBoxCreateProjectName.Text + "&uri=" + txtBoxProjectURL.Text + "&exactEnv=5&exactAtt=5&notExactEnv=5&notExactAtt=5&texts=" + txtBoxProjectAnchors.Text + "&limit=0", formMain.varCookieJar)
                If (addLinkPST.Contains(txtBoxProjectAnchors.Text)) Then
                    'formMain.returnMessage("Anchor text has been added successfully. Now search and buy some links!")
                End If
            Else
                formMain.returnMessage("Error: Project creation failed! use the HTML debug to see the last error shown.")
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim testHTML = formMain.postURL("http://www.sape.ru/ajax_orders.php?ajax_act=search&return_result=true", "act=s_order&filter_mode=0&project_id=1785382&link_id=56482823&show_mode=&pn=1&s_nogood=0&s_pr_from=&s_pr_2=&s_tr_1=&s_tr_2=&s_site_pr_1=&s_site_pr_2=&s_cy_from=&s_cy_2=&s_ext_links=&s_ext_links_forecast=&s_price_from=0&s_price_2=0&s_days_old_whois=&s_in_dmoz=2&s_in_yaca=2&s_in_dmoz_yaca=0&s_domain_level=&s_links_display_mode=-1&categories_selector=on&yaca_categories_selector=on&regions_selector=on&domain_zones_selector=on&s_words_type=0&s_words=&s_words_proximity=3&s_date_added=&s_site_id=&s_page_id=&s_no_double_in_project=&s_no_double_in_folder=&s_flag_blocked_in_yandex=0&s_flag_blocked_in_google=2&s_pages_per_site=preferred&ps=50&anchor_order=&order=&show_mode=1&name=&new_search=1")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Validation.
        If (Me.Text = "") Then
            formMain.returnMessage("If you have just created your first project then close the window then log back in again and select ""View"" next to your project.")
            Exit Sub
        End If
        If (IsNothing(comboBoxLinkType.SelectedItem)) Then
            formMain.returnMessage("You need to select the link type!")
            Exit Sub
        End If
        If (IsNothing(comboBoxSearchLinkID.SelectedItem)) Then
            formMain.returnMessage("You need to select the link ID! Press the ID button above (top right) to auto grab it.")
            Exit Sub
        End If
        ' Run background worker.
        If (bgWorker.IsBusy <> True) Then
            tabControls.SelectedTab = TabPage2
            formMain.returnMessage("Please wait while we search for links, it may take a few minutes..." + Environment.NewLine + Environment.NewLine + "Searching for: (" + comboBoxLinkType.SelectedItem.ToString + ") Links.")
            bgWorker.RunWorkerAsync("sape_begin_search")
            btnSearchLinks.Enabled = False
        End If

    End Sub

    Private Function GetId(tableNode As HtmlNode) As String
        Dim span = From x In tableNode.Descendants("span")
                                   Where x.InnerText.Contains("ID:")

        Dim text = Split(span(0).InnerText, "|")(0)
        text = Replace(text, "ID: ", String.Empty)
        Return Trim(text)
    End Function

    Private Function GetUrl(tableNode As HtmlNode) As String
        Dim div_long_link = From x In tableNode.Descendants("div")
                                   Where x.Name = "div" And Not IsNothing(x.Attributes("class")) And x.Attributes("class").Value = "long_link"

        Dim ajax_link = From x In div_long_link(0).Descendants("a")
        Dim url = ajax_link(0).InnerText
        Return url
    End Function

    Private Function GetPr(ByVal columns As IEnumerable(Of HtmlNode)) As String
        Return columns(4).InnerText
    End Function

    Private Function GetSr(ByVal columns As IEnumerable(Of HtmlNode)) As String
        Return columns(5).InnerText
    End Function

    Private Function GetSecondTable(tables_2 As IEnumerable(Of HtmlNode), id As String) As HtmlNode
        Dim leaf_Id = String.Format("leaf_{0}", id)
        Dim tables = From node In tables_2
                  Where node.Attributes("id").Value = leaf_Id 'node.Attributes("class").Value = "orders_result_tree_info" And

        Return tables(0)
    End Function

    Private Function GetSecondTableColumns(table2 As HtmlNode) As IEnumerable(Of HtmlNode)
        Dim result = From x In table2.Elements("tbody")(0).Elements("tr")(0).Elements("td")
        Return result
    End Function

    Private Function GetTextId(ByVal columns As IEnumerable(Of HtmlNode)) As String
        Return columns.Last().Element("input").Attributes("value").Value
    End Function

    Private Function GetPrice(ByVal columns As IEnumerable(Of HtmlNode)) As String
        Return columns.Last().Element("input").Attributes("price").Value
    End Function

    Private Function GetLinkId(ByVal columns As IEnumerable(Of HtmlNode)) As String
        Dim raw = columns.Last().Element("input").Attributes("id").Value
        Return Split(raw, "_")(1)
    End Function

    Private Function ShouldProcessSubItems(userLinkType As String) As Boolean
        Select Case userLinkType
            Case "Level 1 - /"
                Return False
            Case "Level 2 - //"
                Return True
            Case "Level 3 - ///"
                Return True
        End Select
        Return False
    End Function

    Private Function GetSubTableRows(ByVal subTable As HtmlNode) As IEnumerable(Of HtmlNode)
        Dim result = From x In subTable.Elements("tbody")(0).Elements("tr")
        Return result
    End Function

    Private Sub bgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        ' cast to a string value.
        Dim action As String = TryCast(e.Argument, String)

        If (action = "sape_insert_to_database") Then
            '' Make global.
            'Dim myDataTable As New System.Data.DataTable()

            'If (listViewShowLinks.Items.Count < 1) Then
            '    formMain.returnMessage("There is no URLs in the 'SAPE > PURCHASE LINKS' table!")
            'Else
            '    ' Validation.
            '    If (lblMysql.Text = "Not connected...") Then
            '        formMain.returnMessage("You need to successfully connect to the database first!")
            '        Exit Sub
            '    End If
            '    For Each itm As ListViewItem In listViewShowLinks.CheckedItems
            '        'MessageBox.Show(itm.SubItems(0).Text)
            '        ' Small conversion for the date.
            '        Dim dateNow = DateTime.Now
            '        Dim dateFix As String = "yyyy-MM-dd HH:mm:ss"
            '        Dim dateNew = dateNow.ToString(dateFix)

            '        '//////////////////////////// QUERY ///////////////////////////////////////////////////////////////////
            '        myConn = New MySqlConnection("SERVER=" & txtMysqlIP.Text.Trim() & ";PORT=" & txtMysqlPort.Text.Trim() & ";UID=" & txtMysqlUser.Text.Trim() & ";PASSWORD=" & txtMysqlPass.Text.Trim() & ";DATABASE=" & txtMysqlDBName.Text.Trim())
            '        myConn.Open()
            '        myQery = "SELECT COUNT(*) FROM sape_urls WHERE sape_url='" & itm.SubItems(1).Text.Trim() & "'"
            '        mySqlC = New MySqlCommand(myQery, myConn)
            '        mySqlC.CommandText = "SELECT COUNT(*) FROM sape_urls WHERE sape_url='" & itm.SubItems(1).Text.Trim() & "'"
            '        Dim numRows = mySqlC.ExecuteScalar()
            '        ' Count if the data already exists in the table.
            '        If (CDbl(numRows.ToString) > 0) Then
            '            ' It already exists
            '        Else
            '            '//////////////////////////// QUERY ///////////////////////////////////////////////////////////////////
            '            Try
            '                myConn = New MySqlConnection("SERVER=" & txtMysqlIP.Text.Trim() & ";PORT=" & txtMysqlPort.Text.Trim() & ";UID=" & txtMysqlUser.Text.Trim() & ";PASSWORD=" & txtMysqlPass.Text.Trim() & ";DATABASE=" & txtMysqlDBName.Text.Trim())
            '                myConn.Open()
            '                ' Queries...
            '                myQery = "INSERT INTO sape_urls (sape_unique_id,sape_id,sape_url,sape_url_pr,sape_url_price,sape_url_da,sape_url_pa,sape_level,sape_date_added) VALUES ('','" & itm.SubItems(5).Text.Trim() & "','" & itm.SubItems(1).Text.Trim() & "','" & itm.SubItems(8).Text.Trim() & "','" & itm.SubItems(6).Text.Trim() & "','','','" & comboBoxLinkType.SelectedItem.ToString() & "','" & dateNew.Trim() & "')"
            '                mySqlC = New MySqlCommand(myQery, myConn)
            '                mySqDr = mySqlC.ExecuteReader
            '                myConn.Close()
            '                mySqDr.Close()
            '                itm.Checked = False
            '            Catch ex As Exception
            '                formMain.returnMessage(ex.ToString)
            '                btnMysqlConnect.Enabled = True
            '                btnAddURLsToDatabase.Enabled = True
            '            End Try
            '            '//////////////////////////// QUERY ///////////////////////////////////////////////////////////////////
            '        End If
            '        myConn.Close()
            '    Next
            '    formMain.returnMessage("Successfully added URLs to the database.")
            'End If
        End If
        'sape_insert_to_database

        If (action = "sape_begin_search") Then
            ' [post] - act=s_order&filter_mode=0&project_id=1785382&link_id=56482823&show_mode=&pn=1&s_nogood=1&s_pr_from=1&s_pr_2=2&s_tr_1=&s_tr_2=&s_site_pr_1=&s_site_pr_2=&s_cy_from=&s_cy_2=&s_ext_links=5&s_ext_links_forecast=&s_price_from=0&s_price_2=0&s_days_old_whois=50&s_in_dmoz=2&s_in_yaca=2&s_in_dmoz_yaca=0&s_domain_level=&&s_links_display_mode=-1&categories_selector=on&yaca_categories_selector=on&regions_selector=on&domain_zones_selector=on&s_words_type=0&s_words=&s_words_proximity=3&s_date_added=&s_site_id=&s_page_id=&s_no_double_in_project=&s_no_double_in_folder=&s_flag_blocked_in_yandex=0&s_flag_blocked_in_google=2&s_pages_per_site=preferred&ps=50&anchor_order=&order=&show_mode=1&name=&s_domain_zones%5B%5D=275&s_domain_zones%5B%5D=276&s_categories%5B%5D=52&s_categories%5B%5D=43&new_search=1
            ' [post] - act=s_order&filter_mode=0&project_id=2401979&link_id=89319054&show_mode=&pn=1&s_nogood=0&s_pr_from=&s_pr_2=&s_tr_1=&s_tr_2=&s_site_pr_1=&s_site_pr_2=&s_cy_from=&s_cy_2=&s_ext_links=&s_ext_links_forecast=&s_price_from=0&s_price_2=0&s_days_old_whois=&s_in_dmoz=2&s_in_yaca=2&s_in_dmoz_yaca=0&s_domain_level=&s_links_display_mode=-1&categories_selector=on&yaca_categories_selector=on&regions_selector=on&domain_zones_selector=on&s_words_type=0&s_words=&s_words_proximity=3&s_date_added=&s_site_id=&s_page_id=&s_no_double_in_project=&s_no_double_in_folder=&s_flag_blocked_in_yandex=0&s_flag_blocked_in_google=2&s_pages_per_site=preferred&ps=50&anchor_order=&order=&show_mode=1&name=&new_search=1
            ' vars
            Dim rs As String = String.Empty
            Dim sh As String = String.Empty
            Dim sp As String = String.Empty
            Dim rp As String = String.Empty
            Dim sl As String = String.Empty
            Dim rl As String = String.Empty
            Dim lt As String = String.Empty
            Dim si As String = String.Empty
            Dim pi As String = String.Empty
            Dim s1 As String = String.Empty
            Dim s2 As String = String.Empty
            Dim sID As String = String.Empty
            Dim mID As String = String.Empty
            Dim pID As String = String.Empty
            Dim iID As String = String.Empty
            Dim iUR As String = String.Empty
            Dim userLinkType As String = String.Empty

            If (InvokeRequired) Then
                Invoke(Sub()
                           userLinkType = comboBoxLinkType.SelectedItem.ToString
                       End Sub)
            End If

            Select Case userLinkType
                Case "Level 1 - /"
                    lt = "page_level_1=true"
                Case "Level 2 - //"
                    lt = "page_level_2=true"
                Case "Level 3 - ///"
                    lt = "page_level_3=true"
            End Select
            '//////////////////////////////////////////////////////////////////////////////////////////////

            '//////////////////////////////////////////////////////////////////////////////////////////////
            If (InvokeRequired) Then
                Invoke(Sub()
                           'Application.DoEvents()
                           ' check flag
                           Dim chkFlag As String = String.Empty
                           If (radioWordType0.Checked = True) Then
                               chkFlag = "1"
                           ElseIf (radioWordType1.Checked = True) Then
                               chkFlag = "0"
                           End If
                           ' Do an initial search to find out how many pages the query has.   
                           sh = saperFunctions.postURL("http://www.sape.ru/ajax_orders.php?ajax_act=search&return_result=true", "act=s_order&filter_mode=0&project_id=" + Me.Text + "&link_id=" + comboBoxSearchLinkID.SelectedItem.ToString + "&show_mode=&pn=1&s_nogood=1&s_pr_from=" + txtBoxFromPR.Text.Trim() + "&s_pr_2=" + txtBoxToPR.Text.Trim() + "&s_tr_1=" + txtBoxSR1.Text.Trim() + "&s_tr_2=" + txtBoxSR2.Text.Trim() + "&s_site_pr_1=&s_site_pr_2=&s_cy_from=&s_cy_2=&s_ext_links=" + txtBoxExternalLinks.Text.Trim() + "&s_ext_links_forecast=&s_price_from=0&s_price_2=0&s_days_old_whois=" + txtBoxAgeOver.Text.Trim() + "&s_in_dmoz=2&s_in_yaca=2&s_in_dmoz_yaca=0&s_domain_level=&" + lt + "&s_links_display_mode=-1&categories_selector=on&yaca_categories_selector=on&regions_selector=on&domain_zones_selector=on&s_words_type=" & chkFlag & "&s_words=" + txtBoxSearchTitleTags.Text.Replace(" ", "+") + "&s_words_proximity=3&s_date_added=&s_site_id=&s_page_id=" & txtBoxSearchSearches.Text.Trim() & "&s_no_double_in_project=&s_no_double_in_folder=&s_flag_blocked_in_yandex=0&s_flag_blocked_in_google=2&s_pages_per_site=preferred&ps=50&anchor_order=&order=&show_mode=1&name=" + formZones.txtBoxZonesPostString.Text + formCategories.txtBoxCatPostString.Text + "&new_search=1", formMain.varCookieJar)
                           sp = saperFunctions.returnPagesInTotal(sh)
                           'MessageBox.Show(sh)
                           'MessageBox.Show("act=s_order&filter_mode=0&project_id=" + Me.Text + "&link_id=" + comboBoxSearchLinkID.SelectedItem.ToString + "&show_mode=&pn=1&s_nogood=1&s_pr_from=" + txtBoxFromPR.Text.Trim() + "&s_pr_2=" + txtBoxToPR.Text.Trim() + "&s_tr_1=&s_tr_2=&s_site_pr_1=&s_site_pr_2=&s_cy_from=&s_cy_2=&s_ext_links=" + txtBoxExternalLinks.Text.Trim() + "&s_ext_links_forecast=&s_price_from=0&s_price_2=0&s_days_old_whois=" + txtBoxAgeOver.Text.Trim() + "&s_in_dmoz=2&s_in_yaca=2&s_in_dmoz_yaca=0&s_domain_level=&" + lt + "&s_links_display_mode=-1&categories_selector=on&yaca_categories_selector=on&regions_selector=on&domain_zones_selector=on&s_words_type=" & chkFlag & "&s_words=" + txtBoxSearchTitleTags.Text + "&s_words_proximity=3&s_date_added=&s_site_id=&s_page_id=&s_no_double_in_project=&s_no_double_in_folder=&s_flag_blocked_in_yandex=0&s_flag_blocked_in_google=2&s_pages_per_site=preferred&ps=50&anchor_order=&order=&show_mode=1&name=" + formZones.txtBoxZonesPostString.Text + formCategories.txtBoxCatPostString.Text + "&new_search=1")
                       End Sub)
            End If
            '//////////////////////////////////////////////////////////////////////////////////////////////
            If (sp = "") Then
                formMain.returnMessage("No results to show! please select more options!")
            Else
                ' vars
                Dim daVar As String = String.Empty
                Dim paVar As String = String.Empty
                Dim daPa As String = String.Empty
                Dim lamdaFix1 As String = String.Empty
                Dim lamdaFix2 As String = String.Empty
                Dim lamdaFix3 As String = String.Empty

                ' instantiate moz class
                Dim newMoz As New saperClassMoz()

                Dim i As Integer
                For i = 1 To Convert.ToInt32(sp)
                    bgWorker.WorkerSupportsCancellation = True
                    If (bgWorker.CancellationPending) Then
                        e.Cancel = True
                        formMain.returnMessage("Searching has been stopped!")
                        Exit For
                    End If

                    If (InvokeRequired) Then
                        Invoke(Sub()
                                   Dim chkFlag As String = String.Empty
                                   If (radioWordType0.Checked = True) Then
                                       chkFlag = "1"
                                   ElseIf (radioWordType1.Checked = True) Then
                                       chkFlag = "0"
                                   Else
                                       chkFlag = "0"
                                   End If

                                   ' this queries/scrapes each page
                                   sl = saperFunctions.postURL("http://www.sape.ru/ajax_orders.php?ajax_act=search&return_result=true", "act=s_order&filter_mode=0&project_id=" + Me.Text + "&link_id=" + comboBoxSearchLinkID.SelectedItem.ToString + "&show_mode=&pn=" + i.ToString + "&s_nogood=1&s_pr_from=" + txtBoxFromPR.Text.Trim() + "&s_pr_2=" + txtBoxToPR.Text.Trim() + "&s_tr_1=" & txtBoxSR1.Text.Trim() & "&s_tr_2=" & txtBoxSR2.Text.Trim() & "&s_site_pr_1=&s_site_pr_2=&s_cy_from=&s_cy_2=&s_ext_links=" + txtBoxExternalLinks.Text.Trim() + "&s_ext_links_forecast=&s_price_from=" & txtBoxPriceFrom.Text.Trim() & "&s_price_2=" & txtBoxPriceTo.Text.Trim() & "&s_days_old_whois=" + txtBoxAgeOver.Text.Trim() + "&s_in_dmoz=2&s_in_yaca=2&s_in_dmoz_yaca=0&s_domain_level=&" + lt + "&s_links_display_mode=-1&categories_selector=on&yaca_categories_selector=on&regions_selector=on&domain_zones_selector=on&s_words_type=" & chkFlag & "&s_words=" + txtBoxSearchTitleTags.Text.Replace(" ", "+") + "&s_words_proximity=3&s_date_added=&s_site_id=&s_page_id=" + txtBoxFromPR.Text.Trim() + "&s_no_double_in_project=&s_no_double_in_folder=&s_flag_blocked_in_yandex=0&s_flag_blocked_in_google=0&s_pages_per_site=preferred&ps=50&anchor_order=&order=&show_mode=1&name=" + formZones.txtBoxZonesPostString.Text + formCategories.txtBoxCatPostString.Text + "&new_search=1", formMain.varCookieJar)

                                   ' is debug on?
                                   If (formMain.chkBoxSaveHTMLDebug.Checked = True) Then
                                       Dim rnd As New Random()
                                       Using sw As New StreamWriter("Debug/" & "Page-" & i.ToString & "-" & rnd.Next(11111, 99999) & ".html", True)
                                           sw.WriteLine(sl)
                                           sw.Close()
                                       End Using
                                   End If
                                   GC.Collect()
                               End Sub)
                    End If

                    '//////////////////////////////////////////////////////////////////////////////////////////////

                    Dim doc = New HtmlDocument()
                    doc.LoadHtml(sl)

                    Dim searchId As String = String.Empty
                    Dim ms As String = String.Empty
                    Dim pgex As String = String.Empty

                    Dim idNode = doc.DocumentNode.SelectSingleNode("//input[@name='searchId']")
                    If idNode IsNot Nothing AndAlso idNode.Attributes("value") IsNot Nothing Then
                        searchId = idNode.Attributes("value").Value
                    End If

                    Dim msNode = doc.DocumentNode.SelectSingleNode("//input[@name='ms']")
                    If msNode IsNot Nothing AndAlso msNode.Attributes("value") IsNot Nothing Then
                        ms = msNode.Attributes("value").Value
                    End If

                    Dim pgNode = doc.DocumentNode.SelectSingleNode("//input[@name='pgex']")
                    If pgNode IsNot Nothing AndAlso pgNode.Attributes("value") IsNot Nothing Then
                        pgex = pgNode.Attributes("value").Value
                    End If

                    Dim allHtml = From node In doc.DocumentNode.Descendants()
                                 Where node.Name = "table" And Not IsNothing(node.Attributes("class"))

                    Dim tables_1 = From node In allHtml
                              Where node.Attributes("class").Value = "orders_result_tree_cart"

                    Dim tables_2 = From node In allHtml
                              Where node.Attributes("class").Value = "orders_result_tree_info"

                    ' regular links no sub tables
                    For Each t As HtmlNode In tables_1
                        Dim id = GetId(t)
                        Dim second_table = GetSecondTable(tables_2, id)
                        Dim second_table_columns = GetSecondTableColumns(second_table)
                        Dim mainUrl = String.Format("http://{0}", GetUrl(t))
                        If (InvokeRequired) Then
                            Invoke(Sub()
                                       If (mainUrl.Contains("URL")) Then
                                           ' don't add
                                       Else
                                           listViewShowLinks.BeginUpdate()
                                           Dim lv As ListViewItem = listViewShowLinks.Items.Add(id) '// ID.
                                           lv.SubItems.Add(mainUrl)                          '// URL.
                                           lv.SubItems.Add(searchId)                         '// SEARCH ID.
                                           lv.SubItems.Add(pgex)                             '// PGEX.
                                           lv.SubItems.Add(ms.Trim())                        '// MS.
                                           'lv.SubItems.Add(GetTextId(second_table_columns)) '// TEXT ID.
                                           'lv.SubItems.Add(GetPrice(second_table_columns))  '// PRICE.
                                           'lv.SubItems.Add(GetLinkId(second_table_columns)) '// LINK ID.
                                           lv.SubItems.Add(GetTextId(second_table_columns))  '// TEXT ID.
                                           lv.SubItems.Add(GetPrice(second_table_columns).Replace(",", ".")) '// PRICE.
                                           lv.SubItems.Add(GetTextId(second_table_columns))  '// TEXT ID.
                                           lv.SubItems.Add(GetPr(second_table_columns))      '// PR.
                                           lv.SubItems.Add(GetSr(second_table_columns))      '// SR.
                                           listCopy.Add(lv)
                                           lblLinksCount.Text = listViewShowLinks.Items.Count.ToString() + " Links found."
                                           listViewShowLinks.EndUpdate()
                                       End If
                                   End Sub)
                            ' cap at 5000
                            If (CDbl(listViewShowLinks.Items.Count.ToString()) >= 5000) Then
                                formMain.returnMessage("5000 results limit reached!")
                                Return
                            End If
                        End If

                        ' New Code - Check if sub-tables shown
                        If (ShouldProcessSubItems(userLinkType)) Then
                            Dim rows = GetSubTableRows(second_table)
                            For Each r As HtmlNode In rows
                                Dim columns = r.ChildNodes
                                Dim cellWithUrl = columns(1).Element("div").Element("div").Element("a")
                                If IsNothing(cellWithUrl) Then
                                    Continue For
                                End If
                                Dim url = cellWithUrl.InnerText
                                Dim subItemUrl = String.Format("{0}{1}", mainUrl, url)
                                If (InvokeRequired) Then
                                    Invoke(Sub()
                                               If (subItemUrl.Contains("URL")) Then
                                                   ' don't add
                                               Else
                                                   listViewShowLinks.BeginUpdate()
                                                   Dim item As ListViewItem = listViewShowLinks.Items.Add(id) '// ID.
                                                   item.SubItems.Add(subItemUrl)           '// URL.
                                                   item.SubItems.Add(searchId)             '// SEARCH ID.
                                                   item.SubItems.Add(pgex)                 '// PGEX.
                                                   item.SubItems.Add(ms.Trim())            '// MS.
                                                   item.SubItems.Add(GetTextId(columns))   '// TEXT ID.
                                                   item.SubItems.Add(GetPrice(columns).Replace(",", ".")) '// PRICE.
                                                   item.SubItems.Add(GetTextId(columns))   '// TEXT ID.
                                                   item.SubItems.Add(GetPr(columns))       '// PR.
                                                   item.SubItems.Add(GetSr(columns))       '// SR.
                                                   listCopy.Add(item)
                                                   lblLinksCount.Text = listViewShowLinks.Items.Count.ToString() + " Links found."
                                                   listViewShowLinks.EndUpdate()
                                               End If
                                           End Sub)
                                    ' cap at 5000
                                    If (CDbl(listViewShowLinks.Items.Count.ToString()) >= 5000) Then
                                        formMain.returnMessage("5000 results limit reached!")
                                        Return
                                    End If
                                End If
                            Next
                        End If
                    Next

                    ' try to release memory
                    doc = Nothing
                    allHtml = Nothing
                    tables_1 = Nothing
                    tables_2 = Nothing
                    GC.Collect()
                    '//////////////////////////////////////////////////////////////////////////////////////////////
                    ' vars
                    'Dim sesID As String = String.Empty
                    'Dim mssID As String = String.Empty
                    'Dim pgxID As String = String.Empty

                    'Dim sesIDMatch As Match = Regex.Match(sl, "name=""searchId"" value=""(.*?)""", RegexOptions.IgnoreCase)
                    'If (sesIDMatch.Success) Then
                    '    sesID = sesIDMatch.Groups(1).Value
                    'End If
                    'Dim mssIDMatch As Match = Regex.Match(sl, "name=""ms"" value=""(.*?)""", RegexOptions.IgnoreCase)
                    'If (mssIDMatch.Success) Then
                    '    mssID = mssIDMatch.Groups(1).Value
                    'End If
                    'Dim pgxIDMatch As Match = Regex.Match(sl, "name=""pgex"" value=""(.*?)""", RegexOptions.IgnoreCase)
                    'If (pgxIDMatch.Success) Then
                    '    pgxID = pgxIDMatch.Groups(1).Value
                    'End If
                    'Dim ms As MatchCollection = _
                    '       Regex.Matches(sl, "<div class=""long_link_box"">\s*<div class=""long_link"">\s*<b><a class=""ajax_link""(.*?)(?=<div class=""long_link_box"">\s*<div class=""long_link"">\s*<b><a class=""ajax_link""|$)",
                    '         RegexOptions.Singleline Or RegexOptions.IgnoreCase)

                    'For Each ms_items As Match In ms
                    '    Dim groups As GroupCollection = ms_items.Groups
                    '    Dim m_params = Regex.Match(groups.Item(0).Value, "\s*href=""#""\s*sid=""(\d+)"">(.+?)</a>.+?ID:\s*(\d{1,})\s*\|\s*whois:\s*?\d{1,2}\.\d{1,2}\.\d{1,4}.+?<td\s*style=""width:\d+px;""\s*class=""ca"">(\d{1,})</td>.+?name=""p\[\]""\s*value=""(\d+)""\s*.+?price=""(.*?)""",
                    '                    RegexOptions.Singleline Or RegexOptions.IgnoreCase)

                    '    Dim ms2 As MatchCollection = _
                    '        Regex.Matches(groups.Item(0).Value, "<div class=""long_link"">.+?class=""ca"">(\d).+?name=""p\[\]""\s*value=""(\d+)"".+?price=""(.*?)"".+?id=""(.*?)""",
                    '          RegexOptions.Singleline Or RegexOptions.IgnoreCase)

                    '    For Each ms_items2 As Match In ms2
                    '        Dim groups2 As GroupCollection = ms_items2.Groups

                    '        Dim m_params2 = Regex.Match(groups2.Item(0).Value, "<div class=""long_link"">\s*<a.+?title=""(.+?) -- .+?"".+?class=""ca"">(\d{1,})</td>.+?name=""p\[\]""\s*value=""(\d+)""\s*.+?price=""(.*?)""",
                    '        RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                    '        Dim title_url As String = ""

                    '        Dim mGroups2 As GroupCollection
                    '        If (Not (m_params2.Success)) Then
                    '            m_params2 = Regex.Match(groups2.Item(0).Value, "<div class=""long_link"">(.+?)class=""ca"">(\d{1,})</td>.+?name=""p\[\]""\s*value=""(\d+)""\s*.+?price=""(.*?)""",
                    '           RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                    '            mGroups2 = m_params2.Groups
                    '            title_url = "Missing URL"
                    '        Else
                    '            mGroups2 = m_params2.Groups
                    '            title_url = mGroups2.Item(1).Value
                    '        End If

                    '        If (m_params.Success) Then
                    '            Dim mGroups = m_params.Groups
                    '            If (title_url = "Missing URL") Then
                    '                ' Don't add anything...
                    '            Else
                    '                If (InvokeRequired) Then
                    '                    Invoke(Sub()
                    '                               Dim lv As ListViewItem = Me.listViewShowLinks.Items.Add(mGroups.Item(1).Value)
                    '                               lv.SubItems.Add(title_url) ' URL.

                    '                               ' DA/PA
                    '                               If (chkBoxPADA.Checked = True) Then
                    '                                   daPa = newMoz.createSeoMozRequest(title_url, "103079215104")
                    '                                   Dim matchesSource As New Regex("pda"":(.*?),""upa"":(.*?)}", RegexOptions.IgnoreCase)
                    '                                   Dim matchFound As MatchCollection = matchesSource.Matches(daPa)
                    '                                   'If (matchFound.Count > 0) Then
                    '                                   For Each M As Match In matchFound
                    '                                       lamdaFix2 = M.Groups(1).Value
                    '                                       lamdaFix3 = M.Groups(2).Value
                    '                                   Next
                    '                               End If
                    '                               ' DA/PA

                    '                               lv.SubItems.Add(sesID)
                    '                               lv.SubItems.Add(pgxID)
                    '                               lv.SubItems.Add(mssID)
                    '                               lv.SubItems.Add(mGroups2.Item(3).Value)

                    '                               ' Currency converter.
                    '                               If (radioCur3.Checked = True) Then
                    '                                   colSearchPrice.Text = "Price (RUB)"
                    '                                   lv.SubItems.Add(mGroups2.Item(4).Value.Replace(",", "."))
                    '                               ElseIf (radioCur2.Checked = True) Then
                    '                                   ' GBP
                    '                                   colSearchPrice.Text = "Price (GBP)"
                    '                                   Dim random As New Random
                    '                                   Dim amount As Double = (random.NextDouble * 10000)
                    '                                   Dim dollars As Double = MoneyConverter.RubbleToUsd(amount)
                    '                                   'Console.WriteLine("Rubbles: {0:0.00} - dollars: {1:0.00}. Rate: {2:0.00}.", amount, dollars, MoneyConverter.RubbleUsdRate)
                    '                                   Dim pounds As Double = MoneyConverter.RubbleToPounds(CDbl(Double.Parse(mGroups2.Item(4).Value.Replace(",", "."))))
                    '                                   lv.SubItems.Add(pounds.ToString())
                    '                               ElseIf (radioCur1.Checked = True) Then
                    '                                   ' USD
                    '                                   colSearchPrice.Text = "Price (USD)"
                    '                                   Dim dollars As Double = Double.Parse(CStr(MoneyConverter.RubbleToUsd(CDbl(mGroups2.Item(4).Value.Replace(",", ".")))))
                    '                                   lv.SubItems.Add(dollars.ToString())
                    '                               Else
                    '                                   colSearchPrice.Text = "Price (RUB)"
                    '                                   lv.SubItems.Add(mGroups2.Item(4).Value.Replace(",", "."))
                    '                               End If

                    '                               lv.SubItems.Add(mGroups2.Item(3).Value)
                    '                               lv.SubItems.Add(mGroups.Item(4).Value)
                    '                               ' add the results to the temp listview
                    '                               listCopy.Add(lv)

                    '                           End Sub)
                    '                End If
                    '                '//////////////////////////////////////////////////////////////////////////////////////////////

                    '                ' Update count
                    '                If (InvokeRequired) Then
                    '                    Invoke(Sub()
                    '                               lblLinksCount.Text = listViewShowLinks.Items.Count.ToString() + " Links found."
                    '                           End Sub)
                    '                End If

                    '            End If
                    '        End If

                    '    Next
                    'Next
                    '//////////////////////////////////////////////////////////////////////////////////////////////
                Next ' End loop.
                GC.Collect()
            End If ' End the isNothing
        End If
        ' sape_begin_search

        '          ____       _       ____   _     
        ' |  _"\  U  /"\  u U|  _"\ uU  /"\  u 
        '/| | | |  \/ _ \/  \| |_) |/ \/ _ \/  
        'U| |_| |\ / ___ \   |  __/   / ___ \  
        ' |____/ u/_/   \_\  |_|     /_/   \_\ 
        '  |||_    \\    >>  ||>>_    \\    >> 
        ' (__)_)  (__)  (__)(__)__)  (__)  (__)

        If (action = "sape_pa_da_check") Then

            Dim newMoz As New saperClassMoz()
            Dim daPa As String = String.Empty
            Dim lamdaFix1 As String = String.Empty
            Dim lamdaFix2 As String = String.Empty
            Dim lamdaFix3 As String = String.Empty
            Dim lamdaFix4 As String = String.Empty
            Dim lamdaFix5 As String = String.Empty
            If (InvokeRequired) Then
                Invoke(Sub()
                           For Each itm As ListViewItem In listViewShowLinks.CheckedItems
                               bgWorker.WorkerSupportsCancellation = True
                               If (bgWorker.CancellationPending) Then
                                   e.Cancel = True
                                   formMain.returnMessage("Link analysis has been stopped!")
                                   Exit For
                               End If
                               lamdaFix1 = If((chkBoxAppend1.Checked = True), itm.SubItems(1).Text.Replace("http://", "http://www."), itm.SubItems(1).Text)
                               '// check if append is checked
                               '//Dim uri As String = If((chkBoxAppend1.Checked = True), "http://www." & itm.SubItems(1).Text, itm.SubItems(1).Text)
                               '// request
                               daPa = newMoz.createSeoMozRequest(lamdaFix1, "103079215104")
                               '// regex
                               Dim matchesSource As New Regex("pda"":(.*?),""upa"":(.*?)}", RegexOptions.IgnoreCase)
                               Dim matchFound As MatchCollection = matchesSource.Matches(daPa)
                               If (matchFound.Count > 0) Then
                                   For Each M As Match In matchFound
                                       lamdaFix2 = M.Groups(1).Value
                                       lamdaFix3 = M.Groups(2).Value
                                       Application.DoEvents()
                                       Dim lv As ListViewItem = formMozCheck.listViewMoz.Items.Add(lamdaFix1)
                                       lv.UseItemStyleForSubItems = False
                                       lv.SubItems.Add(Math.Round(Double.Parse(lamdaFix2)).ToString())
                                       lv.SubItems.Add(Math.Round(Double.Parse(lamdaFix3)).ToString())
                                       lv.SubItems.Add("N/A")
                                       lv.SubItems.Add("N/A")
                                       lv.SubItems.Add(itm.SubItems(8).Text)
                                       Dim srVal As Integer
                                       If (itm.SubItems(9).Text = "") Then
                                           srVal = 0
                                       Else
                                           srVal = CInt(itm.SubItems(9).Text)
                                       End If
                                       lv.SubItems.Add(srVal.ToString())

                                       '// algorithm //'
                                       Dim overAllScore = saperFunctions.returnLinkScore(Math.Round(Double.Parse(lamdaFix2)).ToString(), Math.Round(Double.Parse(lamdaFix3)).ToString(), itm.SubItems(8).Text, CStr(srVal))
                                       'formMain.returnMessage(overAllScore)
                                       If (CDbl(overAllScore) <= 0 Or CDbl(overAllScore) <= 25) Then
                                           lv.SubItems.Add(overAllScore & "%").ForeColor = Color.DarkRed
                                       ElseIf (CDbl(overAllScore) <= 26 Or CDbl(overAllScore) <= 45) Then
                                           lv.SubItems.Add(overAllScore & "%").ForeColor = Color.DarkOrange
                                       Else
                                           lv.SubItems.Add(overAllScore & "%").ForeColor = Color.DarkGreen
                                       End If
                                       itm.Checked = False
                                   Next
                               End If
                               ' use the pause?
                               If (chkBoxLinkAnalysisPause.Checked = True) Then
                                   Threading.Thread.Sleep(1)
                               Else
                                   Threading.Thread.Sleep(11000)
                               End If
                           Next
                       End Sub)
            End If

        End If 'sape_pa_da_check

        'If (action = "sape_update_dapa") Then
        '    Invoke(Sub()
        '               For Each itm As ListViewItem In formMozCheck.listViewMoz.Items
        '                   '//////////////////////////// QUERY ///////////////////////////////////////////////////////////////////
        '                   Try
        '                       myConn = New MySqlConnection("SERVER=" & txtMysqlIP.Text.Trim() & ";PORT=" & txtMysqlPort.Text.Trim() & ";UID=" & txtMysqlUser.Text.Trim() & ";PASSWORD=" & txtMysqlPass.Text.Trim() & ";DATABASE=" & txtMysqlDBName.Text.Trim())
        '                       myConn.Open()
        '                       ' Queries...
        '                       myQery = "UPDATE sape_urls SET `sape_url_da`='" & itm.SubItems(1).Text.Trim() & "',`sape_url_pa`='" & itm.SubItems(2).Text.Trim() & "' WHERE `sape_url`='" & itm.SubItems(0).Text.Trim() & "'"
        '                       mySqlC = New MySqlCommand(myQery, myConn)
        '                       mySqDr = mySqlC.ExecuteReader
        '                       myConn.Close()
        '                       mySqDr.Close()
        '                   Catch ex As Exception
        '                       formMain.returnMessage(ex.ToString)
        '                   End Try
        '                   '//////////////////////////// QUERY ///////////////////////////////////////////////////////////////////
        '               Next
        '           End Sub)
        '    formMain.returnMessage("Successfully updated the DA/PA values.")
        'End If
        'sape_update_dapa

        'If (action = "sape_download_api") Then
        '    'MessageBox.Show("http://www.saperstats.com/api.php?search=1&level=" & comboBoxSearchSaperLevel.SelectedItem.ToString() & "&pr=" & comboBoxSearchSaperPR.SelectedItem.ToString() & "&da=&pa=")
        '    Invoke(Sub()
        '               Application.DoEvents()
        '               Dim searchHTML As String = saperFunctions.getURL("http://www.saperstats.com/api.php?search=1&level=" & comboBoxSearchSaperLevel.SelectedItem.ToString() & "&pr=" & comboBoxSearchSaperPR.SelectedItem.ToString() & "&da=" + Me.txtBoxSSDA.Text.Trim() + "&pa=" + Me.txtBoxSSPA.Text.Trim(), formMain.varCookieJar)
        '               If (searchHTML.Contains("NULL")) Then
        '                   formMain.returnMessage("No results to show! try lowering your search criteria.")
        '                   Exit Sub
        '               End If
        '               formSaperStats.Show()
        '               For Each Str As String In searchHTML.Split("#"c)
        '                   Dim lv As ListViewItem = formSaperStats.listViewSaperStats.Items.Add(Str)
        '                   lv.UseItemStyleForSubItems = False
        '                   lv.BackColor = Color.PaleGreen
        '                   formSaperStats.lblLinksCountSS.Text = formSaperStats.listViewSaperStats.Items.Count.ToString() + " Links found."
        '               Next
        '               formSaperStats.listViewSaperStats.Items(formSaperStats.listViewSaperStats.Items.Count - 1).Remove()
        '           End Sub)
        'End If
        'sape_download_api

        If (action = "sape_update_mtmr") Then

            Dim newMoz As New saperClassMoz()
            Dim trMr As String = String.Empty
            Dim lamdaFix1 As String = String.Empty
            Dim lamdaFix2 As String = String.Empty
            Dim lamdaFix3 As String = String.Empty
            Dim lamdaFix4 As String = String.Empty
            Dim lamdaFix5 As String = String.Empty

            Invoke(Sub()
                       Application.DoEvents()
                       For Each itm As ListViewItem In formMozCheck.listViewMoz.CheckedItems
                           bgWorker.WorkerSupportsCancellation = True
                           If (bgWorker.CancellationPending) Then
                               e.Cancel = True
                               formMain.returnMessage("SeoMoz checking has been stopped!")
                               Exit For
                           End If
                           lamdaFix1 = itm.SubItems(0).Text
                           'lamdaFix2 = CStr(itm.Checked = False)
                           trMr = newMoz.createSeoMozRequest(itm.SubItems(0).Text, "16384")
                           'formHTML.txtBoxDebugHTML.Text = trMr
                           'formHTML.Show()
                           Dim matchesSource As New Regex("umrp"":(.*?),""umrr"":(.*?)}", RegexOptions.IgnoreCase)
                           Dim matchFound As MatchCollection = matchesSource.Matches(trMr)
                           If (matchFound.Count > 0) Then
                               For Each M As Match In matchFound
                                   lamdaFix2 = M.Groups(1).Value
                                   lamdaFix3 = M.Groups(2).Value
                                   Invoke(Sub()
                                              Application.DoEvents()
                                              Dim lv As ListViewItem = formMozCheck.listViewMoz.Items.Add(lamdaFix1)
                                              lv.SubItems.Add(Math.Round(Double.Parse(itm.SubItems(1).Text)).ToString())
                                              lv.SubItems.Add(Math.Round(Double.Parse(itm.SubItems(2).Text)).ToString())
                                              lv.SubItems.Add(Format(Convert.ToDouble(lamdaFix2), "#.##"))
                                              lv.SubItems.Add(" - ")
                                              itm.Checked = False
                                              itm.Remove()
                                              'lamdaFix5.ToString()
                                          End Sub)
                               Next
                           End If
                       Next
                   End Sub)

        End If ' sape_update_mtmr

    End Sub

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        ' check if there was any errors...
        If Not (IsNothing(e.Error)) Then
            formMain.returnMessage(String.Format("Error has occured when trying to start threads. {0}", e.Error.ToString()))
            btnSearchLinks.Enabled = True
            btnMozCheck.Enabled = True
            btnCheckLinks.Enabled = True
            Exit Sub
        Else
            btnSearchLinks.Enabled = True
            btnMozCheck.Enabled = True
            formMain.returnMessage("Operation complete!")
        End If
    End Sub

    Private Sub btnStopOperations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopOperations.Click
        If (bgWorker.IsBusy = False) Then
            formMain.returnMessage("No threads are currently running!")
            Exit Sub
        Else
            If (bgWorker.IsBusy) Then
                If (bgWorker.WorkerSupportsCancellation) Then
                    bgWorker.CancelAsync()
                End If
            End If
        End If
    End Sub

    Private Sub btnLoadCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        Dim categories As XmlRpcStruct() = proxy.SapeGetCategories()
        If (userId > 0) Then
            Dim index As Integer = 0
            For Each struct As XmlRpcStruct In categories
                formCategories.listViewCategories.Items.Add(categories(index)("id").ToString() + " - " + categories(index)("name").ToString())
                formCategories.Show()
                index += 1
            Next
        End If
    End Sub

    Private Sub btnLoadTLDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        Dim zones As XmlRpcStruct() = proxy.SapeGetDomainTLDs()
        If (userId > 0) Then
            Dim index As Integer = 0
            For Each struct As XmlRpcStruct In zones
                formZones.listBoxTLDExtensions.Items.Add(zones(index)("id").ToString() + " - " + zones(index)("zone").ToString())
                formZones.Show()
                index += 1
            Next
        End If
    End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
    '    Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
    '    Dim projectSites As XmlRpcStruct() = proxy.SapeGetProjectLinks(Convert.ToInt32(Me.Text))
    '    If (userId > 0) Then
    '        Dim index As Integer = 0
    '        For Each item In projectSites
    '            For Each s As XmlRpcStruct In projectSites
    '                MessageBox.Show("Key: " + s.ToString + " Value: " + s.Item(s).ToString())
    '            Next
    '        Next
    '    End If
    'End Sub

    Private Sub btnClearSearches_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSearches.Click
        listViewShowLinks.Items.Clear()
        lblLinksCount.Text = "0" + " Links found."
    End Sub

    Private Sub btnTesting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTesting.Click
        If (Me.Text = "") Then
            formMain.returnMessage("You need to create a project first before downloading data.")
            Exit Sub
        Else
            Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
            Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
            Dim project As XmlRpcStruct() = proxy.SapeGetURLS(Convert.ToInt32(Me.Text))
            Dim uid As String = String.Empty
            Dim upd As String = String.Empty
            Dim url As String = String.Empty
            Dim upn As String = String.Empty
            Dim ust As String = String.Empty
            Dim usy As String = String.Empty
            Dim uat As String = String.Empty
            Dim ulk As String = String.Empty
            Dim ukw As String = String.Empty
            If (userId > 0) Then
                Try
                    Dim index As Integer = 0
                    For Each struct As XmlRpcStruct In project
                        'MessageBox.Show(project(index)("id").ToString() + " - " + project(index)("url").ToString())
                        index += 1
                        uid = project(index - 1)("id").ToString()
                        upd = project(index - 1)("project_id").ToString()
                        url = project(index - 1)("url").ToString()
                        upn = project(index - 1)("name").ToString()
                        ust = project(index - 1)("amount_today").ToString()
                        usy = project(index - 1)("amount_yesterday").ToString()
                        uat = project(index - 1)("amount_total").ToString()
                        ulk = project(index - 1)("nof_links").ToString()
                        ukw = project(index - 1)("keyword").ToString()

                        ' add the ID to the combobox
                        'If Not (comboBoxSearchLinkID.Items.Contains(uid)) Then
                        '    comboBoxSearchLinkID.Items.Add(uid)
                        '    comboBoxSearchLinkID.SelectedIndex = 0
                        'End If

                        ' add to the listview
                        Dim lv As ListViewItem = formDetailedProject.listViewDetailed.Items.Add(uid)
                        lv.SubItems.Add(upd)
                        lv.SubItems.Add(url)
                        lv.SubItems.Add(upn)
                        lv.SubItems.Add(ust)
                        lv.SubItems.Add(usy)
                        lv.SubItems.Add(uat)
                        lv.SubItems.Add(ulk)
                        lv.SubItems.Add(ukw)
                    Next
                    formDetailedProject.Show()
                Catch ex As Exception
                    formMain.returnMessage("You don't have a URL attached to this project! so we can't get the ID.")
                End Try
            End If
        End If
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        Dim project As XmlRpcStruct() = proxy.SapeGetPagesOnSites(Convert.ToInt32("56482823"))
        If (userId > 0) Then
            For Each xmlRpcStruct As XmlRpcStruct In project
                For Each s As String In xmlRpcStruct.Keys
                    MessageBox.Show("Key: " + s + " Value: " + xmlRpcStruct.Item(s).ToString())
                Next
            Next
        End If
        'url_id = Money site ID.
        'site_id = Site put in to sape to earn money and sites in general that optimizers will purchase.
        'project_id = Obviously project ID.
    End Sub

    Private Sub btnExportSearchLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSearchLinks.Click
        Dim fileNameNew As String = String.Empty
        If (chkBoxExportPurchasedLinks.Checked = True) Then
            fileNameNew = "sapeLinksPurchased.txt"
        Else
            fileNameNew = "sapeLinksSearched.txt"
        End If
        sfDialog.Title = "Select a save file location..."
        sfDialog.InitialDirectory = "C:"
        sfDialog.Filter = "Text Files|*.txt"
        sfDialog.FileName = fileNameNew
        If (sfDialog.ShowDialog = DialogResult.OK) Then
            Using SW As New StreamWriter(sfDialog.FileName, True)
                ' what links to export
                If (chkBoxExportPurchasedLinks.Checked = True) Then
                    For Each itm As ListViewItem In listViewMain.Items
                        If (comboBoxExportFormat.SelectedItem.ToString() = "ID|URL") Then
                            Dim fullUrl As String
                            If (itm.SubItems(5).Text = "/") Then
                                fullUrl = ""
                            Else
                                fullUrl = itm.SubItems(5).Text
                            End If
                            SW.WriteLine(itm.SubItems(6).Text & "|" & itm.SubItems(4).Text & itm.SubItems(5).Text)
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "ID|URL|PRICE") Then
                            Dim fullUrl As String
                            If (itm.SubItems(5).Text = "/") Then
                                fullUrl = ""
                            Else
                                fullUrl = itm.SubItems(5).Text
                            End If
                            ' price conversion needed to USD
                            Dim amount As Double = CDbl(itm.SubItems(11).Text)
                            Dim dollars As Double = Double.Parse(CStr(MoneyConverter.RubbleToUsd(CDbl(amount))))
                            Dim newPrice = Convert.ToDecimal(dollars).ToString("c")
                            SW.WriteLine(itm.SubItems(6).Text & "|" & itm.SubItems(4).Text & itm.SubItems(5).Text & "|" & itm.SubItems(11).Text & " (Rubles monthly.) or " & newPrice.Replace("£", "$") & " (USD monthly.)")
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "URL") Then
                            SW.WriteLine(itm.SubItems(4).Text)
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "URL|PRICE") Then
                            Dim fullUrl As String
                            If (itm.SubItems(5).Text = "/") Then
                                fullUrl = ""
                            Else
                                fullUrl = itm.SubItems(5).Text
                            End If
                            ' price conversion needed to USD
                            Dim amount As Double = CDbl(itm.SubItems(11).Text)
                            Dim dollars As Double = Double.Parse(CStr(MoneyConverter.RubbleToUsd(CDbl(amount))))
                            Dim newPrice = Convert.ToDecimal(dollars).ToString("c")
                            SW.WriteLine(itm.SubItems(4).Text & itm.SubItems(5).Text & "|" & itm.SubItems(11).Text & " (Rubles monthly.) or " & newPrice.Replace("£", "$") & " (USD monthly.)")
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "ID") Then
                            SW.WriteLine(itm.SubItems(6).Text)
                        End If
                    Next
                Else
                    For Each itm As ListViewItem In listViewShowLinks.CheckedItems
                        If (comboBoxExportFormat.SelectedItem.ToString() = "ID|URL") Then
                            SW.WriteLine(itm.SubItems(7).Text & "|" & itm.SubItems(1).Text)
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "ID|URL|PRICE") Then
                            ' price conversion needed to USD
                            Dim amount As Double = CDbl(itm.SubItems(6).Text)
                            Dim dollars As Double = Double.Parse(CStr(MoneyConverter.RubbleToUsd(CDbl(amount))))
                            Dim newPrice = Convert.ToDecimal(dollars).ToString("c")
                            SW.WriteLine(itm.SubItems(7).Text & "|" & itm.SubItems(1).Text & "|" & itm.SubItems(6).Text & " (Rubles daily.) or " & newPrice.Replace("£", "$") & " (USD daily.)")
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "URL") Then
                            SW.WriteLine(itm.SubItems(1).Text)
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "URL|PRICE") Then
                            ' price conversion needed to USD
                            Dim amount As Double = CDbl(itm.SubItems(6).Text)
                            Dim dollars As Double = Double.Parse(CStr(MoneyConverter.RubbleToUsd(CDbl(amount))))
                            Dim newPrice = Convert.ToDecimal(dollars).ToString("c")
                            SW.WriteLine(itm.SubItems(1).Text & "|" & itm.SubItems(6).Text & " (Rubles daily.) or " & newPrice.Replace("£", "$") & " (USD daily.)")
                        ElseIf (comboBoxExportFormat.SelectedItem.ToString() = "ID") Then
                            SW.WriteLine(itm.SubItems(7).Text)
                        End If
                    Next
                End If
            End Using
            formMain.returnMessage("Domains successfully exported.")
        End If
    End Sub

    Private Sub btnDeleteSelectedLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSelectedLinks.Click
        If listViewMain.CheckedItems.Count > 0 Then
            ' CRAZY Sape must be sent as "Double" not "Long"
            Dim result As Boolean
            Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
            Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
            If (userId > 0) Then
                For Each itm As ListViewItem In listViewMain.CheckedItems
                    result = proxy.SapeDeleteLinks(Convert.ToInt64(itm.SubItems(0).Text.Trim()))
                    ' Success.
                    If (result) Then
                        listViewMain.Items.Remove(itm)
                        formMain.returnMessage("You have deleted the link successfully.")
                    Else
                        formMain.returnMessage("There was an error deleting the link.")
                    End If
                Next
            End If
        Else
            formMain.returnMessage("No links selected to be deleted.")
        End If
    End Sub

    Private Sub btnLoadInBrowser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadInBrowser.Click
        If listViewShowLinks.CheckedItems.Count > 0 Then
            For Each itm As ListViewItem In listViewShowLinks.CheckedItems
                If (itm.SubItems(1).Text.Contains("http://")) Then
                    Process.Start(itm.SubItems(1).Text)
                    itm.Checked = False
                Else
                    Process.Start("http://www." + itm.SubItems(1).Text)
                    itm.Checked = False
                End If
            Next
        Else
            formMain.returnMessage("No links selected to view in the browser.")
        End If
    End Sub

    Private Sub btnMozCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMozCheck.Click
        ' validation
        If (formSettings.txtBoxAI.Text = "" Or formSettings.txtBoxKY.Text = "") Then
            formMain.returnMessage("You need to enter your SeoMoz keys in the settings screen.")
            Exit Sub
        End If
        If listViewShowLinks.CheckedItems.Count > 0 Then
            If (bgWorker.IsBusy <> True) Then
                formMozCheck.Show()
                btnMozCheck.Enabled = False
            End If
        Else
            formMain.returnMessage("No URLs selected for analysis!")
            Return
        End If
    End Sub

    Private Sub listViewShowLinks_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles listViewShowLinks.ColumnClick
        ' determine if the clicked column is already the column that is 
        ' being sorted
        If (CDbl(e.Column.ToString) = 8) Then
            ' true/false
            Dim blnAscending As Boolean = False
            Me.listViewShowLinks.ListViewItemSorter = New ListViewItemComparer(e.Column, blnAscending)
        End If

        If (CDbl(e.Column.ToString) = 6) Then
            Dim blnAscending As Boolean = False
            Me.listViewShowLinks.ListViewItemSorter = New ListViewItemComparer(e.Column, blnAscending)
        End If
    End Sub

    Private Sub btnShowStats_Click(sender As System.Object, e As System.EventArgs) Handles btnShowStats.Click
        formStats.Show()
    End Sub

    Private Sub btnSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectAll.Click
        For Each itm As ListViewItem In listViewShowLinks.Items
            itm.Checked = True
        Next
    End Sub

    Private Sub btnSelectNoneLinks_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectNoneLinks.Click
        For Each itm As ListViewItem In listViewShowLinks.Items
            itm.Checked = False
        Next
    End Sub

    Private Sub btnRemoveLinks_Click(sender As System.Object, e As System.EventArgs) Handles btnRemoveLinks.Click
        For Each itm As ListViewItem In listViewShowLinks.Items
            If (itm.Checked = False) Then
                listViewShowLinks.Items.Remove(itm)
            End If
        Next
    End Sub

    Private Sub formProject_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' on form load fire up the combobox values
        comboBoxExportFormat.SelectedIndex = 0
        ' load examples in the project text box
        Me.txtBoxProjectAnchors.Text = "Where can i buy #a#keyword#/a# online?" & vbCrLf & "Have you seen #a#url#/a# it's pretty cool!" & vbCrLf & "Look here #domain# for deals!"
        listViewMain.Items.Clear()
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        If (userId > 0) Then
            Try
                Dim projectSites As XmlRpcStruct() = proxy.SapeGetProjectLinks(Convert.ToInt32(Me.Text))
                If (projectSites.Count > 0) Then
                    Dim index As Integer = 0
                    Dim TotalValue As Double
                    For Each item In projectSites
                        Dim sapeID = projectSites(index)("id").ToString
                        Dim sapeStatus = projectSites(index)("status").ToString
                        Dim sapeSiteID = projectSites(index)("site_id").ToString
                        Dim sapeURLID = projectSites(index)("url_id").ToString
                        Dim sapeURL = projectSites(index)("site_url").ToString()
                        Dim sapePage = projectSites(index)("page_uri").ToString()
                        Dim sapePageID = projectSites(index)("page_id").ToString()
                        Dim sapePagePR = projectSites(index)("page_pr").ToString()
                        Dim sapePageLevel = projectSites(index)("page_level").ToString()
                        Dim sapePageExternalLinks = projectSites(index)("page_nof_ext_links").ToString()
                        Dim sapePageAnchorText = projectSites(index)("txt").ToString()
                        Dim sapePrice = projectSites(index)("price").ToString()
                        Dim sapeCatID = projectSites(index)("category_id").ToString()
                        Dim lv As ListViewItem = listViewMain.Items.Add(sapeID)

                        ' colour the OK
                        If (sapeStatus = "OK") Then
                            lv.UseItemStyleForSubItems = False
                            lv.SubItems.Add(sapeStatus).ForeColor = Color.Green
                        Else
                            lv.UseItemStyleForSubItems = False
                            lv.SubItems.Add(sapeStatus).ForeColor = Color.Red
                        End If

                        lv.SubItems.Add(sapeSiteID)
                        lv.SubItems.Add(sapeURLID)
                        lv.SubItems.Add(sapeURL)
                        lv.SubItems.Add(sapePage)
                        lv.SubItems.Add(sapePageID)
                        lv.SubItems.Add(sapePagePR)

                        ' colour page level
                        If (sapePageLevel = "1") Then
                            lv.SubItems.Add(sapePageLevel).BackColor = Color.LightGreen
                        ElseIf (sapePageLevel = "2") Then
                            lv.SubItems.Add(sapePageLevel).BackColor = Color.LightPink
                        ElseIf (sapePageLevel = "3") Then
                            lv.SubItems.Add(sapePageLevel).BackColor = Color.LightGray
                        Else
                            lv.SubItems.Add(sapePageLevel)
                        End If

                        lv.SubItems.Add(sapePageExternalLinks)
                        lv.SubItems.Add(sapePageAnchorText)
                        lv.SubItems.Add(sapePrice)
                        lv.SubItems.Add(sapeCatID)
                        index += 1

                        TotalValue += CDbl(sapePrice)
                    Next
                    ' price conversion needed to USD
                    Dim amount As Double = CDbl(TotalValue)
                    Dim dollars As Double = Double.Parse(CStr(MoneyConverter.RubbleToUsd(CDbl(amount))))
                    Dim newPrice = Convert.ToDecimal(dollars).ToString("c")
                    lblTotalSpentUSD.Text = newPrice.Replace("£", "$")
                    ' update
                    formMain.returnMessage("Your bought links can be seen on the ""MANAGE LINKS PURCHASED"" tab.")
                Else
                    formMain.returnMessage("No links bought yet! get buying and ranking!")
                End If
            Catch ex As Exception
                formMain.returnMessage("XML-RPC ERROR!" & vbCrLf & vbCrLf & ex.ToString)
            End Try
        End If
    End Sub

    Private Sub chkBoxPADA_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles chkBoxPADA.CheckedChanged
        If (chkBoxPADA.Checked = True) Then
            formMain.returnMessage("NOTE: Checking this can seriously slow down the searches made for links (and make the software unstable), it's recommended to check the DA/PA after the search has been done.")
        End If
    End Sub

    Private Sub btnSearchLinks_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchLinks.Click
        ' validation
        If (Information.IsNothing(Me.comboBoxLinkType.SelectedItem)) Then
            formMain.returnMessage("You need to select the link type!")
            Return
        End If
        If (Information.IsNothing(Me.comboBoxSearchLinkID.SelectedItem)) Then
            formMain.returnMessage("You need to select the link ID! Press the ID button above.")
            Return
        End If
        If (Information.IsNothing(Me.comboBoxText.SelectedItem)) Then
            formMain.returnMessage("You need to select the text ID to post!")
            Return
        End If
        If (chkBoxPADA.Checked = True) Then
            If (formSettings.txtBoxAI.Text = "" Or formSettings.txtBoxKY.Text = "") Then
                formMain.returnMessage("You need to enter your SeoMoz keys in the settings screen. This will slow down searching quite a bit.")
                Exit Sub
            End If
        End If
        If (Not Me.bgWorker.IsBusy) Then
            formMain.returnMessage("Please wait while we search for links, it may take a few minutes..." + vbCrLf + vbCrLf + "Searching for: (" + Me.comboBoxLinkType.SelectedItem.ToString() + ") Links.")
            Me.bgWorker.RunWorkerAsync("sape_begin_search")
            Me.btnSearchLinks.Enabled = False
        End If
    End Sub

    Private Sub btnLoadTLDs_Click_1(sender As System.Object, e As System.EventArgs) Handles btnLoadTLDs.Click
        formZones.Show()
    End Sub

    Private Sub btnCreateProject_Click_1(sender As System.Object, e As System.EventArgs) Handles btnCreateProject.Click
        ' validation
        If (Me.txtBoxCreateProjectName.Text = "" Or Me.txtBoxProjectURL.Text = "" Or Me.txtBoxProjectAnchors.Text = "" Or Me.txtBoxProjectAlias.Text = "" Or Me.txtBoxProjectkeywords.Text = "") Then
            formMain.returnMessage("You must fill in all project fields.")
            Return
        End If
        ' snippet validation
        For Each snippet As String In Me.txtBoxProjectAnchors.Text.Split(CChar(vbCrLf))
            If (snippet.Length > 100) Then
                formMain.returnMessage("1 or more of your snippet(s) is longer that 100 characters!")
                formMain.returnMessage("Snippet over 100 characters: " & vbCrLf & vbCrLf & snippet & " is (" & snippet.Length & ") characters long.")
                Return
            End If
        Next
        ' Add the project
        Dim getFolderID As String = saperFunctions.returnFolderID(saperFunctions.getURL("http://www.sape.ru/project.php?act=add", formMain.varCookieJar))
        'Dim addProject As String = {"name=" + Me.txtBoxCreateProjectName.Text + "&folder_id=" + folderID + "&domain=http%3A%2F%2F&region=%CC%EE%F1%EA%E2%E0&type=normal"}
        Dim projectAdd As String = saperFunctions.postURL("http://www.sape.ru/project.php?act=add", "name=" + Me.txtBoxCreateProjectName.Text + "&folder_id=" + getFolderID + "&domain=http%3A%2F%2F&region=%CC%EE%F1%EA%E2%E0&type=normal", formMain.varCookieJar)

        If (projectAdd.Contains("Проект добавлен в систему. Сейчас Вы можете сделать тонкую настройку.")) Then
            ' Small update
            formMain.returnMessage(String.Concat("Project (" + Me.txtBoxCreateProjectName.Text + ") has been created successfully." + vbCrLf + vbCrLf + "Now adding URL/Keywords then text snippet."))
            ' Get the project ID
            Dim projectID As String = saperFunctions.returnProjectsID(projectAdd)
            'Dim projKeywd As String = String.Concat("http://www.sape.ru/project.php?act=add_url&id=" + projectID.Trim(), "&add_mode=simple")
            Dim projAddFinal As String = saperFunctions.postURL("http://www.sape.ru/project.php?act=add_url&id=" + projectID.Trim() + "&add_mode=simple", "url=" + Me.txtBoxProjectURL.Text + "&name=" + Me.txtBoxProjectAlias.Text + "&keyword=" + Me.txtBoxProjectkeywords.Text, formMain.varCookieJar)
            ' Extra sape validation
            If (projAddFinal.Contains("Неверный формат URL!")) Then
                formMain.returnMessage("Sape reports that your URL is in an incorrect format!")
                Exit Sub
            End If

            ' What is this again?
            If (Not projAddFinal.Contains("Ключевое слово заданное для вашего URL")) Then
                formMain.returnMessage("URL/Keywords then text snippet adding failed! use the HTML debug to see the last error shown was." & vbCrLf & vbCrLf & "Tip: Try and use a more unique project name!")
                Return
            Else
                ' vars
                Dim projLI As String = saperFunctions.returnLinkID(projAddFinal)
                Dim projAN As String = saperFunctions.getURL("https://www.sape.ru/link_texts.php?link_id=" + projLI, formMain.varCookieJar)
                Dim projT1 As String = saperFunctions.postURL("https://www.sape.ru/ajax_task.php?act=add&task=projectUrlTextAdd", "link_id=" + projLI + "&query=" + Me.txtBoxCreateProjectName.Text + "&uri=" + Me.txtBoxProjectURL.Text + "&exactEnv=5&exactAtt=5&notExactEnv=5&notExactAtt=5&texts=" + Me.txtBoxProjectAnchors.Text + "&limit=0", formMain.varCookieJar)
                Dim projT2 As String = saperFunctions.postURL("https://www.sape.ru/ajax_task.php?act=status&task=projectUrlTextAdd", "", formMain.varCookieJar)

                ' responses
                Dim tempPost = New With {Key .message = "", Key .error = 0, Key .done = False, Key .jsdata = ""}
                Dim obj = JsonConvert.DeserializeAnonymousType(projT2, tempPost)
                Dim com As String = obj.message
                Dim obj2 = JsonConvert.DeserializeObject(Of saperJsonObject)(projT2)

                ' success flags
                If CBool((CStr(obj2.done))) Then
                    formMain.returnMessage("Project added successfully! Please logout/login of Saper to view your new project.")
                Else
                    formMain.returnMessage("Project added successfully! Please logout/login of Saper to view your new project.")
                End If
            End If
        End If

    End Sub

    Private Sub btnLoadCategories_Click_1(sender As System.Object, e As System.EventArgs) Handles btnLoadCategories.Click
        formCategories.Show()
    End Sub

    Private Sub btnPlacementText_Click(sender As System.Object, e As System.EventArgs) Handles btnPlacementText.Click
        ' has the link id been selected?
        If (IsNothing(Me.comboBoxSearchLinkID.SelectedItem)) Then
            formMain.returnMessage("You need to select the link ID first!")
            Return
        End If

        Dim html = saperFunctions.getURL("http://www.sape.ru/link_texts.php?link_id=" + comboBoxSearchLinkID.SelectedItem.ToString(), formMain.varCookieJar)

        ' Regex the text.
        Dim matchesSource As New Regex("<td class=""first_td"">(.*?)cnt_use=", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            For Each gotMatch As Match In matchFound

                ' get the ID
                Dim flag1 As String = String.Empty
                Dim regMatch1 As Match = Regex.Match(gotMatch.Groups(1).Value, "<span class=""link_text"">(.*?)</span>", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                If (regMatch1.Success) Then
                    flag1 = regMatch1.Groups(1).Value
                End If

                Dim flag2 As String = String.Empty
                Dim regMatch2 As Match = Regex.Match(gotMatch.Groups(1).Value, "value=""(.*?)""", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                If (regMatch2.Success) Then
                    flag2 = regMatch2.Groups(1).Value
                End If
                comboBoxText.Items.Add(flag1.Trim() + " - " + flag2.Trim())
            Next
            comboBoxText.SelectedIndex = 0
            formMain.returnMessage("Text snippets successfully loaded!")
        End If

    End Sub

    Private Sub btnSyncCurrency_Click(sender As System.Object, e As System.EventArgs) Handles btnSyncCurrency.Click
        Dim amount As Double = CDbl("10.00")
        Dim dollars As Double = MoneyConverter.RubbleToUsd(amount)
        MoneyConverter.RubbleUsdRate = saperCurUpdates.GetRubbleRate("USD")
        dollars = MoneyConverter.RubbleToUsd(amount)
        formCurrency.lblDollarCheck.Text = String.Format("{0:0.00} Rubles in USD is: ${1:0.00} Conversion Rate: {2:0.00}.", amount, dollars, MoneyConverter.RubbleUsdRate)

        Dim pounds As Double = MoneyConverter.RubbleToUsd(amount)
        MoneyConverter.RubbleUsdRate = saperCurUpdates.GetRubbleRate("GBP")
        pounds = MoneyConverter.RubbleToPounds(amount)
        formCurrency.lblPoundCheck.Text = String.Format("{0:0.00} Rubles in GBP is: £{1:0.00} Conversion Rate: {2:0.00}.", amount, pounds, MoneyConverter.RubbleUsdRate)
        formCurrency.Show()
    End Sub

    Private Sub chkBoxEnableDripfeeds_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkBoxEnableDripfeeds.CheckedChanged
        If (chkBoxEnableDripfeeds.Checked = True) Then
            formDripFeeding.Show()
        End If
    End Sub

    Private Sub btnDripFeedLinks_Click(sender As System.Object, e As System.EventArgs) Handles btnDripFeedLinks.Click
        ' validation
        If (listViewShowLinks.Items.Count < 1) Then
            formMain.returnMessage("The searched links tab is empty! there is nothing to add to the dripfeed scheduler.")
            Return
        End If
        ' has anything been checked?
        If listViewShowLinks.CheckedItems.Count > 0 Then
            ' add the links to the scheduler datagrid
            For Each itm As ListViewItem In listViewShowLinks.CheckedItems
                ' is choose random text selected
                Dim splitVal As String()
                If (chkBoxPostRandomLink.Checked = True) Then
                    Dim r As New Random
                    Dim g As Integer
                    Do
                        g = r.Next(comboBoxText.Items.Count)
                    Loop While g = comboBoxText.SelectedIndex
                    splitVal = comboBoxText.Items(g).ToString().Split("-"c)
                Else
                    splitVal = comboBoxText.SelectedItem.ToString().Split("-"c)
                End If
                Dim msId = itm.SubItems(4).Text.Trim()

                ' It can't show too long strings
                'MessageBox.Show(msId)  

                Dim item As ListViewItem = formDripFeeding.lvDripFeed.Items.Add(itm.SubItems(1).Text.Trim())
                item.SubItems.Add(itm.SubItems(7).Text.Trim())
                item.SubItems.Add(itm.SubItems(2).Text.Trim())
                item.SubItems.Add(itm.SubItems(3).Text.Trim())
                item.SubItems.Add(msId)
                item.SubItems.Add(splitVal(1))
                item.SubItems.Add(splitVal(0))
                item.SubItems.Add(comboBoxSearchLinkID.SelectedItem.ToString)
                itm.Checked = False
                formMain.returnMessage("Link successfully added to the dripfeed scheduler.")
            Next
        Else
            formMain.returnMessage("No links selected to add to the dripfeed scheduler.")
        End If
    End Sub

    Private Sub timerMain_Tick(sender As System.Object, e As System.EventArgs) Handles timerMain.Tick
        ' update timer
        For i As Integer = formDripFeeding.lvDripFeed.Items.Count - 1 To 0 Step -1
            ' vars
            Dim linkID As String = CStr(formDripFeeding.lvDripFeed.Items(i).SubItems(1).Text)
            Dim linkSI As String = CStr(formDripFeeding.lvDripFeed.Items(i).SubItems(2).Text)
            Dim linkTI As String = CStr(formDripFeeding.lvDripFeed.Items(i).SubItems(5).Text)
            Dim linkMS As String = CStr(formDripFeeding.lvDripFeed.Items(i).SubItems(4).Text)
            Dim linkPX As String = CStr(formDripFeeding.lvDripFeed.Items(i).SubItems(3).Text)
            Dim linkCI As String = CStr(formDripFeeding.lvDripFeed.Items(i).SubItems(7).Text)
            ' execute link placement
            Dim buyHTML = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=add&task=placementCreate", "p%5B%5D=" + linkID.Trim() + "&url_text_id%5B" + linkID.Trim() + "%5D=" + linkTI.Trim() + "&forceSeoWait=0&link_id=" + linkCI.Trim() + "&filter_mode=0&ms=" + linkMS.Trim() + "&pgex=" + linkPX.Trim() + "&searchId=" + linkSI.Trim() + "&price_2=0", formMain.varCookieJar)
            Dim resHTML = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=status&task=placementCreate", "", formMain.varCookieJar)
            ' remove and exit
            formDripFeeding.lvDripFeed.Items.RemoveAt(i)
            ' start timer
            If i <> 0 Then
                tmrCountDown.Start()
            End If
            Return
        Next
        timerMain.Stop()
        tmrCountDown.Stop()
        formMain.returnMessage("All links have been posted!")
        formDripFeeding.btnEnableTimer.Enabled = True
    End Sub

    Private Sub ViewURLInBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewURLInBrowserToolStripMenuItem.Click
        For Each item As ListViewItem In listViewMain.SelectedItems
            Process.Start(item.SubItems(4).Text & item.SubItems(5).Text)
        Next
    End Sub

    Private Sub btnPreviewText_Click(sender As Object, e As EventArgs) Handles btnPreviewText.Click
        ' validation
        If (Me.txtBoxCreateProjectName.Text = "" Or Me.txtBoxProjectURL.Text = "" Or Me.txtBoxProjectAnchors.Text = "" Or Me.txtBoxProjectAlias.Text = "" Or Me.txtBoxProjectkeywords.Text = "") Then
            formMain.returnMessage("You must fill in all project fields before previewing!")
            Return
        End If
        ' see if the file preview exists if not create
        If (File.Exists("Preview/Preview.html")) Then
            ' do nothing
        Else
            ' create
            Directory.CreateDirectory("Preview")
            File.WriteAllText("Preview/Preview.html", "")
        End If
        ' reset the previous .html file (make blank)
        File.WriteAllText("Preview/Preview.html", "")
        ' conversions
        Using sw As New StreamWriter("Preview/Preview.html", True)
            For Each snippet As String In Me.txtBoxProjectAnchors.Text.Split(CChar(vbCrLf))
                If (snippet.Contains("#a#keyword")) Then
                    Dim keyword As String = "<a href=""" & txtBoxProjectURL.Text & """>" & txtBoxProjectkeywords.Text & "</a>"
                    Dim keywordString As String = snippet.Replace("#a#keyword#/a#", keyword)
                    ' write to .html
                    sw.WriteLine(keywordString & "<br /><br />")
                ElseIf (snippet.Contains("#a#url")) Then
                    Dim keyword As String = "<a href=""" & txtBoxProjectURL.Text & """>" & txtBoxProjectURL.Text & "</a>"
                    Dim keywordString As String = snippet.Replace("#a#url#/a#", keyword)
                    ' write to .html
                    sw.WriteLine(keywordString & "<br /><br />")
                ElseIf (snippet.Contains("#domain#")) Then
                    Dim keyword As String = "<a href=""" & txtBoxProjectURL.Text & """>" & txtBoxProjectURL.Text & "</a>"
                    Dim keywordString As String = snippet.Replace("#domain#", keyword)
                    ' write to .html
                    sw.WriteLine(keywordString & "<br /><br />")
                End If
            Next
            sw.Close()
        End Using
        ' load form
        formPreviewText.Show()
    End Sub

    Private Sub txtBoxSearchSearches_TextChanged(sender As Object, e As EventArgs)
        listViewShowLinks.BeginUpdate()
        If (txtBoxSearchSearches.Text.Trim().Length = 0) Then
            listViewShowLinks.Items.Clear()
            For Each item In listCopy
                listViewShowLinks.Items.Add(item)
            Next
        Else
            listViewShowLinks.Items.Clear()
            For Each item In listCopy
                If (item.SubItems(5).Text.Contains(txtBoxSearchSearches.Text)) Then
                    listViewShowLinks.Items.Add(item)
                End If
            Next
        End If
        listViewShowLinks.EndUpdate()
    End Sub

    Private Sub chkBoxEnablekeywords_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxEnablekeywords.CheckedChanged
        radioCur3.Checked = True
        If (chkBoxEnablekeywords.Checked = True) Then
            radioWordType0.Enabled = True
            radioWordType1.Enabled = True
            radioWordType0.Checked = True
            txtBoxSearchTitleTags.Enabled = True
            radioCur3.Checked = True
        Else
            radioWordType0.Enabled = False
            radioWordType1.Enabled = False
            radioWordType0.Checked = False
            radioWordType1.Checked = False
            txtBoxSearchTitleTags.Enabled = False
            radioCur3.Checked = True
        End If
    End Sub

    Private Sub txtBoxSearchSearches_TextChanged_1(sender As Object, e As EventArgs) Handles txtBoxSearchSearches.TextChanged
        listViewShowLinks.BeginUpdate()
        If (txtBoxSearchSearches.Text.Trim().Length = 0) Then
            listViewShowLinks.Items.Clear()
            For Each item In listCopy
                listViewShowLinks.Items.Add(item)
            Next
        Else
            listViewShowLinks.Items.Clear()
            For Each item In listCopy
                ' if else by search
                Dim searchBy As String = If((chkBoxURL.Checked = True), item.SubItems(1).Text, item.SubItems(7).Text)
                If (searchBy.Contains(txtBoxSearchSearches.Text)) Then
                    listViewShowLinks.Items.Add(item)
                End If
            Next
        End If
        listViewShowLinks.EndUpdate()
    End Sub

    Private Sub chkBoxSearchID_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxSearchID.CheckedChanged
        If (chkBoxSearchID.Checked = True) Then
            txtBoxSearchSearches.BackColor = Color.Aqua
        End If
    End Sub

    Private Sub WAITSEOApprovePostingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WAITSEOApprovePostingToolStripMenuItem.Click
        For Each item As ListViewItem In listViewMain.SelectedItems
            'MessageBox.Show(item.SubItems(1).Text)
            If (item.SubItems(1).Text = "OK") Then
                formMain.returnMessage("This link is already live no posting needed.")
                Return
            ElseIf (item.SubItems(1).Text = "WAIT_SEO") Then
                ' navigate to links
                Dim uHTML As String = saperFunctions.getURL("http://www.sape.ru/links_wait.php", formMain.varCookieJar)

                ' <input type="hidden" name="_uhash" value="db89bfa471ce9127f80f8371b69de9bc276cbea0" />
                Dim uHash As String = saperFunctions.returnUHash(uHTML)

                ' execute link placement
                Dim p = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=add&task=placementAcceptSeoWl", "pl_ids%5B" & item.SubItems(0).Text & "%5D=" & item.SubItems(0).Text & "&_uhash=" & uHash & "&act=placementAcceptSeoWl", formMain.varCookieJar)
                Dim r = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=status&task=placementAcceptSeoWl", "", formMain.varCookieJar)

                ' responses
                Dim tempPost = New With {Key .message = "", Key .error = 0, Key .done = False, Key .jsdata = ""}
                Dim obj = JsonConvert.DeserializeAnonymousType(r, tempPost)
                Dim com As String = obj.message
                Dim obj2 = JsonConvert.DeserializeObject(Of saperJsonObject)(r)

                ' success flags
                If CBool((CStr(obj2.done))) Then
                    formMain.returnMessage("Link successfully approved and posted!")
                Else
                    formMain.returnMessage("Link successfully approved and posted!")
                End If
            End If
        Next
    End Sub

    Private Sub btnSaveSearches_Click(sender As Object, e As EventArgs) Handles btnSaveSearches.Click

        If (listViewShowLinks.Items.Count = 0) Then
            formMain.returnMessage("There is no searches to export!")
            Return
        End If

        sfDialog.Title = "Select a save file location..."
        sfDialog.InitialDirectory = "C:"
        sfDialog.Filter = "XML Files|*.xml"
        sfDialog.FileName = "saperSearches.xml"
        If (sfDialog.ShowDialog = DialogResult.OK) Then
            Try
                ' file location
                Dim enc As Encoding = Nothing
                Dim fileLocation As String = sfDialog.FileName
                Dim myXmlWriter As New Xml.XmlTextWriter(fileLocation, enc)

                ' add a few extra options to the XML
                With myXmlWriter
                    '.Formatting
                    .Indentation = 3
                    .Formatting = Xml.Formatting.Indented
                    myXmlWriter.WriteStartDocument()
                    myXmlWriter.WriteStartElement("saper")

                    Dim groups As New Dictionary(Of String, List(Of ListViewItem))

                    For Each item As ListViewItem In listViewShowLinks.Items
                        Dim key = item.SubItems(4).Text.Trim() ' msId as Key
                        If groups.ContainsKey(key) = False Then
                            Dim list = New List(Of ListViewItem)
                            list.Add(item)
                            groups.Add(key, list)
                        Else
                            Dim list = groups(key)
                            list.Add(item)
                        End If
                    Next

                    ' Write searchId as attribute
                    'Dim searchId = listViewShowLinks.Items(0).SubItems(2).Text.Trim()
                    'myXmlWriter.WriteAttributeString("searchId", searchId)

                    For Each key As String In groups.Keys
                        Dim items = groups(key)
                        myXmlWriter.WriteStartElement("saperMSID")
                        myXmlWriter.WriteAttributeString("MSID", key)
                        For Each itm As ListViewItem In items
                            myXmlWriter.WriteStartElement("saperSearches")

                            myXmlWriter.WriteStartElement("saperSiteID")
                            myXmlWriter.WriteValue(itm.SubItems(0).Text.Trim())
                            myXmlWriter.WriteEndElement()
                            myXmlWriter.WriteStartElement("saperURL")
                            myXmlWriter.WriteValue(itm.SubItems(1).Text.Trim())
                            myXmlWriter.WriteEndElement()
                            myXmlWriter.WriteStartElement("saperSearchID")
                            myXmlWriter.WriteValue(itm.SubItems(2).Text.Trim())
                            myXmlWriter.WriteEndElement()

                            ' ternary operator
                            Dim ternPG As String = If((itm.SubItems(3).Text.Trim() = ""), " ", itm.SubItems(3).Text.Trim())
                            myXmlWriter.WriteStartElement("saperPgexID")
                            myXmlWriter.WriteValue(ternPG)
                            myXmlWriter.WriteEndElement()

                            myXmlWriter.WriteStartElement("saperUniqueID")
                            myXmlWriter.WriteValue(itm.SubItems(5).Text.Trim())
                            myXmlWriter.WriteEndElement()
                            myXmlWriter.WriteStartElement("saperPriceRublesDaily")
                            myXmlWriter.WriteValue(itm.SubItems(6).Text.Trim())
                            myXmlWriter.WriteEndElement()

                            ' ternary operator
                            Dim ternPR As String = If((itm.SubItems(8).Text.Trim() = ""), " ", itm.SubItems(8).Text.Trim())
                            myXmlWriter.WriteStartElement("saperPageRank")
                            myXmlWriter.WriteValue(ternPR)
                            myXmlWriter.WriteEndElement()

                            ' ternary operator
                            Dim ternSR As String = If((itm.SubItems(9).Text.Trim() = ""), " ", itm.SubItems(9).Text.Trim())
                            myXmlWriter.WriteStartElement("saperSapeRank")
                            myXmlWriter.WriteValue(ternSR)
                            myXmlWriter.WriteEndElement()

                            myXmlWriter.WriteEndElement()
                        Next
                        myXmlWriter.WriteEndElement()
                    Next
                    myXmlWriter.WriteEndElement()
                    myXmlWriter.WriteEndDocument()
                End With
                ' once finished close up
                myXmlWriter.Flush()
                myXmlWriter.Close()
                formMain.returnMessage("Searches have been exported successfully.")
            Catch ex As Exception
                formMain.returnMessage("The following error occurred: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnLoadSearches_Click(sender As Object, e As EventArgs) Handles btnLoadSearches.Click
        ' setup
        ofDialog.Filter = " XML Files|*.xml"
        ofDialog.Title = "Select an XML file..."

        ' was cancel pressed?
        If (ofDialog.ShowDialog() = DialogResult.Cancel) Then
            Return
        End If

        ' clear the table
        listViewShowLinks.Items.Clear()
        lblLinksCount.Text = "0" + " Links found."

        ' start reading the .xml
        Dim XMLDoc As New Xml.XmlDocument

        ' find and load the XML file
        XMLDoc.Load(ofDialog.FileName)

        ' loop and add to the listview
        Dim root = XMLDoc.DocumentElement.SelectSingleNode("/saper")
        'Dim sSCI = root.Attributes("searchId").Value
        Dim groups = root.SelectNodes("saperMSID")
        For Each group As XmlNode In groups
            Dim mSID = group.Attributes("MSID").Value
            ' loop and add to the listview
            Dim nodes As XmlNodeList = group.SelectNodes("saperSearches")
            For Each node As XmlNode In nodes
                ' vars
                Dim sSID = node.SelectSingleNode("saperSiteID").InnerText
                Dim sURL = node.SelectSingleNode("saperURL").InnerText
                Dim sSCI = node.SelectSingleNode("saperSearchID").InnerText
                Dim pPID = node.SelectSingleNode("saperPgexID").InnerText
                Dim mPGD = node.SelectSingleNode("saperUniqueID").InnerText
                Dim mRUB = node.SelectSingleNode("saperPriceRublesDaily").InnerText
                Dim mPPR = node.SelectSingleNode("saperPageRank").InnerText
                Dim mSSR = node.SelectSingleNode("saperSapeRank").InnerText
                ' add to the listview
                Dim item As ListViewItem = listViewShowLinks.Items.Add(sSID)
                item.SubItems.Add(sURL)
                item.SubItems.Add(sSCI)
                item.SubItems.Add(pPID)
                item.SubItems.Add(mSID)
                item.SubItems.Add(mPGD)
                item.SubItems.Add(mRUB)
                item.SubItems.Add(mPGD)
                item.SubItems.Add(mPPR)
                item.SubItems.Add(mSSR)
            Next
        Next
        ' update
        lblLinksCount.Text = listViewShowLinks.Items.Count.ToString() + " Links imported."
        formMain.returnMessage(listViewShowLinks.Items.Count.ToString() + " Links imported.")
    End Sub

    Private Sub chkBoxRemoveTopLevelDomains_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxRemoveTopLevelDomains.CheckedChanged
        If (Me.bgWorker.IsBusy = True) Then
            formMain.returnMessage("You can only remove once the searches are done")
            Return
        Else
            If (chkBoxRemoveTopLevelDomains.Checked = True) Then
                ' update
                formMain.returnMessage("Removing top level domains, please wait a few minutes...")

                ' remove top level domains
                Dim itemI As ListViewItem
                Dim itemJ As ListViewItem

                For i As Integer = listViewShowLinks.Items.Count - 1 To 0 Step -1
                    itemI = listViewShowLinks.Items(i)
                    For j As Integer = i + 1 To listViewShowLinks.Items.Count - 1 Step 1
                        itemJ = listViewShowLinks.Items(j)
                        If itemI.SubItems(7).Text = itemJ.SubItems(7).Text Then
                            ' Duplicate item found.
                            listViewShowLinks.Items.Remove(itemI)
                            Exit For
                        End If
                    Next j
                Next i
                lblLinksCount.Text = listViewShowLinks.Items.Count.ToString() + " Links found."
                formMain.returnMessage("Top level domains removed from level 2 and 3 searches.")
                chkBoxRemoveTopLevelDomains.Checked = False
            End If
        End If
    End Sub

    Friend spanCountDown As New TimeSpan()
    Friend spanCountDownTemp As New TimeSpan()
    Private Sub tmrCountDown_Tick(sender As Object, e As EventArgs) Handles tmrCountDown.Tick
        spanCountDownTemp = spanCountDownTemp.Subtract(New TimeSpan(0, 0, 0, 1))
        formDripFeeding.lblCountDown.Text = spanCountDownTemp.ToString()

        If spanCountDownTemp.Hours = 0 AndAlso spanCountDownTemp.Minutes = 0 AndAlso spanCountDownTemp.Seconds = 0 Then
            spanCountDownTemp = spanCountDown
        End If
        If formDripFeeding.lvDripFeed.Items.Count = 0 Then
            tmrCountDown.Stop()
        End If
    End Sub

    Private Sub bgWorkerTwitter_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles bgWorkerTwitter.DoWork
        ' cast to a string value
        Dim action As String = TryCast(e.Argument, String)
        If (action = "sape_twitter_search") Then
            'Try
            '    Dim searchHTML As String
            '    ' no invoke needed
            '    searchHTML = saperFunctions.postURL("http://pr2.sape.ru/twaccount/search/project_id/" & formTwitter.Text, "filter%5Bprice_from%5D=" & formTwitter.txtBoxTwitterPriceFrom.Text & "&filter%5Bprice_to%5D=" & formTwitter.txtBoxTwitterPriceTo.Text & "&filter%5Bfollowers_from%5D=" & formTwitter.txtBoxFollowingFrom.Text & "&filter%5Bfollowers_to%5D=" & formTwitter.txtBoxFollowingTo.Text & "&filter%5Bfriends_from%5D=&filter%5Bfriends_to%5D=&filter%5Bstatuses_from%5D=&filter%5Bstatuses_to%5D=&filter%5Bpr_from%5D=" & formTwitter.txtBoxTwitterPRFrom.Text & "&filter%5Bpr_to%5D=" & formTwitter.txtBoxTwitterPRTo.Text, formMain.varCookieJar)

            '    If (InvokeRequired) Then
            '        Invoke(Sub()
            '                   Dim data = formTwitter.Parse(searchHTML).ToArray()
            '                   MessageBox.Show("NOT SHOWING HERE!" & data(0).AccountName)
            '               End Sub)
            '    End If
            '    Dim pageCount As String()
            '    ' calculate the number of pages
            '    pageCount = saperFunctions.returnLinksTwitterAccounts(searchHTML).Split(CChar(" "))
            '    'MessageBox.Show(pageCount(0))

            '    Dim pages As Integer
            '    ' round up
            '    pages = CInt(CDbl(pageCount(1)) / 20)
            '    'pages = CInt(CDbl(pageCount(1)) / 20)
            '    'MessageBox.Show(pages.ToString)

            '    ' scrape pages 2 - pages - 1
            '    For i As Integer = 2 To pages - 1
            '        'If (InvokeRequired) Then
            '        '    Invoke(Sub()
            '        searchHTML = saperFunctions.postURL("http://pr2.sape.ru/twaccount/search/project_id/" & formTwitter.Text & "?page=" & i.ToString(), "filter%5Bprice_from%5D=" & formTwitter.txtBoxTwitterPriceFrom.Text & "&filter%5Bprice_to%5D=" & formTwitter.txtBoxTwitterPriceTo.Text & "&filter%5Bfollowers_from%5D=" & formTwitter.txtBoxFollowingFrom.Text & "&filter%5Bfollowers_to%5D=" & formTwitter.txtBoxFollowingTo.Text & "&filter%5Bfriends_from%5D=&filter%5Bfriends_to%5D=&filter%5Bstatuses_from%5D=&filter%5Bstatuses_to%5D=&filter%5Bpr_from%5D=" & formTwitter.txtBoxTwitterPRFrom.Text & "&filter%5Bpr_to%5D=" & formTwitter.txtBoxTwitterPRTo.Text, formMain.varCookieJar)
            '        Dim data = formTwitter.Parse(searchHTML).ToArray()
            '        ' sleep to be good
            '        Threading.Thread.Sleep(2000)
            '        '           End Sub)
            '        'End If
            '    Next

            '    If (InvokeRequired) Then
            '        Invoke(Sub()
            '                   ' return the count
            '                   formTwitter.lblNumberOfTwitterAccounts.Text = CStr(formTwitter.listViewTwitter.Items.Count())
            '               End Sub)
            '    End If

            '    'Activate(Controls)
            '    If (formTwitter.listViewTwitter.Items.Count > 0) Then
            '        formTwitter.txtBoxTwitterURL.Enabled = True
            '        formTwitter.txtBoxTwitterBody.Enabled = True
            '        formTwitter.btnPostTweets.Enabled = True
            '        formTwitter.btnTwitterSearch.Enabled = True
            '    End If
            'Catch ex As Exception
            '    formMain.returnMessage("TWITTER ERROR!" & vbCrLf & vbCrLf & ex.ToString)
            'End Try
        End If
    End Sub

    Private Sub chkBoxAdditionalSnippets_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxAdditionalSnippets.CheckedChanged
        If (chkBoxAdditionalSnippets.Checked = True) Then
            btnAddAdditionalSnippets.Enabled = True
        Else
            btnAddAdditionalSnippets.Enabled = False
        End If
    End Sub

    Private Sub btnAddAdditionalSnippets_Click(sender As Object, e As EventArgs) Handles btnAddAdditionalSnippets.Click
        ' validation
        If (Information.IsNothing(Me.comboBoxSearchLinkID.SelectedItem)) Then
            formMain.returnMessage("You need to select the link ID! Press the ID button above.")
            Return
        End If
        ' validation
        If String.IsNullOrEmpty(txtBoxProjectAnchors.Text) Then
            formMain.returnMessage("You need to add more snippets first.")
            Return
        End If
        ' snippet validation
        For Each snippet As String In Me.txtBoxProjectAnchors.Text.Split(CChar(vbCrLf))
            If (snippet.Length > 100) Then
                formMain.returnMessage("1 or more of your snippet(s) is longer that 100 characters!")
                formMain.returnMessage("Snippet over 100 characters: " & vbCrLf & vbCrLf & snippet & " is (" & snippet.Length & ") characters long.")
                Return
            End If
        Next
        'POST http://www.sape.ru/ajax_task.php?act=add&task=projectUrlTextAdd HTTP/1.1
        'Host: www.sape.ru()
        'Connection: keep -alive
        'Content-Length: 182
        'Accept: application/json, text/javascript, */*
        'Origin: http://www.sape.ru
        'X-Requested-With: XMLHttpRequest
        'User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36
        'Content-Type: application/x-www-form-urlencoded
        'Referer: http://www.sape.ru/link_texts.php?link_id=90460818
        'Accept -Encoding : gzip, deflate
        'Accept-Language: en-US,en;q=0.8
        'Cookie: sape_tips=%7B%22excludedIdx%22%3A%5B%5D%2C%22currentIdx%22%3A16%2C%22isClosed%22%3Atrue%7D; plog=%89v%C9%E0%B0%01%EE%FE%B6%A5%FE%90; pr_v2_beta=[1135778]; bb0lastvisit=1437392395; bb0lastactivity=0; pr2_is_projects={"1135778":1}; SAPE=Wxz4a50PpfSvOe32CZvL35BFL80; AUTH_TICKET=caf0319fd29225cc684b1287aa26ea9d; article_informer=a%3A4%3A%7Bs%3A8%3A%22requests%22%3Bi%3A0%3Bs%3A6%3A%22sleepB%22%3Bi%3A0%3Bs%3A8%3A%22nofOrder%22%3Bi%3A0%3Bs%3A6%3A%22userId%22%3Bi%3A1135778%3B%7D; advisor_informer=a%3A3%3A%7Bs%3A9%3A%22nofSurvey%22%3Bi%3A0%3Bs%3A14%3A%22nofWaitPayment%22%3Bi%3A0%3Bs%3A6%3A%22userId%22%3Bs%3A7%3A%221135778%22%3B%7D; pr_informer=a%3A4%3A%7Bs%3A6%3A%22userId%22%3Bs%3A7%3A%221135778%22%3Bs%3A20%3A%22waiting_placement_nb%22%3Bi%3A0%3Bs%3A24%3A%22waiting_placement_amount%22%3Bi%3A0%3Bs%3A23%3A%22waiting_seo_premoderate%22%3Bs%3A1%3A%220%22%3B%7D; advookie=Tx4BADCE27FFA486388C83BBA44D4EB39D9735D049CCC994416827884954D4179835363237383039; __utma=261317330.566004734.1437217907.1440534586.1440856466.20; __utmb=261317330.12.10.1440856466; __utmc=261317330; __utmz=261317330.1440534586.19.2.utmcsr=sape.ru|utmccn=(referral)|utmcmd=referral|utmcct=/sites.php
        'link_id=90460818&query=buy+british+chocolate&uri=http%3A%2F%2Fwww.camnevbritishsweets.co.uk%2F&exactEnv=5&exactAtt=5&notExactEnv=5&notExactAtt=5&texts=here+%23domain%23+there&limit=0
        Try
            Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
            Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
            Dim project As XmlRpcStruct() = proxy.SapeGetURLS(Convert.ToInt32(Me.Text))
            Dim uid As String = String.Empty
            Dim upd As String = String.Empty
            Dim url As String = String.Empty
            Dim upn As String = String.Empty
            Dim ust As String = String.Empty
            Dim usy As String = String.Empty
            Dim uat As String = String.Empty
            Dim ulk As String = String.Empty
            Dim ukw As String = String.Empty
            If (userId > 0) Then
                ' vars
                url = project(0)("url").ToString
                ukw = project(0)("keyword").ToString
                ' GET
                Dim g = saperFunctions.getURL("http://www.sape.ru/link_texts.php?link_id=" & comboBoxSearchLinkID.SelectedItem.ToString(), formMain.varCookieJar)
                ' POST
                Dim p = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=add&task=projectUrlTextAdd", "link_id=" & comboBoxSearchLinkID.SelectedItem.ToString() & "&query=" & ukw.Replace(" ", "+") & "&uri=" & url & "&exactEnv=5&exactAtt=5&notExactEnv=5&notExactAtt=5&texts=" + Me.txtBoxProjectAnchors.Text.Replace(" ", "+") + "&limit=0", formMain.varCookieJar)
                ' POST
                Dim s = saperFunctions.postURL("http://www.sape.ru/ajax_task.php?act=status&task=projectUrlTextAdd", "", formMain.varCookieJar)
                ' responses
                Dim tempPost = New With {Key .message = "", Key .error = 0, Key .done = False, Key .jsdata = ""}
                Dim obj1 = JsonConvert.DeserializeAnonymousType(s, tempPost)
                Dim com As String = obj1.message
                Dim obj2 = JsonConvert.DeserializeObject(Of saperJsonObject)(s)
                ' success flags
                If CBool((CStr(obj2.done))) Then
                    formMain.returnMessage("Updated your snippets successfully!")
                Else
                    formMain.returnMessage("Updated your snippets successfully!")
                End If
            End If
        Catch ex As Exception
            formMain.returnMessage("You don't have a URL attached to this project! so we can't get the ID.")
        End Try

    End Sub

    Private Sub chkBoxURL_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxURL.CheckedChanged
        If chkBoxURL.Checked = True Then
            lblSearchByName.Text = " Search by Name:"
            txtBoxSearchSearches.BackColor = Color.Yellow
        Else
            lblSearchByName.Text = "Search Unique ID:"
            txtBoxSearchSearches.BackColor = Color.White
        End If
    End Sub
End Class
