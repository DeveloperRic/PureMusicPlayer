<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WelcomeScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WelcomeScreen))
        Me.borderPanel = New System.Windows.Forms.Panel()
        Me.PURE_LOGO = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.closeBox = New System.Windows.Forms.PictureBox()
        Me.minimiseBox = New System.Windows.Forms.PictureBox()
        Me.maximiseBox = New System.Windows.Forms.PictureBox()
        Me.InfoPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.borderPanel.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.closeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.minimiseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.maximiseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'borderPanel
        '
        Me.borderPanel.Controls.Add(Me.PURE_LOGO)
        Me.borderPanel.Controls.Add(Me.Panel7)
        Me.borderPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.borderPanel.Location = New System.Drawing.Point(0, 0)
        Me.borderPanel.Name = "borderPanel"
        Me.borderPanel.Size = New System.Drawing.Size(1264, 24)
        Me.borderPanel.TabIndex = 20
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
        Me.PURE_LOGO.Size = New System.Drawing.Size(79, 21)
        Me.PURE_LOGO.TabIndex = 4
        Me.PURE_LOGO.Text = "Pure Player"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.closeBox)
        Me.Panel7.Controls.Add(Me.minimiseBox)
        Me.Panel7.Controls.Add(Me.maximiseBox)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(1159, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(105, 24)
        Me.Panel7.TabIndex = 3
        '
        'closeBox
        '
        Me.closeBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeBox.BackgroundImage = CType(resources.GetObject("closeBox.BackgroundImage"), System.Drawing.Image)
        Me.closeBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.closeBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.closeBox.Location = New System.Drawing.Point(78, 1)
        Me.closeBox.Name = "closeBox"
        Me.closeBox.Size = New System.Drawing.Size(20, 20)
        Me.closeBox.TabIndex = 0
        Me.closeBox.TabStop = False
        '
        'minimiseBox
        '
        Me.minimiseBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.minimiseBox.BackgroundImage = CType(resources.GetObject("minimiseBox.BackgroundImage"), System.Drawing.Image)
        Me.minimiseBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.minimiseBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.minimiseBox.Location = New System.Drawing.Point(6, 1)
        Me.minimiseBox.Name = "minimiseBox"
        Me.minimiseBox.Size = New System.Drawing.Size(20, 20)
        Me.minimiseBox.TabIndex = 2
        Me.minimiseBox.TabStop = False
        '
        'maximiseBox
        '
        Me.maximiseBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maximiseBox.BackgroundImage = CType(resources.GetObject("maximiseBox.BackgroundImage"), System.Drawing.Image)
        Me.maximiseBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.maximiseBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.maximiseBox.Location = New System.Drawing.Point(42, 1)
        Me.maximiseBox.Name = "maximiseBox"
        Me.maximiseBox.Size = New System.Drawing.Size(20, 20)
        Me.maximiseBox.TabIndex = 1
        Me.maximiseBox.TabStop = False
        '
        'InfoPanel
        '
        Me.InfoPanel.Controls.Add(Me.Label1)
        Me.InfoPanel.Location = New System.Drawing.Point(496, 199)
        Me.InfoPanel.Name = "InfoPanel"
        Me.InfoPanel.Size = New System.Drawing.Size(272, 282)
        Me.InfoPanel.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(77, 231)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PurePlayer"
        '
        'WelcomeScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.InfoPanel)
        Me.Controls.Add(Me.borderPanel)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WelcomeScreen"
        Me.Text = "WelcomeScreen"
        Me.borderPanel.ResumeLayout(False)
        Me.borderPanel.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.closeBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.minimiseBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.maximiseBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InfoPanel.ResumeLayout(False)
        Me.InfoPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents borderPanel As Panel
    Friend WithEvents PURE_LOGO As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents closeBox As PictureBox
    Friend WithEvents minimiseBox As PictureBox
    Friend WithEvents maximiseBox As PictureBox
    Friend WithEvents InfoPanel As Panel
    Friend WithEvents Label1 As Label
End Class
