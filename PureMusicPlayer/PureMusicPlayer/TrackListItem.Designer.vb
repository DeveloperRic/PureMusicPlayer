<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrackListItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me._name = New System.Windows.Forms.Label()
        Me.tableLayout = New System.Windows.Forms.TableLayoutPanel()
        Me._duration = New System.Windows.Forms.Label()
        Me._year = New System.Windows.Forms.Label()
        Me._album = New System.Windows.Forms.Label()
        Me._artist = New System.Windows.Forms.Label()
        Me._separator = New System.Windows.Forms.Panel()
        Me._pausePlay = New System.Windows.Forms.PictureBox()
        Me.rightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewAlbumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrackInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveFromQueueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewPlaylistTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.RemoveFromPlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tableLayout.SuspendLayout()
        CType(Me._pausePlay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rightClickMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        '_name
        '
        Me._name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._name.AutoSize = True
        Me._name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._name.Location = New System.Drawing.Point(45, 5)
        Me._name.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._name.Name = "_name"
        Me._name.Size = New System.Drawing.Size(83, 20)
        Me._name.TabIndex = 0
        Me._name.Text = "Track Name"
        Me._name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tableLayout
        '
        Me.tableLayout.ColumnCount = 6
        Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.761905!))
        Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.28566!))
        Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.18073!))
        Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.66928!))
        Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.907569!))
        Me.tableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.19487!))
        Me.tableLayout.Controls.Add(Me._duration, 5, 0)
        Me.tableLayout.Controls.Add(Me._year, 4, 0)
        Me.tableLayout.Controls.Add(Me._album, 3, 0)
        Me.tableLayout.Controls.Add(Me._artist, 2, 0)
        Me.tableLayout.Controls.Add(Me._name, 1, 0)
        Me.tableLayout.Controls.Add(Me._separator, 0, 1)
        Me.tableLayout.Controls.Add(Me._pausePlay, 0, 0)
        Me.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayout.Location = New System.Drawing.Point(0, 0)
        Me.tableLayout.Name = "tableLayout"
        Me.tableLayout.RowCount = 2
        Me.tableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.83691!))
        Me.tableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.16309!))
        Me.tableLayout.Size = New System.Drawing.Size(900, 30)
        Me.tableLayout.TabIndex = 1
        '
        '_duration
        '
        Me._duration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._duration.AutoSize = True
        Me._duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._duration.Location = New System.Drawing.Point(839, 5)
        Me._duration.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._duration.Name = "_duration"
        Me._duration.Size = New System.Drawing.Size(58, 20)
        Me._duration.TabIndex = 4
        Me._duration.Text = "Duration"
        Me._duration.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_year
        '
        Me._year.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._year.AutoSize = True
        Me._year.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._year.Location = New System.Drawing.Point(738, 5)
        Me._year.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._year.Name = "_year"
        Me._year.Size = New System.Drawing.Size(37, 20)
        Me._year.TabIndex = 3
        Me._year.Text = "Year"
        Me._year.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_album
        '
        Me._album.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._album.AutoSize = True
        Me._album.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._album.Location = New System.Drawing.Point(534, 5)
        Me._album.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._album.Name = "_album"
        Me._album.Size = New System.Drawing.Size(46, 20)
        Me._album.TabIndex = 2
        Me._album.Text = "Album"
        Me._album.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_artist
        '
        Me._artist.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._artist.AutoSize = True
        Me._artist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._artist.Location = New System.Drawing.Point(299, 5)
        Me._artist.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._artist.Name = "_artist"
        Me._artist.Size = New System.Drawing.Size(37, 20)
        Me._artist.TabIndex = 1
        Me._artist.Text = "Artist"
        Me._artist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_separator
        '
        Me.tableLayout.SetColumnSpan(Me._separator, 6)
        Me._separator.Dock = System.Windows.Forms.DockStyle.Fill
        Me._separator.Location = New System.Drawing.Point(3, 28)
        Me._separator.Name = "_separator"
        Me._separator.Size = New System.Drawing.Size(894, 1)
        Me._separator.TabIndex = 5
        '
        '_pausePlay
        '
        Me._pausePlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me._pausePlay.Dock = System.Windows.Forms.DockStyle.Fill
        Me._pausePlay.Location = New System.Drawing.Point(3, 3)
        Me._pausePlay.Name = "_pausePlay"
        Me._pausePlay.Size = New System.Drawing.Size(36, 19)
        Me._pausePlay.TabIndex = 6
        Me._pausePlay.TabStop = False
        '
        'rightClickMenu
        '
        Me.rightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayToolStripMenuItem, Me.ViewAlbumToolStripMenuItem, Me.TrackInfoToolStripMenuItem, Me.RemoveFromQueueToolStripMenuItem, Me.AddToPlaylistToolStripMenuItem, Me.RemoveFromPlaylistToolStripMenuItem})
        Me.rightClickMenu.Name = "rightClickMenu"
        Me.rightClickMenu.Size = New System.Drawing.Size(187, 136)
        '
        'PlayToolStripMenuItem
        '
        Me.PlayToolStripMenuItem.Name = "PlayToolStripMenuItem"
        Me.PlayToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.PlayToolStripMenuItem.Text = "Play"
        '
        'ViewAlbumToolStripMenuItem
        '
        Me.ViewAlbumToolStripMenuItem.Name = "ViewAlbumToolStripMenuItem"
        Me.ViewAlbumToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.ViewAlbumToolStripMenuItem.Text = "View album"
        '
        'TrackInfoToolStripMenuItem
        '
        Me.TrackInfoToolStripMenuItem.Name = "TrackInfoToolStripMenuItem"
        Me.TrackInfoToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.TrackInfoToolStripMenuItem.Text = "Edit track info"
        '
        'RemoveFromQueueToolStripMenuItem
        '
        Me.RemoveFromQueueToolStripMenuItem.Name = "RemoveFromQueueToolStripMenuItem"
        Me.RemoveFromQueueToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.RemoveFromQueueToolStripMenuItem.Text = "Remove from Queue"
        '
        'AddToPlaylistToolStripMenuItem
        '
        Me.AddToPlaylistToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewPlaylistTextBox})
        Me.AddToPlaylistToolStripMenuItem.Name = "AddToPlaylistToolStripMenuItem"
        Me.AddToPlaylistToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AddToPlaylistToolStripMenuItem.Text = "Add to Playlist"
        '
        'NewPlaylistTextBox
        '
        Me.NewPlaylistTextBox.Name = "NewPlaylistTextBox"
        Me.NewPlaylistTextBox.Size = New System.Drawing.Size(100, 23)
        Me.NewPlaylistTextBox.ToolTipText = "New Playlist"
        '
        'RemoveFromPlaylistToolStripMenuItem
        '
        Me.RemoveFromPlaylistToolStripMenuItem.Name = "RemoveFromPlaylistToolStripMenuItem"
        Me.RemoveFromPlaylistToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.RemoveFromPlaylistToolStripMenuItem.Text = "Remove from Playlist"
        '
        'TrackListItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tableLayout)
        Me.Name = "TrackListItem"
        Me.Size = New System.Drawing.Size(900, 30)
        Me.tableLayout.ResumeLayout(False)
        Me.tableLayout.PerformLayout()
        CType(Me._pausePlay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rightClickMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents _name As Label
    Friend WithEvents tableLayout As TableLayoutPanel
    Friend WithEvents _duration As Label
    Friend WithEvents _year As Label
    Friend WithEvents _album As Label
    Friend WithEvents _artist As Label
    Friend WithEvents _separator As Panel
    Friend WithEvents _pausePlay As PictureBox
    Friend WithEvents rightClickMenu As ContextMenuStrip
    Friend WithEvents TrackInfoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewAlbumToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToPlaylistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveFromPlaylistToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveFromQueueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewPlaylistTextBox As ToolStripTextBox
End Class
