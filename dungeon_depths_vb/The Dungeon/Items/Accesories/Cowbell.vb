Public Class Cowbell
    Inherits Accessory
    'The red headband provides a +1 attack buff
    Sub New()
        MyBase.setName(perk.cowbell)
        MyBase.setDesc("A large brass bell attached to a collar that rings steadily with its wearer's gait." & vbCrLf &
                       "+20 Health." & vbCrLf &
                       "-1 WIL")
        id = 70
        tier = 2
        MyBase.setUsable(False)
        MyBase.hBoost = 20
        MyBase.wBoost = -1
        MyBase.count = 0
        MyBase.value = 434
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(4, False, True)
    End Sub

    Overrides Sub onEquip(ByRef p As Player)
        p.health += 20 / p.getMaxHealth
        p.ongoingTFs.Add(New MinoFTF(9, 15, 2.0, True))
        If p.health > 1 Then p.health = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.perks(perk.cowbell) > -1 Then p.perks(perk.cowbell) = -1
        If p.health > 1 Then p.health = 1
    End Sub
End Class
