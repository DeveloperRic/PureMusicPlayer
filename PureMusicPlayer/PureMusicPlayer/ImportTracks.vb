Imports System.ComponentModel

Public Class ImportTracks
    Public Property track As Track
        Get
            Return tracks(cur)
        End Get
        Set(value As Track)
            tracks.Item(cur) = value
        End Set
    End Property
    Public cur As Integer
    Public tracks As New List(Of Track)
    Private Sub CreateTrack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        colourWindows()
        MainPlayer.noFocus = True
        MainPlayer.returnFocus = Me
        hideControls()
        lblPath.Text = ""
    End Sub
    Public Sub hideControls()
        lblPath.Text = "Reading your tracks..."
        TrackTable.Hide()
        btnPrevious.Hide()
        btnContinue.Hide()
    End Sub
    Public Sub showControls()
        lblPath.Text = "Path: "
        TrackTable.Show()
        btnPrevious.Show()
        btnContinue.Show()
    End Sub
    Dim prevLoc As Integer = -1
    Dim prevLength As Integer
    Private Sub picUploadMusic_Click(sender As Object, e As EventArgs) Handles picUploadMusic.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Music files (*.mp3, *.wav)|*.mp3;*.wav"
        OpenFileDialog1.RestoreDirectory = True
        OpenFileDialog1.Multiselect = True
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If OpenFileDialog1.FileNames.Count > 0 Then
                If PurePlayer.queue IsNot Nothing Then
                    prevLoc = PurePlayer.queue.location
                    If PurePlayer.queue.trackPlaying IsNot Nothing Then
                        prevLength = PurePlayer.queue.trackPlaying.Time
                    End If
                End If
                picUploadMusic.Hide()
                hideControls()
                tracks.Clear()
                For Each name As String In OpenFileDialog1.FileNames
                    Dim t As Track = Track.createTrack(name)
                    tracks.Add(t)
                    MainPlayer.loadedTracks.Add(t.SongPath)
                Next
                showControls()
                refreshControls()
            End If
        End If
    End Sub
    Private Sub picUploadMusic_MouseEnter(sender As Object, e As EventArgs) Handles picUploadMusic.MouseEnter
        picUploadMusic.BackgroundImage = My.Resources.upload_icon_hover
    End Sub

    Private Sub picUploadMusic_MouseLeave(sender As Object, e As EventArgs) Handles picUploadMusic.MouseLeave
        picUploadMusic.BackgroundImage = My.Resources.upload_icon
    End Sub
    Dim pathAnim As TextSlider
    Public Sub refreshControls()
        If tracks.Count > 0 Then
            If pathAnim IsNot Nothing Then
                pathAnim.toggleProcessor(False)
                pathAnim = Nothing
            End If
            If track.OrgPath.Length > 70 Then
                pathAnim = New TextSlider(lblPath, track.OrgPath, 1, 70)
                pathAnim.toggleProcessor(True)
            Else
                lblPath.Text = track.OrgPath
            End If
            lblTitle.Text = track.TrackName
            lblArtist.Text = track.Artist
            lblAlbum.Text = track.Album
            lblYear.Text = track.Year
            If cur > 0 Then
                btnPrevious.Show()
            Else
                btnPrevious.Hide()
            End If
        End If
    End Sub
    Public Sub finish()
        If tracks.Count > 0 Then
            If PurePlayer.queue IsNot Nothing Then
                For Each t As Track In Track.tracks
                    Dim found As Boolean
                    For Each cur As Track In PurePlayer.queue.tracks
                        If cur.Dir = t.Dir Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        PurePlayer.queue.tracks.Add(t)
                    End If
                Next
                PurePlayer.queue.location = prevLoc
                PurePlayer.queue.trackPlaying.Time = prevLength
                PurePlayer.queue.play()
            Else
                PurePlayer.queue = New Queue(New Queue.QueueData(Queue.QueueType.BASIC), Track.tracks)
            End If
            If MainPlayer.HtrackList IsNot Nothing Then
                MainPlayer.HtrackList.Tracks = MainPlayer.Queue.tracks
            End If
        End If
        Me.Close()
    End Sub
    Public Sub [next](Optional ByVal shift As Integer = 1)
        cur += shift
        If cur < tracks.Count Then
            refreshControls()
        Else
            Dim result As MsgBoxResult = MsgBox("Reached end of list. Have you finished modifying your tracks?", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.Yes Then
                finish()
            End If
        End If
    End Sub

    Private Sub btnChangeTitle_Click(sender As Object, e As EventArgs) Handles btnChangeTitle.Click
        track.TrackName = InputBox("Please enter the real track title", "Create Track", track.TrackName)
        refreshControls()
    End Sub

    Private Sub btnChangeArtist_Click(sender As Object, e As EventArgs) Handles btnChangeArtist.Click
        track.Artist = InputBox("Please enter the real track artist", "Create Track", track.Artist)
        refreshControls()
    End Sub

    Private Sub btnChangeAlbum_Click(sender As Object, e As EventArgs) Handles btnChangeAlbum.Click
        track.Album = InputBox("Please enter the real track album", "Create Track", track.Album)
        refreshControls()
    End Sub

    Private Sub btnChangeYear_Click(sender As Object, e As EventArgs) Handles btnChangeYear.Click
        Try
            Dim year As Integer = Val(InputBox("Please enter the real track year", "Create Track", track.Year))
            track.Year = year.ToString
            refreshControls()
        Catch ex As Exception
            MsgBox("Invalid year!",, "Create Track")
        End Try
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        [next]()
    End Sub

    Private Sub closeBox_Click(sender As Object, e As EventArgs) Handles closeBox.Click
        Dim result As MsgBoxResult = MsgBox("You have not edited your tracks!" & vbNewLine & "Exiting now will cause all tracks to be defaulted!" & vbNewLine & "Are you sure you want to do this?", MsgBoxStyle.YesNo)
        If result = MsgBoxResult.Yes Then
            finish()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        [next](-1)
    End Sub
    Private Sub colourWindows()
        Me.BackColor = ColorTranslator.FromHtml("#101010")
        borderPanel.BackColor = ColorTranslator.FromHtml("#080808")
        TrackTable.BackColor = ColorTranslator.FromHtml("#171717")
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
        btnContinue.BackColor = ColorTranslator.FromHtml("#ffebee")
        btnPrevious.BackColor = ColorTranslator.FromHtml("#ffebee")
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

    Private Sub CreateTrack_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MainPlayer.noFocus = False
        MainPlayer.returnFocus = Nothing
    End Sub

#End Region
End Class