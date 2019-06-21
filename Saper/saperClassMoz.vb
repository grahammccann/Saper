Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports CookComputing.XmlRpc

Public Class saperClassMoz

    Public Function createSeoMozRequest(ByVal sWebSiteURL As String, ByVal cols As String) As String
        ' USER CREDENTIALS...
        Dim aID As String = ""
        Dim aKY As String = ""
        aID = formSettings.txtBoxAI.Text
        aKY = formSettings.txtBoxKY.Text
        ' EXPIRY DATE...
        'Dim strExpiry As Long = DateDiff("s", DateSerial(1970, 1, 1), Now()) + 300
        Dim add As Double = 15
        Dim tsDuration As TimeSpan = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0))
        ' Add intExpiryHours to the duration
        Dim tsEnd As TimeSpan = TimeSpan.FromMinutes(add)
        tsDuration = tsDuration.Add(tsEnd)
        ' Generate our unix timestamp
        Dim dblUnixTime As Double = tsDuration.TotalSeconds
        ' Remove the decimal parts, we don't need them
        Dim intUnixTime As Integer = CInt(dblUnixTime)
        ' Convert to string for the api request
        Dim strExpiry As String = intUnixTime.ToString()
        ' HASH ENCODE AND SET SIGNATURE...
        Dim encoding As New UTF8Encoding()
        Dim keyByte As Byte() = encoding.GetBytes(aKY)
        Dim messageBytes As Byte() = encoding.GetBytes(aID & vbLf & strExpiry)
        Dim algorithm As New System.Security.Cryptography.HMACSHA1(keyByte)
        Dim hash As Byte() = algorithm.ComputeHash(messageBytes)
        Dim strSignature As String = Convert.ToBase64String(hash)
        Dim finalString = "http://lsapi.seomoz.com/linkscape/url-metrics/" & sWebSiteURL & "?Cols=" & cols & "&AccessID=" & aID & "&Expires=" & strExpiry & "&Signature=" & HttpUtility.UrlEncode(strSignature)
        Dim returnString = getURL(finalString, formMain.varCookieJar)
        Return returnString
    End Function
End Class


