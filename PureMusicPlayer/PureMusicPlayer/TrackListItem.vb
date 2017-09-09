Public Class TrackListItem
    Dim dur As Integer
    Dim _fcolour As Color
    Dim _altcolour As Color
    Dim _group As New List(Of TrackListItem)
    Dim base As TrackList
    Public path As String
    Dim index As Integer
    Dim _blank As Boolean
    Shared drag As TrackListItem
    Public Sub New(ByRef base As TrackList, ByVal path As String, ByVal index As Integer, Optional ByVal hidebar As Boolean = False, Optional ByVal specialText As String = "")
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        Me.base = base
        ItemWidth = base.view.ClientSize.Width - 20
        Me.HideBar = hidebar
        Me.path = path
        Me.index = index
        Me.AllowDrop = True
        For Each con As Control In Me.Controls
            If TypeOf con Is PictureBox Then
                Continue For
            ElseIf TypeOf con Is Label Then
                con.ForeColor = ColorTranslator.FromHtml("#ffebee")
            End If
            con.AllowDrop = True
            AddHandler con.MouseEnter, AddressOf handleEnter
            AddHandler con.MouseLeave, AddressOf handleLeave
            AddHandler con.DoubleClick, AddressOf handleDoubleClick
            AddHandler con.MouseDown, AddressOf notifyMouseDown
            AddHandler con.MouseMove, AddressOf checkDrag
            AddHandler con.MouseUp, AddressOf notifyMouseUp
            AddHandler con.DragEnter, AddressOf notifyDrag
            AddHandler con.DragDrop, AddressOf finishDrag
            'AddHandler con.Click, AddressOf handleClick
        Next
        ContextMenuStrip = rightClickMenu
        _separator.BackColor = ColorTranslator.FromHtml("#232323")
        If Not specialText = "" Then
            Blank = True
            _name.Hide()
            _album.Hide()
            _year.Hide()
            _duration.Hide()
            tableLayout.SetColumn(_artist, 1)
            tableLayout.SetColumnSpan(_artist, 4)
            _artist.Dock = DockStyle.Fill
            _artist.TextAlign = ContentAlignment.MiddleCenter
            _artist.Text = specialText
        End If
        If Not base.data.type = TrackList.TrackListType.QUEUE Then
            rightClickMenu.Items(3).Visible = False
        End If
        If Not base.data.type = TrackList.TrackListType.PLAYLIST Then
            rightClickMenu.Items(5).Visible = False
        End If
        If base.data.type = TrackList.TrackListType.ALBUM Then
            rightClickMenu.Items(1).Visible = False
        End If
        Dim i As ToolStripMenuItem = rightClickMenu.Items(4)
        AddHandler i.DropDownItemClicked, AddressOf handleAddToPlaylistClick
        For Each p As Playlist In Playlist.playlists
            Dim j As New ToolStripMenuItem(p.name)
            i.DropDownItems.Add(j)
        Next
    End Sub
    Private Sub _pausePlay_MouseEnter(sender As Object, e As EventArgs) Handles _pausePlay.MouseEnter
        If _blank Then
            Exit Sub
        End If
        If MainPlayer.Queue IsNot Nothing Then
            Dim cur As Track = MainPlayer.Queue.trackPlaying
            If cur IsNot Nothing Then
                If cur.SongPath = path Then
                    If Not cur.IsPaused Then
                        _pausePlay.BackgroundImage = My.Resources.pause_button_hover
                        Exit Sub
                    End If
                End If
            End If
        End If
        _pausePlay.BackgroundImage = My.Resources.play_button_hover
    End Sub

    Private Sub _pausePlay_MouseLeave(sender As Object, e As EventArgs) Handles _pausePlay.MouseLeave
        If _blank Then
            Exit Sub
        End If
        If MainPlayer.Queue IsNot Nothing Then
            Dim cur As Track = MainPlayer.Queue.trackPlaying
            If cur IsNot Nothing Then
                If cur.SongPath = path Then
                    If Not cur.IsPaused Then
                        _pausePlay.BackgroundImage = My.Resources.pause_button
                        Exit Sub
                    End If
                End If
            End If
        End If
        _pausePlay.BackgroundImage = My.Resources.play_button
    End Sub
    Public Sub handleEnter()
        If _blank Then
            Exit Sub
        End If
        Dim pause As Boolean
        If MainPlayer.Queue IsNot Nothing Then
            Dim cur As Track = MainPlayer.Queue.trackPlaying
            If cur IsNot Nothing Then
                If cur.SongPath = path Then
                    If Not cur.IsPaused Then
                        _pausePlay.BackgroundImage = My.Resources.pause_button
                        pause = True
                    End If
                End If
            End If
        End If
        If Not pause Then
            _pausePlay.BackgroundImage = My.Resources.play_button
        End If
        For Each t As TrackListItem In _group
            If t.insideItem Then
                t.handleLeave()
            End If
        Next
        If drag IsNot Nothing Then
            finishDrag()
        End If
        insideItem = True
    End Sub
    Public insideItem
    Public Sub handleLeave()
        Dim p As Point = Me.PointToClient(MousePosition)
        If p.Y > tableLayout.Top And p.Y < (tableLayout.Top + tableLayout.Height) And p.X > tableLayout.Left And p.X < (tableLayout.Left + tableLayout.Width) Then
            Exit Sub
        Else
            _pausePlay.BackgroundImage = Nothing
            insideItem = False
        End If
        If drag Is Me Then
            finishDrag()
        End If
    End Sub

    Public Sub handleDoubleClick()
        If _blank Then
            Exit Sub
        End If
        If base.data.type = TrackList.TrackListType.QUEUE Then
            If PurePlayer.queue.location >= 0 Then
                Dim songLoc As Integer = -999
                For i = 0 To PurePlayer.queue.tracks.Count - 1
                    Dim t As Track = PurePlayer.queue.tracks(i)
                    If t.SongPath = path Then
                        songLoc = i
                        Exit For
                    End If
                Next
                If songLoc >= 0 Then
                    PurePlayer.queue.play(, songLoc, True)
                Else
                    sendNotification("Could not find track in queue :(", 3)
                End If
            Else
                sendNotification("Something wrong happened :/", 2)
            End If
            Else
                Dim tracks As New List(Of Track)
            For i = 0 To index - 1
                Dim t As TrackListItem = base._group(i)
                If t IsNot Me Then
                    tracks.Add(Track.getTrack(t.path))
                End If
            Next
            Dim playLocation As Integer = tracks.Count
            tracks.Add(Track.getTrack(path))
            For i = index + 1 To base._group.Count - 1
                Dim t As TrackListItem = base._group(i)
                If t IsNot Me Then
                    tracks.Add(Track.getTrack(t.path))
                End If
            Next
            MainPlayer.Queue.stop()
            MainPlayer.Queue = New Queue(New Queue.QueueData(base.data.type, base.data.args), tracks)
            MainPlayer.Queue.play(, playLocation,, True)
        End If
    End Sub
    Dim MouseIsDown As Boolean = False
    Private Sub notifyMouseDown()
        MouseIsDown = True
        startLongPressTimer()
    End Sub
    Private Async Sub startLongPressTimer()
        For i = 1 To 3
            Await Task.Delay(1000)
            If Not MouseIsDown Then
                Exit Sub
            End If
        Next
        If MouseIsDown Then
            rightClickMenu.Show(MousePosition)
        End If
    End Sub
    Private Sub notifyMouseUp()
        finishDrag()
        MouseIsDown = False
    End Sub
    Public Sub checkDrag()
        If MouseIsDown Then
            startDrag()
            Exit Sub
        End If
    End Sub
    Public Sub startDrag()
        Blank = True
        drag = Me
        Me.DoDragDrop("", DragDropEffects.Scroll)
        MouseIsDown = False
    End Sub
    Public Sub notifyDrag()
        If drag IsNot Nothing Then
            Dim toIndex As Integer = index
            Dim newgroup As New List(Of TrackListItem)
            newgroup.AddRange(drag.Group)
            For Each g As TrackListItem In newgroup
                If g.index = toIndex Then
                    g.index = drag.index
                    Exit For
                End If
            Next
            drag.index = toIndex
            Dim highest As Integer = drag.base.view.list.Controls.Count - 1
            drag.base.view.list.Controls.Clear()
            newgroup.Add(drag)
            For i = 0 To highest
                For Each g As TrackListItem In newgroup
                    If g.index = i Then
                        drag.base.view.list.Controls.Add(g)
                        g.Group = newgroup
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub
    Public Sub finishDrag()
        Blank = False
        drag = Nothing
        Dim newg As New List(Of TrackListItem)
        newg.Add(Me)
        newg.AddRange(Group)
        Dim newt As New List(Of Track)
        For Each t As TrackListItem In newg
            For Each tr As Track In Track.tracks
                If tr.SongPath = t.path Then
                    newt.Add(tr)
                    Exit For
                End If
            Next
        Next
        Track.trackQueue.location = -1
        Track.trackQueue.tracks = newt
    End Sub

    Private Sub _pausePlay_Click(sender As Object, e As EventArgs) Handles _pausePlay.Click
        If MainPlayer.Queue IsNot Nothing Then
            Dim cur As Track = MainPlayer.Queue.trackPlaying
            If cur IsNot Nothing Then
                If cur.SongPath = path Then
                    If Not cur.IsPaused Then
                        MainPlayer.Queue.pause()
                    Else
                        MainPlayer.Queue.resume()
                    End If
                    Exit Sub
                End If
            End If
        End If
        handleDoubleClick()
    End Sub
