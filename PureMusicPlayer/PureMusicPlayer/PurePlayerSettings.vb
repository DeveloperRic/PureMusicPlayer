Imports System.IO
Module PurePlayerSettings
    Private initialised As Boolean

    Public Sub init()
        If Not My.Computer.FileSystem.FileExists(filePath & "settings.txt") Then
            Dim writer As New StreamWriter(filePath & "settings.txt", False)
            writer.Close()
        End If
        defaults()
        initialised = True
    End Sub

    Private Sub defaults()
        mainPlayerMaximised = False
        autoDownloadCovers = True
        internetDownloadQuality = DownloadQuality.Medium
    End Sub

    Public Sub loadSettings()
        If Not initialised Then
            init()
        End If
        Using reader As New StreamReader(filePath & "settings.txt")
            While reader.Peek <> -1
                Dim line As String = reader.ReadLine
                Select Case line.Split(":")(0)
                    Case "maximised"
                        mainPlayerMaximised = CBool(line.Split(":")(1))
                    Case "autoDownloadCovers"
                        autoDownloadCovers = CBool(line.Split(":")(1))
                    Case "internetDownloadQuality"
                        internetDownloadQuality = line.Split(":")(1)
                End Select
            End While
        End Using
    End Sub

    Public Sub saveSettings()
        Using writer As New StreamWriter(filePath & "settings.txt", False)
            writer.WriteLine("maximised:" & MainPlayer.maximised)
            writer.WriteLine("autoDownloadCovers" & autoDownloadCovers)
            writer.WriteLine("internetdownloadQuality" & internetDownloadQuality)
        End Using
    End Sub

    Private _mainPlayerMaximised As Boolean
    Public Property mainPlayerMaximised() As Boolean
        Get
            Return _mainPlayerMaximised
        End Get
        Set(ByVal value As Boolean)
            _mainPlayerMaximised = value
            MainPlayer.maximised = value
            If Not value Then
                MainPlayer.Size = New Size(1228, 705)
            Else
                With Screen.PrimaryScreen.WorkingArea
                    MainPlayer.SetBounds(.Left, .Top, .Width, .Height)
                End With
            End If
        End Set
    End Property

    Private _autoDownloadCovers As Boolean
    Public Property autoDownloadCovers() As Boolean
        Get
            Return _autoDownloadCovers
        End Get
        Set(ByVal value As Boolean)
            _autoDownloadCovers = value
        End Set
    End Property

    Public Enum DownloadQuality
        Low = 0
        Medium = 1
        High = 2
    End Enum

    Private _downloadQuality As DownloadQuality
    Public Property internetDownloadQuality() As DownloadQuality
        Get
            Return _downloadQuality
        End Get
        Set(ByVal value As DownloadQuality)
            _downloadQuality = value
        End Set
    End Property
End Module
