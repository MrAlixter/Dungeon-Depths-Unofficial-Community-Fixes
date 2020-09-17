Public Class DemWhip
    Inherits Whip

    Sub New()
        MyBase.setName("Demonic_Whip")
        MyBase.setDesc("A black leather whip that burns with a naughty aura and critically hits more often than a standard sword.  " & vbCrLf & _
                       "+38 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 38
        isMonsterDrop = True
        id = 217
        tier = Nothing
        MyBase.count = 0
        MyBase.value = 3333
    End Sub

    Public Overrides Function getTier() As Integer
        Try
            If Game.currFloor.floorNumber > 7 Then Return 3
        Catch ex As Exception
        End Try

        Return Nothing
    End Function

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        p.lust += 10
        Return MyBase.attack(p, m)
    End Function
End Class
