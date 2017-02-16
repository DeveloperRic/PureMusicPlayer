Imports System.IO
Public Class Track
    Public Shared tracks As New List(Of Track)
    Public Shared trackQueue As Queue
    Private Shared Sub purgeTracks()
        Dim inuse As Boolean = True
        If Not inuse Then
            Exit Sub
        End If
        Dim dirs As DirectoryInfo() = My.Computer.FileSystem.GetDirectoryInfo(filePath & "\tracks").GetDirectories.ToArray
        For Each dir As DirectoryInfo In dirs
            For Each file As FileInfo In dir.GetFiles
                file.Delete()
            Next
            dir.Delete()
        Next
        My.Computer.FileSystem.GetDirectoryInfo(filePath & "\tracks").Delete()
        My.Computer.FileSystem.CreateDirectory(filePath & "\tracks")
    End Sub
    Public Shared Sub loadTracks()
        If trackQueue IsNot Nothing Then
            trackQueue.stop()
        End If
        If MainPlayer.Queue IsNot Nothing Then
            MainPlayer.Queue.stop()
        End If
        tracks.Clear()
        'purgeTracks()
        For Each dir As DirectoryInfo In My.Computer.FileSystem.GetDirectoryInfo(filePath & "\tracks").GetDirectories.ToArray
            instTrack(dir.FullName)
        Next
        trackQueue = New Queue(New Queue.QueueData(Queue.QueueType.DUMMY))
        trackQueue.tracks = tracks
    End Sub
    Public Shared Sub saveTracks()
        Dim dirnames As New List(Of String)
        For Each t As Track In tracks
            Dim dir As String = t.Dir
            dirnames.Add(dir.Substring(0, dir.Length - 1))
        Next
        Dim dirs As DirectoryInfo() = My.Computer.FileSystem.GetDirectoryInfo(filePath & "\tracks").GetDirectories.ToArray
        For Each dir As DirectoryInfo In dirs
            If Not dirnames.Contains(dir.FullName) Then
                For Each file As FileInfo In dir.GetFiles
                    file.Delete()
                Next
                dir.Delete()
            End If
        Next
        For Each dirName As String In dirnames
            If Not My.Computer.FileSystem.DirectoryExists(dirName) Then
                My.Computer.FileSystem.CreateDirectory(dirName)
            End If
        Next
        For Each t As Track In tracks
            saveSingleTrack(t)
        Next
    End Sub
    Public Shared Sub saveSingleTrack(ByRef t As Track)
        Try
            Dim writer As New StreamWriter(t.Dir & "settings.txt", False)
            writer.WriteLine("songPath:" & t.SongPath.Replace(":", "?"))
            writer.WriteLine("trackName:" & t.TrackName)
            writer.WriteLine("artist:" & t.Artist)
            writer.WriteLine("album:" & t.Album)
            writer.WriteLine("type:" & t.Type)
            writer.WriteLine("year:" & t.Year)
            writer.WriteLine("length:" & t.Length)
            writer.Close()
            If t.AlbumCover IsNot Nothing Then
                t.AlbumCover.Save(t.Dir & "cover.png")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Shared Function firstInstTrack(ByVal path As String) As Track
        Try
            Dim fs As FileStream = New FileStream(path, FileMode.Open)
            'Seek to the Last 128 bytes
            fs.Seek(-128, SeekOrigin.End)
            Dim TagBytes(2) As Byte
            fs.Read(TagBytes, 0, 3)
            'Get the Tag
            Dim tag As String = System.Text.Encoding.Default.GetString(TagBytes)

            Dim dirs() As String = path.Split("\")
            Dim album As String = "Unknown"
            If dirs.Count >= 3 Then
                album = dirs(UBound(dirs) - 1)
            End If
            Dim song As New Track
            If (tag.ToUpper().Equals("TAG")) Then
                'Get the title of this song.
                Dim TitleBytes(30) As Byte
                fs.Read(TitleBytes, 0, 30)
                Dim Title As String = System.Text.Encoding.Default.GetString(TitleBytes)
                'Get the Artist of this song.
                Dim ArtistBytes(30) As Byte
                fs.Read(ArtistBytes, 0, 30)
                Dim Artist As String = System.Text.Encoding.Default.GetString(ArtistBytes)
                'Construct Mp3Song object.
                With song
                    ._orgPath = path
                    .TrackName = Title
                    .Artist = Artist
                    .Album = album
                    .Type = Right(path, 3)
                    .Year = DateTime.Now.Year
                End With
            Else
                Dim name As String = dirs(UBound(dirs)).Replace(path.Substring(path.LastIndexOf(".")), "")
                Dim artist As String = ""
                If name.Contains("-") Then
                    If name.Split("-").Count = 2 Then
                        artist = name.Split("-")(1).Trim
                        name = name.Split("-")(0).Trim
                    End If
                End If
                With song
                    ._orgPath = path
                    .TrackName = name
                    If Not artist = "" Then
                        .Artist = artist
                    End If
                    .Album = album
                    .Type = Right(path, 3)
                    .Year = DateTime.Now.Year
                End With
            End If
            fs.Close()
            With song
                ._dir = tracksPath & My.Computer.FileSystem.GetDirectoryInfo(filePath & "\tracks").GetDirectories.Count & "\"
            End With
            tryDownloadInfo(song)
            tracks.Add(song)
            trackQueue.tracks.Add(song)
            Return song
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Private Shared Function instTrack(ByVal dir As String) As Track
        Try
            Dim song As New Track
            If Not My.Computer.FileSystem.DirectoryExists(dir) Then
                My.Computer.FileSystem.CreateDirectory(dir)
            End If
            Dim settings As Dictionary(Of String, String) = loadSettings(dir)
            Dim download As Boolean
            With song
                ._dir = dir & "\"
                ._songPath = settings("songPath").Replace("?", ":")
                .TrackName = settings("trackName")
                .Artist = settings("artist")
                .Album = settings("album")
                .Type = settings("type")
                .Year = settings("year")
                ._length = CInt(settings("length"))
                If My.Computer.FileSystem.FileExists(dir & "\cover.png") Then
                    .AlbumCover = Image.FromFile(dir & "\cover.png")
                Else
                    download = True
                End If
            End With
            If download Then
                tryDownloadInfo(song)
            End If
            tracks.Add(song)
            Return song
        Catch ex As Exception
        End Try
        Return Nothing
    End Function
    Public Shared Sub tryDownloadInfo(ByRef song As Track)
        Dim result As TrackInfoJSON = getTrackInfo(song)
        If Not result.name = "" Then
            song.TrackName = result.name
        End If
        If Not result.album = "" Then
            song.Album = result.album
        End If
        If Not result.artists.Count = 0 Then
            Dim s As String = ""
            For Each a As String In result.artists
                If s = "" Then
                    s += a
                Else
                    s += ", " & a
                End If
            Next
            song.Artist = s
        End If
        If Not result.year = "" Then
            song.Year = result.year
        End If
        GetAlbumCover(song, result)
        If Not result.cover Is Nothing Then
            song.AlbumCover = result.cover
        End If
    End Sub
    Public Sub New()
        timer.Enabled = False
        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf trackTick
    End Sub
    Public Shared Function getTrack(ByVal path As String) As Track
        For Each track As Track In tracks
            If track.SongPath = path Then
                Return track
            End If
        Next
        Return Nothing
    End Function
    Public Shared Function createTrack(ByVal path As String) As Track
        Dim track As Track = firstInstTrack(path)
        track._dir = tracksPath & My.Computer.FileSystem.GetDirectoryInfo(filePath & "\tracks").GetDirectories.Count & "\"
        My.Computer.FileSystem.CreateDirectory(track.Dir)
        track._songPath = track.Dir & "track." & track.Type
        My.Computer.FileSystem.CopyFile(path, track.SongPath, True)
        track.Play()
        track._length = track.Milleseconds / 1000
        track.Stop()
        track.Close()
        saveSingleTrack(track)
        Return track
    End Function
    Public Function createArray() As String()
        Dim duration As String = "-"
        Try
            Dim min As Integer = Math.Truncate(Length / 60)
            Dim rsec As Integer = (Length - (60 * min))
            Dim sec As String = rsec.ToString
            If sec.Length > 2 Then
                sec = sec.Substring(0, 2)
            ElseIf sec.Length < 2 Then
                sec = "0" & sec
            End If
            duration = min & ":" & sec
        Catch ex As Exception
        End Try
        Return New String() {_trackName, _artist, _album, _year, duration}
    End Function
    Private Shared Function loadSettings(ByVal dir As String) As Dictionary(Of String, String)
        Dim s As New Dictionary(Of String, String)
        Dim reader As New StreamReader(dir & "\settings.txt")
        While reader.Peek <> -1
            Try
                Dim e As String() = reader.ReadLine.Split(":")
                s.Add(e(0), e(1))
            Catch ex As Exception
            End Try
        End While
        reader.Close()
        Return s
    End Function
    Private Sub trackTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _time += 1000
        If Not _time > _length * 1000 Then
            MainPlayer.notifyTime()
        Else
            MainPlayer.Queue.addTrack(Nothing, 1)
        End If
    End Sub
    Private _artist As String
    Private _trackName As String
    Private _orgPath As String
    Private _songPath As String
    Private _dir As String
    Private _album As String
    Private _albumCover As Image
    Private _type As String
    Private _year As Integer
    Private _time As Integer
    Private _volume As Integer
    Private timer As New Timer
    Private _length As Decimal
    'Artist
    Public Property Artist() As String
        Get
            Return _artist
        End Get
        Set(ByVal value As String)
            Me._artist = value
        End Set
    End Property
    'Song title
    Public Property TrackName() As String
        Get
            Return _trackName
        End Get
        Set(ByVal value As String)
            Me._trackName = value
        End Set
    End Property
    'song path
    Public ReadOnly Property OrgPath() As String
        Get
            Return _orgPath
        End Get
    End Property
    Public ReadOnly Property SongPath() As String
        Get
            Return _songPath
        End Get
    End Property
    Public ReadOnly Property Dir() As String
        Get
            Return _dir
        End Get
    End Property
    Public Property Album() As String
        Get
            Return _album
        End Get
        Set(ByVal value As String)
            Me._album = value
        End Set
    End Property
    Public Property AlbumCover As Image
        Get
            Return _albumCover
        End Get
        Set(value As Image)
            _albumCover = value
        End Set
    End Property
    'Type
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            Me._type = value
        End Set
    End Property
    Public Property Year() As String
        Get
            Return _year
        End Get
        Set(ByVal value As String)
            Me._year = value
        End Set
    End Property
    Public ReadOnly Property Length()
        Get
            Return _length
        End Get
    End Property
    'display [Artist] - [Song]
    Public ReadOnly Property ArtistAndName()
        Get
            Dim ch() As Char = {Convert.ToChar(&H20), Convert.ToChar(&H0)}
            Dim a As String = "Unknown"
            Me._artist = Me._artist.Trim(ch)
            Me._trackName = Me._trackName.TrimEnd(ch)
            Return _artist & "-" & _trackName
        End Get
    End Property
    Property Time() As Integer
        Get
            Return _time / 1000
        End Get
        Set(ByVal v As Integer)
            _time = v * 1000
        End Set
    End Property
    Property Volume() As Integer
        Get
            Return _volume / 1000
        End Get
        Set(value As Integer)
            _volume = value
            mciSendString("setaudio " & _orgPath & " volume to " & _volume, Nothing, 0, IntPtr.Zero)
        End Set
    End Property
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Int32, ByVal hwndCallback As Int32) As Int32

    Public Sub Play()
        If _songPath = "" Or SongPath.Length <= 4 Then Exit Sub

        Select Case Right(SongPath, 3).ToLower
            Case "mp3"
                mciSendString("open """ & _songPath & """ type mpegvideo alias audiofile", Nothing, 0, IntPtr.Zero)

                Dim playCommand As String = "play audiofile from " & _time

                If _wait = True Then playCommand += " wait"

                mciSendString(playCommand, Nothing, 0, IntPtr.Zero)
            Case "wav"
                mciSendString("open """ & _songPath & """ type waveaudio alias audiofile", Nothing, 0, IntPtr.Zero)
                mciSendString("play audiofile from " & _time, Nothing, 0, IntPtr.Zero)
            Case "mid", "idi"
                mciSendString("stop midi", "", 0, 0)
                mciSendString("close midi", "", 0, 0)
                mciSendString("open sequencer!" & _songPath & " alias midi", "", 0, 0)
                mciSendString("play midi", "", 0, 0)
            Case Else
                Throw New Exception("File type not supported.")
                Call Close()
        End Select
        timer.Enabled = True
        Volume = 100
        IsPaused = False
        If MainPlayer.Queue IsNot Nothing Then
            MainPlayer.notifyPlay()
        End If
    End Sub

    ''' <summary>
    ''' Pause the current play back.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Pause()
        mciSendString("pause audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = True
        timer.Enabled = False
    End Sub

    ''' <summary>
    ''' Resume the current play back if it is currently paused.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub [Resume]()
        mciSendString("resume audiofile", Nothing, 0, IntPtr.Zero)
        IsPaused = False
        timer.Enabled = True
    End Sub

    ''' <summary>
    ''' Stop the current file if it's playing.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub [Stop]()
        mciSendString("stop audiofile", Nothing, 0, IntPtr.Zero)
        timer.Enabled = False
        _time = 0
    End Sub

    ''' <summary>
    ''' Close the file.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Close()
        mciSendString("close audiofile", Nothing, 0, IntPtr.Zero)
        timer.Enabled = False
    End Sub

    Private _wait As Boolean = False
    ''' <summary>
    ''' Halt the program until the .wav file is done playing.  Be careful, this will lock the entire program up until the
    ''' file is done playing.  It behaves as if the Windows Sleep API is called while the file is playing (and maybe it is, I don't
    ''' actually know, I'm just theorizing).  :P
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Wait() As Boolean
        Get
            Return _wait
        End Get
        Set(ByVal value As Boolean)
            _wait = value
        End Set
    End Property

    ''' <summary>
    ''' Sets the audio file's time format via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Milleseconds() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("set audiofile time format milliseconds", Nothing, 0, IntPtr.Zero)
            mciSendString("status audiofile length", buf, 255, IntPtr.Zero)

            buf = Replace(buf, Chr(0), "") ' Get rid of the nulls, they muck things up

            If buf = "" Then
                Return 0
            Else
                Return CInt(buf)
            End If
        End Get
    End Property

    ''' <summary>
    ''' Gets the status of the current playback file via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Status() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile mode", buf, 255, IntPtr.Zero)
            buf = Replace(buf, Chr(0), "")  ' Get rid of the nulls, they muck things up
            Return buf
        End Get
    End Property

    ''' <summary>
    ''' Gets the file size of the current audio file.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property FileSize() As Integer
        Get
            Try
                Return My.Computer.FileSystem.GetFileInfo(_orgPath).Length
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    ''' <summary>
    ''' Gets the channels of the file via the mciSendString API.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Channels() As Integer
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            If IsNumeric(buf) = True Then
                Return CInt(buf)
            Else
                Return -1
            End If
        End Get
    End Property

    ''' <summary>
    ''' Used for debugging purposes.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Debug() As String
        Get
            Dim buf As String = Space(255)
            mciSendString("status audiofile channels", buf, 255, IntPtr.Zero)

            Return Str(buf)
        End Get
    End Property

    Private _isPaused As Boolean = False
    ''' <summary>
    ''' Whether or not the current playback is paused.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsPaused() As Boolean
        Get
            Return _isPaused
        End Get
        Set(ByVal value As Boolean)
            _isPaused = value
        End Set
    End Property
End Class
