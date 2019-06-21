Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private AscOrder As Boolean

    Public Sub New()
        col = 0
        AscOrder = True
    End Sub

    Public Sub New(ByVal column As Integer, ByVal Ascending As Boolean)
        col = column
        AscOrder = Ascending
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
        Implements IComparer.Compare
        If AscOrder Then
            Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        Else
            Return [String].Compare(CType(y, ListViewItem).SubItems(col).Text, CType(x, ListViewItem).SubItems(col).Text)
        End If
    End Function
End Class