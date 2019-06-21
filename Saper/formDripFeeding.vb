Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports CookComputing.XmlRpc
Imports MySql.Data.MySqlClient

Public Class formDripFeeding
    Private Sub btnHideDripFeed_Click(sender As System.Object, e As System.EventArgs) Handles btnHideDripFeed.Click
        Me.Hide()
    End Sub

    Private Sub btnEnableTimer_Click(sender As System.Object, e As System.EventArgs) Handles btnEnableTimer.Click
        ' validation
        'If (dataGridDripFeed.Rows.Count < 1) Then
        If (lvDripFeed.Items.Count < 1) Then
            formMain.returnMessage("No links have been added to the dripfeed scheduler.")
            Return
        End If
        ' interval
        Dim inValue As Integer
        If (comboBoxDripFeed.SelectedItem.ToString = "1") Then
            ' 1 hour
            inValue = 60000 * 60
        Else
            ' 1 hour
            inValue = CInt(60000 * 60 * CDbl(comboBoxDripFeed.SelectedItem.ToString))
        End If
        Me.btnEnableTimer.Enabled = False
        formProject.timerMain.Interval = inValue
        formProject.timerMain.Start()
        formProject.spanCountDown = New TimeSpan(0, 0, 0, 0, inValue)
        formProject.spanCountDownTemp = New TimeSpan(0, 0, 0, 0, inValue)
        formProject.tmrCountDown.Start()
    End Sub

    Private Sub formDripFeeding_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (MessageBox.Show("Are you sure you want to close? all scheduled links will be lost?", "Saper", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub formDripFeeding_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        comboBoxDripFeed.SelectedIndex = 0
        ' update timer
        'Me.lblTimeNow.Text = DateTime.Now.ToString
    End Sub

    Private Sub btnDeleteDripFeedLink_Click(sender As Object, e As EventArgs) Handles btnDeleteDripFeedLink.Click
        ' loop checked rows and delete
        'For Each row As DataGridViewRow In dataGridDripFeed.Rows
        '    If (row.Cells(8).Value IsNot Nothing) Then
        '        dataGridDripFeed.Rows.Remove(row)
        '    End If
        'Next
        For Each item As ListViewItem In lvDripFeed.Items
            If item.Checked Then
                lvDripFeed.Items.Remove(item)
            End If
        Next
    End Sub
End Class