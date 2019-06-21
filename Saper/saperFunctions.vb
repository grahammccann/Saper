Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports CookComputing.XmlRpc

Module saperFunctions

    ' This function creates a GET request
    Public Function getURL(ByVal url As String, ByVal varCookieJar As CookieContainer) As String
        Dim GHTML As String = String.Empty
        Try
            Dim GetRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            With GetRequest
                .CookieContainer = varCookieJar
                ' Break up the lines from the file into a String Array
                Dim names As String() = IO.File.ReadAllLines("userAgents.txt")
                Dim rnd As New Random()
                ' Select a random index from the array
                Dim selectedIndex = rnd.Next(0, names.Length)
                ' Set the name to the String array value at the random index
                Dim selectedName = names(selectedIndex)
                .UserAgent = selectedName
                .Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
                .Headers.Add("Accept-Language", "ru,en-us;q=0.7,en;q=0.3")
                .Headers.Add("Accept-Encoding", "gzip, deflate")
                .Headers.Add("Accept-Charset", "windows-1251,utf-8;q=0.7,*;q=0.7")
                .KeepAlive = True
                .AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            End With
            Dim GetResponse As HttpWebResponse = DirectCast(GetRequest.GetResponse(), HttpWebResponse)
            If (GetResponse.StatusCode = HttpStatusCode.OK) Then
                Dim getStreamreader As StreamReader
                ' Check response charset and use proper encoding.
                If (Not String.IsNullOrEmpty(GetResponse.CharacterSet)) Then
                    Dim encoding As Encoding = encoding.GetEncoding(GetResponse.CharacterSet)
                    getStreamreader = New StreamReader(GetResponse.GetResponseStream, encoding)
                Else
                    getStreamreader = New StreamReader(GetResponse.GetResponseStream)
                End If
                GHTML = getStreamreader.ReadToEnd()
                If (formMain.chkBoxDebug.Checked = True) Then
                    formHTML.txtBoxDebugHTML.Text = GHTML
                    formHTML.Show()
                End If
                GetResponse.Close()
                getStreamreader.Close()
                Return GHTML
            End If
        Catch ex As Exception
            formMain.returnMessage("GET (HTTPWEBREQUEST) ERROR!" & vbCrLf & vbCrLf & ex.ToString)
        End Try
        Return GHTML
    End Function
    ' This function creates a POST request
    Public Function postURL(ByVal url As String, ByVal postData As String, ByVal varCookieJar As CookieContainer) As String
        'MessageBox.Show(postData)
        Dim PHTML As String = String.Empty
        Try
            Dim postRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim varPOSTData As New StringBuilder
            varPOSTData.Append(postData)
            ' Set Encoding to UTF8.
            Dim varBytes As Byte() = Encoding.UTF8.GetBytes(varPOSTData.ToString)
            With postRequest
                ' Break up the lines from the file into a String Array
                Dim names As String() = IO.File.ReadAllLines("userAgents.txt")
                Dim rnd As New Random()
                ' Select a random index from the array
                Dim selectedIndex = rnd.Next(0, names.Length)
                ' Set the name to the String array value at the random index
                Dim selectedName = names(selectedIndex)
                .UserAgent = selectedName
                .Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
                .Headers.Add("Accept-Language", "ru,en-us;q=0.7,en;q=0.3")
                .Headers.Add("Accept-Encoding", "gzip, deflate")
                .Headers.Add("Accept-Charset", "windows-1251,utf-8;q=0.7,*;q=0.7")
                .AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
                .CookieContainer = varCookieJar
                .ContentLength = varBytes.Length
                .ContentType = "application/x-www-form-urlencoded"
                .Method = "POST"
                .KeepAlive = True
            End With
            Dim postStream = postRequest.GetRequestStream()
            postStream.Write(varBytes, 0, varBytes.Length)
            Dim postResponse As HttpWebResponse = DirectCast(postRequest.GetResponse(), HttpWebResponse)
            If (postResponse.StatusCode = HttpStatusCode.OK) Then
                Dim varStreamreader As StreamReader
                ' Check response charset and use proper encoding.
                If (Not String.IsNullOrEmpty(postResponse.CharacterSet)) Then
                    Dim encoding As Encoding = encoding.GetEncoding(postResponse.CharacterSet)
                    varStreamreader = New StreamReader(postResponse.GetResponseStream, encoding)
                Else
                    varStreamreader = New StreamReader(postResponse.GetResponseStream)
                End If
                PHTML = varStreamreader.ReadToEnd()
                formMain.varCookieJar.Add(postResponse.Cookies)
                If (formMain.chkBoxDebug.Checked = True) Then
                    formHTML.txtBoxDebugHTML.Text = PHTML
                    formHTML.Show()
                End If
                postStream.Close()
                varStreamreader.Close()
                Return PHTML
            End If
        Catch ex As Exception
            formMain.returnMessage("POST (HTTPWEBREQUEST) ERROR!" & vbCrLf & vbCrLf & ex.ToString)
        End Try
        Return PHTML
    End Function
    ' This function returns the projects and adds them to the main datagrid
    Public Function returnProjects(ByVal html As String) As String
        Dim found As Boolean = True
        Dim matchesSource As New Regex("toggle_project((.*?)); return false;"" title=""Дата создания: (.*?)"">(.*?)<img", RegexOptions.IgnoreCase)
        'Dim matchesSource As New Regex("<input type=""hidden"" name=""id"" value=""(.*?)"" id=""project_id"">", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            formMain.dataGridProjects.Rows.Clear()
            For Each Match As Match In matchFound
                Dim cleanedString1 = Match.Groups(1).Value.Replace("(", " ")
                Dim cleanedString2 = cleanedString1.Replace(")", " ")
                'MessageBox.Show(cleanedString2)
                formMain.dataGridProjects.Rows.Add(cleanedString2.Trim(), Match.Groups(4).Value, Match.Groups(3).Value)
                formMain.dataGridProjects.Rows(formMain.dataGridProjects.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGreen
                found = True
            Next
            found = True
        Else
            found = False
        End If
        Return found.ToString
    End Function
    ' This function returns the projects and adds them to the main datagrid
    Public Function returnSubProjects(ByVal html As String) As String
        Dim found As Boolean = True
        Dim matchesSource As New Regex("toggle_project((.*?)); return false;"" title=""Дата создания: (.*?)"">(.*?)<img", RegexOptions.IgnoreCase)
        'Dim matchesSource As New Regex("<input type=""hidden"" name=""id"" value=""(.*?)"" id=""project_id"">", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            formMain.dataGridProjects.Rows.Clear()
            For Each Match As Match In matchFound
                Dim cleanedString1 = Match.Groups(1).Value.Replace("(", " ")
                Dim cleanedString2 = cleanedString1.Replace(")", " ")
                'MessageBox.Show(cleanedString2)
                formMain.dataGridProjects.Rows.Add(cleanedString2.Trim(), Match.Groups(4).Value, Match.Groups(3).Value)
                formMain.dataGridProjects.Rows(formMain.dataGridProjects.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGreen
                found = True
            Next
            found = True
        Else
            found = False
        End If
        Return found.ToString
    End Function
    ' This function returns the projects ID
    Public Function returnProjectsID(ByVal html As String) As String
        Dim cleanedString1 As String = String.Empty
        Dim cleanedString2 As String = String.Empty
        Dim matchesSource As New Regex("<input type=""hidden"" name=""id"" value=""(.*?)"" id=""project_id"">", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            For Each Match As Match In matchFound
                cleanedString1 = Match.Groups(1).Value.Replace("(", " ")
                cleanedString2 = cleanedString1.Replace(")", " ")
                'MessageBox.Show(cleanedString2)
                formMain.dataGridProjects.Rows.Add(cleanedString2.Trim(), Match.Groups(4).Value, Match.Groups(3).Value)
                formMain.dataGridProjects.Rows(formMain.dataGridProjects.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGreen
                'found = True
            Next
            Return cleanedString2
        Else
            Return cleanedString2
        End If
        Return cleanedString2
    End Function
    ' This function returns the link ID
    Public Function returnLinkID(ByVal html As String) As String
        Dim matchString As String = String.Empty
        Dim matchesSource As New Regex("<input type=""hidden"" name=""link_id"" value=""(.*?)"">", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            For Each M As Match In matchFound
                matchString = M.Groups(1).Value
                'MessageBox.Show(matchString)
            Next
            Return matchString
        Else
            Return matchString
        End If
        Return matchString
    End Function
    ' This function returns the search URLs
    Public Function returnSearchUrls(ByVal html As String) As String
        Dim found As Boolean = True
        Dim matchesSource As New Regex("<b><a class=""ajax_link"" href=""#"" sid=""(.*?)"">(.*?)</a></b>", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            Dim sID As String = returnSearchId(html)
            For Each gotMatch As Match In matchFound
                If (gotMatch.Groups(2).Value.Trim().StartsWith("URL")) Then
                    Dim lv As ListViewItem = formProject.listViewShowLinks.Items.Add(gotMatch.Groups(1).Value.Trim())
                    lv.UseItemStyleForSubItems = False
                    lv.SubItems.Add(gotMatch.Groups(2).Value.Trim()).BackColor = Color.LightGray
                    lv.SubItems.Add(sID.Trim()).BackColor = Color.LightGray
                    lv.BackColor = Color.LightGreen
                    found = True
                Else
                    Dim lv As ListViewItem = formProject.listViewShowLinks.Items.Add(gotMatch.Groups(1).Value.Trim())
                    lv.UseItemStyleForSubItems = False
                    lv.SubItems.Add(gotMatch.Groups(2).Value.Trim()).BackColor = Color.LightGreen
                    lv.SubItems.Add(sID.Trim()).BackColor = Color.LightGreen
                    lv.BackColor = Color.LightGreen
                    found = True
                End If
            Next
            found = True
        Else
            found = False
        End If
        Return found.ToString
    End Function
    ' This function returns the folder ID
    Public Function returnFolderID(ByVal html As String) As String
        Dim returnString As String = String.Empty
        Dim matchesSource As New Regex("<select name=""folder_id""><option value=""(.*?)""", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            For Each gotMatch As Match In matchFound
                returnString = gotMatch.Groups(1).Value.Trim()
                'MessageBox.Show(returnString)
                Return returnString
            Next
        End If
        Return returnString
    End Function
    ' This function returns the links ID(s)
    Public Function returnSearchLinkIDs(ByVal html As String) As String
        Dim returnString As String = String.Empty
        Dim matchesSource As New Regex("link_id=(.*?)""", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        'MessageBox.Show(matchFound.Count.ToString)
        If (matchFound.Count > 0) Then
            For Each gotMatch As Match In matchFound
                returnString = gotMatch.Groups(1).Value.Trim()
                'MessageBox.Show(returnString)
                Return returnString
            Next
        End If
        Return returnString
    End Function
    ' This function returns the links ID
    Public Function returnLinksID(ByVal html As String) As String
        Dim flag As String = String.Empty
        Dim regMatch As Match = Regex.Match(html, "value=""(.*?)"" id=""project_id", RegexOptions.IgnoreCase)
        If (regMatch.Success) Then
            flag = regMatch.Groups(1).Value
        End If
        Return flag
    End Function
    ' This function returns the links ID
    Public Function returnLinksTwitterAccounts(ByVal html As String) As String
        Dim flag As String = String.Empty
        Dim regMatch As Match = Regex.Match(html, "<div class=""tabs__item-info"">(.*?)</div>", RegexOptions.IgnoreCase)
        If (regMatch.Success) Then
            flag = regMatch.Groups(1).Value
        End If
        Return flag
    End Function
    ' This function returns the number of pages found
    Public Function returnPagesInTotal(ByVal html As String) As String
        Dim flag As String = String.Empty
        Dim regMatch As Match = Regex.Match(html, "nof_total=""(.*?)""", RegexOptions.IgnoreCase)
        If (regMatch.Success) Then
            ' Divide the number [2042 for example] by 50.
            Dim divNum As Double = Convert.ToInt32(regMatch.Groups(1).Value) / 50
            ' Round it up 42.54 to the nearest whole number.
            Dim outputNum As Double = Math.Ceiling(divNum)
            flag = outputNum.ToString
        End If
        Return flag
    End Function
    ' This function returns the pagination URL
    Public Function returnPaginationURL(ByVal html As String) As String
        Dim flag As String = String.Empty
        Dim regMatch As Match = Regex.Match(html, "<p class=""pagination_arrow_right"" style=""margin-left:10%""><a href=""(.*?)""", RegexOptions.IgnoreCase)
        If (regMatch.Success) Then
            flag = regMatch.Groups(1).Value
        End If
        Return flag
    End Function
    ' This function returns the search ID (TODO: is this invalid as the regex does this?)
    Public Function returnSearchId(ByVal html As String) As String
        Dim flag As String = String.Empty
        Dim regMatch As Match = Regex.Match(html, "name=""searchId"" value=""(.*?)""", RegexOptions.IgnoreCase)
        If (regMatch.Success) Then
            flag = regMatch.Groups(1).Value
        End If
        Return flag
    End Function
    ' This function returns the uHash value
    Public Function returnUHash(ByVal html As String) As String
        Dim returnString As String = String.Empty
        Dim matchesSource As New Regex("name=""_uhash"" value=""(.*?)""", RegexOptions.IgnoreCase)
        Dim matchFound As MatchCollection = matchesSource.Matches(html)
        If (matchFound.Count > 0) Then
            For Each gotMatch As Match In matchFound
                returnString = gotMatch.Groups(1).Value.Trim()
                MessageBox.Show(returnString)
                Return returnString
            Next
        End If
        Return returnString
    End Function
    ' This function returns a score for the link
    Function returnLinkScore(ByVal da As String, ByVal pa As String, ByVal pr As String, ByVal sr As String) As String
        Dim result As Decimal
        result = CDec(Math.Round((Integer.Parse(da) + Integer.Parse(pa) + Integer.Parse(pr) + Integer.Parse(sr)) / 220 * 100))
        returnLinkScore = result.ToString()
    End Function
End Module
