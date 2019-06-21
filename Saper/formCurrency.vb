Public Class formCurrency

    Private Sub btnCheckCurrency_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckCurrency.Click

        If (IsNumeric(txtBoxDecimal.Text.Trim())) Then
            Dim amount As Double = CDbl(txtBoxDecimal.Text.Trim())
            Dim dollars As Double = MoneyConverter.RubbleToUsd(amount)
            MoneyConverter.RubbleUsdRate = saperCurUpdates.GetRubbleRate("USD")
            dollars = MoneyConverter.RubbleToUsd(amount)
            Me.lblDollarCheck.Text = String.Format("{0:0.00} Rubles in USD is: ${1:0.00} Conversion Rate: {2:0.00}.", amount, dollars, MoneyConverter.RubbleUsdRate)

            Dim pounds As Double = MoneyConverter.RubbleToUsd(amount)
            MoneyConverter.RubbleUsdRate = saperCurUpdates.GetRubbleRate("GBP")
            pounds = MoneyConverter.RubbleToPounds(amount)
            Me.lblPoundCheck.Text = String.Format("{0:0.00} Rubles in GBP is: £{1:0.00} Conversion Rate: {2:0.00}.", amount, pounds, MoneyConverter.RubbleUsdRate)
        Else
            formMain.returnMessage("Only numbers can be entered!")
            Exit Sub
        End If

    End Sub

    Private Sub formCurrency_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class