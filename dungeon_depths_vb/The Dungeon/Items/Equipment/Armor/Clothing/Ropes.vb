Public Class Ropes
    Inherits Armor

    Public Const ITEM_NAME As String = "Ropes"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 54
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = False
        cursed = True
        bind_wearer = True
        hide_dick = False

        '|Stats|
        s_boost = -15
        count = 0
        value = 100

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(13, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(63, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(72, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(73, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(74, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(75, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(76, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(19, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(44, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(45, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(46, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(47, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)

        '|Description|
        setDesc("A tightened set of ropes that both reduces mobility and leaves one nearly naked." & DDUtils.RNRN &
                "May not be easy to remove" & DDUtils.RNRN &
                getStatInformation() & DDUtils.RNRN &
                getSizeInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.pForm.canBeBound Then
            EquipmentDialogBackend.equipArmor(p, "Naked")
            TextEvent.push("You effortlessly break your bonds.")
            TextEvent.pushLog("You effortlessly break your bonds.")
        Else
            'p.perks(perk.gagged) = 1
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.bind_wearer = False
        MyBase.bind_wearer = True

        'p.perks(perk.gagged) = -1
    End Sub
End Class
