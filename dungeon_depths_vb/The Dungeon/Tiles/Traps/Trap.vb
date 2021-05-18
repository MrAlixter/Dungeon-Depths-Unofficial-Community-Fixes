Public Enum tInd
    dart
    rope
    ruby
    coupon
    mirror
    doctor
    gynoid1
    button1
    gynoid2
End Enum
Public Class Trap
    Public pos As Point
    Public iD As Integer

    Sub New(ByVal p As Point)
        pos = p
        iD = Int(Rnd() * 5)
    End Sub

    Shared Function trapFactory(ByVal s As String)
        Dim cArray() As String = s.Split("*")
        Dim p = New Point(CInt(cArray(0)), CInt(cArray(1)))
        Dim i = CInt(cArray(2))

        Return trapFactory(i, p)
    End Function
    Shared Function trapFactory(ByVal i As Integer, ByVal p As Point)
        Select Case i
            Case tInd.rope
                Return New RopeTrap(p)
            Case tInd.ruby
                Return New RubyTrap(p)
            Case tInd.coupon
                Return New CouponTrap(p)
            Case tInd.mirror
                Return New TGMirrorTrap(p)
            Case tInd.doctor
                Return New DoctorScanner(p)
            Case tInd.gynoid1
                Return New GynoidTrap(p)
            Case tInd.button1
                Return New Button1Trap(p)
            Case tInd.gynoid2
                Return New GynoidTrap2(p)
            Case Else
                Return New DartTrap(p)
        End Select

    End Function

    Public Overridable Sub activate()
        Game.pushLstLog("Trap activated!")
        pos = New Point(-1, -1)
    End Sub

    Public Overrides Function ToString() As String
        Return pos.X & "*" & pos.Y & "*" & iD
    End Function
End Class
