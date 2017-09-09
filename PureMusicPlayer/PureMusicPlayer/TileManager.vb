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
        PLAYER_PAGE
        OPEN_WINDOW
        PLAYLIST
        ALBUM
        BLANK
        DUMMY
        RUN_CODE
    End Enum
    Public Sub addTile(ByRef type As TileType, ByVal label As String, ParamArray args() As Object)
        Dim tile As New Tile(Me, type, label, args)
        tiles.Add(tile)
        panel.Controls.Add(tile)
    End Sub
    Public Sub addTileWAction(ByRef type As TileType, ByVal label As String, ParamArray args() As Action)
        Dim tile As New Tile(Me, type, label, args)
        tiles.Add(tile)
        panel.Controls.Add(tile)
    End Sub
    Private Sub handleResize()
        For Each ctrl As Control In panel.Controls
            ctrl.Width = panel.ClientSize.Width - 20
        Next
    End Sub
End Class
