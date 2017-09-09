<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PlaylistCard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Cover1 = New System.Windows.Forms.PictureBox()
        Me.TableLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.Cover4 = New System.Windows.Forms.PictureBox()
        Me.Cover3 = New System.Windows.Forms.PictureBox()
        Me.Cover2 = New System.Windows.Forms.PictureBox()
        Me.PlaylistName = New System.Windows.Forms.Label()
        Me.playPause = New System.Windows.Forms.PictureBox()
        Me.lblCardType = New System.Windows.Forms.Label()
        CType(Me.Cover1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayout.SuspendLayout()
        CType(Me.Cover4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cover3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cover2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.playPause, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cover1
        '
        Me.Cover1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cover1.Location = New System.Drawing.Point(0, 0)
        Me.Cover1.Margin = New System.Windows.Forms.Padding(0)
        Me.Cover1.Name = "Cover1"
        Me.Cover1.Size = New System.Drawing.Size(100, 100)
        Me.Cover1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Cover1.TabIndex = 0
        Me.Cover1.TabStop = False
        '
        'TableLayout
        '
        Me.TableLayout.ColumnCount = 2
        Me.TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayout.Controls.Add(Me.Cover4, 1, 1)
        Me.TableLayout.Controls.Add(Me.Cover3, 0, 1)
        Me.TableLayout.Controls.Add(Me.Cover2, 1, 0)
        Me.TableLayout.Controls.Add(Me.Cover1, 0, 0)
        Me.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayout.Location = New System.Drawing.Point(0, 0)
        Me.TableLayout.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayout.Name = "TableLayout"
        Me.TableLayout.RowCount = 2
        Me.TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayout.Size = New System.Drawing.Size(200, 200)
        Me.TableLayout.TabIndex = 4
        '
        'Cover4
        '
        Me.Cover4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cover4.Location = New System.Drawing.Point(100, 100)
        Me.Cover4.Margin = New System.Windows.Forms.Padding(0)
        Me.Cover4.Name = "Cover4"
        Me.Cover4.Size = New System.Drawing.Size(100, 100)
        Me.Cover4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Cover4.TabIndex = 3
        Me.Cover4.TabStop = False
        '
        'Cover3
        '
        Me.Cover3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cover3.Location = New System.Drawing.Point(0, 100)
        Me.Cover3.Margin = New System.Windows.Forms.Padding(0)
        Me.Cover3.Name = "Cover3"
        Me.Cover3.Size = New System.Drawing.Size(100, 100)
        Me.Cover3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Cover3.TabIndex = 2
        Me.Cover3.TabStop = False
        '
        'Cover2
        '
        Me.Cover2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cover2.Location = New System.Drawing.Point(100, 0)
        Me.Cover2.Margin = New System.Windows.Forms.Padding(0)
        Me.Cover2.Name = "Cover2"
        Me.Cover2.Size = New System.Drawing.Size(100, 100)
        Me.Cover2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Cover2.TabIndex = 1
        Me.Cover2.TabStop = False
        '
        'PlaylistName
        '
        Me.PlaylistName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.PlaylistName.AutoSize = True
        Me.PlaylistName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlaylistName.Location = New System.Drawing.Point(50, 165)
        Me.PlaylistName.Name = "PlaylistName"
        Me.PlaylistName.Size = New System.Drawing.Size(103, 20)
        Me.PlaylistName.TabIndex = 2
        Me.PlaylistName.Text = "Playlist Name"
        Me.PlaylistName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'playPause
        '
        Me.playPause.Image = Global.PureMusicPlayer.My.Resources.Resources.play_button
        Me.playPause.Location = New System.Drawing.Point(10, 160)
        Me.playPause.Name = "playPause"
        Me.playPause.Size = New System.Drawing.Size(30, 30)
        Me.playPause.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.playPause.TabIndex = 3
        Me.playPause.TabStop = False
        '
        'lblCardType
        '
        Me.lblCardType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblCardType.AutoSize = True
        Me.lblCardType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCardType.Location = New System.Drawing.Point(10, 10)
        Me.lblCardType.Name = "lblCardType"
        Me.lblCardType.Size = New System.Drawing.Size(57, 20)
        Me.lblCardType.TabIndex = 7
        Me.lblCardType.Text = "Playlist"
        Me.lblCardType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlaylistCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblCardType)
        Me.Controls.Add(Me.playPause)
        Me.Controls.Add(Me.PlaylistName)
        Me.Controls.Add(Me.TableLayout)
        Me.Name = "PlaylistCard"
        Me.Size = New System.Drawing.Size(200, 200)
        CType(Me.Cover1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayout.ResumeLayout(False)
        CType(Me.Cover4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cover3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cover2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.playPause, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cover1 As PictureBox
    Friend WithEvents TableLayout As TableLayoutPanel
    Friend WithEvents Cover4 As PictureBox
    Friend WithEvents Cover3 As PictureBox
    Friend WithEvents Cover2 As PictureBox
    Friend WithEvents PlaylistName As Label
    Friend WithEvents playPause As PictureBox
    Friend WithEvents lblCardType As Label
End Class
