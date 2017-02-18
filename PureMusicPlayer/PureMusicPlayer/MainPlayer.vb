Imports System.ComponentModel
Imports System.Runtime.InteropServices
Public Class MainPlayer
    Public loadedTracks As New List(Of String)
    Dim volume As Integer
    Dim exiting As Boolean
    Public AlbumTracksFlow As TrackList
    Public PlaylistTracksFlow As TrackList
    Public Property Queue As Queue
        Get
            Return PurePlayer.queue
        End Get
        Set(value As Queue)
            PurePlayer.queue = value
        End Set
    End Property
    Public Enum MainPlayerPage
        LOAD = 0
        HOME = 1
        QUEUE = 2
        ALBUM = 3
        PLAYLIST = 4
    End Enum
    Public Class MainPlayerPageData
        Public page As MainPlayerPage
        Public args() As Object
        Public Sub New(ByVal page As MainPlayerPage, ParamArray args() As Object)
            Me.page = page
            Me.args = args
        End Sub
    End Class
    Public pageStack As New Stack(Of MainPlayerPageData)
    Public pageCallPosition As Integer
    Public Property CurrentPage As MainPlayerPage
        Get
            Return pageStack(pageCallPosition).page
        End Get
        Set(value As MainPlayerPage)
            MainPlayerPages.SelectedIndex = value
            Dim data As New MainPlayerPageData(value)
            While pageCallPosition > 0
                pageStack.Pop()
                pageCallPosition -= 1
            End While
            pageStack.Push(data)
            updateNavigationButtons()
        End Set
    End Property
    Public Property CurrentPageWithData As MainPlayerPageData
        Get
            Return pageStack(pageCallPosition)
        End Get
        Set(value As MainPlayerPageData)
            MainPlayerPages.SelectedIndex = value.page
            While pageCallPosition > 0
                pageStack.Pop()
                pageCallPosition -= 1
            End While
            pageStack.Push(value)
            updateNavigationButtons()
            moveInPageStack(0)
        End Set
    End Property
    Public Sub moveInPageStack(ByVal shift As Integer)
        pageCallPosition -= shift
        If pageCallPosition < 0 Then
            pageCallPosition = 0
            Exit Sub
        ElseIf pageCallPosition >= pageStack.Count - 1 Then
            pageCallPosition = pageStack.Count - 2
            Exit Sub
        End If
        If CurrentPage = MainPlayerPage.ALBUM Then
            Dim data As MainPlayerPageData = CurrentPageWithData
            Try
                AlbumName.Text = data.args(0)
                AlbumArtists.Text = data.args(1)
                AlbumTracks.Text = data.args(2)
                AlbumCover.Image = data.args(3)
                Dim tracks As List(Of Track) = data.args(4)
                If tracks.Count = 1 Then
                    AlbumLabel.Text = "SINGLE"
                Else
                    AlbumLabel.Text = "ALBUM"
                End If
                AlbumTracksFlow = New TrackList(tracks, AlbumTracksCollection, New Point(0, 0), AlbumTracksCollection.Size, New TrackList.TrackListData(TrackList.TrackListType.ALBUM, data.args(0)))
            Catch ex As Exception
            End Try
        ElseIf CurrentPage = MainPlayerPage.PLAYLIST Then
            Dim playlist As Playlist = CurrentPageWithData.args(0)
            PlaylistName.Text = playlist.name
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
            PlaylistArtists.Text = artists
            PlaylistCreated.Text = playlist.created
            PlaylistCover.display(playlist, PlaylistCoverImage)
            PlaylistTracksFlow = New TrackList(playlist.tracks, PlaylistTracksCollection, New Point(0, 0), PlaylistTracksCollection.Size, New TrackList.TrackListData(TrackList.TrackListType.PLAYLIST, playlist))
        End If
        MainPlayerPages.SelectedIndex = CurrentPage
        updateNavigationButtons()
    End Sub
    Public Sub updateNavigationButtons()
        If pageCallPosition = 0 Then
            tileNextPage.Hide()
        Else
            tileNextPage.Show()
        End If
        If pageCallPosition = pageStack.Count - 2 Then
            tilePrevPage.Hide()
        Else
            tilePrevPage.Show()
        End If
    End Sub
    Public ReadOnly Property CurrentTabPage As TabPage
        Get
            Return MainPlayerPages.TabPages(CurrentPage)
        End Get
    End Property
    Public Function getTabPage(ByVal page As MainPlayerPage) As TabPage
        Return MainPlayerPages.TabPages(page)
    End Function
    Private Sub WelcomeScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        init()
        colourWindows()
        Dim hour As Integer = Date.Now.Hour
        If hour >= 0 And hour < 5 Then
            lblGreeting.Text = "Time for a late night music sesh."
            lblGreeting2.Text = "Let the music roll"
        ElseIf hour >= 5 And hour < 11 Then
            lblGreeting.Text = "Good morning!"
            lblGreeting2.Text = "Time to get your day started"
        ElseIf hour >= 11 And hour < 17 Then
            lblGreeting.Text = "Afternoons are the worst."
            lblGreeting2.Text = "So let's spice it up!"
        ElseIf hour >= 17 And hour <= 23 Then
            lblGreeting.Text = "Good evening!"
        End If
        For Each track As Track In Track.tracks
            loadedTracks.Add(track.SongPath)
        Next
        volume = NPvolume.Value
        MainPlayerPages.Appearance = TabAppearance.FlatButtons
        MainPlayerPages.ItemSize = New Size(0, 1)
        MainPlayerPages.SizeMode = TabSizeMode.Fixed
        StatusStrip.Hide()
    End Sub
    Private Sub WelcomeScreen_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Not maximised Then
            Size = New Size(1228, 705)
        Else
            With Screen.PrimaryScreen.WorkingArea
                SetBounds(.Left, .Top, .Width, .Height)
            End With
        End If
        MainPlayerPages_Resize(Nothing, New EventArgs)
        checkCur(Controls)
        CurrentPage = MainPlayerPage.HOME
        ' New Point(10, 125), New Size(1045, 480)
        HtrackList = New TrackList(Track.trackQueue.tracks, HtracksCollection, New Point(0, 0), HtracksCollection.Size, New TrackList.TrackListData(TrackList.TrackListType.HOME))
        PurePlayer.tileManager = New TileManager(HtilesList)
        PurePlayer.tileManager.addTile(TileManager.TileType.HOME, "Home")
        PurePlayer.tileManager.addTile(TileManager.TileType.IMPORT_TRACKS, "Import Tracks")
        PurePlayer.tileManager.addTile(TileManager.TileType.BLANK, "")
        PurePlayer.tileManager.addTile(TileManager.TileType.DUMMY, "Playlists")
        For Each playlist As Playlist In Playlist.playlists
            PurePlayer.tileManager.addTile(TileManager.TileType.PLAYLIST, playlist.name, playlist)
            HplaylistCardReel.Controls.Add(New PlaylistCard(playlist))
        Next
        PurePlayer.tileManager.addTile(TileManager.TileType.BLANK, "")
        PurePlayer.tileManager.addTile(TileManager.TileType.DUMMY, "Albums")
        Dim albums As New List(Of String)
        For Each t As Track In Track.tracks
            Dim found As Boolean
            For Each album As String In albums
                If t.Album.ToLower = album.ToLower Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                PurePlayer.tileManager.addTile(TileManager.TileType.ALBUM, t.Album, loadAlbumData(t.Album).args)
                albums.Add(t.Album)
            End If
        Next
        If tilesBar.Width < 157 Then
            tilesBar.Width = 157
        End If
        'fadeInControl(tilesBar, True, 255, False, 0.4) <-- Currently Broken, working on fixing
        'fadeInControl(nowPlaying, True, 255, False, 30) <-- //
    End Sub
    Private Sub checkCur(ByVal cs As Control.ControlCollection)
        For Each c As Control In cs
            If c.Cursor = Cursors.Hand And TypeOf c Is FlowLayoutPanel Then
                c.Cursor = Cursors.Default
            End If
            checkCur(c.Controls)
        Next
    End Sub
    Private Sub colourWindows()
        Me.BackColor = ColorTranslator.FromHtml("#171717")
        borderPanel.BackColor = ColorTranslator.FromHtml("#101010") '#050505
        tilesBar.BackColor = ColorTranslator.FromHtml("#101010")
        Dim nowPColor As New CompoundColourSet(nowPlaying, ColorTranslator.FromHtml("#212121"))
        nowPColor.run()
        NPprogress.BackColor = ColorTranslator.FromHtml("#212121")
        NPvolume.BackColor = ColorTranslator.FromHtml("#212121")
        NPprogress.ForeColor = ColorTranslator.FromHtml("#ffebee")
        NPvolume.ForeColor = ColorTranslator.FromHtml("#ffebee")
        NPtrackName.ForeColor = ColorTranslator.FromHtml("#ffebee")
        NPartist.ForeColor = ColorTranslator.FromHtml("#ffebee")
        NPalbumYear.ForeColor = ColorTranslator.FromHtml("#ffebee")
        NPcurTime.ForeColor = ColorTranslator.FromHtml("#ffebee")
        NPmaxTime.ForeColor = ColorTranslator.FromHtml("#ffebee")
        MainPlayerPages.BackColor = ColorTranslator.FromHtml("#171717")
        For Each tabpage As TabPage In MainPlayerPages.TabPages
            tabpage.BackColor = ColorTranslator.FromHtml("#171717")
        Next
        StatusStrip.BackColor = ColorTranslator.FromHtml("#00c853")
        StatusStrip.Items(0).ForeColor = ColorTranslator.FromHtml("#ffebee")
        For Each c As Control In tilesBar.Controls
            c.BackColor = Color.Transparent
            c.Cursor = Cursors.Hand
        Next
        lblGreeting.ForeColor = ColorTranslator.FromHtml("#ffebee")
        lblGreeting2.ForeColor = ColorTranslator.FromHtml("#ffebee")
        lblQueuedTracks.ForeColor = ColorTranslator.FromHtml("#ffebee")
        HtracksCollection.BackColor = ColorTranslator.FromHtml("#191919")
        AlbumName.ForeColor = ColorTranslator.FromHtml("#ffebee")
        AlbumArtists.ForeColor = ColorTranslator.FromHtml("#BFBFBF")
        AlbumTracks.ForeColor = ColorTranslator.FromHtml("#BFBFBF")
        AlbumHeader.BackColor = ColorTranslator.FromHtml("#191919")
        AlbumLabel.ForeColor = ColorTranslator.FromHtml("#757575")
        AlbumPlay.BackColor = ColorTranslator.FromHtml("#00c853")
        PlaylistName.ForeColor = ColorTranslator.FromHtml("#ffebee")
        PlaylistArtists.ForeColor = ColorTranslator.FromHtml("#BFBFBF")
        PlaylistCreated.ForeColor = ColorTranslator.FromHtml("#BFBFBF")
        PlaylistHeader.BackColor = ColorTranslator.FromHtml("#191919")
        PlaylistLabel.ForeColor = ColorTranslator.FromHtml("#757575")
        PlaylistPlay.BackColor = ColorTranslator.FromHtml("#00c853")
        QplayingFrom.ForeColor = ColorTranslator.FromHtml("#757575")
    End Sub
    Public Sub convertLoadedToQueue()
        Queue = New Queue(New Queue.QueueData(Queue.QueueType.BASIC))
        If loadedTracks.Count > 0 Then
            For Each j As String In loadedTracks
                Queue.tracks.Add(Track.getTrack(j))
            Next
            Queue.location = 0
        End If
    End Sub
    Private Sub TabControl1_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MainPlayerPages.DrawItem
        Dim g As Graphics = e.Graphics
        Dim pn As Pen = New Pen(Me.BackColor, 10)  '10 can be increased if you see bit of boarders
        g.DrawRectangle(pn, MainPlayerPages.TabPages(0).Bounds)
    End Sub
    Private Sub homePage_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles homePage.Paint
        Me.MainPlayerPages.Region = New Region(New RectangleF(MainPlayerPages.TabPages(0).Left, MainPlayerPages.TabPages(0).Top, MainPlayerPages.TabPages(0).Width, MainPlayerPages.TabPages(0).Height))
    End Sub
    Private Async Sub fadeInControl(ByVal control As Control, Optional ByVal fadeIn As Boolean = True, Optional ByVal finishAlpha As Integer = 255, Optional ByVal isForeColour As Boolean = False, Optional ByVal speed As Decimal = 1)
        Dim animation As New CompoundFadeAnimation(control, fadeIn, finishAlpha, isForeColour, speed)
        Await Task.Run(AddressOf animation.run)
    End Sub
    Private Sub musicView_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs)
        Dim strFormat As New StringFormat()
        e.DrawBackground()
        e.Graphics.FillRectangle(New SolidBrush(ColorTranslator.FromHtml("#e57373")), e.Bounds)
        Dim headerFont As New Font("Arial", 8, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, New SolidBrush(ColorTranslator.FromHtml("#ffebee")), e.Bounds, strFormat)
    End Sub

    Public Sub stopCurrentTrack()
        If Queue Is Nothing Then
            Exit Sub
        End If
        Queue.stop()
        NPpausePlay.BackgroundImage = My.Resources.play_button
    End Sub
    Public Sub pauseCurrentTrack()
        If Queue Is Nothing Then
            Exit Sub
        End If
        Queue.pause()
        NPpausePlay.BackgroundImage = My.Resources.play_button
    End Sub
    Public Sub resumeCurrentTrack()
        If Queue Is Nothing Then
            Exit Sub
        End If
        Queue.resume()
        NPpausePlay.BackgroundImage = My.Resources.pause_button
    End Sub
    Private Sub WelcomeScreen_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        saveSettings()
        Track.saveTracks()
    End Sub

    Private Sub btnPausePlay_MouseEnter(sender As Object, e As EventArgs) Handles NPpausePlay.MouseEnter
        If Queue Is Nothing Then
            NPpausePlay.BackgroundImage = My.Resources.play_button_hover
            Exit Sub
        End If
        If Queue.tracks.Count = 0 Then
            NPpausePlay.BackgroundImage = My.Resources.play_button_hover
            Exit Sub
        End If
        If Not Queue.playing Then
            NPpausePlay.BackgroundImage = My.Resources.play_button_hover
        Else
            NPpausePlay.BackgroundImage = My.Resources.pause_button_hover
        End If
    End Sub

    Private Sub btnPausePlay_MouseLeave(sender As Object, e As EventArgs) Handles NPpausePlay.MouseLeave
        If Queue Is Nothing Then
            NPpausePlay.BackgroundImage = My.Resources.play_button
            Exit Sub
        End If
        If Queue.tracks.Count = 0 Then
            NPpausePlay.BackgroundImage = My.Resources.play_button_hover
            Exit Sub
        End If
        If Not Queue.playing Then
            NPpausePlay.BackgroundImage = My.Resources.play_button
        Else
            NPpausePlay.BackgroundImage = My.Resources.pause_button
        End If
    End Sub

    Private Sub btnPausePlay_Click(sender As Object, e As EventArgs) Handles NPpausePlay.Click
        If Queue Is Nothing Then
            Queue = New Queue(New Queue.QueueData(Queue.QueueType.BASIC))
            If HtrackList.view.list.Controls.Count > 0 Then
                For j = 0 To HtrackList.view.list.Controls.Count - 2
                    Queue.tracks.Add(Track.getTrack(loadedTracks(j)))
                Next
                Queue.addTrack(Track.getTrack(loadedTracks(HtrackList.view.list.Controls.Count - 1)))
            End If
        Else
            If Queue.tracks.Count = 0 Then
                If HtrackList.view.list.Controls.Count > 0 Then
                    For j = 0 To HtrackList.view.list.Controls.Count - 2
                        Queue.tracks.Add(Track.getTrack(loadedTracks(j)))
                    Next
                    Queue.addTrack(Track.getTrack(loadedTracks(HtrackList.view.list.Controls.Count - 1)))
                End If
            Else
                If Not Queue.playing Then
                    resumeCurrentTrack()
                Else
                    pauseCurrentTrack()
                End If
            End If
        End If
    End Sub
    Dim trackAnim As Animations.TextSlider
    Dim artistAnim As Animations.TextSlider
    Dim albumYAnim As Animations.TextSlider
    Public Sub notifyPlay()
        'Song name animator
        Dim t As Track = Queue.trackPlaying
        If t Is Nothing Then
            Exit Sub
        End If
        If trackAnim IsNot Nothing Then
            trackAnim.enabled = False
        End If
        If t.TrackName.Length <= 17 Then
            trackAnim = Nothing
            NPtrackName.Text = t.TrackName
        Else
            trackAnim = New TextSlider(NPtrackName, t.TrackName)
        End If
        If trackAnim IsNot Nothing Then
            trackAnim.run()
        End If
        'Artist animator
        If artistAnim IsNot Nothing Then
            artistAnim.enabled = False
        End If
        If t.Artist.Length <= 17 Then
            artistAnim = Nothing
            NPartist.Text = t.Artist
        Else
            artistAnim = New TextSlider(NPartist, t.Artist)
        End If
        If artistAnim IsNot Nothing Then
            artistAnim.run()
        End If
        'Album animator
        Dim albumY As String = t.Album & " - " & t.Year
        If albumYAnim IsNot Nothing Then
            albumYAnim.enabled = False
        End If
        If albumY.Length <= 17 Then
            albumYAnim = Nothing
            NPalbumYear.Text = albumY
        Else
            albumYAnim = New TextSlider(NPalbumYear, albumY)
        End If
        If albumYAnim IsNot Nothing Then
            albumYAnim.run()
        End If
        If t.AlbumCover Is Nothing Then
            GetAlbumCover(t)
        End If
        If t.AlbumCover Is Nothing Then
            NPalbumCover.BackgroundImage = My.Resources.album_cover_default
        Else
            NPalbumCover.BackgroundImage = t.AlbumCover
        End If
        NPprogress.Maximum = t.Length
        NPprogress.Value = 0
        Dim time As Integer = t.Length
        Dim min As Integer = Math.Truncate(time / 60)
        Dim rsec As Integer = (time - (60 * min))
        Dim sec As String = rsec.ToString
        If sec.Length > 2 Then
            sec = sec.Substring(0, 2)
        ElseIf sec.Length < 2 Then
            sec = "0" & sec
        End If
        NPmaxTime.Text = min & ":" & sec
        notifyTime()
        NPpausePlay.BackgroundImage = My.Resources.pause_button
    End Sub
    Public Sub notifyTime()
        Dim time = Queue.trackPlaying.Time
        Dim min As Integer = Math.Truncate(time / 60)
        Dim rsec As Integer = (time - (60 * min))
        Dim sec As String = rsec.ToString
        If sec.Length > 2 Then
            sec = sec.Substring(0, 2)
        ElseIf sec.Length < 2 Then
            sec = "0" & sec
        End If
        NPcurTime.Text = min & ":" & sec
        NPprogress.Value = time
    End Sub

    Private Sub NPPrevTrack_MouseEnter(sender As Object, e As EventArgs) Handles NPPrevTrack.MouseEnter
        NPPrevTrack.BackgroundImage = My.Resources.prev_track_button_hover
    End Sub

    Private Sub NPPrevTrack_MouseLeave(sender As Object, e As EventArgs) Handles NPPrevTrack.MouseLeave
        NPPrevTrack.BackgroundImage = My.Resources.prev_track_button
    End Sub

    Private Sub NPNextTrack_MouseEnter(sender As Object, e As EventArgs) Handles NPNextTrack.MouseEnter
        NPNextTrack.BackgroundImage = My.Resources.next_track_button_hover
    End Sub

    Private Sub NPNextTrack_MouseLeave(sender As Object, e As EventArgs) Handles NPNextTrack.MouseLeave
        NPNextTrack.BackgroundImage = My.Resources.next_track_button
    End Sub


    Private Sub NPNextTrack_Click(sender As Object, e As EventArgs) Handles NPNextTrack.Click
        Queue.play(1)
    End Sub

    Private Sub NPrepeat_Click(sender As Object, e As EventArgs) Handles NPrepeat.Click
        If Queue IsNot Nothing Then
            If Queue._repeat Then
                Queue._repeat = False
                NPrepeat.BackgroundImage = My.Resources.repeat_icon_off
            Else
                Queue._repeat = True
                NPrepeat.BackgroundImage = My.Resources.repeat_icon_on
            End If
            notifyQueue()
        End If
    End Sub

    Private Sub NPprogress_Scroll(sender As Object, e As EventArgs) Handles NPprogress.Scroll
        Queue.trackPlaying.Stop()
        Queue.trackPlaying.Time = NPprogress.Value
        Queue.trackPlaying.Play()
        notifyTime()
        Queue.playing = True
        NPpausePlay.BackgroundImage = My.Resources.pause_button
    End Sub

    Private Sub NPPrevTrack_Click(sender As Object, e As EventArgs) Handles NPPrevTrack.Click
        Queue.play(-1)
    End Sub

    Private Sub NPvolume_Scroll(sender As Object, e As EventArgs) Handles NPvolume.Scroll
        Queue.trackPlaying.Volume = NPvolume.Value
    End Sub

    Private Sub closeBox_Click(sender As Object, e As EventArgs) Handles closeBox.Click
        Me.Close()
    End Sub

    Private Sub NPshuffle_Click(sender As Object, e As EventArgs) Handles NPshuffle.Click
        If Queue IsNot Nothing Then
            If Queue.tracks.Count > 0 Then
                Queue.shuffle()
                If Queue._shuffle Then
                    NPshuffle.BackgroundImage = My.Resources.shuffle_icon_off
                    Queue._shuffle = False
                Else
                    NPshuffle.BackgroundImage = My.Resources.shuffle_icon_on
                    Queue._shuffle = True
                End If
            End If
            notifyQueue()
        End If
    End Sub
    Public maximised As Boolean
    Private Sub maximiseBox_Click(sender As Object, e As EventArgs) Handles maximiseBox.Click
        If maximised Then
            Me.Size = New Size(1228, 705)
        Else
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
        End If
        maximised = Not maximised
    End Sub

    Private Sub minimiseBox_Click(sender As Object, e As EventArgs) Handles minimiseBox.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Public Class VolumeControl
        <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
        End Function
        Const WM_APPCOMMAND As UInteger = &H319
        Const APPCOMMAND_VOLUME_UP As UInteger = &HA
        Const APPCOMMAND_VOLUME_DOWN As UInteger = &H9
        Const APPCOMMAND_VOLUME_MUTE As UInteger = &H8
        Public Shared Sub UP()
            SendMessage(MainPlayer.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_UP * &H10000)
        End Sub
        Public Shared Sub DOWN()
            SendMessage(MainPlayer.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_DOWN * &H10000)
        End Sub
        Public Shared Sub MUTE()
            SendMessage(MainPlayer.Handle, WM_APPCOMMAND, &H200EB0, APPCOMMAND_VOLUME_MUTE * &H10000)
        End Sub
    End Class