#Region "Properties"
    <System.ComponentModel.Category("Appearance")>
    Public Property TrackName() As String
        Get
            Return _name.Text
        End Get
        Set(ByVal Value As String)
            _name.Text = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property Artist() As String
        Get
            Return _artist.Text
        End Get
        Set(ByVal Value As String)
            _artist.Text = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property Album() As String
        Get
            Return _album.Text
        End Get
        Set(ByVal Value As String)
            _album.Text = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property Year() As String
        Get
            Return _year.Text
        End Get
        Set(ByVal Value As String)
            _year.Text = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public WriteOnly Property HideBar() As Boolean
        Set(ByVal Value As Boolean)
            _separator.Visible = Not Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property Duration() As Integer
        Get
            Return dur
        End Get
        Set(ByVal Value As Integer)
            If Value = False And drag IsNot Nothing Then
                Exit Property
            End If
            If Not _blank Then
                Dim min As Integer = Math.Truncate(Value / 60)
                Dim rsec As Integer = (Value - (60 * min))
                Dim sec As String = rsec.ToString
                If sec.Length > 2 Then
                    sec = sec.Substring(0, 2)
                ElseIf sec.Length < 2 Then
                    sec = "0" & sec
                End If
                _duration.Text = min & ":" & sec
            Else
                _duration.Text = ""
            End If
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property TextColour() As Color
        Get
            Return _fcolour
        End Get
        Set(ByVal Value As Color)
            _fcolour = Value
            _name.ForeColor = Value
            _artist.ForeColor = Value
            _album.ForeColor = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property AltColour() As Color
        Get
            Return _altcolour
        End Get
        Set(ByVal Value As Color)
            _altcolour = Value
            _year.ForeColor = Value
            _duration.ForeColor = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property ItemWidth() As Integer
        Get
            Return Me.Width
        End Get
        Set(ByVal Value As Integer)
            Me.Width = Value
        End Set
    End Property
    <System.ComponentModel.Category("Behaviour")>
    Public Property Group() As List(Of TrackListItem)
        Get
            Return _group
        End Get
        Set(value As List(Of TrackListItem))
            Dim v As New List(Of TrackListItem)
            v.AddRange(value)
            If v.Contains(Me) Then
                v.Remove(Me)
            End If
            _group = v
        End Set
    End Property
    <System.ComponentModel.Category("Behaviour")>
    Public Property Blank() As Boolean
        Get
            Return _blank
        End Get
        Set(value As Boolean)
            _blank = value
            If value Then
                _pausePlay.BackgroundImage = Nothing
                TrackName = ""
                Artist = ""
                Album = ""
                Year = ""
                Duration = 0
            Else
                If drag Is Nothing Then
                    Dim org As Track = Track.getTrack(path)
                    TrackName = org.TrackName
                    Artist = org.Artist
                    Album = org.Album.Name
                    Year = org.Album.year
                    Duration = org.Length
                Else
                    Dim org As Track = Track.getTrack(drag.path)
                    drag.TrackName = org.TrackName
                    drag.Artist = org.Artist
                    drag.Album = org.Album.Name
                    drag.Year = org.Album.year
                    drag.Duration = org.Length
                End If
            End If
        End Set
    End Property
