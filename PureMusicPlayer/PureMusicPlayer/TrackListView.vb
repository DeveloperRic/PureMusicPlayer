Public Class TrackListView
    Public Sub New()
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _name.ForeColor = ColorTranslator.FromHtml("#8C8C8C")
        _artist.ForeColor = ColorTranslator.FromHtml("#8C8C8C")
        _album.ForeColor = ColorTranslator.FromHtml("#8C8C8C")
        _year.ForeColor = ColorTranslator.FromHtml("#8C8C8C")
        _duration.ForeColor = ColorTranslator.FromHtml("#8C8C8C")
        _separator.BackColor = ColorTranslator.FromHtml("#232323")
        list.HorizontalScroll.Enabled = False
        list.HorizontalScroll.Visible = False
    End Sub
    Const scrollAmount As Integer = 10
    Private Sub scrollUp()
        Dim cur As Integer = list.VerticalScroll.Value
        If cur - scrollAmount < 0 Then
            list.VerticalScroll.Value = 0
        Else
            list.VerticalScroll.Value = cur - scrollAmount
        End If
    End Sub
    Private Sub scrollDown()
        Dim cur As Integer = list.VerticalScroll.Value
        If cur + scrollAmount > list.VerticalScroll.Maximum Then
            list.VerticalScroll.Value = list.VerticalScroll.Maximum
        Else
            list.VerticalScroll.Value = cur + scrollAmount
        End If
    End Sub
    Private Sub notifyPaint()
        If list.HorizontalScroll.Visible Then
            list.HorizontalScroll.Visible = False
        End If
    End Sub

    Private Sub _name_MouseEnter(sender As Object, e As EventArgs) Handles _name.MouseEnter
        _name.Font = New Font(fontRegular.Font, FontStyle.Bold)
    End Sub

    Private Sub _name_MouseLeave(sender As Object, e As EventArgs) Handles _name.MouseLeave
        _name.Font = fontRegular.Font
    End Sub

    Private Sub _artist_MouseEnter(sender As Object, e As EventArgs) Handles _artist.MouseEnter
        _artist.Font = New Font(fontRegular.Font, FontStyle.Bold)
    End Sub

    Private Sub _artist_MouseLeave(sender As Object, e As EventArgs) Handles _artist.MouseLeave
        _artist.Font = fontRegular.Font
    End Sub

    Private Sub _album_MouseEnter(sender As Object, e As EventArgs) Handles _album.MouseEnter
        _album.Font = New Font(fontRegular.Font, FontStyle.Bold)
    End Sub

    Private Sub _album_MouseLeave(sender As Object, e As EventArgs) Handles _album.MouseLeave
        _album.Font = fontRegular.Font
    End Sub

    Private Sub _year_MouseEnter(sender As Object, e As EventArgs) Handles _year.MouseEnter
        _year.Font = New Font(fontRegular.Font, FontStyle.Bold)
    End Sub

    Private Sub _year_MouseLeave(sender As Object, e As EventArgs) Handles _year.MouseLeave
        _year.Font = fontRegular.Font
    End Sub

    Private Sub _duration_MouseEnter(sender As Object, e As EventArgs) Handles _duration.MouseEnter
        _duration.Font = New Font(fontRegular.Font, FontStyle.Bold)
    End Sub

    Private Sub _duration_MouseLeave(sender As Object, e As EventArgs) Handles _duration.MouseLeave
        _duration.Font = fontRegular.Font
    End Sub

    Private Sub TrackListView_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged
        'MsgBox("MP " & (MainPlayer.Width - 202) & vbNewLine & "Ps " & MainPlayer.MainPlayerPages.Width & vbNewLine & "Ht " & MainPlayer.HtracksCollection.Width & vbNewLine & "Ve " & ClientSize.Width & vbNewLine & "Li " & list.Width)
        If list.Controls.Count > 0 Then
            'MsgBox(list.Controls(0).Width)
        End If
        For Each ctrl In list.Controls
            ctrl.Width = list.ClientSize.Width - 20
        Next
    End Sub
End Class
