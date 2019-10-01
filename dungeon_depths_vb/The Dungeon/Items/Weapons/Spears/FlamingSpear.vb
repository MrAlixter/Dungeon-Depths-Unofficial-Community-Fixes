Public Class FlamingSpear
    Inherits Spear

    Sub New()
        MyBase.setName("Flaming_Spear")
        MyBase.setDesc("A unique spear that's perpetually on fire.  While it hits for a lot of damage, it also takes damage from physical attacks as well as throws." & vbCrLf &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+37 ATK" & vbCrLf &
                       "-1 SPD")
        id = 157
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.aBoost = 37
        MyBase.sBoost = -1
        MyBase.count = 0
        MyBase.value = 900
        MyBase.weight = 25
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg = MyBase.attack(p, m)

        If dmg <> -1 Then
            durability -= weight
            If durability <= 0 Then break()
        End If

        Return dmg
    End Function
End Class
