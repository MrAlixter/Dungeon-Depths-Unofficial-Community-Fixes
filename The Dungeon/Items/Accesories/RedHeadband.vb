Public Class RedHeadband
    Inherits Accessory
    'The red headband provides a +1 attack buff
    Sub New()
        MyBase.setName("Red_Headband")
        MyBase.setDesc("An aggressive looking red headband." & vbCrLf & _
                       "+1 ATK.")
        id = 67
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean)(2, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean)(1, False)
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
