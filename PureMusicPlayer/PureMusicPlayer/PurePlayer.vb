Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Module PurePlayer
    Public appPath As String = Application.StartupPath()
    Public filePath As String = appPath & "\PurePlayer_Files\"
    Public tracksPath As String = filePath & "tracks\"
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
        If Not My.Computer.FileSystem.FileExists(filePath & "settings.txt") Then
            Dim writer As New StreamWriter(filePath & "settings.txt", False)
            writer.Close()
        End If
        If Not My.Computer.FileSystem.FileExists(filePath & "queue.txt") Then
            Dim writer As New StreamWriter(filePath & "queue.txt", False)
            writer.Close()
        End If
        MainPlayer.CurrentPage = MainPlayer.MainPlayerPage.LOAD
        loadSettings()
        Track.loadTracks()
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
    Private Sub loadSettings()
        Using reader As New StreamReader(filePath & "settings.txt")
            While reader.Peek <> -1
                Dim line As String = reader.ReadLine
                Select Case line.Split(":")(0)
                    Case "maximised"
                        Dim value As Boolean = line.Split(":")(1)
                        MainPlayer.maximised = value
                        If Not value Then
                            MainPlayer.Size = New Size(1228, 705)
                        Else
                            With Screen.PrimaryScreen.WorkingArea
                                MainPlayer.SetBounds(.Left, .Top, .Width, .Height)
                            End With
                        End If
                End Select
            End While
        End Using
    End Sub
    Public Sub saveSettings()
        Using writer As New StreamWriter(filePath & "settings.txt", False)
            writer.WriteLine("maximised:" & MainPlayer.maximised)
        End Using
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
            'Dim json As JObject = ConvertToJSON(myreader.ReadToEnd)
            Dim json As JObject = ConvertToJSON(myreader.ReadToEnd)
            myreader.Close()
            webStream.Close()
            Dim data As List(Of JToken) = json.Children().ToList
            iterateForTrack(info, data, False)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & "" & vbNewLine & ex.StackTrace)
        End Try
        Return info
    End Function
    Private Sub iterateForTrack(ByRef info As TrackInfoJSON, ByRef data As List(Of JToken), ByVal passedTopLevel As Boolean)
        For Each item As JToken In data
            item.CreateReader()
            If TypeOf item Is JProperty Then
                Dim prop As JProperty = item
                Static prev As String
                prev = prop.Name
                Select Case prop.Name
                    Case "album"
                        If info.album = "" Then
                            info.album = prop.Value.ToString.Trim
                        End If
                        passedTopLevel = True
                    Case "name"
                        If info.name = "" Then
                            info.name = prop.Value.ToString.Trim
                        End If
                        passedTopLevel = True
                    Case "artist"
                        For Each itemA As JToken In item.Children.ToList
                            For Each itemB As JToken In itemA.Children.ToList
                                If TypeOf itemB Is JProperty Then
                                    Dim itemBprop As JProperty = itemB
                                    info.artists.Add(itemBprop.Value.ToString.Trim)
                                    Exit For
                                End If
                            Next
                        Next
                        passedTopLevel = True
                    Case "published"
                        If info.year = "" Then
                            Dim parts As String() = prop.Value.ToString.Trim.Split(" ")
                            info.year = parts(2)
                        End If
                        passedTopLevel = True
                End Select
            End If
            If Not passedTopLevel Then
                iterateForTrack(info, item.Children.ToList, False)
            End If
        Next
    End Sub
    Public Function GetAlbumCover(ByRef track As Track, Optional ByRef info As TrackInfoJSON = Nothing) As TrackInfoJSON
        If info Is Nothing Then
            info = New TrackInfoJSON
        End If
        Dim inuse As Boolean = True
        If inuse Then
            Try
                Dim webStream As Stream
                Dim webResponse As String = ""
                Dim req As HttpWebRequest
                Dim res As HttpWebResponse
                Dim query As String = "http://ws.audioscrobbler.com/2.0/?method=album.search&api_key=5c9c499b2bbd2dcd0b871a3518a3c661&artist=" & track.Artist & "&album=" & track.Album & "&format=json"
                req = CType(WebRequest.Create(query), HttpWebRequest)
                req.Method = "GET" ' Method of sending HTTP Request(GET/POST)
                res = CType(req.GetResponse(), HttpWebResponse) ' Send Request
                webStream = res.GetResponseStream() ' Get Response

                Dim myreader As New IO.StreamReader(webStream)
                Dim str As String = myreader.ReadToEnd
                myreader.Close()
                webStream.Close()
                Dim json As JObject = ConvertToJSON(str)
                Dim data As List(Of JToken) = json.Children().ToList
                iterateForAlbumCover(track, info, data, False)
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & "" & vbNewLine & ex.StackTrace)
            End Try
        End If
        Return info
    End Function
    Private Sub iterateForAlbumCover(ByRef track As Track, ByRef info As TrackInfoJSON, ByRef data As List(Of JToken), ByVal passedTopLevel As Boolean)
        For Each item As JToken In data
            item.CreateReader()
            If TypeOf item Is JProperty Then
                Dim prop As JProperty = item
                Static prev As String
                prev = prop.Name
                Select Case prop.Name
                    Case "image"
                        If info.cover Is Nothing Then
                            For Each itemA As JToken In item.Children.ToList
                                Dim array As JArray = JsonConvert.DeserializeObject(itemA.ToString)
                                Dim totalIndex As Integer = itemA.Children.ToList.Count
                                Dim itemBindex As Integer
                                For Each itemB As JToken In array
                                    For Each itemC As JToken In itemB.Children.ToList
                                        If TypeOf itemC Is JProperty Then
                                            Dim itemCprop As JProperty = itemC
                                            If itemCprop.Name = "#text" Then
                                                itemBindex += 1
                                                If itemBindex >= totalIndex Then
                                                    Try
                                                        Dim url As String = itemCprop.Value.ToString
                                                        Dim savePath As String = track.Dir & "cover.png"
                                                        Using Client As New WebClient
                                                            If track.AlbumCover IsNot Nothing Then
                                                                track.AlbumCover.Dispose()
                                                            End If
                                                            Client.DownloadFile(url, savePath)
                                                        End Using
                                                        If My.Computer.FileSystem.FileExists(savePath) Then
                                                            info.cover = Image.FromFile(savePath)
                                                        End If
                                                    Catch ex As Exception
                                                    End Try
                                                End If
                                            End If
                                        End If
                                    Next
                                Next
                                Exit For
                            Next
                        End If
                        passedTopLevel = True
                End Select
            End If
            If Not passedTopLevel Then
                iterateForAlbumCover(track, info, item.Children.ToList, False)
            End If
        Next
    End Sub
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
    Public Sub sendNotification(ByVal text As String, Optional ByVal lvl As Integer = 1, Optional ByVal dur As Integer = 2)
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
                MainPlayer.StatusStrip.BackColor = ColorTranslator.FromHtml("#00c853")
            Case 2
                MainPlayer.StatusStrip.BackColor = ColorTranslator.FromHtml("#ffab00")
            Case 3
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
            If t.Album.ToLower = name.ToLower Then
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
            cover = tracks(0).AlbumCover
            For Each t As Track In tracks
                If t.AlbumCover Is Nothing Then
                    Continue For
                End If
                If cover Is Nothing Then
                    cover = t.AlbumCover
                    Continue For
                End If
                If t.AlbumCover.Width > cover.Width Or t.AlbumCover.Height > cover.Height Then
                    cover = t.AlbumCover
                End If
            Next
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
End Module
