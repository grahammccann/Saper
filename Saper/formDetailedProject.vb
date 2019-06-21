Option Strict Off
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

Public Class formDetailedProject

    ' make global
    Dim a As Integer = 0

    Private Sub btnCloseProjectSelection_Click(sender As Object, e As EventArgs) Handles btnCloseProjectSelection.Click
        ' close
        Me.Close()
    End Sub

    Private Sub formDetailedProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSelectProject_Click(sender As Object, e As EventArgs) Handles btnSelectProject.Click
        ' clear previous id's
        formProject.comboBoxSearchLinkID.Items.Clear()
        formProject.comboBoxText.Items.Clear()
        If listViewDetailed.CheckedItems.Count > 0 Then
            For Each itm As ListViewItem In listViewDetailed.CheckedItems
                ' add the ID to the combobox
                If Not (formProject.comboBoxSearchLinkID.Items.Contains(itm.Text)) Then
                    formProject.comboBoxSearchLinkID.Items.Add(itm.Text)
                    formProject.comboBoxSearchLinkID.SelectedIndex = 0
                End If
            Next
            formMain.returnMessage("The ID has been added to the search tab.")
            Me.Close()
        Else
            formMain.returnMessage("No project ID has been selected.")
            Return
        End If
    End Sub

    Private Sub listViewDetailed_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles listViewDetailed.ItemCheck
        ' only check one row at a time
        For Each item In listViewDetailed.Items
            If Not item.Index = e.Index Then item.Checked = False
        Next
    End Sub

    Private Sub listViewDetailed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewDetailed.SelectedIndexChanged

    End Sub
End Class