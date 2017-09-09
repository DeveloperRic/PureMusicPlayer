Public Class SuggestionCard
    Public Sub New(Optional ByRef album As Album = Nothing, Optional ByRef track As Track = Nothing)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.album = album
        Me.track = track
        PlayName.ForeColor = ColorTranslator.FromHtml("#ffebee")
        lblCardType.ForeColor = ColorTranslator.FromHtml("#ffebee")
        If Title.Length <= 15 Then
            PlayName.Text = Title
        Else
            PlayName.Text = Title.Substring(0, 12) + "..."
        End If
        Dim cover As Image
        If album IsNot Nothing Then
            If album.Cover IsNot Nothing Then
                cover = album.Cover
            Else
                cover = My.Resources.album_cover_default
            End If
            lblCardType.Text = "Album"
        Else
            If track.Album.Cover IsNot Nothing Then
                cover = track.Album.Cover
            Else
                cover = My.Resources.album_cover_default
            End If
            lblCardType.Text = "Track"
        End If
        albumCoverBox.BackgroundImage = cover
        BackColor = ColorTranslator.FromHtml("#212121")
    End Sub

    Private album As Album
    Private track As Track

    Public ReadOnly Property Title() As String
        Get
            If album IsNot Nothing Then
                Return album.Name
            Else
                Return track.TrackName
            End If
        End Get
    End Property

    Private ReadOnly Property QueueType As Queue.QueueType
        Get
            If album IsNot Nothing Then
                Return Queue.QueueType.ALBUM
            Else
                Return Queue.QueueType.BASIC
            End If
        End Get
    End Property

    Public Property PlayCount() As Integer
        Get
            If album IsNot Nothing Then
                Return album.PlayCount
            Else
                Return track.PlayCount
            End If
        End Get
        Set(ByVal value As Integer)
            If album IsNot Nothing Then
                album.PlayCount = value
            Else
                track.PlayCount = value
            End If
        End Set
    End Property

    Private Sub playPause_Click(sender As Object, e As EventArgs) Handles playPause.Click
        If PurePlayer.queue.playing And PurePlayer.queue.data.type = QueueType Then
            If album IsNot Nothing Then
                Dim a As Album = Album.findAlbumWithoutEdit(PurePlayer.queue.data.args(0))
                If a IsNot Nothing Then
                    If a.Name = album.Name Then
                        PurePlayer.queue.pause()
                        playPause.Image = My.Resources.play_button_hover
                        Exit Sub
                    End If
                End If
            Else
                Dim t As Track = PurePlayer.queue.trackPlaying
                If t IsNot Nothing Then
                    If t.Dir = track.Dir Then
                        PurePlayer.queue.pause()
                        playPause.Image = My.Resources.play_button_hover
                        Exit Sub
                    End If
                End If
            End If
        End If
        PurePlayer.queue.stop()
        If album IsNot Nothing Then
            PurePlayer.queue = New Queue(New Queue.QueueData(QueueType, album.Name), album.tracks)
        Else
            Dim tracks As New List(Of Track)
            tracks.Add(track)
            For Each t As Track In Track.tracks
                If t.Dir <> track.Dir Then
                    tracks.Add(t)
                End If
            Next
            PurePlayer.queue = New Queue(New Queue.QueueData(QueueType, track.Dir), tracks)
        End If
        If PurePlayer.queue.Shuffled Then
            PurePlayer.queue.shuffle()
        End If
        PurePlayer.queue.play(, 0,, True)
        PlayCount += 1
        playPause.Image = My.Resources.pause_button_hover
    End Sub

    Private Sub playPause_MouseEnter(sender As Object, e As EventArgs) Handles playPause.MouseEnter
        If PurePlayer.queue.playing And PurePlayer.queue.data.type = QueueType Then
            If album IsNot Nothing Then
                Dim a As Album = Album.findAlbumWithoutEdit(PurePlayer.queue.data.args(0))
                If a IsNot Nothing Then
                    If a.Name = album.Name Then
                        playPause.Image = My.Resources.pause_button_hover
                        Exit Sub
                    End If
                End If
            Else
                Dim t As Track = PurePlayer.queue.trackPlaying
                If t IsNot Nothing Then
                    If t.Dir = track.Dir Then
                        playPause.Image = My.Resources.pause_button_hover
                        Exit Sub
                    End If
                End If
            End If
        End If
        playPause.Image = My.Resources.play_button_hover
    End Sub

    Private Sub playPause_MouseLeave(sender As Object, e As EventArgs) Handles playPause.MouseLeave
        If PurePlayer.queue.playing And PurePlayer.queue.data.type = QueueType Then
            If album IsNot Nothing Then
                Dim a As Album = Album.findAlbumWithoutEdit(PurePlayer.queue.data.args(0))
                If a IsNot Nothing Then
                    If a.Name = album.Name Then
                        playPause.Image = My.Resources.pause_button
                        Exit Sub
                    End If
                End If
            Else
                Dim t As Track = PurePlayer.queue.trackPlaying
                If t IsNot Nothing Then
                    If t.Dir = track.Dir Then
                        playPause.Image = My.Resources.pause_button
                        Exit Sub
                    End If
                End If
            End If
        End If
        playPause.Image = My.Resources.play_button
    End Sub
End Class
