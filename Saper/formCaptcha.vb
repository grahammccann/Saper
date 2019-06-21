Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports CookComputing.XmlRpc

Public Class formCaptcha

    Private Sub formCaptcha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.picBoxCaptcha.Load("https://auth.sape.ru/captcha.png")
    End Sub

    Private Sub btnSubmitCaptcha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmitCaptcha.Click
        If (txtBoxCaptchaReply.Text = "") Then
            formMain.returnMessage("You never entered the captcha!")
            Exit Sub
        End If
        Dim H = saperFunctions.postURL("https://auth.sape.ru/login/", "username=" & formMain.txtUser.Text.Trim() & "&password=" & formMain.txtPass.Text.Trim() & "&checkCode=" + Me.txtBoxCaptchaReply.Text.Trim() + "&__checkbox_bindip=true", formMain.varCookieJar)
        If (H.Contains("Ошибка сервера")) Then
            formMain.returnMessage("Sape is reporting a server issue, wait 20 minutes until the captcha message disappears then login again.")
            Me.Close()
            Exit Sub
        End If
        If (H.Contains("/?act=logout")) Then
            Dim stringReplaced As String = String.Empty
            Dim balanceHTML = saperFunctions.getURL("http://widget.sape.ru/balance/?alt=html&tpl=balance_main&container_id=balance_widget_src&charset=windows-1251", formMain.varCookieJar)
            Dim token As Match = Regex.Match(balanceHTML, "<td colspan=""2"">        <b>            (.*?)        </b>    </td>", RegexOptions.IgnoreCase)
            If (token.Success) Then
                stringReplaced = token.Groups(1).Value.Trim().Replace(",", ".")
                formMain.lblLoginStatus.Text = "$" & stringReplaced
                formMain.lblLoginStatus.ForeColor = Color.Green
                Me.Close()
            Else
                formMain.lblLoginStatus.Text = "Error..."
                formMain.lblLoginStatus.ForeColor = Color.Red
            End If
            formMain.btnLogin.Enabled = False
            formMain.radioXMLRPC.Checked = True
            Dim projectHTML = saperFunctions.getURL("http://www.sape.ru/projects.php", formMain.varCookieJar)
            Dim projectFlag = saperFunctions.returnProjects(projectHTML)
            ' Enough money in sape?
            If (stringReplaced.ToString = "0.00") Then
                MessageBox.Show("You don't have any funds in Sape, you must top up your account before you can go to work.", "Saper", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            ' First time setup.
            If (formMain.dataGridProjects.Rows.Count < 1) Then
                formMain.btnFirstTimeSetup.Visible = True
            End If
        Else

        End If
    End Sub

End Class