Imports System.IO
Public Class Playlist
    Public Shared playlists As New List(Of Playlist)
    Public Shared Function createPlaylist(ByVal name As String, ByVal tracks As List(Of Track)) As Playlist
        Dim playlist As New Playlist
        With playlist
            .name = name
            .tracks = tracks
            .created = Now.ToUniversalTime
        End With
        playlists.Add(playlist)
        For Each list As TrackList In trackLists
            For Each item In list._group
                Dim i As ToolStripMenuItem = item.rightClickMenu.Items(4)
                Dim j As New ToolStripMenuItem(name)
                i.DropDownItems.Add(j)
            Next
        Next
        PurePlayer.tileManager.addTile(TileManager.TileType.PLAYLIST, name, playlist)
        Return playlist
    End Function
    Public Shared Sub savePlaylists()
        For Each file As FileInfo In My.Computer.FileSystem.GetDirectoryInfo(filePath & "\playlists").GetFiles
            file.Delete()
        Next
        For Each playlist As Playlist In playlists
            saveSinglePlaylist(playlist)
        Next
    End Sub
    Public Shared Sub saveSinglePlaylist(ByRef playlist As Playlist)
        Dim dir As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(filePath & "\playlists")
        Using writer As New StreamWriter(playlistsPath & dir.GetFiles.Count, False)
            For Each track As Track In playlist.tracks
                writer.WriteLine(track.SongPath)
            Next
            writer.WriteLine("name?" & playlist.name)
            writer.WriteLine("created?" & playlist.created)
        End Using
    End Sub
    Public Shared Sub loadPlaylists()
        playlists.Clear()
        Dim dir As DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(filePath & "\playlists")
        If dir.GetFiles.Count > 0 Then
            For i = 0 To dir.GetFiles.Count - 1
                Dim playlist As New Playlist
                Using reader As New StreamReader(playlistsPath & i)
                    While reader.Peek <> -1
                        Dim line As String = reader.ReadLine
                        If line.StartsWith("name?") Then
                            playlist.name = line.Substring(5)
                        ElseIf line.StartsWith("created?") Then
                            playlist.created = line.Substring(9)
                        Else
                            playlist.tracks.Add(Track.getTrack(line))
                        End If
                    End While
                End Using
                playlist.id = i
                playlists.Add(playlist)
            Next
        End If
    End Sub
    Public tracks As New List(Of Track)
    Public name As String
    Public created As Date
    Public id As Integer
    Public Sub removeTrack(ByRef track As Track)
        tracks.Remove(track)
        MainPlayer.moveInPageStack(0)
    End Sub
End Class
