Public Class IcespikeSpear
    Inherits Spear

    Public Const ITEM_NAME As String = "Icespike_Pike"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 432
        tier = Nothing

        '|Item Flags|
        usable = True
        npc_drop_only = True

        '|Stats|
        a_boost = 44
        s_boost = -10
        count = 0
        value = 644
        weight = 50

        '|Description|
        setDesc("A hefty column of ice that can be wielded like a spear.  Some would even call it an ""Icicle Spear"", but they would be swiftly reprimanded by the Lord High Wizard; author of many common spellbooks." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                "Attacking with or throwing this weapon will cause it to take massive damage." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg = MyBase.attack(p, m)

        If dmg = -2 Then
            damage(999)
        ElseIf dmg <> -1 Then
            damage(33 + Int(Rnd() * 100))
        End If

        Return dmg
    End Function
End Class
