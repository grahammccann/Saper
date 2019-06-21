Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports CookComputing.XmlRpc

Public Class formZones

    Private Sub btnSelectTLDs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectTLDs.Click
        txtBoxZonesPostString.Text = ""
        Dim sb As StringBuilder = New StringBuilder()
        For Each ci As ListViewItem In listBoxTLDExtensions.CheckedItems
            Dim splitCats As String() = ci.Text.Split("-"c)
            sb.Append("&s_domain_zones%5B%5D=" + splitCats(0).ToString().Trim())
        Next
        Dim res = sb.ToString()
        txtBoxZonesPostString.Text = res
        'formProject.btnLoadTLDs.Text = listBoxTLDExtensions.CheckedItems.Count.ToString
        Me.Hide()
    End Sub

    Private Sub formZones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        Dim zones As XmlRpcStruct() = proxy.SapeGetDomainTLDs()
        If (userId > 0) Then
            For Each xmlRpcStruct As XmlRpcStruct In zones
                Me.listBoxTLDExtensions.Items.Add(xmlRpcStruct("id").ToString() + " - " + xmlRpcStruct("zone").ToString())
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each itm As ListViewItem In listBoxTLDExtensions.Items
            itm.Checked = True
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each itm As ListViewItem In listBoxTLDExtensions.Items
            itm.Checked = False
        Next
    End Sub
End Class