#Region " Move Form "

    ' [ Move Form ]
    '
    ' // By Elektro 

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles borderPanel.MouseDown  ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles borderPanel.MouseMove  ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
            maximised = False
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles borderPanel.MouseUp  ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub

#End Region
    Private Const HTCAPTION As Integer = 2
    Private Const HTLEFT As Integer = 10
    Private Const HTRIGHT As Integer = 11
    Private Const HTTOP As Integer = 12
    Private Const HTTOPLEFT As Integer = 13
    Private Const HTTOPRIGHT As Integer = 14
    Private Const HTBOTTOM As Integer = 15
    Private Const HTBOTTOMLEFT As Integer = 16
    Private Const HTBOTTOMRIGHT As Integer = 17
    Private Const WM_NCHITTEST As Integer = &H84
    Private borders As New List(Of Component)
    Private Sub instBorders()
        borders.Add(Me)
        borders.Add(Panel7)
        borders.Add(tilesBar)
        borders.Add(nowPlaying)
    End Sub
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_NCHITTEST Then
            Dim pt As New Point(m.LParam.ToInt32)
            pt = Me.PointToClient(pt)
            If pt.X < 5 AndAlso pt.Y < 5 Then
                m.Result = New IntPtr(HTTOPLEFT)
            ElseIf pt.X > (Me.Width - 5) AndAlso pt.Y < 5 Then
                m.Result = New IntPtr(HTTOPRIGHT)
            ElseIf pt.Y < 5 Then
                m.Result = New IntPtr(HTTOP)
            ElseIf pt.X < 5 AndAlso pt.Y > (Me.Height - 5) Then
                m.Result = New IntPtr(HTBOTTOMLEFT)
            ElseIf pt.X > (Me.Width - 5) AndAlso pt.Y > (Me.Height - 5) Then
                m.Result = New IntPtr(HTBOTTOMRIGHT)
            ElseIf pt.Y > (Me.Height - 5) Then
                m.Result = New IntPtr(HTBOTTOM)
            ElseIf pt.X < 5 Then
                m.Result = New IntPtr(HTLEFT)
            ElseIf pt.X > (Me.Width - 5) Then
                m.Result = New IntPtr(HTRIGHT)
            Else
                MyBase.WndProc(m)
            End If
        Else
            MyBase.WndProc(m)
        End If
    End Sub

    Private Sub NPqueue_Click(sender As Object, e As EventArgs) Handles NPqueue.Click
        If Not CurrentPage = MainPlayerPage.QUEUE Then
            CurrentPage = MainPlayerPage.QUEUE
            notifyQueue()
        Else
            moveInPageStack(-1)
        End If
    End Sub
    Public HtrackList As TrackList
    Public QtrackList As TrackList
    Public Sub notifyQueue()
        If CurrentPage = MainPlayerPage.QUEUE Then
            If Queue IsNot Nothing Then
                Dim list As New List(Of Track)
                list = Queue.createQueueList
                If QtrackList Is Nothing Then
                    QtrackList = New TrackList(list, QtracksCollection, New Point(10, 90), New Size(1045, 480), New TrackList.TrackListData(TrackList.TrackListType.QUEUE, Queue))
                Else
                    QtrackList.Tracks = list
                End If
                If Queue._repeat Then
                    QtrackList.addSpecialItem("-- Queue Repeats from here --")
                    For i = 0 To Queue.location
                        QtrackList.addTrack(Queue.tracks(i))
                    Next
                End If
                Dim fromText As String = "PLAYING FROM "
                Try
                    Select Case Queue.data.type
                        Case Queue.QueueType.BASIC
                            fromText += "PURE PLAYER"
                        Case Queue.QueueType.DUMMY
                            fromText += "AN UNKNOWN SOURCE"
                        Case Queue.QueueType.PLAYLIST
                            Dim playlist As Playlist = Queue.data.args(0)
                            fromText += "PLAYLIST - " & playlist.name
                        Case Queue.QueueType.ALBUM
                            fromText += "ALBUM - " & Queue.data.args(0)
                    End Select
                Catch ex As Exception
                    fromText = "COULD NOT DETERMINE PLAYBACK LOCATION"
                End Try
                QplayingFrom.Text = fromText
            End If
        End If
    End Sub

    Private Sub NPqueue_MouseEnter(sender As Object, e As EventArgs) Handles NPqueue.MouseEnter
        NPqueue.BackgroundImage = My.Resources.queue_button_hover
    End Sub

    Private Sub NPqueue_MouseLeave(sender As Object, e As EventArgs) Handles NPqueue.MouseLeave
        NPqueue.BackgroundImage = My.Resources.queue_button
    End Sub
    Public noFocus As Boolean
    Public returnFocus As Form
    Private Sub MainPlayer_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If noFocus Then
            returnFocus.Focus()
        End If
    End Sub

    Private Sub tilePrevPage_MouseEnter(sender As Object, e As EventArgs) Handles tilePrevPage.MouseEnter
        tilePrevPage.BackgroundImage = My.Resources.previous_page_icon_hover
    End Sub

    Private Sub tilePrevPage_MouseLeave(sender As Object, e As EventArgs) Handles tilePrevPage.MouseLeave
        tilePrevPage.BackgroundImage = My.Resources.previous_page_icon
    End Sub

    Private Sub tileNextPage_MouseEnter(sender As Object, e As EventArgs) Handles tileNextPage.MouseEnter
        tileNextPage.BackgroundImage = My.Resources.next_page_icon_hover
    End Sub

    Private Sub tileNextPage_MouseLeave(sender As Object, e As EventArgs) Handles tileNextPage.MouseLeave
        tileNextPage.BackgroundImage = My.Resources.next_page_icon
    End Sub

    Private Sub tilePrevPage_Click(sender As Object, e As EventArgs) Handles tilePrevPage.Click
        moveInPageStack(-1)
    End Sub

    Private Sub tileNextPage_Click(sender As Object, e As EventArgs) Handles tileNextPage.Click
        moveInPageStack(1)
    End Sub

    Private Sub AlbumPlay_Click(sender As Object, e As EventArgs) Handles AlbumPlay.Click
        If CurrentPage = MainPlayerPage.ALBUM Then
            Dim data As MainPlayerPageData = CurrentPageWithData
            If Queue IsNot Nothing Then
                Queue.stop()
            Else
                Queue = New Queue(New Queue.QueueData(Queue.QueueType.ALBUM, data.args(0)))
            End If
            Queue.tracks = data.args(4)
            If Queue.Shuffled Then
                Queue.shuffle(True)
            End If
            Queue.play(, 0)
        End If
    End Sub

    Private Sub PlaylistPlay_Click(sender As Object, e As EventArgs) Handles PlaylistPlay.Click
        If CurrentPage = MainPlayerPage.PLAYLIST Then
            Dim playlist As Playlist = CurrentPageWithData.args(0)
            If Queue IsNot Nothing Then
                Queue.stop()
            Else
                Queue = New Queue(New Queue.QueueData(Queue.QueueType.PLAYLIST, playlist))
            End If
            Queue.tracks = playlist.tracks
            If Queue.Shuffled Then
                Queue.shuffle(True)
            End If
            Queue.play(, 0)
        End If
    End Sub

    Private Sub MainPlayerPages_Resize(sender As Object, e As EventArgs) Handles MainPlayerPages.Resize
        HtracksCollection.Width = homePage.Width
        HtracksCollection.Height = homePage.Height - HtracksCollection.Location.Y
        AlbumTracksCollection.Width = albumPage.Width - 25
        AlbumTracksCollection.Height = albumPage.Height - AlbumTracksCollection.Location.Y
        PlaylistTracksCollection.Width = playlistPage.Width - 25
        PlaylistTracksCollection.Height = playlistPage.Height - PlaylistTracksCollection.Location.Y
        QtracksCollection.Width = queuePage.Width
        QtracksCollection.Height = queuePage.Height - QtracksCollection.Location.Y
    End Sub

    Private Sub MainPlayer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim widthToSet As Integer = Width - tilesBar.Width
        Dim heightToSet As Integer = Height - MainPlayerPages.Location.Y
        MainPlayerPages.Width = widthToSet
        MainPlayerPages.Height = heightToSet
        For Each page As TabPage In MainPlayerPages.TabPages
            page.Width = widthToSet
            page.Height = heightToSet
        Next
    End Sub

    Private Sub tilesBar_Resize(sender As Object, e As EventArgs) Handles tilesBar.Resize
        If PurePlayer.tileManager IsNot Nothing Then
            Dim maxTileWidth As Integer
            For Each tile As Tile In PurePlayer.tileManager.tiles
                If tile.Width > maxTileWidth Then
                    maxTileWidth = tile.Width
                End If
            Next
            tilesBar.Width = maxTileWidth
        End If
    End Sub
End Class
