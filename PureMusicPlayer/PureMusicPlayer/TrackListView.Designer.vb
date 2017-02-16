<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrackListView
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
        Me.list = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tableLayout = New System.Windows.Forms.TableLayoutPanel()
        Me.fontRegular = New System.Windows.Forms.Label()
        Me._duration = New System.Windows.Forms.Label()
        Me._year = New System.Windows.Forms.Label()
        Me._album = New System.Windows.Forms.Label()
        Me._artist = New System.Windows.Forms.Label()
        Me._name = New System.Windows.Forms.Label()
        Me._separator = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.tableLayout.SuspendLayout()
        Me.SuspendLayout()
        '
        'list
        '
        Me.list.AutoScroll = True
        Me.list.Dock = System.Windows.Forms.DockStyle.Fill
        Me.list.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.list.Location = New System.Drawing.Point(0, 33)
        Me.list.Name = "list"
        Me.list.Size = New System.Drawing.Size(1031, 433)
        Me.list.TabIndex = 4
        Me.list.WrapContents = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tableLayout)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1031, 33)
        Me.Panel1.TabIndex = 5
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
        Me.tableLayout.Controls.Add(Me.fontRegular, 0, 0)
        Me.tableLayout.Controls.Add(Me._duration, 5, 0)
        Me.tableLayout.Controls.Add(Me._year, 4, 0)
        Me.tableLayout.Controls.Add(Me._album, 3, 0)
        Me.tableLayout.Controls.Add(Me._artist, 2, 0)
        Me.tableLayout.Controls.Add(Me._name, 1, 0)
        Me.tableLayout.Controls.Add(Me._separator, 0, 1)
        Me.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayout.Location = New System.Drawing.Point(0, 0)
        Me.tableLayout.Name = "tableLayout"
        Me.tableLayout.RowCount = 2
        Me.tableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.83691!))
        Me.tableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.16309!))
        Me.tableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayout.Size = New System.Drawing.Size(1031, 33)
        Me.tableLayout.TabIndex = 2
        '
        'fontRegular
        '
        Me.fontRegular.AutoSize = True
        Me.fontRegular.Dock = System.Windows.Forms.DockStyle.Left
        Me.fontRegular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontRegular.Location = New System.Drawing.Point(3, 5)
        Me.fontRegular.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.fontRegular.Name = "fontRegular"
        Me.fontRegular.Size = New System.Drawing.Size(11, 23)
        Me.fontRegular.TabIndex = 6
        Me.fontRegular.Text = "."
        Me.fontRegular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_duration
        '
        Me._duration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me._duration.AutoSize = True
        Me._duration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._duration.Location = New System.Drawing.Point(970, 5)
        Me._duration.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._duration.Name = "_duration"
        Me._duration.Size = New System.Drawing.Size(58, 23)
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
        Me._year.Location = New System.Drawing.Point(845, 5)
        Me._year.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._year.Name = "_year"
        Me._year.Size = New System.Drawing.Size(37, 23)
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
        Me._album.Location = New System.Drawing.Point(612, 5)
        Me._album.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._album.Name = "_album"
        Me._album.Size = New System.Drawing.Size(46, 23)
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
        Me._artist.Location = New System.Drawing.Point(343, 5)
        Me._artist.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._artist.Name = "_artist"
        Me._artist.Size = New System.Drawing.Size(37, 23)
        Me._artist.TabIndex = 1
        Me._artist.Text = "Artist"
        Me._artist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_name
        '
        Me._name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._name.AutoSize = True
        Me._name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._name.Location = New System.Drawing.Point(52, 5)
        Me._name.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me._name.Name = "_name"
        Me._name.Size = New System.Drawing.Size(83, 23)
        Me._name.TabIndex = 0
        Me._name.Text = "Track Name"
        Me._name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_separator
        '
        Me.tableLayout.SetColumnSpan(Me._separator, 6)
        Me._separator.Dock = System.Windows.Forms.DockStyle.Fill
        Me._separator.Location = New System.Drawing.Point(3, 31)
        Me._separator.Name = "_separator"
        Me._separator.Size = New System.Drawing.Size(1025, 1)
        Me._separator.TabIndex = 5
        '
        'TrackListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.Controls.Add(Me.list)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TrackListView"
        Me.Size = New System.Drawing.Size(1031, 466)
        Me.Panel1.ResumeLayout(False)
        Me.tableLayout.ResumeLayout(False)
        Me.tableLayout.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents list As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tableLayout As TableLayoutPanel
    Friend WithEvents _duration As Label
    Friend WithEvents _year As Label
    Friend WithEvents _album As Label
    Friend WithEvents _artist As Label
    Friend WithEvents _name As Label
    Friend WithEvents _separator As Panel
    Friend WithEvents fontRegular As Label
End Class
