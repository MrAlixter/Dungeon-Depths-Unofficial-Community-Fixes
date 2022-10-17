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
    defaultnote
    gag
    faeofwishes
    mspores
    acorn
    broken
End Enum
Public Class Trap
    Private Shared random_traps() As tInd = {tInd.dart, tInd.rope, tInd.ruby, tInd.coupon, tInd.mirror, tInd.gag, tInd.faeofwishes, tInd.mspores}

    Public pos As Point
    Public iD As Integer

    Sub New(ByVal p As Point)
        pos = p
        iD = getRandomTrapId()
    End Sub

    Public Shared Function getRandomTrapId(Optional ByVal floor As Integer = 1) As tInd
        If {6, 7, 8, 9, 10, 11, 12, 13}.Contains(floor) Then
            random_traps = {tInd.ruby, tInd.mirror, tInd.faeofwishes, tInd.mspores, tInd.acorn}
        Else
            random_traps = {tInd.dart, tInd.rope, tInd.ruby, tInd.coupon, tInd.mirror, tInd.gag, tInd.faeofwishes}
        End If

        Return random_traps(Int(Rnd() * random_traps.Count))
    End Function

    Shared Function trapFactory(ByVal s As String)
        Dim cArray() As String = s.Split("*")
        Dim p = New Point(CInt(cArray(0)), CInt(cArray(1)))
        Dim i = CInt(cArray(2))

        Return trapFactory(i, p)
    End Function
    Shared Function trapFactory(ByVal i As Integer, ByVal p As Point)
        If Not Game.player1.forcedPath Is Nothing Then Return New BrokenTrap(p)

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
            Case tInd.defaultnote
                Return New NoteTrap(p)
            Case tInd.gag
                Return New GagTrap(p)
            Case tInd.faeofwishes
                Return New FaeOfWishes(p)
            Case tInd.mspores
                Return New MesmerizingSpores(p)
            Case tInd.acorn
                Return New AcornTrap(p)
            Case Else
                Return New DartTrap(p)
        End Select
    End Function

    Public Overridable Sub activate()
        TextEvent.pushLog("Trap activated!")
        pos = New Point(-1, -1)
    End Sub

    Public Overrides Function ToString() As String
        Return pos.X & "*" & pos.Y & "*" & iD
    End Function
End Class
