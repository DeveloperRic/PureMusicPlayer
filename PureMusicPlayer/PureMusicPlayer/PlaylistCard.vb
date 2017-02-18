Public Class PlaylistCard
    Public playlist As Playlist
    Public Sub New(ByRef playlist As Playlist)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.playlist = playlist
        If playlist.tracks.Count > 0 Then
            If playlist.tracks.Count < 4 Then
                Cover1.Image = playlist.tracks(0).AlbumCover
                TableLayout.SetRowSpan(Cover1, 2)
                TableLayout.SetColumnSpan(Cover1, 2)
            Else
                Cover1.Image = playlist.tracks(0).AlbumCover
                Cover2.Image = playlist.tracks(1).AlbumCover
                Cover3.Image = playlist.tracks(2).AlbumCover
                Cover4.Image = playlist.tracks(3).AlbumCover
            End If
        End If
        PlaylistName.ForeColor = ColorTranslator.FromHtml("#ffebee")
        PlaylistName.Text = playlist.name
    End Sub

    Private Sub playPause_Click(sender As Object, e As EventArgs) Handles playPause.Click
        If PurePlayer.queue.playing And PurePlayer.queue.data.type = Queue.QueueType.PLAYLIST Then
            Dim p As Playlist = PurePlayer.queue.data.args(0)
            If p.id = playlist.id Then
                PurePlayer.queue.pause()
                playPause.Image = My.Resources.play_button_hover
                Exit Sub
            End If
        End If
        PurePlayer.queue.stop()
        PurePlayer.queue = New Queue(New Queue.QueueData(Queue.QueueType.PLAYLIST, playlist), playlist.tracks)
        PurePlayer.queue.play(, 0)
        playPause.Image = My.Resources.pause_button_hover
    End Sub

    Private Sub playPause_MouseEnter(sender As Object, e As EventArgs) Handles playPause.MouseEnter
        If PurePlayer.queue.playing And PurePlayer.queue.data.type = Queue.QueueType.PLAYLIST Then
            Dim p As Playlist = PurePlayer.queue.data.args(0)
            If p.id = playlist.id Then
                playPause.Image = My.Resources.pause_button_hover
                Exit Sub
            End If
        End If
        playPause.Image = My.Resources.play_button_hover
    End Sub

    Private Sub playPause_MouseLeave(sender As Object, e As EventArgs) Handles playPause.MouseLeave
        If PurePlayer.queue.playing And PurePlayer.queue.data.type = Queue.QueueType.PLAYLIST Then
            Dim p As Playlist = PurePlayer.queue.data.args(0)
            If p.id = playlist.id Then
                playPause.Image = My.Resources.pause_button
                Exit Sub
            End If
        End If
        playPause.Image = My.Resources.play_button
    End Sub
End Class
