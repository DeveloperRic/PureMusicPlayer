<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrackInfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnChangeTitle = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnChangeArtist = New System.Windows.Forms.Button()
        Me.lblArtist = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnChangeAlbum = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblAlbum = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnChangeYear = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TrackTable = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.closeBox = New System.Windows.Forms.PictureBox()
        Me.PURE_LOGO = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.borderPanel = New System.Windows.Forms.Panel()
        Me.btnSearchCover = New System.Windows.Forms.Button()
        Me.btnSearchDetails = New System.Windows.Forms.Button()
        Me.btnSetCover = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TrackTable.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.closeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.borderPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnChangeTitle
        '
        Me.btnChangeTitle.Location = New System.Drawing.Point(17, 94)
        Me.btnChangeTitle.Name = "btnChangeTitle"
        Me.btnChangeTitle.Size = New System.Drawing.Size(251, 23)
        Me.btnChangeTitle.TabIndex = 2
        Me.btnChangeTitle.Text = "Change Title"
        Me.btnChangeTitle.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(14, 50)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(17, 16)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "..."
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Track Title"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnChangeTitle)
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(289, 131)
        Me.Panel1.TabIndex = 0
        '
        'btnChangeArtist
        '
        Me.btnChangeArtist.Location = New System.Drawing.Point(20, 95)
        Me.btnChangeArtist.Name = "btnChangeArtist"
        Me.btnChangeArtist.Size = New System.Drawing.Size(251, 23)
        Me.btnChangeArtist.TabIndex = 5
        Me.btnChangeArtist.Text = "Change Artist"
        Me.btnChangeArtist.UseVisualStyleBackColor = True
        '
        'lblArtist
        '
        Me.lblArtist.AutoSize = True
        Me.lblArtist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArtist.Location = New System.Drawing.Point(17, 51)
        Me.lblArtist.Name = "lblArtist"
        Me.lblArtist.Size = New System.Drawing.Size(17, 16)
        Me.lblArtist.TabIndex = 4
        Me.lblArtist.Text = "..."
        Me.lblArtist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(99, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Track Artist"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnChangeArtist)
        Me.Panel2.Controls.Add(Me.lblArtist)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(298, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(289, 131)
        Me.Panel2.TabIndex = 1
        '
        'btnChangeAlbum
        '
        Me.btnChangeAlbum.Location = New System.Drawing.Point(20, 95)
        Me.btnChangeAlbum.Name = "btnChangeAlbum"
        Me.btnChangeAlbum.Size = New System.Drawing.Size(251, 23)
        Me.btnChangeAlbum.TabIndex = 5
        Me.btnChangeAlbum.Text = "Change Album"
        Me.btnChangeAlbum.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(109, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Track Year"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAlbum
        '
        Me.lblAlbum.AutoSize = True
        Me.lblAlbum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlbum.Location = New System.Drawing.Point(17, 51)
        Me.lblAlbum.Name = "lblAlbum"
        Me.lblAlbum.Size = New System.Drawing.Size(17, 16)
        Me.lblAlbum.TabIndex = 4
        Me.lblAlbum.Text = "..."
        Me.lblAlbum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(99, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Track Album"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnChangeYear
        '
        Me.btnChangeYear.Location = New System.Drawing.Point(20, 95)
        Me.btnChangeYear.Name = "btnChangeYear"
        Me.btnChangeYear.Size = New System.Drawing.Size(251, 23)
        Me.btnChangeYear.TabIndex = 5
        Me.btnChangeYear.Text = "Chnage Year"
        Me.btnChangeYear.UseVisualStyleBackColor = True
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYear.Location = New System.Drawing.Point(17, 51)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(17, 16)
        Me.lblYear.TabIndex = 4
        Me.lblYear.Text = "..."
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnChangeYear)
        Me.Panel4.Controls.Add(Me.lblYear)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Location = New System.Drawing.Point(298, 140)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(289, 131)
        Me.Panel4.TabIndex = 3
        '
        'TrackTable
        '
        Me.TrackTable.ColumnCount = 2
        Me.TrackTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TrackTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TrackTable.Controls.Add(Me.Panel4, 1, 1)
        Me.TrackTable.Controls.Add(Me.Panel3, 0, 1)
        Me.TrackTable.Controls.Add(Me.Panel2, 1, 0)
        Me.TrackTable.Controls.Add(Me.Panel1, 0, 0)
        Me.TrackTable.Location = New System.Drawing.Point(12, 62)
        Me.TrackTable.MaximumSize = New System.Drawing.Size(590, 275)
        Me.TrackTable.MinimumSize = New System.Drawing.Size(590, 275)
        Me.TrackTable.Name = "TrackTable"
        Me.TrackTable.RowCount = 2
        Me.TrackTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TrackTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TrackTable.Size = New System.Drawing.Size(590, 275)
        Me.TrackTable.TabIndex = 28
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnChangeAlbum)
        Me.Panel3.Controls.Add(Me.lblAlbum)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(3, 140)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(289, 131)
        Me.Panel3.TabIndex = 2
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPath.Location = New System.Drawing.Point(11, 33)
        Me.lblPath.MinimumSize = New System.Drawing.Size(590, 0)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(590, 20)
        Me.lblPath.TabIndex = 27
        Me.lblPath.Text = "Path: "
        '
        'closeBox
        '
        Me.closeBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeBox.BackgroundImage = Global.PureMusicPlayer.My.Resources.Resources.close_button
        Me.closeBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.closeBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.closeBox.Location = New System.Drawing.Point(3, 1)
        Me.closeBox.Name = "closeBox"
        Me.closeBox.Size = New System.Drawing.Size(34, 20)
        Me.closeBox.TabIndex = 0
        Me.closeBox.TabStop = False
        '
        'PURE_LOGO
        '
        Me.PURE_LOGO.AutoSize = True
        Me.PURE_LOGO.BackColor = System.Drawing.Color.Transparent
        Me.PURE_LOGO.Dock = System.Windows.Forms.DockStyle.Left
        Me.PURE_LOGO.Font = New System.Drawing.Font("Papyrus", 9.75!)
        Me.PURE_LOGO.ForeColor = System.Drawing.Color.White
        Me.PURE_LOGO.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PURE_LOGO.Location = New System.Drawing.Point(0, 0)
        Me.PURE_LOGO.Name = "PURE_LOGO"
        Me.PURE_LOGO.Size = New System.Drawing.Size(73, 21)
        Me.PURE_LOGO.TabIndex = 4
        Me.PURE_LOGO.Text = "Track Info"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.closeBox)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(574, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(40, 24)
        Me.Panel7.TabIndex = 3
        '
        'borderPanel
        '
        Me.borderPanel.Controls.Add(Me.PURE_LOGO)
        Me.borderPanel.Controls.Add(Me.Panel7)
        Me.borderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.borderPanel.Location = New System.Drawing.Point(0, 0)
        Me.borderPanel.Name = "borderPanel"
        Me.borderPanel.Size = New System.Drawing.Size(614, 24)
        Me.borderPanel.TabIndex = 26
        '
        'btnSearchCover
        '
        Me.btnSearchCover.Location = New System.Drawing.Point(330, 343)
        Me.btnSearchCover.Name = "btnSearchCover"
        Me.btnSearchCover.Size = New System.Drawing.Size(133, 23)
        Me.btnSearchCover.TabIndex = 30
        Me.btnSearchCover.Text = "Search for Album Cover"
        Me.btnSearchCover.UseVisualStyleBackColor = True
        '
        'btnSearchDetails
        '
        Me.btnSearchDetails.Location = New System.Drawing.Point(191, 343)
        Me.btnSearchDetails.Name = "btnSearchDetails"
        Me.btnSearchDetails.Size = New System.Drawing.Size(133, 23)
        Me.btnSearchDetails.TabIndex = 31
        Me.btnSearchDetails.Text = "Search for Track Details"
        Me.btnSearchDetails.UseVisualStyleBackColor = True
        '
        'btnSetCover
        '
        Me.btnSetCover.Location = New System.Drawing.Point(469, 343)
        Me.btnSetCover.Name = "btnSetCover"
        Me.btnSetCover.Size = New System.Drawing.Size(133, 23)
        Me.btnSetCover.TabIndex = 32
        Me.btnSetCover.Text = "Set Album Cover"
        Me.btnSetCover.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TrackInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 369)
        Me.Controls.Add(Me.btnSetCover)
        Me.Controls.Add(Me.btnSearchDetails)
        Me.Controls.Add(Me.btnSearchCover)
        Me.Controls.Add(Me.TrackTable)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.borderPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(614, 369)
        Me.MinimumSize = New System.Drawing.Size(614, 369)
        Me.Name = "TrackInfo"
        Me.Text = "TrackInfo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TrackTable.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.closeBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.borderPanel.ResumeLayout(False)
        Me.borderPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChangeTitle As Button
    Friend WithEvents lblTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnChangeArtist As Button
    Friend WithEvents lblArtist As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnChangeAlbum As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents lblAlbum As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnChangeYear As Button
    Friend WithEvents lblYear As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents TrackTable As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblPath As Label
    Friend WithEvents closeBox As PictureBox
    Friend WithEvents PURE_LOGO As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents borderPanel As Panel
    Friend WithEvents btnSearchCover As Button
    Friend WithEvents btnSearchDetails As Button
    Friend WithEvents btnSetCover As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
