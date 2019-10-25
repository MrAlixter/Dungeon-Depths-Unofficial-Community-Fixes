Public Class StealthGear
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        MyBase.setName("Stealth_Gear")
        MyBase.setDesc("Wraps of fabric that tighten down loose clothing in order to make its wearer more sneaky." & vbCrLf &
                       "Reduces encouter rate, low dodge chance." & vbCrLf &
                       "+4 SPD")
        id = 164
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 10
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(13, False, True)
    End Sub
    Public Overrides Sub onEquip()
        MyBase.onEquip()
        Game.player.perks("stealth") = 1
        Game.drawBoard()
    End Sub
    Public Overrides Sub onUnequip()
        MyBase.onUnequip()
        Game.player.perks("stealth") = -1
        Game.drawBoard()
    End Sub
End Class
