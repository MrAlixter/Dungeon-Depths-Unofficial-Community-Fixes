Public Class FlamingSpear
    Inherits Spear

    Public Const ITEM_NAME As String = "Flaming_Spear"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 157
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        a_boost = 37
        s_boost = -1
        count = 0
        value = 1820
        weight = 25

        '|Description|
        setDesc("A unique spear that's perpetually on fire.  While it hits for a lot of damage, it also takes damage from physical attacks as well as throws." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
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
