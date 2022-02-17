Public Class SpidersilkBonds
    Inherits Armor

    Public Const ITEM_NAME As String = "Spidersilk_Bonds"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 239
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        cursed = True
        bind_wearer = True
        rando_inv_allowed = False
        hide_dick = False

        '|Stats|
        a_boost = -31
        s_boost = -31
        count = 0
        value = 25

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(73, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(74, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(335, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(336, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(337, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(338, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(339, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(72, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(318, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(319, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(320, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(321, True, True)

        '|Description|
        setDesc("A tight, binding web of spidersilk.  While the threads are nearly impossible to break from within, they are fairly delicate to outside attacks..." & DDUtils.RNRN &
                "May not be easy to remove" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.pForm.canBeBound Then
            EquipmentDialogBackend.equipArmor(p, "Naked")
            TextEvent.push("You effortlessly break your bonds.")
            TextEvent.pushLog("You effortlessly break your bonds.")
        End If
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.bind_wearer = False
        MyBase.bind_wearer = True
    End Sub
End Class
