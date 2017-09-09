<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuggestionCard
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
        Me.PlayName = New System.Windows.Forms.Label()
        Me.lblCardType = New System.Windows.Forms.Label()
        Me.playPause = New System.Windows.Forms.PictureBox()
        Me.albumCoverBox = New System.Windows.Forms.PictureBox()
        CType(Me.playPause, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.albumCoverBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PlayName
        '
        Me.PlayName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.PlayName.AutoSize = True
        Me.PlayName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayName.Location = New System.Drawing.Point(50, 165)
        Me.PlayName.Name = "PlayName"
        Me.PlayName.Size = New System.Drawing.Size(84, 20)
        Me.PlayName.TabIndex = 4
        Me.PlayName.Text = "Play Name"
        Me.PlayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCardType
        '
        Me.lblCardType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblCardType.AutoSize = True
        Me.lblCardType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardType.Location = New System.Drawing.Point(10, 10)
        Me.lblCardType.Name = "lblCardType"
        Me.lblCardType.Size = New System.Drawing.Size(81, 20)
        Me.lblCardType.TabIndex = 6
        Me.lblCardType.Text = "Card Type"
        Me.lblCardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'playPause
        '
        Me.playPause.Image = Global.PureMusicPlayer.My.Resources.Resources.play_button
        Me.playPause.Location = New System.Drawing.Point(10, 160)
        Me.playPause.Name = "playPause"
        Me.playPause.Size = New System.Drawing.Size(30, 30)
        Me.playPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.playPause.TabIndex = 5
        Me.playPause.TabStop = False
        '
        'albumCoverBox
        '
        Me.albumCoverBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.albumCoverBox.Location = New System.Drawing.Point(0, 0)
        Me.albumCoverBox.Name = "albumCoverBox"
        Me.albumCoverBox.Size = New System.Drawing.Size(200, 200)
        Me.albumCoverBox.TabIndex = 0
        Me.albumCoverBox.TabStop = False
        '
        'SuggestionCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblCardType)
        Me.Controls.Add(Me.playPause)
        Me.Controls.Add(Me.PlayName)
        Me.Controls.Add(Me.albumCoverBox)
        Me.Name = "SuggestionCard"
        Me.Size = New System.Drawing.Size(200, 200)
        CType(Me.playPause, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.albumCoverBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents albumCoverBox As PictureBox
    Friend WithEvents playPause As PictureBox
    Friend WithEvents PlayName As Label
    Friend WithEvents lblCardType As Label
End Class
