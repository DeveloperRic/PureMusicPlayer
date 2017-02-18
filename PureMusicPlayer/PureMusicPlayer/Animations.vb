Module Animations
    Public Class FadeAnimation
        Dim control As Control
        Dim finishAlpha, alpha As Integer
        Dim speed As Decimal
        Dim initialColour As Color
        Dim isForeColour, fadeIn As Boolean
        Public Sub New(ByVal control As Control, Optional ByVal fadeIn As Boolean = True, Optional ByVal finishAlpha As Integer = 255, Optional ByVal isForeColour As Boolean = False, Optional ByVal speed As Decimal = 1)
            Me.isForeColour = isForeColour
            Me.fadeIn = fadeIn
            Me.control = control
            Me.finishAlpha = finishAlpha
            If isForeColour Then
                initialColour = Me.control.ForeColor
            Else
                initialColour = Me.control.BackColor
            End If
            If fadeIn Then
                alpha = 0
            Else
                alpha = initialColour.A
            End If
            Me.speed = finishAlpha / ((speed * 1000) / 50)
        End Sub
        Public Async Sub run()
            Dim complete As Boolean
            While Not complete
                Try
                    If isForeColour Then
                        control.ForeColor = Color.FromArgb(alpha, initialColour.R, initialColour.G, initialColour.B)
                    Else
                        control.BackColor = Color.FromArgb(alpha, initialColour.R, initialColour.G, initialColour.B)
                    End If
                    If fadeIn Then
                        alpha += speed 'amount of opacity change for each timer tick
                        If alpha >= finishAlpha Then
                            complete = True
                        End If
                    Else
                        alpha -= speed
                        If alpha <= finishAlpha Then
                            complete = True
                        End If
                    End If
                Catch ex As Exception
                    complete = True
                End Try
                Await Task.Delay(50)
            End While
        End Sub
    End Class
    Public Class CompoundFadeAnimation
        Dim control As Control
        Dim speed As Decimal
        Dim finishAlpha As Integer
        Dim fadeIn, isForeColour As Boolean
        Public Sub New(ByVal control As Control, Optional ByVal fadeIn As Boolean = True, Optional ByVal finishAlpha As Integer = 255, Optional ByVal isForeColour As Boolean = False, Optional ByVal speed As Decimal = 1)
            Me.control = control
            Me.speed = speed
            Me.finishAlpha = finishAlpha
            Me.fadeIn = fadeIn
            Me.isForeColour = isForeColour
        End Sub
        Public Sub run()
            process(control)
        End Sub
        Private Sub process(ByVal c As Control)
            Dim animation As New FadeAnimation(c, fadeIn, finishAlpha, isForeColour, speed)
            animation.run()
            For Each co As Control In c.Controls
                process(co)
            Next
        End Sub
    End Class
    Public Class TextSlider
        Dim original As String
        Dim current As String
        Dim control As Control
        Dim speed As Integer
        Dim leftPointer, rightPointer As Integer
        Dim length As Integer
        Public enabled As Boolean
        Public Sub New(ByVal c As Control, ByVal str As String, Optional ByVal speed As Integer = 1, Optional length As Integer = 15)
            Me.original = str.Replace(vbNullChar, "")
            Me.length = length
            current = original.Substring(0, length)
            Me.control = c
            Me.speed = speed
            rightPointer = current.Length - 1
        End Sub
        Public Async Sub run()
            enabled = True
            While enabled
                Dim trimC As String = current
                trimC.Trim()
                If Not leftPointer < 0 Then
                    If Not leftPointer + 1 + rightPointer + speed + 1 > original.Length Then
                        'Calculates positions while original moves out of view (<<<) "abcd[efghijklmn]opqr"
                        leftPointer += speed
                        rightPointer += speed
                        current = original.Substring(leftPointer, rightPointer + 1)
                    ElseIf trimC.Length > 0 Then
                        If Not leftPointer + speed > original.Length Then
                            'Adds spaces ' ' to original while original is exiting "abcd[efgh"      ]
                            leftPointer += speed
                            current = original.Substring(leftPointer) + " "
                        Else
                            'Fills entire area with spaces ' ' to prepare for orignial re-entering [          ]"abcdefg"
                            leftPointer = -1
                            rightPointer = 0
                            Dim ex As String = ""
                            For i = 1 To length + 2
                                ex += " "
                            Next
                            current = ex & original.Substring(rightPointer)
                            current = current.Substring(0, (2 * length) + 2)
                        End If
                    End If
                Else
                    rightPointer += speed
                    Dim ex As String = ""
                    For i = 1 To length + 2
                        ex += " "
                    Next
                    current = ex & original
                    If rightPointer + (2 * length) + 2 <= current.Length Then
                        'Trims spaces ' ' from begining upon original re-entering [      "abcd]efg"
                        current = current.Substring(rightPointer, (2 * length) + 2)
                    Else
                        Dim dif As Integer = (rightPointer + (2 * length) + 2) - current.Length
                        If Not rightPointer + 1 >= original.Length Then
                            'Trims spaces ' ' from begining after original re-entering [      "abcd]efg" AND pushes original along if shorter than space [   "abcdefg" ]
                            current = current.Substring(rightPointer, (2 * length) + 2 - dif)
                        Else
                            'Resets Algorithm once a cycle is complete ["abcdefg]hijklmn"
                            leftPointer = 0
                            rightPointer = current.Length - 1
                            current = original
                            Await Task.Delay(2500)
                        End If
                    End If
                End If
                control.Text = current
                Await Task.Delay(250)
            End While
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