#End Region
    Public Sub handleClick(sender As Object, e As MouseEventArgs)
        MouseIsDown = False
        If e.Button = MouseButtons.Right Then
            rightClickMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub rightClickMenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles rightClickMenu.ItemClicked
        rightClickMenu.Hide()
        Select Case e.ClickedItem.Text.ToLower
            Case "play"
                handleDoubleClick()
            Case "edit track info"
                TrackInfo.Show()
                TrackInfo.track = Track.getTrack(path)
                TrackInfo.refreshControls()
            Case "view album"
                MainPlayer.CurrentPageWithData = loadAlbumData(Track.getTrack(path).Album.Name)
            Case "remove from playlist"
                Dim playlist As Playlist = MainPlayer.CurrentPageWithData.args(0)
                playlist.removeTrack(Track.getTrack(path))
        End Select
    End Sub
    Private Sub openPlaylist(ByVal playlist As Playlist)
        Dim args As New List(Of Object)
        args.Add(playlist)
        MainPlayer.PlaylistName.Text = playlist.name
        Dim artists As String = ""
        For Each t As Track In playlist.tracks
            If Not artists.Contains(t.Artist) Then
                If artists = "" Then
                    artists = t.Artist
                Else
                    artists += ", " & t.Artist
                End If
            End If
        Next
        MainPlayer.PlaylistArtists.Text = artists
        MainPlayer.PlaylistCreated.Text = playlist.created
        MainPlayer.PlaylistCoverImage.Controls.Add(New PlaylistCover(playlist))
        Dim data As New MainPlayer.MainPlayerPageData(MainPlayer.MainPlayerPage.PLAYLIST, args.ToArray)
        MainPlayer.CurrentPageWithData = data
        If MainPlayer.PlaylistTracksFlow Is Nothing Then
            MainPlayer.PlaylistTracksFlow = New TrackList(playlist.tracks, MainPlayer.PlaylistTracksCollection, New Point(0, 0), MainPlayer.PlaylistTracksCollection.Size, New TrackList.TrackListData(TrackList.TrackListType.PLAYLIST, playlist))
        Else
            MainPlayer.PlaylistTracksFlow.Tracks = playlist.tracks
        End If
    End Sub

    Private Sub NewPlaylistTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles NewPlaylistTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not NewPlaylistTextBox.Text = "" Then
                rightClickMenu.Hide()
                Dim nt As New List(Of Track)
                nt.Add(Track.getTrack(path))
                Dim playlist As Playlist = Playlist.createPlaylist(NewPlaylistTextBox.Text, nt)
                NewPlaylistTextBox.Text = ""
                openPlaylist(playlist)
                sendNotification("Playlist created!")
            End If
        End If
    End Sub

    Public Sub handleAddToPlaylistClick2()
        sendNotification("Testing...", 1)
        sendNotification("Playlist was not found!", 2)
        sendNotification("Fail!!", 3)
    End Sub

    Public Sub handleAddToPlaylistClick(sender As Object, e As ToolStripItemClickedEventArgs)
        Dim playlist As Playlist = findPlaylist(e.ClickedItem.Text)
        If playlist IsNot Nothing Then
            playlist.tracks.Add(Track.getTrack(path))
            sendNotification("Track successfully added to playlist " & playlist.name)
        Else
            sendNotification("Playlist was not found!", 2)
        End If
    End Sub
End Class
