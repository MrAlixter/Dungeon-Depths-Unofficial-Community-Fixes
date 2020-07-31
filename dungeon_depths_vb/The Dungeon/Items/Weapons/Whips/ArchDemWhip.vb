Public Class ArchDemWhip
    Inherits Whip

    Sub New()
        MyBase.setName("Archdemon_Whip")
        MyBase.setDesc("A studded black leather whip that burns with a naughty aura that critically hits more often than a standard sword." & vbCrLf & _
                       "+66 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 66
        isMonsterDrop = True
        id = 218
        tier = 3
        MyBase.count = 0
        MyBase.value = 6666
    End Sub

    Public Overrides Function getTier() As Integer
        If Game.currFloor.floorNumber > 14 Then Return 3
        Return MyBase.getTier()
    End Function

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        p.lust += 20
        Return MyBase.attack(p, m)
    End Function
End Class
