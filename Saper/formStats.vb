Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports CookComputing.XmlRpc

Public Class formStats

    Private Sub formStats_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        If (userId > 0) Then
            Try
                Dim userInfo As UserInfo = proxy.SapeGetUser()
                Dim sb As StringBuilder = New StringBuilder()
                gbStats.Text = "Your Sape ID: (" + userId.ToString() + ")"
                For Each s As System.Reflection.PropertyInfo In userInfo.GetType().GetProperties()
                    Dim stringReplaced As String = s.Name.Replace("_", " ")
                    sb.AppendLine(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(stringReplaced) + ": (" + s.GetValue(userInfo, Nothing).ToString() + ")")
                Next
                txtBoxStats.Text = sb.ToString()
            Catch ex As Exception
                formMain.returnMessage("XML-RPC ERROR!" & vbCrLf & vbCrLf & ex.ToString)
            End Try
        End If
    End Sub

    Private Sub btnCloseStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub txtBoxStats_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBoxStats.TextChanged

    End Sub
End Class