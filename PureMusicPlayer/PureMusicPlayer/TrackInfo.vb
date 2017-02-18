Imports System.ComponentModel

Public Class TrackInfo
    Public track As Track
    Public returnTrackItem As TrackListItem
    Private Sub CreateTrack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        colourWindows()
        MainPlayer.noFocus = True
        MainPlayer.returnFocus = Me
    End Sub
    Dim pathAnim As TextSlider
    Public Sub refreshControls()
        If pathAnim IsNot Nothing Then
            pathAnim.enabled = False
            pathAnim = Nothing
        End If
        If track.SongPath.Length > 70 Then
            pathAnim = New TextSlider(lblPath, track.SongPath, 1, 70)
            pathAnim.run()
        Else
            lblPath.Text = track.SongPath
        End If
        lblTitle.Text = track.TrackName
        lblArtist.Text = track.Artist
        lblAlbum.Text = track.Album
        lblYear.Text = track.Year
        If track.AlbumCover IsNot Nothing Then
            BackgroundImage = track.AlbumCover
        End If
    End Sub

    Private Sub btnChangeTitle_Click(sender As Object, e As EventArgs) Handles btnChangeTitle.Click
        Dim name As String = InputBox("Please enter the real track title", "Track Info", track.TrackName)
        If Not name = "" Then
            track.TrackName = name
        End If
        refreshControls()
    End Sub

    Private Sub btnChangeArtist_Click(sender As Object, e As EventArgs) Handles btnChangeArtist.Click
        Dim artist As String = InputBox("Please enter the real track artist", "Track Info", track.Artist)
        If Not artist = "" Then
            track.Artist = artist
        End If
        refreshControls()
    End Sub

    Private Sub btnChangeAlbum_Click(sender As Object, e As EventArgs) Handles btnChangeAlbum.Click
        Dim album As String = InputBox("Please enter the real track album", "Track Info", track.Album)
        If Not album = "" Then
            track.Album = album
        End If
        refreshControls()
    End Sub

    Private Sub btnChangeYear_Click(sender As Object, e As EventArgs) Handles btnChangeYear.Click
        Try
            Dim year As Integer = Val(InputBox("Please enter the real track year", "Track Info", track.Year))
            track.Year = year.ToString
            refreshControls()
        Catch ex As Exception
            MsgBox("Invalid year!",, "Track Info")
        End Try
    End Sub

    Private Sub closeBox_Click(sender As Object, e As EventArgs) Handles closeBox.Click
        If returnTrackItem IsNot Nothing Then
            With returnTrackItem
                .TrackName = track.TrackName
                .Artist = track.Artist
                .Album = track.Album
                .Year = track.Year
            End With
        End If
        Track.saveSingleTrack(track)
        Me.Close()
        MainPlayer.Focus()
    End Sub

    Private Sub colourWindows()
        Me.BackColor = ColorTranslator.FromHtml("#191919")
        borderPanel.BackColor = ColorTranslator.FromHtml("#141414")
        TrackTable.BackColor = ColorTranslator.FromHtml("#262626")
        lblTitle.ForeColor = ColorTranslator.FromHtml("#ffebee")
        lblArtist.ForeColor = ColorTranslator.FromHtml("#ffebee")
        lblAlbum.ForeColor = ColorTranslator.FromHtml("#ffebee")
        lblYear.ForeColor = ColorTranslator.FromHtml("#ffebee")
        Label1.ForeColor = ColorTranslator.FromHtml("#ffebee")
        Label5.ForeColor = ColorTranslator.FromHtml("#ffebee")
        Label7.ForeColor = ColorTranslator.FromHtml("#ffebee")
        Label9.ForeColor = ColorTranslator.FromHtml("#ffebee")
        lblPath.ForeColor = ColorTranslator.FromHtml("#ffebee")
        btnChangeTitle.BackColor = ColorTranslator.FromHtml("#ffebee")
        btnChangeArtist.BackColor = ColorTranslator.FromHtml("#ffebee")
        btnChangeAlbum.BackColor = ColorTranslator.FromHtml("#ffebee")
        btnChangeYear.BackColor = ColorTranslator.FromHtml("#ffebee")
        btnSearchCover.BackColor = ColorTranslator.FromHtml("#ffebee")
        btnSearchDetails.BackColor = ColorTranslator.FromHtml("#ffebee")
        btnSetCover.BackColor = ColorTranslator.FromHtml("#ffebee")
    End Sub
#Region " Move Form "

    ' [ Move Form ]
    '
    ' // By Elektro 

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    borderPanel.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    borderPanel.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    borderPanel.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub
#End Region

    Private Sub TrackInfo_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MainPlayer.noFocus = False
        MainPlayer.returnFocus = Nothing
    End Sub

    Private Sub btnSearchCover_Click(sender As Object, e As EventArgs) Handles btnSearchCover.Click
        Dim info As TrackInfoJSON = GetAlbumCover(track)
        If info.cover IsNot Nothing Then
            track.AlbumCover = info.cover
            BackgroundImage = track.AlbumCover
        Else
            MsgBox("Query returned no new album covers!")
        End If
    End Sub

    Private Sub btnSearchDetails_Click(sender As Object, e As EventArgs) Handles btnSearchDetails.Click
        Dim info As TrackInfoJSON = getTrackInfo(track)
        With info
            If Not .name = "" Then
                track.TrackName = .name
            End If
            If Not .artists.Count = 0 Then
                Dim s As String = ""
                For Each a As String In .artists
                    If s = "" Then
                        s += a
                    Else
                        s += ", " & a
                    End If
                Next
                track.Artist = s
            End If
            If Not .album = "" Then
                track.Album = .album
            End If
            If Not .year = "" Then
                track.Year = .year
            End If
        End With
    End Sub

    Private Sub btnSetCover_Click(sender As Object, e As EventArgs) Handles btnSetCover.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Images (*.png)|*.png"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Multiselect = False
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If My.Computer.FileSystem.FileExists(OpenFileDialog1.FileName) Then
                Using img As Image = Image.FromFile(OpenFileDialog1.FileName)
                    track.AlbumCover.Dispose()
                    track.AlbumCover = img
                    'BackgroundImage = img
                    img.Dispose()
                End Using
            End If
        End If
    End Sub
End Class