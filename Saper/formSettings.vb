Public Class formSettings

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If (txtBoxAI.Text = "" Or txtBoxKY.Text = "") Then
        '    formMain.returnMessage("You never entered both API key fields!")
        '    Exit Sub
        'Else
        '    ' SAVE THE API KEY
        '    'If (My.Settings.smAID <> "") Then
        '    My.Settings.smAID = txtBoxAI.Text
        '    My.Settings.smKEY = txtBoxKY.Text
        '    My.Settings.Save()
        '    'End If
        'End If
        Me.Hide()
    End Sub

    Private Sub formSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class