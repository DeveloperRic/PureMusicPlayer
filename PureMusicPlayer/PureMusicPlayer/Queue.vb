Imports System.IO

Public Class Queue
    Public tracks As New List(Of Track)
    Public location As Integer = -1
    Public _shuffle As Boolean
    Public _repeat As Boolean
    Public playing As Boolean
    Public data As QueueData
    Public Class QueueData
        Public type As QueueType
        Public args As Object()
        Public Sub New(ByVal type As QueueType, ParamArray args As Object())
            With Me
                .type = type
                If args IsNot Nothing Then
                    .args = args
                Else
                    .args = New Object() {}
                End If
            End With
        End Sub
    End Class
    Public Enum QueueType
        BASIC
        DUMMY
        ALBUM
        PLAYLIST
    End Enum
    Public Sub New(ByRef data As QueueData, Optional ByVal tracks As List(Of Track) = Nothing)
        If tracks IsNot Nothing Then
            Me.tracks = tracks
        End If
        Me.data = data
    End Sub
    Public Sub New(ByVal reader As StreamReader)
        If reader IsNot Nothing Then
            Dim lastTrackIndex As Integer = -1
            While reader.Peek <> -1
                Try
                    Dim line As String = reader.ReadLine
                    If line.StartsWith("cur") Then
                        Dim lastTrack = Track.getTrack(line.Split("?")(1))
                        lastTrack.Time = Val(line.Split("?")(2))
                        lastTrackIndex = tracks.Count
                        tracks.Add(lastTrack)
                        Continue While
                    ElseIf line.StartsWith("shuffle") Then
                        Shuffled = CBool(line.Split("?")(1))
                    ElseIf line.StartsWith("repeat") Then
                        Repeat = CBool(line.Split("?")(1))
                    Else
                        tracks.Add(Track.getTrack(line))
                    End If
                Catch ex As Exception
                End Try
            End While
            PurePlayer.queue = Me
            Shuffled = Shuffled
            Repeat = Repeat
            data = New QueueData(QueueType.DUMMY)
            If lastTrackIndex >= 0 Then
                play(, lastTrackIndex, False)
                pause()
            End If
        End If
    End Sub
    Public ReadOnly Property trackPlaying As Track
        Get
            If canPlay() Then
                Return tracks(location)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Property Shuffled As Boolean
        Get
            Return _shuffle
        End Get
        Set(value As Boolean)
            _shuffle = value
            If PurePlayer.queue Is Me Then
                If value Then
                    MainPlayer.NPshuffle.BackgroundImage = My.Resources.shuffle_icon_on
                Else
                    MainPlayer.NPshuffle.BackgroundImage = My.Resources.shuffle_icon_off
                End If
            End If
        End Set
    End Property
    Property Repeat As Boolean
        Get
            Return _repeat
        End Get
        Set(value As Boolean)
            _repeat = value
            If PurePlayer.queue Is Me Then
                If value Then
                    MainPlayer.NPrepeat.BackgroundImage = My.Resources.repeat_icon_on
                Else
                    MainPlayer.NPrepeat.BackgroundImage = My.Resources.repeat_icon_off
                End If
            End If
        End Set
    End Property
    Public Sub play(Optional ByVal shift As Integer = 0, Optional ByVal start As Integer = -999, Optional ByVal stopCurrent As Boolean = True)
        Dim time As Integer
        If location >= 0 And location < tracks.Count And stopCurrent Then
            time = trackPlaying.Time
            [stop]()
        End If
        If Not start = -999 Then
            location = start
        Else
            If trackPlaying IsNot Nothing And shift = -1 Then
                Static waiting As Boolean
                If waiting Then
                    If time <= trackPlaying.Length * 0.025 Then
                        location += shift
                        waiting = False
                    End If
                Else
                    waiting = True
                End If
            Else
                location += shift
            End If
        End If
        If location >= tracks.Count And tracks.Count > 0 Then
            location = 0
            trackPlaying.Play()
            [stop]()
            If Not Repeat Then
                Exit Sub
            End If
        End If
        If Not canPlay() Then
            Exit Sub
        End If
        If start >= tracks.Count Then
            Throw New IndexOutOfRangeException("The specified start location is out of the bounds of the queue")
        End If
        trackPlaying.Play()
        playing = True
        MainPlayer.notifyQueue()
    End Sub
    Public Sub [stop]()
        If Not canPlay() Then
            Exit Sub
        End If
        trackPlaying.Stop()
        trackPlaying.Close()
        playing = False
    End Sub
    Public Sub pause()
        If Not canPlay() Then
            Exit Sub
        End If
        tracks(location).Pause()
        playing = False
        MainPlayer.NPpausePlay.BackgroundImage = My.Resources.play_button
    End Sub
    Public Sub [resume]()
        If Not canPlay() Then
            Exit Sub
        End If
        If tracks(location).IsPaused Then
            tracks(location).Resume()
            playing = True
            MainPlayer.NPpausePlay.BackgroundImage = My.Resources.pause_button
        Else
            play()
        End If
    End Sub
    Public Sub shuffle(Optional ByVal forceShuffle As Boolean = False)
        If Not canPlay() Then
            Exit Sub
        End If
        Dim cur As Track = tracks(location)
        pause()
        Dim newq As New List(Of Track)
        If _shuffle And Not forceShuffle Then
            For i = 0 To Track.tracks.Count - 1
                Dim t As Track = Track.tracks(i)
                Dim found As Boolean
                For Each tr As Track In tracks
                    If tr.Dir = t.Dir Then
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    Continue For
                End If
                If t.Dir = cur.Dir Then
                    location = newq.Count
                    newq.Add(cur)
                Else
                    newq.Add(t)
                End If
            Next
        Else
            If Not forceShuffle Then
                newq.Add(cur)
            End If
            While newq.Count <> tracks.Count
                Dim t As Track = tracks(CInt(Math.Floor(((tracks.Count - 1) - 0 + 1) * Rnd())) + 0)
                Dim valid As Boolean = True
                If Not forceShuffle Then
                    valid = Not t.SongPath = cur.SongPath
                End If
                If valid Then
                    Dim u As Boolean = True
                    For Each tr As Track In newq
                        If tr.SongPath = t.SongPath Then
                            u = False
                            Exit For
                        End If
                    Next
                    If Not u Then
                        Continue While
                    End If
                    newq.Add(t)
                End If
            End While
            location = 0
        End If
        tracks = newq
        [resume]()
    End Sub
    Public Function canPlay() As Boolean
        If tracks.Count > 0 And location < tracks.Count And location >= 0 Then
            Return True
        End If
        Return False
    End Function
    Public Sub addTrack(Optional ByVal t As Track = Nothing, Optional ByVal i As Integer = 1, Optional ByVal playTrack As Boolean = True)
        [stop]()
        If t IsNot Nothing Then
            tracks.Add(t)
        End If
        location += i
        If location < 0 Then
            location = tracks.Count - 1
        End If
        If location >= tracks.Count Then
            location = 0
        End If
        If playTrack Then
            If tracks(location).IsPaused Then
                [resume]()
            Else
                play()
            End If
            MainPlayer.notifyPlay()
            playing = True
            MainPlayer.NPpausePlay.BackgroundImage = My.Resources.pause_button
        End If
    End Sub
    Public Sub saveQueue()
        Dim cur As Track = trackPlaying()
        Using writer As New StreamWriter(filePath & "queue.txt", False)
            For Each t In tracks
                If cur IsNot Nothing Then
                    If cur.Dir = t.Dir Then
                        writer.WriteLine("cur?" & cur.SongPath & "?" & cur.Time)
                        Continue For
                    End If
                End If
                writer.WriteLine(t.SongPath)
            Next
            writer.WriteLine("shuffle?" & _shuffle)
            writer.WriteLine("repeat?" & _repeat)
        End Using
    End Sub
    Public Function createQueueList() As List(Of Track)
        Dim list As New List(Of Track)
        Dim cur As Track = trackPlaying
        Dim adding As Boolean = False
        If cur Is Nothing Then
            adding = True
        End If
        For i = 0 To tracks.Count - 1
            Dim t As Track = tracks(i)
            If adding Then
                list.Add(t)
            Else
                If t.Dir = cur.Dir Then
                    adding = True
                    Continue For
                End If
            End If
        Next
        Return list
    End Function
End Class
