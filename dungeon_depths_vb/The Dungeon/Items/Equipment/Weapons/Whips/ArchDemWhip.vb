Public Class ArchDemWhip
    Inherits Whip

    Sub New()
        setName("Archdemon_Whip")
        setDesc("A studded black leather whip that burns with a naughty aura that critically hits more often than a standard sword." & vbCrLf & _
                       "+66 ATK")
        usable = false
        MyBase.a_boost = 66
        droppable = True
        id = 218
        tier = 3
        count = 0
        value = 6666
    End Sub

    Public Overrides Function getTier() As Integer
        If Game.currFloor IsNot Nothing AndAlso Game.currFloor.floorNumber > 14 Then
            Return 3
        Else
            Return Nothing
        End If
    End Function

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        p.lust += 20
        Return MyBase.attack(p, m)
    End Function
End Class
