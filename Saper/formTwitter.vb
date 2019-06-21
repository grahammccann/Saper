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

Public Class formTwitter

    Public Shared tbodyRegex As New Regex("<tbody>(.*?)<\/tbody", RegexOptions.Singleline Or RegexOptions.Compiled)
    Public Shared trRegex As New Regex("<tr.*?>(.*?)<\/tr>", RegexOptions.Singleline Or RegexOptions.Compiled)
    Public Shared tdRegex As New Regex("<td.*?>(.*?)<\/td>", RegexOptions.Singleline Or RegexOptions.Compiled)
    Public Shared aRegex As New Regex("<a.*?>(.*?)<\/a>", RegexOptions.Singleline Or RegexOptions.Compiled)
    Public Shared idRegex As New Regex("<input.*?value=""(.*?)""", RegexOptions.Singleline Or RegexOptions.Compiled)

    Public Shared Iterator Function Parse(text As String) As IEnumerable(Of Data)
        Dim tableText = tbodyRegex.Match(text).Groups(1).Value
        Dim trs = trRegex.Matches(tableText)
        For i As Integer = 0 To trs.Count - 1
            Dim tds = tdRegex.Matches(trs(i).Groups(1).Value)
            Dim result = New Data()
            Dim idCell = tds(0).Groups(1).Value
            Dim accountCell = tds(1).Groups(1).Value
            Dim followersCell = tds(2).Groups(1).Value
            Dim followingCell = tds(3).Groups(1).Value
            Dim numberOfTweetsCell = tds(4).Groups(1).Value
            Dim prCell = tds(5).Groups(1).Value
            Dim priceCell = tds(6).Groups(1).Value
            ' regex the values
            result.ID = idRegex.Match(idCell).Groups(1).Value
            result.AccountName = aRegex.Match(accountCell).Groups(1).Value
            result.Followers = followersCell.Trim()
            result.Following = followingCell.Trim()
            result.NumberOfTweets = numberOfTweetsCell.Trim()
            result.PR = prCell.Trim()
            result.Price = priceCell.Replace("&nbsp;", "").Replace("&#8399;", "").Replace(",", ".").Trim()
            ' add to the listview
            formTwitter.listViewTwitter.BeginUpdate()
            Dim lv As ListViewItem = formTwitter.listViewTwitter.Items.Add(result.ID)
            lv.SubItems.Add(result.AccountName)
            lv.SubItems.Add(result.Followers)
            lv.SubItems.Add(result.Following)
            lv.SubItems.Add(result.NumberOfTweets)
            lv.SubItems.Add(result.PR)
            lv.SubItems.Add(result.Price)
            formTwitter.listViewTwitter.EndUpdate()
            ' return values
            Yield result
        Next
    End Function

    Public Class Data
        Public Property ID() As String
            Get
                Return m_ID
            End Get
            Set(value As String)
                m_ID = value
            End Set
        End Property
        Private m_ID As String
        Public Property AccountName() As String
            Get
                Return m_AccountName
            End Get
            Set(value As String)
                m_AccountName = value
            End Set
        End Property
        Private m_AccountName As String
        Public Property Followers() As String
            Get
                Return m_Followers
            End Get
            Set(value As String)
                m_Followers = value
            End Set
        End Property
        Private m_Followers As String
        Public Property Following() As String
            Get
                Return m_Following
            End Get
            Set(value As String)
                m_Following = value
            End Set
        End Property
        Private m_Following As String
        Public Property NumberOfTweets() As String
            Get
                Return m_NumberOfTweets
            End Get
            Set(value As String)
                m_NumberOfTweets = value
            End Set
        End Property
        Private m_NumberOfTweets As String
        Public Property PR() As String
            Get
                Return m_PR
            End Get
            Set(value As String)
                m_PR = value
            End Set
        End Property
        Private m_PR As String
        Public Property Price() As String
            Get
                Return m_Price
            End Get
            Set(value As String)
                m_Price = value
            End Set
        End Property
        Private m_Price As String
    End Class

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCloseTwitter.Click
        Me.Close()
    End Sub

    Private Sub btnParseTwitterers_Click(sender As Object, e As EventArgs) Handles btnParseTwitterers.Click
        'Dim tweetHTML As String = saperFunctions.getURL("http://pr2.sape.ru/twaccount/search/project_id/" & Me.Text, formMain.varCookieJar)
        'Dim data = Parse(tweetHTML).ToArray()
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
        'POST http://pr2.sape.ru/twaccount/search/project_id/1268140 HTTP/1.1
        'Host:   pr2.sape.ru()
        'Connection: keep -alive
        'Content-Length: 245
        'Cache -Control : max -age = 0
        'Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
        'Origin: http://pr2.sape.ru
        'Upgrade-Insecure-Requests: 1
        'User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36
        'Content-Type: application/x-www-form-urlencoded
        'Referer: http://pr2.sape.ru/twaccount/search/project_id/1268140
        'Accept -Encoding : gzip, deflate
        'Accept-Language: en-US,en;q=0.8
        'Cookie: sape_tips=%7B%22excludedIdx%22%3A%5B%5D%2C%22currentIdx%22%3A16%2C%22isClosed%22%3Atrue%7D; pr_v2_beta=[1135778]; bb0lastvisit=1437392395; bb0lastactivity=0; pr2_is_projects={"1135778":1}; jv_client_id_yeKRzktijd=6346.CdNKq9p93nFVzhbLEDvNMJHpQ8yTuav7nVniH5FZvpI; SAPE=OM4N0DEV40AGlvRYPXbb3OpFSqa; __utmt=1; AUTH_TICKET=caf0319fd29225cca8b038d2cd18f335; article_informer=a%3A4%3A%7Bs%3A8%3A%22requests%22%3Bi%3A0%3Bs%3A6%3A%22sleepB%22%3Bi%3A0%3Bs%3A8%3A%22nofOrder%22%3Bi%3A0%3Bs%3A6%3A%22userId%22%3Bi%3A1135778%3B%7D; advisor_informer=a%3A3%3A%7Bs%3A9%3A%22nofSurvey%22%3Bi%3A0%3Bs%3A14%3A%22nofWaitPayment%22%3Bi%3A0%3Bs%3A6%3A%22userId%22%3Bs%3A7%3A%221135778%22%3B%7D; pr_informer=a%3A4%3A%7Bs%3A6%3A%22userId%22%3Bs%3A7%3A%221135778%22%3Bs%3A20%3A%22waiting_placement_nb%22%3Bi%3A0%3Bs%3A24%3A%22waiting_placement_amount%22%3Bi%3A0%3Bs%3A23%3A%22waiting_seo_premoderate%22%3Bs%3A1%3A%220%22%3B%7D; PR2=f6e096675fe8cce6c7ee08e5800b28c7:85167ce780d1e5e8b06c6763dc01a6f1bbab0d1c; jv_enter_ts_yeKRzktijd=1440437932291; jv_refer_yeKRzktijd=http%3A%2F%2Fwww.sape.ru%2F; jv_visits_count_yeKRzktijd=5; __utma=261317330.566004734.1437217907.1440367321.1440437925.13; __utmb=261317330.26.9.1440438223710; __utmc=261317330; __utmz=261317330.1437217907.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); _ym_visorc_28733991=w
        'filter%5Bprice_from%5D=10&filter%5Bprice_to%5D=20&filter%5Bfollowers_from%5D=&filter%5Bfollowers_to%5D=&filter%5Bfriends_from%5D=&filter%5Bfriends_to%5D=&filter%5Bstatuses_from%5D=&filter%5Bstatuses_to%5D=&filter%5Bpr_from%5D=&filter%5Bpr_to%5D=
    End Sub

    Private Sub btnPostTweets_Click(sender As Object, e As EventArgs) Handles btnPostTweets.Click
        'POST http://pr2.sape.ru/twadvert/create HTTP/1.1
        'Host:   pr2.sape.ru()
        'Connection: keep -alive
        'Content-Length: 304
        'Cache -Control : max -age = 0
        'Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
        'Origin: http://pr2.sape.ru
        'Upgrade-Insecure-Requests: 1
        'User-Agent: Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36
        'Content-Type: application/x-www-form-urlencoded
        'Referer: http://pr2.sape.ru/twadvert/new
        'Accept -Encoding : gzip, deflate
        'Accept-Language: en-US,en;q=0.8
        'Cookie: sape_tips=%7B%22excludedIdx%22%3A%5B%5D%2C%22currentIdx%22%3A16%2C%22isClosed%22%3Atrue%7D; pr_v2_beta=[1135778]; bb0lastvisit=1437392395; bb0lastactivity=0; pr2_is_projects={"1135778":1}; jv_client_id_yeKRzktijd=6346.CdNKq9p93nFVzhbLEDvNMJHpQ8yTuav7nVniH5FZvpI; SAPE=OM4N0DEV40AGlvRYPXbb3OpFSqa; __utmt=1; AUTH_TICKET=caf0319fd29225cca8b038d2cd18f335; article_informer=a%3A4%3A%7Bs%3A8%3A%22requests%22%3Bi%3A0%3Bs%3A6%3A%22sleepB%22%3Bi%3A0%3Bs%3A8%3A%22nofOrder%22%3Bi%3A0%3Bs%3A6%3A%22userId%22%3Bi%3A1135778%3B%7D; advisor_informer=a%3A3%3A%7Bs%3A9%3A%22nofSurvey%22%3Bi%3A0%3Bs%3A14%3A%22nofWaitPayment%22%3Bi%3A0%3Bs%3A6%3A%22userId%22%3Bs%3A7%3A%221135778%22%3B%7D; pr_informer=a%3A4%3A%7Bs%3A6%3A%22userId%22%3Bs%3A7%3A%221135778%22%3Bs%3A20%3A%22waiting_placement_nb%22%3Bi%3A0%3Bs%3A24%3A%22waiting_placement_amount%22%3Bi%3A0%3Bs%3A23%3A%22waiting_seo_premoderate%22%3Bs%3A1%3A%220%22%3B%7D; PR2=f6e096675fe8cce6c7ee08e5800b28c7:85167ce780d1e5e8b06c6763dc01a6f1bbab0d1c; jv_enter_ts_yeKRzktijd=1440437932291; jv_refer_yeKRzktijd=http%3A%2F%2Fwww.sape.ru%2F; jv_visits_count_yeKRzktijd=5; _ym_visorc_28733991=w; __utma=261317330.566004734.1437217907.1440367321.1440437925.13; __utmb=261317330.30.9.1440438260299; __utmc=261317330; __utmz=261317330.1437217907.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)
        'type=link&project_id=1268140&twaccount%5B%5D=13514&tw_advert%5Bid%5D=&tw_advert%5Bproject_id%5D=1268140&tw_advert%5Btype%5D=link&tw_advert%5Bsite_id%5D=&create_twitter=created&tw_advert%5Burl%5D=http%3A%2F%2Fwww.camnevbritishsweets.co.uk%2F&tw_advert%5Btext%5D=testing+tweety&twitter_status=select_active
        ' validation
        If (txtBoxTwitterURL.Text = "" Or txtBoxTwitterBody.Text = "") Then
            formMain.returnMessage("Both your tweet URL and body must be entered!")
            Return
        End If
        ' tweet length
        If (txtBoxTwitterBody.TextLength >= 140) Then
            formMain.returnMessage("Your tweet body is " & txtBoxTwitterBody.TextLength & " characters long! too long.")
            Return
        End If
        ' more validation
        If listViewTwitter.CheckedItems.Count > 0 Then
            ' put the seelcted id's in an array
            Dim arr As New ArrayList

            ' loop and add them
            For Each itm As ListViewItem In listViewTwitter.CheckedItems
                'MessageBox.Show(itm.SubItems(0).Text)
                arr.Add(itm.SubItems(0).Text)
            Next
            Dim acc As String = String.Empty
            For i As Integer = 0 To arr.Count - 1
                acc += "twaccount%5B%5D=" & arr(i).ToString()
            Next
            'MessageBox.Show(acc.Count.ToString())
            ' post tweet
            Dim postTweet As String = saperFunctions.postURL("http://pr2.sape.ru/twadvert/create", "type=link&project_id=" & Me.Text & "&" & acc & "&tw_advert%5Bid%5D=&tw_advert%5Bproject_id%5D=" & Me.Text & "&tw_advert%5Btype%5D=link&tw_advert%5Bsite_id%5D=&create_twitter=created&tw_advert%5Burl%5D=" & txtBoxTwitterURL.Text & "&tw_advert%5Btext%5D=" & txtBoxTwitterBody.Text & "&twitter_status=select_active", formMain.varCookieJar)
            ' error flag
            If (postTweet.Contains("недостаточно средств для блокировки")) Then
                formMain.returnMessage("You don't have enough funds to post these tweets.")
                Return
            End If
            ' success flag
            If (postTweet.Contains("Заявка была успешно создана")) Then
                formMain.returnMessage("Tweet(s) posted successfully!")
                Return
            End If
        Else
            formMain.returnMessage("No accounts have been selected!")
        End If
    End Sub

    Private Sub btnTwitterSearch_Click(sender As Object, e As EventArgs) Handles btnTwitterSearch.Click
        ' labels reset
        lblNumberOfTwitterAccounts.Text = "0"
        ' clear listview
        listViewTwitter.Items.Clear()
        Try
            Dim searchHTML As String
            ' no invoke needed
            searchHTML = saperFunctions.postURL("http://pr2.sape.ru/twaccount/search/project_id/" & Me.Text, "filter%5Bprice_from%5D=" & txtBoxTwitterPriceFrom.Text & "&filter%5Bprice_to%5D=" & txtBoxTwitterPriceTo.Text & "&filter%5Bfollowers_from%5D=" & txtBoxFollowingFrom.Text & "&filter%5Bfollowers_to%5D=" & txtBoxFollowingTo.Text & "&filter%5Bfriends_from%5D=&filter%5Bfriends_to%5D=&filter%5Bstatuses_from%5D=&filter%5Bstatuses_to%5D=&filter%5Bpr_from%5D=" & txtBoxTwitterPRFrom.Text & "&filter%5Bpr_to%5D=" & txtBoxTwitterPRTo.Text, formMain.varCookieJar)
            Dim data = formTwitter.Parse(searchHTML).ToArray()
            Dim pageCount As String()
            ' calculate the number of pages
            pageCount = saperFunctions.returnLinksTwitterAccounts(searchHTML).Split(CChar(" "))
            Dim pages As Integer
            ' round up
            pages = CInt(CDbl(pageCount(1)) / 20)
            ' scrape pages 2 - pages - 1
            For i As Integer = 2 To pages - 1
                searchHTML = saperFunctions.postURL("http://pr2.sape.ru/twaccount/search/project_id/" & Me.Text & "?page=" & i.ToString(), "filter%5Bprice_from%5D=" & txtBoxTwitterPriceFrom.Text & "&filter%5Bprice_to%5D=" & txtBoxTwitterPriceTo.Text & "&filter%5Bfollowers_from%5D=" & txtBoxFollowingFrom.Text & "&filter%5Bfollowers_to%5D=" & txtBoxFollowingTo.Text & "&filter%5Bfriends_from%5D=&filter%5Bfriends_to%5D=&filter%5Bstatuses_from%5D=&filter%5Bstatuses_to%5D=&filter%5Bpr_from%5D=" & txtBoxTwitterPRFrom.Text & "&filter%5Bpr_to%5D=" & txtBoxTwitterPRTo.Text, formMain.varCookieJar)
                data = formTwitter.Parse(searchHTML).ToArray()
                ' sleep to be good
                Threading.Thread.Sleep(2000)
            Next
            ' return the count
            Me.lblNumberOfTwitterAccounts.Text = CStr(Me.listViewTwitter.Items.Count())
            'Activate(Controls)
            If (Me.listViewTwitter.Items.Count > 0) Then
                Me.txtBoxTwitterURL.Enabled = True
                Me.txtBoxTwitterBody.Enabled = True
                Me.btnPostTweets.Enabled = True
                Me.btnTwitterSearch.Enabled = True
            End If
        Catch ex As Exception
            formMain.returnMessage("TWITTER ERROR!" & vbCrLf & vbCrLf & ex.ToString)
        End Try
        'If (Not formProject.bgWorkerTwitter.IsBusy) Then
        '    ' log
        '    formMain.returnMessage("We are grabbing you some twitterers, please wait...")
        '    ' run backgroundworker
        '    formProject.bgWorkerTwitter.RunWorkerAsync("sape_twitter_search")
        '    ' disable button
        '    btnTwitterSearch.Enabled = False
        'End If
    End Sub

    Private Sub listViewTwitter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewTwitter.SelectedIndexChanged

    End Sub

    Private Sub btnParsePosted_Click(sender As Object, e As EventArgs) Handles btnParsePosted.Click
        ' clear listview
        listViewTwitterPosted.Items.Clear()
        ' a simple GET here
        Dim getHTML As String = saperFunctions.getURL("http://pr2.sape.ru/project/twadverts?id=" & Me.Text, formMain.varCookieJar)
        ' regex values
        Dim doc = New HtmlAgilityPack.HtmlDocument()
        doc.LoadHtml(getHTML)
        If doc.ParseErrors IsNot Nothing AndAlso doc.ParseErrors.Any() Then
            formMain.returnMessage("HTML parsing error occurred!")
        Else
            Try
                ' target tables
                Dim form = doc.DocumentNode.SelectSingleNode("//div[@id='tableFixedWell']//form")
                Dim tableRows = form.SelectNodes("//table/tbody/tr")
                ' vars (could have done in loop)
                Dim id As String = String.Empty
                Dim datePosted As String = String.Empty
                Dim tweetBody As String = String.Empty
                Dim url As String = String.Empty
                Dim user As String = String.Empty
                Dim price As String = String.Empty
                For i As Integer = 1 To tableRows.Count
                    ' find values
                    id = (form.SelectSingleNode(String.Format("//table/tbody/tr[{0}]/td[2]/div/a", i)).InnerText.Trim())
                    datePosted = (form.SelectSingleNode(String.Format("//table/tbody/tr[{0}]/td[2]/div/time", i)).InnerText.Trim())
                    tweetBody = form.SelectSingleNode(String.Format("//table/tbody/tr[{0}]/td[3]/div/div[1]", i)).InnerText.Trim()
                    url = form.SelectSingleNode(String.Format("//table/tbody/tr[{0}]/td[3]/div/div[2]/a", i)).InnerText.Trim()
                    user = form.SelectSingleNode(String.Format("//table/tbody/tr[{0}]/td[5]/div/a", i)).InnerText.Trim()
                    price = form.SelectSingleNode(String.Format("//table/tbody/tr[{0}]/td[6]", i)).InnerText.Trim().Replace("&nbsp;&#8399;", String.Empty)
                    ' add to the listview
                    Me.listViewTwitterPosted.BeginUpdate()
                    Dim lv As ListViewItem = Me.listViewTwitterPosted.Items.Add(id)
                    lv.SubItems.Add(url)
                    lv.SubItems.Add(tweetBody)
                    lv.SubItems.Add("@" & user)
                    lv.SubItems.Add(price.Replace("&nbsp;", "").Replace("&#8399;", "").Replace(",", ".").Trim())
                    lv.SubItems.Add(datePosted)
                    Me.listViewTwitterPosted.EndUpdate()
                Next
                formMain.returnMessage(listViewTwitterPosted.Items.Count() & " tweets parsed.")
            Catch ex As Exception
                formMain.returnMessage("No posts parsed, it look like you never posted any tweets.")
            End Try
        End If

    End Sub

End Class