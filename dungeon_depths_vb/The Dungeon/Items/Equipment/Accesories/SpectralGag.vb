Public Class SpectralGag
    Inherits Accessory

    Public Const ITEM_NAME As String = "Spectral_Gag"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 321
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        hide_mouth = True
        droppable = False
        gag = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(26, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(19, False, True)

        '|Description|
        setDesc("A glowing teal band of energy that seals its wearer from speaking or casting spells." & DDUtils.RNRN &
                "Requires 6 mana to remove" & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If Not getCursed(p) Then
            p.mana -= 6

            TextEvent.pushAndLog("You focus and are able to break through the enchanted gag!  -6 Mana...")

            p.inv.add(getAName, -1)

            If Game.combat_engaged Then Game.progressTurn()
        End If
    End Sub

    Public Overrides Function getCursed(ByRef p As Player) As Boolean
        If p.getMana < 6 Then Return True Else Return False
    End Function
End Class
