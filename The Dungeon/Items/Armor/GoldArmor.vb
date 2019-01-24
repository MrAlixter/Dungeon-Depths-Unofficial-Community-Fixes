Public Class GoldArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Gold_Armor")
        MyBase.setDesc("A expensive looking armor set made for the wealthy." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+30 DEF")
        id = 38
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 30
        MyBase.count = 0
        MyBase.value = 1850
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(9, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(51, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(52, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(53, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
