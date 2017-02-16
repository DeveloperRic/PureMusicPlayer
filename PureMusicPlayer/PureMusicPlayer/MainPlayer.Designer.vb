<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainPlayer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainPlayer))
        Me.MainPlayerPages = New System.Windows.Forms.TabControl()
        Me.loadPage = New System.Windows.Forms.TabPage()
        Me.homePage = New System.Windows.Forms.TabPage()
        Me.HplaylistCardReel = New System.Windows.Forms.FlowLayoutPanel()
        Me.HtracksCollection = New System.Windows.Forms.Panel()
        Me.lblGreeting2 = New System.Windows.Forms.Label()
        Me.lblGreeting = New System.Windows.Forms.Label()
        Me.queuePage = New System.Windows.Forms.TabPage()
        Me.QplayingFrom = New System.Windows.Forms.Label()
        Me.QtracksCollection = New System.Windows.Forms.Panel()
        Me.lblQueuedTracks = New System.Windows.Forms.Label()
        Me.albumPage = New System.Windows.Forms.TabPage()
        Me.AlbumTracksCollection = New System.Windows.Forms.Panel()
        Me.AlbumHeader = New System.Windows.Forms.Panel()
        Me.AlbumPlay = New System.Windows.Forms.Button()
        Me.AlbumLabel = New System.Windows.Forms.Label()
        Me.AlbumCover = New System.Windows.Forms.PictureBox()
        Me.AlbumTracks = New System.Windows.Forms.Label()
        Me.AlbumName = New System.Windows.Forms.Label()
        Me.AlbumArtists = New System.Windows.Forms.Label()
        Me.playlistPage = New System.Windows.Forms.TabPage()
        Me.PlaylistTracksCollection = New System.Windows.Forms.Panel()
        Me.PlaylistHeader = New System.Windows.Forms.Panel()
        Me.PlaylistCoverImage = New System.Windows.Forms.Panel()
        Me.PlaylistPlay = New System.Windows.Forms.Button()
        Me.PlaylistLabel = New System.Windows.Forms.Label()
        Me.PlaylistCreated = New System.Windows.Forms.Label()
        Me.PlaylistName = New System.Windows.Forms.Label()
        Me.PlaylistArtists = New System.Windows.Forms.Label()
        Me.HtilesList = New System.Windows.Forms.FlowLayoutPanel()
        Me.tilesBar = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.tileNextPage = New System.Windows.Forms.PictureBox()
        Me.tilePrevPage = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.NPalbumCover = New System.Windows.Forms.PictureBox()
        Me.NPtrackName = New System.Windows.Forms.Label()
        Me.NPalbumYear = New System.Windows.Forms.Label()
        Me.NPartist = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NPqueue = New System.Windows.Forms.PictureBox()
        Me.NPrepeat = New System.Windows.Forms.PictureBox()
        Me.NPshuffle = New System.Windows.Forms.PictureBox()
        Me.NPNextTrack = New System.Windows.Forms.PictureBox()
        Me.NPPrevTrack = New System.Windows.Forms.PictureBox()
        Me.NPpausePlay = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.NPprogress = New System.Windows.Forms.TrackBar()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.NPmaxTime = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.NPcurTime = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.NPvolume = New System.Windows.Forms.TrackBar()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.nowPlaying = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.closeBox = New System.Windows.Forms.PictureBox()
        Me.minimiseBox = New System.Windows.Forms.PictureBox()
        Me.maximiseBox = New System.Windows.Forms.PictureBox()
        Me.PURE_LOGO = New System.Windows.Forms.Label()
        Me.borderPanel = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.StatusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MainPlayerPages.SuspendLayout()
        Me.homePage.SuspendLayout()
        Me.queuePage.SuspendLayout()
        Me.albumPage.SuspendLayout()
        Me.AlbumHeader.SuspendLayout()
        CType(Me.AlbumCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.playlistPage.SuspendLayout()
        Me.PlaylistHeader.SuspendLayout()
        Me.tilesBar.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        CType(Me.tileNextPage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tilePrevPage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.NPalbumCover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.NPqueue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NPrepeat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NPshuffle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NPNextTrack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NPPrevTrack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NPpausePlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.NPprogress, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NPvolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.nowPlaying.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.closeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimiseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maximiseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.borderPanel.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPlayerPages
        '
        Me.MainPlayerPages.Controls.Add(Me.loadPage)
        Me.MainPlayerPages.Controls.Add(Me.homePage)
        Me.MainPlayerPages.Controls.Add(Me.queuePage)
        Me.MainPlayerPages.Controls.Add(Me.albumPage)
        Me.MainPlayerPages.Controls.Add(Me.playlistPage)
        resources.ApplyResources(Me.MainPlayerPages, "MainPlayerPages")
        Me.MainPlayerPages.Name = "MainPlayerPages"
        Me.MainPlayerPages.SelectedIndex = 0
        Me.MainPlayerPages.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.MainPlayerPages.TabStop = False
        '
        'loadPage
        '
        resources.ApplyResources(Me.loadPage, "loadPage")
        Me.loadPage.Name = "loadPage"
        Me.loadPage.UseVisualStyleBackColor = True
        '
        'homePage
        '
        Me.homePage.Controls.Add(Me.HplaylistCardReel)
        Me.homePage.Controls.Add(Me.HtracksCollection)
        Me.homePage.Controls.Add(Me.lblGreeting2)
        Me.homePage.Controls.Add(Me.lblGreeting)
        resources.ApplyResources(Me.homePage, "homePage")
        Me.homePage.Name = "homePage"
        Me.homePage.UseVisualStyleBackColor = True
        '
        'HplaylistCardReel
        '
        resources.ApplyResources(Me.HplaylistCardReel, "HplaylistCardReel")
        Me.HplaylistCardReel.Name = "HplaylistCardReel"
        '
        'HtracksCollection
        '
        resources.ApplyResources(Me.HtracksCollection, "HtracksCollection")
        Me.HtracksCollection.Name = "HtracksCollection"
        '
        'lblGreeting2
        '
        resources.ApplyResources(Me.lblGreeting2, "lblGreeting2")
        Me.lblGreeting2.Name = "lblGreeting2"
        '
        'lblGreeting
        '
        resources.ApplyResources(Me.lblGreeting, "lblGreeting")
        Me.lblGreeting.Name = "lblGreeting"
        '
        'queuePage
        '
        Me.queuePage.Controls.Add(Me.QplayingFrom)
        Me.queuePage.Controls.Add(Me.QtracksCollection)
        Me.queuePage.Controls.Add(Me.lblQueuedTracks)
        resources.ApplyResources(Me.queuePage, "queuePage")
        Me.queuePage.Name = "queuePage"
        Me.queuePage.UseVisualStyleBackColor = True
        '
        'QplayingFrom
        '
        resources.ApplyResources(Me.QplayingFrom, "QplayingFrom")
        Me.QplayingFrom.Name = "QplayingFrom"
        '
        'QtracksCollection
        '
        resources.ApplyResources(Me.QtracksCollection, "QtracksCollection")
        Me.QtracksCollection.Name = "QtracksCollection"
        '
        'lblQueuedTracks
        '
        resources.ApplyResources(Me.lblQueuedTracks, "lblQueuedTracks")
        Me.lblQueuedTracks.Name = "lblQueuedTracks"
        '
        'albumPage
        '
        Me.albumPage.Controls.Add(Me.AlbumTracksCollection)
        Me.albumPage.Controls.Add(Me.AlbumHeader)
        resources.ApplyResources(Me.albumPage, "albumPage")
        Me.albumPage.Name = "albumPage"
        Me.albumPage.UseVisualStyleBackColor = True
        '
        'AlbumTracksCollection
        '
        resources.ApplyResources(Me.AlbumTracksCollection, "AlbumTracksCollection")
        Me.AlbumTracksCollection.Name = "AlbumTracksCollection"
        '
        'AlbumHeader
        '
        Me.AlbumHeader.Controls.Add(Me.AlbumPlay)
        Me.AlbumHeader.Controls.Add(Me.AlbumLabel)
        Me.AlbumHeader.Controls.Add(Me.AlbumCover)
        Me.AlbumHeader.Controls.Add(Me.AlbumTracks)
        Me.AlbumHeader.Controls.Add(Me.AlbumName)
        Me.AlbumHeader.Controls.Add(Me.AlbumArtists)
        resources.ApplyResources(Me.AlbumHeader, "AlbumHeader")
        Me.AlbumHeader.Name = "AlbumHeader"
        '
        'AlbumPlay
        '
        resources.ApplyResources(Me.AlbumPlay, "AlbumPlay")
        Me.AlbumPlay.Name = "AlbumPlay"
        Me.AlbumPlay.UseVisualStyleBackColor = True
        '
        'AlbumLabel
        '
        resources.ApplyResources(Me.AlbumLabel, "AlbumLabel")
        Me.AlbumLabel.Name = "AlbumLabel"
        '
        'AlbumCover
        '
        resources.ApplyResources(Me.AlbumCover, "AlbumCover")
        Me.AlbumCover.Name = "AlbumCover"
        Me.AlbumCover.TabStop = False
        '
        'AlbumTracks
        '
        resources.ApplyResources(Me.AlbumTracks, "AlbumTracks")
        Me.AlbumTracks.Name = "AlbumTracks"
        '
        'AlbumName
        '
        resources.ApplyResources(Me.AlbumName, "AlbumName")
        Me.AlbumName.Name = "AlbumName"
        '
        'AlbumArtists
        '
        resources.ApplyResources(Me.AlbumArtists, "AlbumArtists")
        Me.AlbumArtists.Name = "AlbumArtists"
        '
        'playlistPage
        '
        Me.playlistPage.Controls.Add(Me.PlaylistTracksCollection)
        Me.playlistPage.Controls.Add(Me.PlaylistHeader)
        resources.ApplyResources(Me.playlistPage, "playlistPage")
        Me.playlistPage.Name = "playlistPage"
        Me.playlistPage.UseVisualStyleBackColor = True
        '
        'PlaylistTracksCollection
        '
        resources.ApplyResources(Me.PlaylistTracksCollection, "PlaylistTracksCollection")
        Me.PlaylistTracksCollection.Name = "PlaylistTracksCollection"
        '
        'PlaylistHeader
        '
        Me.PlaylistHeader.Controls.Add(Me.PlaylistCoverImage)
        Me.PlaylistHeader.Controls.Add(Me.PlaylistPlay)
        Me.PlaylistHeader.Controls.Add(Me.PlaylistLabel)
        Me.PlaylistHeader.Controls.Add(Me.PlaylistCreated)
        Me.PlaylistHeader.Controls.Add(Me.PlaylistName)
        Me.PlaylistHeader.Controls.Add(Me.PlaylistArtists)
        resources.ApplyResources(Me.PlaylistHeader, "PlaylistHeader")
        Me.PlaylistHeader.Name = "PlaylistHeader"
        '
        'PlaylistCoverImage
        '
        resources.ApplyResources(Me.PlaylistCoverImage, "PlaylistCoverImage")
        Me.PlaylistCoverImage.Name = "PlaylistCoverImage"
        '
        'PlaylistPlay
        '
        resources.ApplyResources(Me.PlaylistPlay, "PlaylistPlay")
        Me.PlaylistPlay.Name = "PlaylistPlay"
        Me.PlaylistPlay.UseVisualStyleBackColor = True
        '
        'PlaylistLabel
        '
        resources.ApplyResources(Me.PlaylistLabel, "PlaylistLabel")
        Me.PlaylistLabel.Name = "PlaylistLabel"
        '
        'PlaylistCreated
        '
        resources.ApplyResources(Me.PlaylistCreated, "PlaylistCreated")
        Me.PlaylistCreated.Name = "PlaylistCreated"
        '
        'PlaylistName
        '
        resources.ApplyResources(Me.PlaylistName, "PlaylistName")
        Me.PlaylistName.Name = "PlaylistName"
        '
        'PlaylistArtists
        '
        resources.ApplyResources(Me.PlaylistArtists, "PlaylistArtists")
        Me.PlaylistArtists.Name = "PlaylistArtists"
        '
        'HtilesList
        '
        resources.ApplyResources(Me.HtilesList, "HtilesList")
        Me.HtilesList.Name = "HtilesList"
        '
        'tilesBar
        '
        Me.tilesBar.Controls.Add(Me.HtilesList)
        Me.tilesBar.Controls.Add(Me.Panel14)
        resources.ApplyResources(Me.tilesBar, "tilesBar")
        Me.tilesBar.Name = "tilesBar"
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Panel16)
        Me.Panel14.Controls.Add(Me.Panel15)
        resources.ApplyResources(Me.Panel14, "Panel14")
        Me.Panel14.Name = "Panel14"
        '
        'Panel16
        '
        resources.ApplyResources(Me.Panel16, "Panel16")
        Me.Panel16.Name = "Panel16"
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.tileNextPage)
        Me.Panel15.Controls.Add(Me.tilePrevPage)
        resources.ApplyResources(Me.Panel15, "Panel15")
        Me.Panel15.Name = "Panel15"
        '
        'tileNextPage
        '
        resources.ApplyResources(Me.tileNextPage, "tileNextPage")
        Me.tileNextPage.Name = "tileNextPage"
        Me.tileNextPage.TabStop = False
        '
        'tilePrevPage
        '
        resources.ApplyResources(Me.tilePrevPage, "tilePrevPage")
        Me.tilePrevPage.Name = "tilePrevPage"
        Me.tilePrevPage.TabStop = False
        '
        'Panel2
        '
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Controls.Add(Me.NPalbumCover)
        Me.Panel2.Controls.Add(Me.NPtrackName)
        Me.Panel2.Controls.Add(Me.NPalbumYear)
        Me.Panel2.Controls.Add(Me.NPartist)
        Me.Panel2.Name = "Panel2"
        '
        'NPalbumCover
        '
        resources.ApplyResources(Me.NPalbumCover, "NPalbumCover")
        Me.NPalbumCover.Name = "NPalbumCover"
        Me.NPalbumCover.TabStop = False
        '
        'NPtrackName
        '
        resources.ApplyResources(Me.NPtrackName, "NPtrackName")
        Me.NPtrackName.Name = "NPtrackName"
        '
        'NPalbumYear
        '
        resources.ApplyResources(Me.NPalbumYear, "NPalbumYear")
        Me.NPalbumYear.Name = "NPalbumYear"
        '
        'NPartist
        '
        resources.ApplyResources(Me.NPartist, "NPartist")
        Me.NPartist.Name = "NPartist"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NPqueue)
        Me.Panel1.Controls.Add(Me.NPrepeat)
        Me.Panel1.Controls.Add(Me.NPshuffle)
        Me.Panel1.Controls.Add(Me.NPNextTrack)
        Me.Panel1.Controls.Add(Me.NPPrevTrack)
        Me.Panel1.Controls.Add(Me.NPpausePlay)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'NPqueue
        '
        Me.NPqueue.BackgroundImage = Global.PureMusicPlayer.My.Resources.Resources.queue_button
        resources.ApplyResources(Me.NPqueue, "NPqueue")
        Me.NPqueue.Name = "NPqueue"
        Me.NPqueue.TabStop = False
        '
        'NPrepeat
        '
        Me.NPrepeat.BackgroundImage = Global.PureMusicPlayer.My.Resources.Resources.repeat_icon_off
        resources.ApplyResources(Me.NPrepeat, "NPrepeat")
        Me.NPrepeat.Name = "NPrepeat"
        Me.NPrepeat.TabStop = False
        '
        'NPshuffle
        '
        Me.NPshuffle.BackgroundImage = Global.PureMusicPlayer.My.Resources.Resources.shuffle_icon_off
        resources.ApplyResources(Me.NPshuffle, "NPshuffle")
        Me.NPshuffle.Name = "NPshuffle"
        Me.NPshuffle.TabStop = False
        '
        'NPNextTrack
        '
        Me.NPNextTrack.BackgroundImage = Global.PureMusicPlayer.My.Resources.Resources.next_track_button
        resources.ApplyResources(Me.NPNextTrack, "NPNextTrack")
        Me.NPNextTrack.Name = "NPNextTrack"
        Me.NPNextTrack.TabStop = False
        '
        'NPPrevTrack
        '
        Me.NPPrevTrack.BackgroundImage = Global.PureMusicPlayer.My.Resources.Resources.prev_track_button
        resources.ApplyResources(Me.NPPrevTrack, "NPPrevTrack")
        Me.NPPrevTrack.Name = "NPPrevTrack"
        Me.NPPrevTrack.TabStop = False
        '
        'NPpausePlay
        '
        Me.NPpausePlay.BackgroundImage = Global.PureMusicPlayer.My.Resources.Resources.play_button
        resources.ApplyResources(Me.NPpausePlay, "NPpausePlay")
        Me.NPpausePlay.Name = "NPpausePlay"
        Me.NPpausePlay.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Panel5)
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.Name = "Panel4"
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.NPprogress)
        resources.ApplyResources(Me.Panel8, "Panel8")
        Me.Panel8.Name = "Panel8"
        '
        'NPprogress
        '
        resources.ApplyResources(Me.NPprogress, "NPprogress")
        Me.NPprogress.Maximum = 0
        Me.NPprogress.Name = "NPprogress"
        Me.NPprogress.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.NPmaxTime)
        resources.ApplyResources(Me.Panel6, "Panel6")
        Me.Panel6.Name = "Panel6"
        '
        'NPmaxTime
        '
        resources.ApplyResources(Me.NPmaxTime, "NPmaxTime")
        Me.NPmaxTime.Name = "NPmaxTime"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.NPcurTime)
        resources.ApplyResources(Me.Panel5, "Panel5")
        Me.Panel5.Name = "Panel5"
        '
        'NPcurTime
        '
        resources.ApplyResources(Me.NPcurTime, "NPcurTime")
        Me.NPcurTime.Name = "NPcurTime"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.PictureBox1)
        Me.Panel9.Controls.Add(Me.NPvolume)
        resources.ApplyResources(Me.Panel9, "Panel9")
        Me.Panel9.Name = "Panel9"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'NPvolume
        '
        resources.ApplyResources(Me.NPvolume, "NPvolume")
        Me.NPvolume.Maximum = 100
        Me.NPvolume.Name = "NPvolume"
        Me.NPvolume.TickStyle = System.Windows.Forms.TickStyle.None
        Me.NPvolume.Value = 50
        '
        'Panel10
        '
        resources.ApplyResources(Me.Panel10, "Panel10")
        Me.Panel10.Controls.Add(Me.Panel1)
        Me.Panel10.Controls.Add(Me.Panel2)
        Me.Panel10.Name = "Panel10"
        '
        'nowPlaying
        '
        Me.nowPlaying.Controls.Add(Me.Panel4)
        Me.nowPlaying.Controls.Add(Me.Panel10)
        Me.nowPlaying.Controls.Add(Me.Panel9)
        resources.ApplyResources(Me.nowPlaying, "nowPlaying")
        Me.nowPlaying.Name = "nowPlaying"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.closeBox)
        Me.Panel7.Controls.Add(Me.minimiseBox)
        Me.Panel7.Controls.Add(Me.maximiseBox)
        resources.ApplyResources(Me.Panel7, "Panel7")
        Me.Panel7.Name = "Panel7"
        '
        'closeBox
        '
        resources.ApplyResources(Me.closeBox, "closeBox")
        Me.closeBox.Name = "closeBox"
        Me.closeBox.TabStop = False
        '
        'minimiseBox
        '
        resources.ApplyResources(Me.minimiseBox, "minimiseBox")
        Me.minimiseBox.Name = "minimiseBox"
        Me.minimiseBox.TabStop = False
        '
        'maximiseBox
        '
        resources.ApplyResources(Me.maximiseBox, "maximiseBox")
        Me.maximiseBox.Name = "maximiseBox"
        Me.maximiseBox.TabStop = False
        '
        'PURE_LOGO
        '
        resources.ApplyResources(Me.PURE_LOGO, "PURE_LOGO")
        Me.PURE_LOGO.BackColor = System.Drawing.Color.Transparent
        Me.PURE_LOGO.ForeColor = System.Drawing.Color.White
        Me.PURE_LOGO.Name = "PURE_LOGO"
        '
        'borderPanel
        '
        Me.borderPanel.Controls.Add(Me.PURE_LOGO)
        Me.borderPanel.Controls.Add(Me.Panel7)
        resources.ApplyResources(Me.borderPanel, "borderPanel")
        Me.borderPanel.Name = "borderPanel"
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.MainPlayerPages)
        Me.Panel17.Controls.Add(Me.StatusStrip)
        resources.ApplyResources(Me.Panel17, "Panel17")
        Me.Panel17.Name = "Panel17"
        '
        'StatusStrip
        '
        resources.ApplyResources(Me.StatusStrip, "StatusStrip")
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusStripLabel})
        Me.StatusStrip.Name = "StatusStrip"
        '
        'StatusStripLabel
        '
        resources.ApplyResources(Me.StatusStripLabel, "StatusStripLabel")
        Me.StatusStripLabel.Name = "StatusStripLabel"
        '
        'MainPlayer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Panel17)
        Me.Controls.Add(Me.tilesBar)
        Me.Controls.Add(Me.borderPanel)
        Me.Controls.Add(Me.nowPlaying)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainPlayer"
        Me.ShowIcon = False
        Me.MainPlayerPages.ResumeLayout(False)
        Me.homePage.ResumeLayout(False)
        Me.homePage.PerformLayout()
        Me.queuePage.ResumeLayout(False)
        Me.queuePage.PerformLayout()
        Me.albumPage.ResumeLayout(False)
        Me.AlbumHeader.ResumeLayout(False)
        Me.AlbumHeader.PerformLayout()
        CType(Me.AlbumCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.playlistPage.ResumeLayout(False)
        Me.PlaylistHeader.ResumeLayout(False)
        Me.PlaylistHeader.PerformLayout()
        Me.tilesBar.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        CType(Me.tileNextPage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tilePrevPage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.NPalbumCover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.NPqueue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NPrepeat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NPshuffle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NPNextTrack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NPPrevTrack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NPpausePlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.NPprogress, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NPvolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.nowPlaying.ResumeLayout(False)
        Me.nowPlaying.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.closeBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimiseBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maximiseBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.borderPanel.ResumeLayout(False)
        Me.borderPanel.PerformLayout()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPlayerPages As TabControl
    Friend WithEvents homePage As TabPage
    Friend WithEvents lblGreeting As Label
    Friend WithEvents lblGreeting2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents NPNextTrack As PictureBox
    Friend WithEvents NPPrevTrack As PictureBox
    Friend WithEvents NPpausePlay As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents NPalbumCover As PictureBox
    Friend WithEvents NPtrackName As Label
    Friend WithEvents NPalbumYear As Label
    Friend WithEvents NPartist As Label
    Friend WithEvents NPrepeat As PictureBox
    Friend WithEvents NPshuffle As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents NPprogress As TrackBar
    Friend WithEvents Panel6 As Panel
    Friend WithEvents NPmaxTime As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents NPcurTime As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents NPvolume As TrackBar
    Friend WithEvents Panel10 As Panel
    Friend WithEvents nowPlaying As Panel
    Friend WithEvents NPqueue As PictureBox
    Friend WithEvents queuePage As TabPage
    Friend WithEvents lblQueuedTracks As Label
    Friend WithEvents loadPage As TabPage
    Friend WithEvents tilesBar As Panel
    Friend WithEvents HtilesList As FlowLayoutPanel
    Friend WithEvents HtracksCollection As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents tileNextPage As PictureBox
    Friend WithEvents tilePrevPage As PictureBox
    Friend WithEvents albumPage As TabPage
    Friend WithEvents AlbumArtists As Label
    Friend WithEvents AlbumCover As PictureBox
    Friend WithEvents AlbumName As Label
    Friend WithEvents AlbumHeader As Panel
    Friend WithEvents AlbumTracks As Label
    Friend WithEvents AlbumTracksCollection As Panel
    Friend WithEvents AlbumLabel As Label
    Friend WithEvents AlbumPlay As Button
    Friend WithEvents playlistPage As TabPage
    Friend WithEvents PlaylistTracksCollection As Panel
    Friend WithEvents PlaylistHeader As Panel
    Friend WithEvents PlaylistPlay As Button
    Friend WithEvents PlaylistLabel As Label
    Friend WithEvents PlaylistCreated As Label
    Friend WithEvents PlaylistName As Label
    Friend WithEvents PlaylistArtists As Label
    Friend WithEvents PlaylistCoverImage As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents closeBox As PictureBox
    Friend WithEvents minimiseBox As PictureBox
    Friend WithEvents maximiseBox As PictureBox
    Friend WithEvents PURE_LOGO As Label
    Friend WithEvents borderPanel As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents StatusStripLabel As ToolStripStatusLabel
    Friend WithEvents QtracksCollection As Panel
    Friend WithEvents HplaylistCardReel As FlowLayoutPanel
    Friend WithEvents QplayingFrom As Label
End Class
