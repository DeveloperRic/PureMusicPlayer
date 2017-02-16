Public Class TrackList
    Public view As TrackListView
    Public base As Control
    Public _group As New List(Of TrackListItem)
    Public _tracks As New List(Of Track)
    Public data As TrackListData
    Public Class TrackListData
        Public type As TrackListType
        Public args As Object()
        Public Sub New(ByVal type As TrackListType, Optional ByVal args As Object() = Nothing)
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
    Public Enum TrackListType
        ALBUM
        GENERIC
        HOME
        PLAYLIST
        QUEUE
    End Enum
    Public Property Tracks As List(Of Track)
        Get
            Return _tracks
        End Get
        Set(value As List(Of Track))
            _tracks = value
            refresh()
        End Set
    End Property
    Public Sub New(ByVal tracks As List(Of Track), ByRef base As Control, ByVal panelLocation As Point, ByVal panelSize As Size, ByVal data As TrackListData)
        Me.base = base
        base.Controls.Clear()
        view = New TrackListView
        With view
            .Parent = base
            .Location = panelLocation
            .Size = panelSize
            .Anchor = AnchorStyles.Top And AnchorStyles.Left And AnchorStyles.Right
            .Dock = DockStyle.Fill
        End With
        handleResize()
        _tracks = tracks
        Me.data = data
        AddHandler base.Resize, AddressOf handleResize
        refresh()
        trackLists.Add(Me)
    End Sub
    Public Sub refresh()
        view.list.Controls.Clear()
        _group.Clear()
        Dim index As Integer = 0
        For Each track As Track In _tracks
            Dim hidebar As Boolean = If(index = _tracks.Count - 1, True, False)
            Dim control As New TrackListItem(Me, track.SongPath, index, hidebar)
            With control
                .TrackName = track.TrackName
                .Artist = track.Artist
                .Album = track.Album
                .Year = track.Year
                .Duration = track.Length
                .TextColour = ColorTranslator.FromHtml("#ffebee")
                .AltColour = ColorTranslator.FromHtml("#8C8C8C")
            End With
            view.list.Controls.Add(control)
            _group.Add(control)
            index += 1
        Next
        For Each t As TrackListItem In _group
            t.Group = _group
        Next
    End Sub
    Public Sub addItem(ByRef item As TrackListItem)
        view.list.Controls.Add(item)
        _group.Add(item)
    End Sub
    Public Sub addTrack(ByRef track As Track)
        If _group.Count > 0 Then
            _group(_group.Count - 1).HideBar = False
        End If
        Dim control As New TrackListItem(Me, track.OrgPath, _group.Count, True)
        With control
            .TrackName = track.TrackName
            .Artist = track.Artist
            .Album = track.Album
            .Year = track.Year
            .Duration = track.Length
            .TextColour = ColorTranslator.FromHtml("#ffebee")
            .AltColour = ColorTranslator.FromHtml("#CCCCCC")
        End With
        view.list.Controls.Add(control)
        _group.Add(control)
        control.Group = _group
    End Sub
    Public Sub addSpecialItem(ByVal text As String)
        If text = "" Then
            Exit Sub
        End If
        If _group.Count > 0 Then
            _group(_group.Count - 1).HideBar = False
        End If
        Dim control As New TrackListItem(Me, "", _group.Count, True, text)
        With control
            .TextColour = ColorTranslator.FromHtml("#ffebee")
            .AltColour = ColorTranslator.FromHtml("#CCCCCC")
        End With
        view.list.Controls.Add(control)
        _group.Add(control)
        control.Group = _group
    End Sub
    Private Sub handleResize()
        view.Size = base.Size
    End Sub
End Class
