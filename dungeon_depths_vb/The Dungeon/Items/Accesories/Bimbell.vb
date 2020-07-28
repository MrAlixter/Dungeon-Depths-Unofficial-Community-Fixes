Public Class Bimbell
    Inherits Accessory

    Sub New()
        MyBase.setName("Bimbell")
        MyBase.setDesc("A large metal bell attached to a pink collar that rings hypnotically with its wearer's gait." & vbCrLf &
                       "+40 Health." & vbCrLf &
                       "-15 WIL")
        id = 197
        tier = 3
        MyBase.setUsable(False)
        MyBase.hBoost = 20
        MyBase.wBoost = -1
        MyBase.count = 0
        MyBase.value = 434
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)
    End Sub

    Overrides Sub onEquip(ByRef p As Player)
        p.health += 40 / p.getMaxHealth
        p.ongoingTFs.Add(New BimBellTF(9, 15, 2.0, True))
        If p.health > 1 Then p.health = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.perks(perk.cowbell) > -1 Then p.perks(perk.cowbell) = -1
        If p.health > 1 Then p.health = 1
    End Sub
End Class
