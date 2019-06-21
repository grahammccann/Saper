Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports CookComputing.XmlRpc

Public Class formCategories

    Private Sub btnSelectCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectCategories.Click
        txtBoxCatPostString.Text = ""
        Dim vals As List(Of String) = New List(Of String)
        Dim sb As StringBuilder = New StringBuilder()
        For Each ci As ListViewItem In listViewCategories.CheckedItems
            Dim splitCats As String() = ci.Text.Split("-"c)
            sb.Append("&s_categories%5B%5D=" + splitCats(0).ToString().Trim())
        Next
        Dim res = sb.ToString()
        txtBoxCatPostString.Text = res
        'formProject.btnLoadCategories.Text = listViewCategories.CheckedItems.Count.ToString
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each itm As ListViewItem In listViewCategories.Items
            itm.Checked = True
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        For Each itm As ListViewItem In listViewCategories.Items
            itm.Checked = False
        Next
    End Sub

    Private Sub formCategories_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim proxy As ISapeXmlRpc = XmlRpcProxyGen.Create(Of ISapeXmlRpc)()
        Dim userId As Integer = proxy.SapeLogin(formMain.txtUser.Text.Trim(), formMain.txtPass.Text.Trim())
        Dim cats As XmlRpcStruct() = proxy.SapeGetCategories()

        If (File.Exists("Cats/Categories.txt")) Then
            Dim objReader As New System.IO.StreamReader("Cats/Categories.txt")
            Do While objReader.Peek() <> -1
                If (userId > 0) Then
                    For Each xmlRpcStruct As XmlRpcStruct In cats
                        Dim str = objReader.ReadLine()
                        Dim splitString As String() = str.Split("-"c)
                        'MessageBox.Show(xmlRpcStruct("id").ToString().Trim() + " - " + splitString(0).Trim())
                        If (xmlRpcStruct("id").ToString().Trim() = splitString(0).Trim()) Then
                            Me.listViewCategories.Items.Add(splitString(0) + " - " + splitString(1).Trim())
                        End If
                    Next
                End If
            Loop
        Else
            For Each xmlRpcStruct As XmlRpcStruct In cats
                Me.listViewCategories.Items.Add(xmlRpcStruct("id").ToString() + " - " + xmlRpcStruct("name").ToString())
            Next
        End If
    End Sub
End Class