Public Class EmeraldCirclet
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        MyBase.setName("Emerald_Circlet")
        MyBase.setDesc("A large emerald inset on a gold-alloy band, this circlet is commonly worn by archmages." & vbCrLf & _
                       "+10 Mana, +10 SPD")
        id = 140
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 10
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(10, False, True)
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
