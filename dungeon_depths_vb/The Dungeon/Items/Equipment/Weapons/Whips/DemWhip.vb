Public Class DemWhip
    Inherits Whip

    Sub New()
        setName("Demonic_Whip")
        setDesc("A black leather whip that burns with a naughty aura and critically hits more often than a standard sword.  " & vbCrLf & _
                       "+38 ATK")
        usable = false
        MyBase.a_boost = 38
        droppable = True
        id = 217
        tier = Nothing
        count = 0
        value = 3333
    End Sub

    Public Overrides Function getTier() As Integer
        If Game.currFloor IsNot Nothing AndAlso Game.currFloor.floorNumber > 7 Then
            Return 3
        Else
            Return Nothing
        End If
    End Function

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        p.lust += 10
        Return MyBase.attack(p, m)
    End Function
End Class
