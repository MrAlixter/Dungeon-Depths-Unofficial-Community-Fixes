Public Class MOAmaraphne
    Inherits Accessory

    Public Const ITEM_NAME As String = "Mark_of_Amaraphne"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 327
        If DDDateTime.isValen Then tier = 3 Else tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        cursed = True
        rando_inv_allowed = False
        under_b_clothes = True

        '|Stats|
        defence = 5
        will = 5
        count = 0
        value = 1500

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(29, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(29, True, True)

        '|Description|
        setDesc("A glowing pink tattoo that blesses its bearer with the protection of Amaraphne, Goddess of Love and Lust." & DDUtils.RNRN &
                "Can be ""used"" to convert equipped armor to the corresponding slut variant" & vbCrLf &
                "Prevents succubi from appearing in random encounters" & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)
        If Not Equipment.clothingCurse1(p) Then TextEvent.push("While the mark glows a little, nothing seems to happen.")
        p.drawPort()
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.moamarphne) = 1 
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.perks(perk.moamarphne) = 1 Then p.perks(perk.moamarphne) = -1
    End Sub
End Class
