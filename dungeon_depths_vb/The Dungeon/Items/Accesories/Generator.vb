Public Class Generator
    Inherits Accessory

    Sub New()
        MyBase.setName("Mobile_Powerbank")
        MyBase.setDesc("A small yet effective generator that, in addition to condensing mana for later use, powers a communication device.  Too bad there's no signal..." & vbCrLf & _
                       "+5 Max Mana, Fast Mana Regen")
        id = 110
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 5
        MyBase.count = 0
        MyBase.value = 5000
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
    End Sub
    Public Overrides Sub onEquip()
        Game.player.perks("minmanregen") = 1
    End Sub
    Public Overrides Sub onUnequip()
        Game.player.perks("minmanregen") = -1
    End Sub
End Class
