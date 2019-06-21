Public Class formMozCheck

    Private Sub btnCloseMoz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseMoz.Click
        formProject.btnMozCheck.Enabled = True
        Me.Close()
    End Sub

    Private Sub listViewMoz_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles listViewMoz.ColumnClick
        If (CDbl(e.Column.ToString) = 1) Then
            ' true/false
            Dim blnAscending As Boolean = False
            Me.listViewMoz.ListViewItemSorter = New ListViewItemComparer(e.Column, blnAscending)
        End If
        If (CDbl(e.Column.ToString) = 2) Then
            ' true/false
            Dim blnAscending As Boolean = False
            Me.listViewMoz.ListViewItemSorter = New ListViewItemComparer(e.Column, blnAscending)
        End If
        If (CDbl(e.Column.ToString) = 3) Then
            ' true/false
            Dim blnAscending As Boolean = False
            Me.listViewMoz.ListViewItemSorter = New ListViewItemComparer(e.Column, blnAscending)
        End If
    End Sub

    Private Sub btnBuySelectedLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuySelectedLinks.Click
        For Each itm As ListViewItem In listViewMoz.CheckedItems
            Dim urlCheck As String = String.Empty
            'MessageBox.Show(itm.SubItems(0).Text)
            For Each it As ListViewItem In formProject.listViewShowLinks.Items
                urlCheck = itm.SubItems(0).Text
                If (urlCheck = it.SubItems(1).Text) Then
                    it.Checked = True
                End If
            Next
        Next
    End Sub

    Private Sub formMozCheck_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'If (formProject.lblMysql.Text = "Successfully connected...") Then
        '    btnUpdateMYSQL.Visible = True
        'End If
    End Sub

    Private Sub btnUpdateMYSQL_Click(sender As System.Object, e As System.EventArgs)
        ' validation
        'If (formProject.lblMysql.Text = "Successfully connected...") Then
        '    If (formProject.bgWorker.IsBusy <> True) Then
        '        Me.btnUpdateMYSQL.Enabled = False
        '        formProject.bgWorker.RunWorkerAsync("sape_update_dapa")
        '    End If
        'Else
        '    formMain.returnMessage("You never connected successfully to the MYSQL database!")
        'End If
    End Sub

    Private Sub btnCancelMozCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelMozCheck.Click
        If (formProject.bgWorker.IsBusy = False) Then
            formMain.returnMessage("No threads are currently running!")
            Exit Sub
        Else
            If (formProject.bgWorker.IsBusy) Then
                If (formProject.bgWorker.WorkerSupportsCancellation) Then
                    formProject.bgWorker.CancelAsync()
                End If
            End If
        End If
    End Sub

    Private Sub btnCheckMozRankTrust_Click(sender As Object, e As EventArgs)
        'formMain.returnMessage("This is primarily for the Pro account only!")
        ' validation
        'If (formProject.bgWorker.IsBusy <> True) Then
        '    Me.btnCheckMozRankTrust.Enabled = False
        '    formProject.bgWorker.RunWorkerAsync("sape_update_mtmr")
        'Else
        '    formMain.returnMessage("Please wait untill the current thread is finished.")
        'End If
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For Each itm As ListViewItem In listViewMoz.Items
            itm.Checked = True
        Next
    End Sub

    Private Sub btnSelectNoneLinks_Click(sender As Object, e As EventArgs) Handles btnSelectNoneLinks.Click
        For Each itm As ListViewItem In listViewMoz.Items
            itm.Checked = False
        Next
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        If (formProject.bgWorker.IsBusy <> True) Then
            formProject.bgWorker.RunWorkerAsync("sape_pa_da_check")
        End If
    End Sub
End Class