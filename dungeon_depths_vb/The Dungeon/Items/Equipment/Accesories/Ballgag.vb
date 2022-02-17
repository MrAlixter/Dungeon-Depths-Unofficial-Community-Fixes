Public Class Ballgag
    Inherits Accessory

    Public Const ITEM_NAME As String = "Ball_Gag"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 320
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        hide_mouth = True

        '|Stats|
        d_boost = 5
        count = 0
        value = 156

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(25, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(18, False, True)

        '|Description|
        setDesc("A simple gag that prevents its wearer from speaking or casting spells, sealed by a spell that prevents removal by those who are aroused." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.gagged) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks(perk.gagged) = -1
    End Sub

    Public Overrides Function getCursed(ByRef p As Player) As Boolean
        If p.getLust > 15 Then Return True Else Return False
    End Function

    Public Overrides Function getDesc() As Object
        Return "A simple gag that prevents its wearer from speaking or casting spells, sealed by a spell that prevents removal by those who are aroused." & DDUtils.RNRN &
               If(getCursed(Game.player1), "You are currently unable to remove this gag...", "You could remove this gag once equipped.") & DDUtils.RNRN &
               getStatInformation()
    End Function
End Class
