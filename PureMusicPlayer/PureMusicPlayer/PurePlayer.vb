Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq
Module PurePlayer
    Public appPath As String = Application.StartupPath()
    Public filePath As String = appPath & "\PurePlayer_Files\"
    Public tracksPath As String = filePath & "tracks\"
    Public albumsPath As String = filePath & "albums\"
    Public playlistsPath As String = filePath & "playlists\"
    Public queue As Queue = Nothing
    Public trackLists As New List(Of TrackList)
    Public tileManager As TileManager
    Public Sub init()
        If Not My.Computer.FileSystem.DirectoryExists(appPath & "\PurePlayer_Files") Then
            My.Computer.FileSystem.CreateDirectory(appPath & "\PurePlayer_Files")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(filePath & "tracks") Then
            My.Computer.FileSystem.CreateDirectory(filePath & "tracks")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(filePath & "playlists") Then
            My.Computer.FileSystem.CreateDirectory(filePath & "playlists")
        End If
        If Not My.Computer.FileSystem.DirectoryExists(filePath & "albums") Then
            My.Computer.FileSystem.CreateDirectory(filePath & "albums")
        End If
        If Not My.Computer.FileSystem.FileExists(filePath & "queue.txt") Then
            Dim writer As New StreamWriter(filePath & "queue.txt", False)
            writer.Close()
        End If
        PurePlayerSettings.init()
        MainPlayer.CurrentPage = MainPlayer.MainPlayerPage.LOAD
        loadSettings()
        Album.loadAlbums()
        Track.loadTracks()
        Album.purgeAlbums()
        Dim reader As New StreamReader(filePath & "queue.txt")
        If reader.Peek <> -1 Then
            queue = New Queue(reader)
        Else
            queue = New Queue(New Queue.QueueData(Queue.QueueType.BASIC), Track.trackQueue.tracks)
        End If
        reader.Close()
        Playlist.loadPlaylists()
        AddHandler Application.ApplicationExit, AddressOf OnApplicationExit
    End Sub
    Public Sub saveState()
        saveSettings()
        Track.saveTracks()
        Album.saveAlbums()
    End Sub
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
        Track.saveTracks()
        If queue IsNot Nothing Then
            queue.saveQueue()
        End If
        Playlist.savePlaylists()
    End Sub
    Public Function getTrackInfo(ByRef track As Track) As TrackInfoJSON
        Dim info As New TrackInfoJSON
        Try
            Dim webStream As Stream
            Dim webResponse As String = ""
            Dim req As HttpWebRequest
            Dim res As HttpWebResponse
            Dim query As String = "http://ws.audioscrobbler.com/2.0/?method=track.getInfo&api_key=5c9c499b2bbd2dcd0b871a3518a3c661&artist=" & track.Artist & "&track=" & track.TrackName & "&format=json"
            req = CType(WebRequest.Create(query), HttpWebRequest)
            req.Method = "GET" ' Method of sending HTTP Request(GET/POST)
            res = CType(req.GetResponse(), HttpWebResponse) ' Send Request
            webStream = res.GetResponseStream() ' Get Response

            Dim myreader As New IO.StreamReader(webStream)
            Dim response As String = myreader.ReadToEnd
            myreader.Close()
            webStream.Close()
            Dim json As EasyJSON = EasyJSON.read(response)
            info.artists = json.valuesOf(Of String)("track", "artist", "name")
            info.name = json.valueOf(Of String)("track", "name")
            Try
                Dim published As String = json.valueOf(Of String)("track", "wiki", "published").Replace(",", "").Replace(":", "")
                For Each part As String In published.Split(" ")
                    If part.Length = 4 Then
                        Try
                            Dim testInt As Integer = CInt(part)
                            If testInt > 0 Then
                                info.year = testInt
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            Catch ex As Exception
            End Try
        Catch ex As Exception
            'MsgBox(ex.Message & vbNewLine & "" & vbNewLine & ex.StackTrace)
        End Try
        Return info
    End Function
    Public Function GetAlbumCover(ByRef track As Track, ByRef album As Album, Optional ByRef info As TrackInfoJSON = Nothing) As TrackInfoJSON
        If info Is Nothing Then
            info = New TrackInfoJSON
        End If
        Try
            Dim webStream As Stream
            Dim webResponse As String = ""
            Dim req As HttpWebRequest
            Dim res As HttpWebResponse
            Dim query As String = "http://ws.audioscrobbler.com/2.0/?method=album.search&api_key=5c9c499b2bbd2dcd0b871a3518a3c661&artist=" & track.Artist & "&album=" & album.Name & "&format=json"
            req = CType(WebRequest.Create(query), HttpWebRequest)
            req.Method = "GET" ' Method of sending HTTP Request(GET/POST)
            res = CType(req.GetResponse(), HttpWebResponse) ' Send Request
            webStream = res.GetResponseStream() ' Get Response

            Dim myreader As New IO.StreamReader(webStream)
            Dim response As String = myreader.ReadToEnd
            myreader.Close()
            webStream.Close()
            Dim json As EasyJSON = EasyJSON.read(response)
            info.artists = json.valuesOf(Of String)("track", "artist", "name")
            Dim list As EasyJSON.JSONElement = json.search("results", "albummatches", "album")
            If list.children.Count > 0 Then
                Dim images As EasyJSON.JSONElement = list.children(0).search("image").children(0)
                If images.children.Count > 0 Then
                    Dim imageIndex As Integer
                    If images.children.Count >= 4 Then
                        If internetDownloadQuality = DownloadQuality.Low Or images.children.Count < 6 Then
                            imageIndex = 2
                        ElseIf internetDownloadQuality = DownloadQuality.Medium Or images.children.Count < 8 Then
                            imageIndex = 4
                        Else
                            imageIndex = images.children.Count - 2
                        End If
                    End If
                    Dim url As String = images.children(imageIndex).value
                    Dim savePath As String = albumsPath & album.Name & "\cover.png"
                    Using Client As New WebClient
                        Client.DownloadFile(url, savePath)
                    End Using
                    If My.Computer.FileSystem.FileExists(savePath) Then
                        Dim cover As Image = Image.FromFile(savePath)
                        album.Cover = cover
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message & vbNewLine & "" & vbNewLine & ex.StackTrace)
        End Try
        Return info
    End Function
    Public Function ConvertToJSON(ByVal json As String) As JObject
        Dim ser As JObject = JObject.Parse(json)
        Return ser
    End Function
    Public Function findPlaylist(ByVal name As String) As Playlist
        For Each p As Playlist In Playlist.playlists
            If p.name = name Then
                Return p
            End If
        Next
        Return Nothing
    End Function
    Private notificationQueue As New List(Of Notification)
    Private Class Notification
        Public text As String
        Public lvl As Integer
        Public dur As Integer
        Public Sub New(ByVal text As String, ByVal lvl As Integer, ByVal dur As Integer)
            With Me
                .text = text
                .lvl = lvl
                .dur = dur
            End With
        End Sub
    End Class
    Public Sub sendNotification(ByVal text As String, Optional ByVal lvl As Integer = 1, Optional ByVal dur As Integer = 4)
        notificationQueue.Add(New Notification(text, lvl, dur))
        If notificationQueue.Count = 1 Then
            MainPlayer.StatusStrip.Show()
            processNextNotification()
        End If
    End Sub
    Private Async Sub processNextNotification()
        MainPlayer.Focus()
        Select Case notificationQueue(0).lvl
            Case 1
                MainPlayer.StatusStripLabel.ForeColor = ColorTranslator.FromHtml("#171717")
                MainPlayer.StatusStrip.BackColor = ColorTranslator.FromHtml("#00c853")
            Case 2
                MainPlayer.StatusStripLabel.ForeColor = ColorTranslator.FromHtml("#171717")
                MainPlayer.StatusStrip.BackColor = ColorTranslator.FromHtml("#ffab00")
            Case 3
                MainPlayer.StatusStripLabel.ForeColor = ColorTranslator.FromHtml("#ffebee")
                MainPlayer.StatusStrip.BackColor = ColorTranslator.FromHtml("#d50000")
        End Select
        MainPlayer.StatusStripLabel.Text = notificationQueue(0).text
        Await Task.Delay(notificationQueue(0).dur * 1000)
        notificationQueue.Remove(notificationQueue.Item(0))
        If notificationQueue.Count > 0 Then
            processNextNotification()
        Else
            MainPlayer.StatusStrip.Hide()
        End If
    End Sub

    Public Function loadAlbumData(ByVal name As String) As MainPlayer.MainPlayerPageData
        Dim args As New List(Of Object)
        MainPlayer.AlbumName.Text = name
        args.Add(name)
        Dim tracks As New List(Of Track)
        Dim artists As String = ""
        Dim songs As String = ""
        For Each t As Track In Track.tracks
            If t.Album.Name = name Then
                tracks.Add(t)
                If Not artists.Contains(t.Artist) Then
                    If artists = "" Then
                        artists = t.Artist
                    Else
                        artists += ", " & t.Artist
                    End If
                End If
                If songs = "" Then
                    songs = t.TrackName
                Else
                    songs += ", " & t.TrackName
                End If
            End If
        Next
        MainPlayer.AlbumArtists.Text = artists
        args.Add(artists)
        MainPlayer.AlbumTracks.Text = songs
        args.Add(songs)
        Dim cover As Image = Nothing
        If tracks.Count > 0 Then
            cover = tracks(0).Album.Cover
        End If
        If cover IsNot Nothing Then
            MainPlayer.AlbumCover.Image = cover
        Else
            cover = My.Resources.album_cover_default
            MainPlayer.AlbumCover.Image = My.Resources.album_cover_default
        End If
        args.Add(cover)
        args.Add(tracks)
        Return New MainPlayer.MainPlayerPageData(MainPlayer.MainPlayerPage.ALBUM, args.ToArray)
    End Function

    Public Async Sub delayTask(ByVal delaySeconds As Decimal, ByVal action As Action)
        Await Task.Delay(delaySeconds * 1000)
        Await Task.Run(action)
    End Sub

    Public Async Sub runTasksWithDelay(ByVal preDelaySeconds As Decimal, ByVal delaySeconds As Decimal, ParamArray ByVal actions() As Action)
        Await Task.Delay(preDelaySeconds * 1000)
        For Each action As Action In actions
            Await Task.Run(action)
            Await Task.Delay(delaySeconds * 1000)
        Next
    End Sub
    Public Sub sortGenericList(Of T)(ByRef list As List(Of T), ByVal comparator As Func(Of T, T, Boolean))
        Dim swaps As Integer = 1
        Dim pass As Integer
        While swaps > 0
            swaps = 0
            For i = 0 To list.Count - pass - 1
                If i + 1 < list.Count - pass - 1 Then
                    If comparator(list(i), list(i + 1)) Then
                        Dim temp As T = list(i + 1)
                        list(i + 1) = list(i)
                        list(i) = temp
                        swaps += 1
                    End If
                End If
            Next
            pass += 1
        End While
    End Sub
End Module
