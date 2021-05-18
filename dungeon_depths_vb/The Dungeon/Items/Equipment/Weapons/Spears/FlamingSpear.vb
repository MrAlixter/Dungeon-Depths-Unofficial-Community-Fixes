Public Class FlamingSpear
    Inherits Spear

    Sub New()
        '|ID Info|
        setName("Flaming_Spear")
        id = 157
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        MyBase.a_boost = 37
        MyBase.s_boost = -1
        count = 0
        value = 1820
        MyBase.weight = 25

        '|Description|
        setDesc("A unique spear that's perpetually on fire.  While it hits for a lot of damage, it also takes damage from physical attacks as well as throws." & DDUtils.RNRN &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+37 ATK" & vbCrLf &
                       "-1 SPD")
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
