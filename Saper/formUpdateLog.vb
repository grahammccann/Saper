Public Class formUpdateLog

    Private Sub formUpdateLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim updateLog = getURL("http://www.camnevsoftware.com/saper/change.log", formMain.varCookieJar)
        txtBoxUpdates.Text = updateLog
    End Sub

    Private Sub btnCloseUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseUpdates.Click
        Me.Close()
    End Sub
End Class