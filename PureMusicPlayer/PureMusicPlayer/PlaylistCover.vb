Public Class PlaylistCover
    Public playlist As Playlist
    Public Shared Sub display(ByRef playlist As Playlist, ByRef base As Control)
        Dim cover As New PlaylistCover(playlist)
        cover.Dock = DockStyle.Fill
        base.Controls.Clear()
        base.Controls.Add(cover)
    End Sub
    Public Sub New(ByRef playlist As Playlist)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.playlist = playlist
        If playlist.tracks.Count > 0 Then
            If playlist.tracks.Count < 4 Then
                Cover1.Image = playlist.tracks(0).Album.Cover
                TableLayout.SetRowSpan(Cover1, 2)
                TableLayout.SetColumnSpan(Cover1, 2)
            Else
                Cover1.Image = playlist.tracks(0).Album.Cover
                Cover2.Image = playlist.tracks(1).Album.Cover
                Cover3.Image = playlist.tracks(2).Album.Cover
                Cover4.Image = playlist.tracks(3).Album.Cover
            End If
        End If
    End Sub
End Class
