Friend Class MoneyConverter
    ''' <summary>
    ''' Convert rubbles to uk pounds
    ''' </summary>
    ''' <param name="amount">Amount in rubbles</param>
    ''' <returns>Result in pounds</returns>
    ''' <remarks></remarks>
    Public Shared Function RubbleToPounds(ByVal amount As Double) As Double
        Return (amount / _rubblePoundsRate)
    End Function

    ''' <summary>
    ''' Convert rubbles to usd dollars
    ''' </summary>
    ''' <param name="amount">Amount in rubbles</param>
    ''' <returns>Result in dollars</returns>
    ''' <remarks></remarks>
    Public Shared Function RubbleToUsd(ByVal amount As Double) As Double
        Return (amount / _rubbleUsdRate)
    End Function


    ' Properties
    Public Shared Property RubblePoundsRate As Double
        Get
            Return _rubblePoundsRate
        End Get
        Set(ByVal value As Double)
            _rubblePoundsRate = value
        End Set
    End Property

    Public Shared Property RubbleUsdRate As Double
        Get
            Return _rubbleUsdRate
        End Get
        Set(ByVal value As Double)
            _rubbleUsdRate = value
        End Set
    End Property


    ' Example rates, you can always change them to current or else.
    Private Shared _rubblePoundsRate As Double = 71.33
    Private Shared _rubbleUsdRate As Double = 45.39
End Class

