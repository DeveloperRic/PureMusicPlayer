Module Animations
    Public Class TranslationAnimation
        Dim tmr As New Timer
        Dim control As Control
        Dim curX, curY, startX, startY, endX, endY As Decimal
        Dim increment As Decimal
        Dim speed As Decimal
        Dim moveX, moveY As Boolean
        Public Sub New(ByVal c As Control, ByVal vectorX As Decimal, ByVal vectorY As Decimal, Optional ByVal startX As Decimal = -0, Optional ByVal startY As Decimal = -0, Optional ByVal increment As Decimal = 5, Optional ByVal speed As Decimal = 1)
            control = c
            tmr.Interval = 50 '1 Second
            tmr.Enabled = False
            AddHandler tmr.Tick, AddressOf MyTimerTick
            If startX = 0 Then
                startX = c.Location.X
            End If
            If startY = 0 Then
                startY = c.Location.Y
            End If
            endX = startX + vectorX
            endY = startY + vectorY
            curX = startX
            curY = startY
            Me.increment = increment
            Me.speed = speed
        End Sub
        Public Sub toggleProcessor(ByVal t As Boolean)
            If tmr IsNot Nothing Then
                moveX = t
                moveY = t
                tmr.Enabled = t
            End If
        End Sub
        Private Sub MyTimerTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If curX >= endX Then
                moveX = False
            End If
            If curY >= endY Then
                moveY = False
            End If
            If moveX Then
                curX += increment * speed
            End If
            If moveY Then
                curY += increment * speed
            End If
            control.Location = New Point(curX, curY)
        End Sub
    End Class
    Public Class CompoundFadeAnimation
        Dim control As Control
        Dim s As Decimal
        Dim a As Integer
        Dim reverse, track As Boolean
        Public complete As Boolean
        Dim count As Integer
        Public Sub New(ByVal c As Control, Optional ByVal s As Decimal = 1, Optional ByVal a As Integer = 255, Optional ByVal reverse As Boolean = False, Optional ByVal track As Boolean = False)
            control = c
            Me.s = s
            Me.a = a
            Me.reverse = reverse
            Me.track = track
        End Sub
        Public Sub run()
            process(control)
        End Sub
        Private Sub process(ByVal c As Control)
            count += 1
            If Not reverse Then
                Dim f As New FadeAnimation(c, s, a, Me)
                f.toggleProcessor(True)
            Else
                Dim f As New ReverseFadeAnimation(c, s, a, Me)
                f.toggleProcessor(True)
            End If
            For Each co As Control In c.Controls
                process(co)
            Next
        End Sub
        Public Sub notifyProcessComplete()
            If track Then
                count -= 1
                If count <= 0 Then
                    'MainPlayer.notifyFinishTransistionSec()
                End If
            End If
        End Sub
    End Class
    Public Class FadeAnimation
        Dim fadeControl As Control
        Dim fadeIntoAlpha As Integer
        Dim fadeQueue As New List(Of FadeQueueItem)
        Dim r, g, b, a, s As Integer
        Dim fr, fg, fb As Integer
        Dim tmr As New Timer
        Public complete As Boolean
        Dim compound As CompoundFadeAnimation
        Public Sub New(ByVal c As Control, Optional ByVal s As Decimal = 1, Optional ByVal a As Integer = 255, Optional ByRef compound As CompoundFadeAnimation = Nothing)
            tmr.Interval = 50 '1 Second
            tmr.Enabled = False
            AddHandler tmr.Tick, AddressOf MyTimerTick
            If tmr.Enabled = False Then
                loadFadeParams(c, a, s)
            Else
                c.Hide()
                Dim f As New FadeQueueItem(c, a, s)
                fadeQueue.Add(f)
            End If
            Me.compound = compound
        End Sub
        Public Sub toggleProcessor(ByVal t As Boolean)
            tmr.Enabled = t
        End Sub
        Private Sub MyTimerTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'timer event handler
            Try
                fadeControl.BackColor = Color.FromArgb(a, r, g, b)
                fadeControl.ForeColor = Color.FromArgb(a, fr, fg, fb)
                a += s 'amount of opacity change for each timer tick
                If a >= fadeIntoAlpha Then
                    tmr.Enabled = False 'finished fade-in
                    If fadeQueue.Count > 0 Then
                        Dim f As FadeQueueItem = fadeQueue(0)
                        f.c.Show()
                        loadFadeParams(f.c, f.a, f.s)
                        tmr.Enabled = True
                        fadeQueue.Remove(f)
                    Else
                        complete = True
                        If compound IsNot Nothing Then
                            compound.notifyProcessComplete()
                        End If
                    End If
                End If
            Catch ex As Exception
                tmr.Enabled = False
                complete = True
                If compound IsNot Nothing Then
                    compound.notifyProcessComplete()
                End If
            End Try
        End Sub
        Private Sub loadFadeParams(ByVal c As Control, ByVal a As Integer, ByVal s As Decimal)
            fadeControl = c
            fadeIntoAlpha = a
            r = fadeControl.BackColor.R
            g = fadeControl.BackColor.G
            b = fadeControl.BackColor.B
            fr = fadeControl.ForeColor.R
            fg = fadeControl.ForeColor.G
            fb = fadeControl.ForeColor.B
            Me.a = 0
            Me.s = a / ((s * 1000) / 50)
        End Sub
        Public Class FadeQueueItem
            Public c As Control
            Public a As Integer
            Public s As Decimal
            Sub New(ByVal c As Control, Optional ByVal a As Integer = 255, Optional ByVal s As Decimal = 1)
                Me.c = c
                Me.a = a
                Me.s = s
            End Sub
        End Class
    End Class
    Public Class ReverseFadeAnimation
        Dim fadeControl As Control
        Dim fadeIntoAlpha As Integer
        Dim fadeQueue As New List(Of FadeQueueItem)
        Dim r, g, b, a, s As Integer
        Dim fr, fg, fb As Integer
        Dim tmr As New Timer
        Public complete As Boolean
        Dim compound As CompoundFadeAnimation
        Public Sub New(ByVal c As Control, Optional ByVal s As Decimal = 1, Optional ByVal a As Integer = 255, Optional ByRef compound As CompoundFadeAnimation = Nothing)
            tmr.Interval = 50 '1 Second
            tmr.Enabled = False
            AddHandler tmr.Tick, AddressOf MyTimerTick
            If tmr.Enabled = False Then
                loadFadeParams(c, a, s)
            Else
                c.Hide()
                Dim f As New FadeQueueItem(c, a, s)
                fadeQueue.Add(f)
            End If
            Me.compound = compound
        End Sub
        Public Sub toggleProcessor(ByVal t As Boolean)
            tmr.Enabled = t
        End Sub
        Private Sub MyTimerTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'timer event handler
            Try
                fadeControl.BackColor = Color.FromArgb(a, r, g, b)
                fadeControl.ForeColor = Color.FromArgb(a, fr, fg, fb)
                a -= s 'amount of opacity change for each timer tick
                If a <= fadeIntoAlpha Then
                    tmr.Enabled = False 'finished fade-in
                    If fadeQueue.Count > 0 Then
                        Dim f As FadeQueueItem = fadeQueue(0)
                        f.c.Show()
                        loadFadeParams(f.c, f.a, f.s)
                        tmr.Enabled = True
                        fadeQueue.Remove(f)
                    Else
                        complete = True
                        If compound IsNot Nothing Then
                            compound.notifyProcessComplete()
                        End If
                    End If
                End If
            Catch ex As Exception
                tmr.Enabled = False
                complete = True
                If compound IsNot Nothing Then
                    compound.notifyProcessComplete()
                End If
            End Try
        End Sub
        Private Sub loadFadeParams(ByVal c As Control, ByVal a As Integer, ByVal s As Decimal)
            fadeControl = c
            fadeIntoAlpha = a
            r = fadeControl.BackColor.R
            g = fadeControl.BackColor.G
            b = fadeControl.BackColor.B
            fr = fadeControl.ForeColor.R
            fg = fadeControl.ForeColor.G
            fb = fadeControl.ForeColor.B
            Me.a = 0
            Me.s = a / ((s * 1000) / 50)
        End Sub
        Public Class FadeQueueItem
            Public c As Control
            Public a As Integer
            Public s As Decimal
            Sub New(ByVal c As Control, Optional ByVal a As Integer = 255, Optional ByVal s As Decimal = 1)
                Me.c = c
                Me.a = a
                Me.s = s
            End Sub
        End Class
    End Class
    Public Class TextSlider
        Dim org As String
        Dim cur As String
        Dim control As Control
        Dim speed As Integer
        Dim tmr As New Timer
        Dim lp As Integer = 0
        Dim rp As Integer
        Dim length As Integer
        Public Sub New(ByVal c As Control, ByVal str As String, Optional ByVal speed As Integer = 1, Optional length As Integer = 15)
            tmr.Interval = 250 '1 Second
            tmr.Enabled = False
            AddHandler tmr.Tick, AddressOf MyTimerTick
            Me.org = str.Replace(vbNullChar, "")
            Me.length = length
            cur = org.Substring(0, length)
            Me.control = c
            Me.speed = speed
            rp = cur.Length - 1
        End Sub
        Public Sub toggleProcessor(ByVal t As Boolean)
            tmr.Enabled = t
        End Sub
        Private Sub MyTimerTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim trimC As String = cur
            trimC.Trim()
            If Not lp < 0 Then
                If Not lp + 1 + rp + speed + 1 > org.Length Then
                    lp += speed
                    rp += speed
                    cur = org.Substring(lp, rp + 1)
                ElseIf trimC.Length > 0 Then
                    If Not lp + speed > org.Length Then
                        lp += speed
                        cur = org.Substring(lp) + " "
                    Else
                        lp = -1
                        rp = 0
                        Dim ex As String = ""
                        For i = 1 To length + 2
                            ex += " "
                        Next
                        cur = ex & org.Substring(rp)
                        cur = cur.Substring(0, (2 * length) + 2)
                    End If
                End If
            Else
                rp += speed
                Dim ex As String = ""
                For i = 1 To length + 2
                    ex += " "
                Next
                cur = ex & org
                If rp + (2 * length) + 2 <= cur.Length Then
                    cur = cur.Substring(rp, (2 * length) + 2)
                Else
                    Dim dif As Integer = (rp + (2 * length) + 2) - cur.Length
                    If Not rp + 1 >= org.Length Then
                        cur = cur.Substring(rp, (2 * length) + 2 - dif)
                    Else
                        lp = 0
                        rp = cur.Length - 1
                        cur = org
                    End If
                End If
            End If
            control.Text = cur
        End Sub
    End Class
    Public Class HueCycle
        Dim control As Control
        Dim a, r, g, b, s As Integer
        Dim tmr As New Timer
        Public Sub New(ByVal c As Control, Optional ByVal s As Decimal = 10)
            tmr.Interval = 5
            tmr.Enabled = False
            AddHandler tmr.Tick, AddressOf MyTimerTick
            loadParams(c, s)
        End Sub
        Public Sub toggleProcessor(ByVal t As Boolean)
            tmr.Enabled = t
        End Sub
        Private Sub MyTimerTick(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                If b >= 255 Then
                    b = 0
                    g += s
                    If g >= 255 Then
                        g = 0
                        r += s
                        If r >= 255 Then
                            r = 0
                        End If
                    Else
                        g += s
                    End If
                Else
                    b += s
                End If
                control.ForeColor = Color.FromArgb(a, r, g, b)
            Catch ex As Exception
            End Try
        End Sub
        Private Sub loadParams(ByVal c As Control, ByVal s As Decimal)
            control = c
            a = control.BackColor.A
            r = control.BackColor.R
            g = control.BackColor.G
            b = control.BackColor.B
            Me.s = s
        End Sub
    End Class
    Public Class CompoundColourSet
        Dim control As Control
        Dim backColor, foreColor As Color
        Public Sub New(ByVal control As Control, ByVal backColor As Color, Optional ByVal foreColor As Color = Nothing)
            Me.control = control
            If foreColor = Nothing Then
                Me.foreColor = control.ForeColor
            End If
            Me.backColor = backColor
        End Sub
        Public Sub run()
            process(control)
        End Sub
        Private Sub process(ByVal control As Control)
            Try
                control.BackColor = backColor
                control.ForeColor = foreColor
                For Each c In control.Controls
                    process(c)
                Next
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Module
