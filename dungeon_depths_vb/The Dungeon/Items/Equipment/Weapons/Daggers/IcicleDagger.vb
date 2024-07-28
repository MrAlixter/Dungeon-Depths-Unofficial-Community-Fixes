Public Class IcicleDagger
    Inherits Dagger

    Public Const ITEM_NAME As String = "Icicle_Dagger"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 433
        tier = 2

        '|Item Flags|
        usable = False
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 644
        a_boost = 18

        '|Description|
        setDesc("A spike of ice that can be wielded like a dagger." & DDUtils.RNRN &
                "When attacking, the user hits twice." & DDUtils.RNRN &
                "Attacking with this weapon will cause it to take massive damage." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg = MyBase.attack(p, m)

        If dmg = -2 Then
            damage(999)
        ElseIf dmg <> -1 Then
            damage(45 + Int(Rnd() * 100))
        End If

        Return dmg
    End Function
End Class
