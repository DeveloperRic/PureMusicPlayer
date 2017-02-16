Public Class TileManager
    Public panel As FlowLayoutPanel
    Public tiles As New List(Of Tile)
    Public Sub New(ByRef panel As FlowLayoutPanel)
        Me.panel = panel
        AddHandler panel.ClientSizeChanged, AddressOf handleResize
    End Sub
    Public Sub refresh()
        panel.Controls.Clear()
        tiles.Clear()
        For Each tile As Tile In tiles
            panel.Controls.Add(tile)
        Next
    End Sub
    Public Enum TileType
        HOME
        IMPORT_TRACKS
        QUEUE
        PLAYLIST
        ALBUM
        BLANK
        DUMMY
    End Enum
    Public Sub addTile(ByRef type As TileType, ByVal label As String, ParamArray args() As Object)
        Dim tile As New Tile(Me, type, label, args)
        tiles.Add(tile)
        panel.Controls.Add(tile)
    End Sub
    Private Sub handleResize()
        For Each ctrl In panel.Controls
            ctrl.Width = panel.ClientSize.Width - 20
        Next
    End Sub
End Class
