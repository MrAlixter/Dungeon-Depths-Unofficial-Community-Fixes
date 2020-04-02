Public Class ROAmaraphne
    Inherits Accessory

    Sub New()
        MyBase.setName("Ring_of_Amaraphne")
        MyBase.setDesc("While on the surface, this seems to be but an ornate ring crafted from " &
                       "extremely precious materials, closer inspection reveals that the inside " &
                       "of its band is inscribed with a blessing of Amaraphne, the love goddess." & vbCrLf &
                       "Use to change armor to slut variant" & vbCrLf &
                       "+ DEF based on equipped armor" & vbCrLf &
                       "+ SPD based on bust size" & vbCrLf & vbCrLf &
                       "[dev. note:  this is not fully implemented yet, and while at the momment " &
                       "it is a rare Valentine's day item, I plan on expanding its effect and making " &
                       "it a regular rare item.  I plan on making it so that its effect triggers after " &
                       "a near death, includes a transformation, and also has a punishment for abusing its " &
                       "power too much.]")
        id = 81
        If DDDateTime.isValen Then tier = 3 Else tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 3333
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)

        MyBase.isRandoTFAcceptable = False
    End Sub
    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)
        If Not Equipment.clothingCurse1(p) Then Game.pushLblEvent("While the ring glows a little, nothing seems to happen.")
        p.drawPort()
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks("rotlg") = 1
        PerkEffects.ROTLGRoute()
        p.UIupdate()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks("rotlg") = -1
        Equipment.antiClothingCurse(p)
        p.drawPort()
    End Sub
End Class
