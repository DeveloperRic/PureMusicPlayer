<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tile
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
        Me._text = New System.Windows.Forms.Label()
        Me._separator = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        '_text
        '
        Me._text.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._text.AutoSize = True
        Me._text.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me._text.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me._text.Location = New System.Drawing.Point(3, 9)
        Me._text.Name = "_text"
        Me._text.Size = New System.Drawing.Size(52, 20)
        Me._text.TabIndex = 5
        Me._text.Text = "Home"
        Me._text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        '_separator
        '
        Me._separator.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me._separator.Location = New System.Drawing.Point(3, 32)
        Me._separator.Name = "_separator"
        Me._separator.Size = New System.Drawing.Size(52, 1)
        Me._separator.TabIndex = 6
        '
        'Tile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me._text)
        Me.Controls.Add(Me._separator)
        Me.Name = "Tile"
        Me.Size = New System.Drawing.Size(60, 40)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents _text As Label
    Friend WithEvents _separator As Panel
End Class
