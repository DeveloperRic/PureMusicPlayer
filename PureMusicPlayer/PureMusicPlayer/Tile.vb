Public Class Tile
    Private _base As TileManager
    Private _type As TileManager.TileType
    Private _active As Boolean
    Private _showSeparator As Boolean
    Private _args As Object()
    Public Sub New(ByRef base As TileManager, ByVal type As TileManager.TileType, Optional ByVal label As String = "", Optional ByVal args() As Object = Nothing, Optional ByVal separator As Boolean = False)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _base = base
        _type = type
        ShowSeparator = separator
        Me._args = args
        ItemWidth = base.panel.ClientSize.Width - 20
        Me.Label = label
        If Not (type = TileManager.TileType.BLANK Or type = TileManager.TileType.DUMMY) Then
            _text.ForeColor = ColorTranslator.FromHtml("#ffebee")
            AddHandler Click, AddressOf handleClick
            AddHandler _text.Click, AddressOf handleClick
            AddHandler MouseEnter, AddressOf handleEnter
            AddHandler _text.MouseEnter, AddressOf handleEnter
            AddHandler MouseLeave, AddressOf handleLeave
            AddHandler _text.MouseLeave, AddressOf handleLeave
        ElseIf type = TileManager.TileType.DUMMY Then
            _text.ForeColor = ColorTranslator.FromHtml("#8C8C8C")
            _text.Font = New Font(_text.Font.FontFamily, _text.Font.Size - 2, FontStyle.Italic)
            _separator.Hide()
            Me.Label = Me.Label.ToUpper
            ShowSeparator = True
        End If
    End Sub
    Public Sub New(ByRef base As TileManager, ByVal type As TileManager.TileType, Optional ByVal label As String = "", Optional ByVal args() As Action = Nothing, Optional ByVal separator As Boolean = False)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        _base = base
        _type = type
        ShowSeparator = separator
        Me._args = args
        ItemWidth = base.panel.ClientSize.Width - 20
        Me.Label = label
        If Not (type = TileManager.TileType.BLANK Or type = TileManager.TileType.DUMMY) Then
            _text.ForeColor = ColorTranslator.FromHtml("#ffebee")
            AddHandler Click, AddressOf handleClick
            AddHandler _text.Click, AddressOf handleClick
            AddHandler MouseEnter, AddressOf handleEnter
            AddHandler _text.MouseEnter, AddressOf handleEnter
            AddHandler MouseLeave, AddressOf handleLeave
            AddHandler _text.MouseLeave, AddressOf handleLeave
        ElseIf type = TileManager.TileType.DUMMY Then
            _text.ForeColor = ColorTranslator.FromHtml("#8C8C8C")
            _text.Font = New Font(_text.Font.FontFamily, _text.Font.Size - 2, FontStyle.Italic)
            _separator.Hide()
            Me.Label = Me.Label.ToUpper
            ShowSeparator = True
        End If
    End Sub
    Public Sub handleClick()
        Select Case _type
            Case TileManager.TileType.PLAYER_PAGE
                Try
                    Dim page As MainPlayer.MainPlayerPage = Args(0)
                    MainPlayer.CurrentPage = page
                Catch ex As Exception
                    sendNotification("Internal error: player page not referenced", 3)
                End Try
            Case TileManager.TileType.OPEN_WINDOW
                Try
                    Dim form As Form = Args(0)
                    form.Show()
                Catch ex As Exception
                    sendNotification("Internal error: Window not referenced", 3)
                End Try
            Case TileManager.TileType.PLAYLIST
                Dim data As New MainPlayer.MainPlayerPageData(MainPlayer.MainPlayerPage.PLAYLIST, Args)
                MainPlayer.CurrentPageWithData = data
            Case TileManager.TileType.ALBUM
                Dim data As New MainPlayer.MainPlayerPageData(MainPlayer.MainPlayerPage.ALBUM, Args)
                MainPlayer.CurrentPageWithData = data
            Case TileManager.TileType.RUN_CODE
                Try
                    Dim action As Action = Args(0)
                    action.Invoke
                Catch ex As Exception
                    sendNotification("Internal error: code to run not referenced", 3)
                End Try
        End Select
    End Sub
    Public Sub handleEnter()
        BackColor = ColorTranslator.FromHtml("#191919")
    End Sub
    Public Sub handleLeave()
        BackColor = ColorTranslator.FromHtml("#101010")
    End Sub
    <System.ComponentModel.Category("Behaviour")>
    Public Property Type() As TileManager.TileType
        Get
            Return _type
        End Get
        Set(ByVal Value As TileManager.TileType)
            _type = Value
        End Set
    End Property
    <System.ComponentModel.Category("Behaviour")>
    Public Property Args() As Object()
        Get
            Return _args
        End Get
        Set(ByVal Value As Object())
            _args = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property ItemWidth() As Integer
        Get
            Return Me.Width
        End Get
        Set(ByVal Value As Integer)
            Me.Width = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property Label() As String
        Get
            Return _text.Text
        End Get
        Set(ByVal Value As String)
            _text.Text = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal Value As Boolean)
            If Value Then
                _text.Show()
                _separator.Visible = _showSeparator
            Else
                _text.Hide()
                _separator.Hide()
            End If
            _active = Value
        End Set
    End Property
    <System.ComponentModel.Category("Appearance")>
    Public Property ShowSeparator() As String
        Get
            Return _showSeparator
        End Get
        Set(ByVal Value As String)
            _separator.Visible = Value
            _showSeparator = Value
        End Set
    End Property
End Class
