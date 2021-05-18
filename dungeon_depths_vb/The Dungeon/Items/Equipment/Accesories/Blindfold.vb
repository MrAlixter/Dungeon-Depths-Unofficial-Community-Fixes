Public Class Blindfold
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        setName("Blindfold")
        setDesc("A ruby inset on a gold band, this circlet is commonly worn by mages." & vbCrLf & _
                       "+2 Mana.")
        id = 161
        tier = Nothing
        usable = false
        count = 0
        value = 0

        m_boost = 2

        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(12, False, True)
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.blind) = 1
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks(perk.blind) = -1
        Game.drawBoard()
    End Sub
End Class
