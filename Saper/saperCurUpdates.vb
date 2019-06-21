Imports System.Globalization

Public Class saperCurUpdates

    ' Methods
    Public Shared Function GetRubbleRate(ByVal code As String) As Double
        Dim str As String = code.ToUpperInvariant
        If Not _isUpdated Then
            UpdateRates()
        End If
        Return ValuteDictionary.Item(str)
    End Function

    Public Shared Sub UpdateRates()
        ' Here can be a problem (exception) if XDocument can't be loaded via xml link.
        Dim root As XElement = XDocument.Load((Link & DateTime.UtcNow.ToString("dd.MM.yyyy"))).Root
        If (root Is Nothing) Then
            Throw New Exception("No root element")
        End If
        Dim items As IEnumerable(Of XElement) = root.Elements("Valute")
        Dim item As XElement
        For Each item In items
            Dim xElement As XElement = item.Element("CharCode")
            If (Not xElement Is Nothing) Then
                Dim key As String = xElement.Value
                xElement = item.Element("Value")
                If (Not xElement Is Nothing) Then
                    Dim num As Double = Double.Parse(xElement.Value.Replace(","c, "."c), CultureInfo.InvariantCulture)
                    If ValuteDictionary.ContainsKey(key) Then
                        ValuteDictionary.Item(key) = num
                    Else
                        ValuteDictionary.Add(key, num)
                    End If
                End If
            End If
        Next
        _isUpdated = True
    End Sub

    ' Fields.
    Private Shared _isUpdated As Boolean
    Private Const Link As String = "http://www.cbr.ru/scripts/XML_daily.asp?date_req="
    Private Shared ReadOnly ValuteDictionary As Dictionary(Of String, Double) = New Dictionary(Of String, Double)

End Class
