Public Class formPreviewText

    Private Sub formPreviewText_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' navigate and load the file onLoad
        wbMain.Navigate("file:///" & IO.Path.GetFullPath(".\Preview/Preview.html"))
    End Sub
End Class