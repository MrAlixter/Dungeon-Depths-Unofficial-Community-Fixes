Public Class RubyCirclet
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        MyBase.setName("Ruby_Circlet")
        MyBase.setDesc("A ruby inset on a gold band, this circlet is commonly worn by mages." & vbCrLf & _
                       "+2 Mana.")
        id = 68
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(3, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(2, False, False)
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
