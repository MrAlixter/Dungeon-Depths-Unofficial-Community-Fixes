Public Class PrincessGown
    Inherits Armor
    Sub New()
        MyBase.setName("Regal_Gown")
        MyBase.setDesc("The frilly ballgown of a bonafide princess." & vbCrLf & "+2 MaxMana")
        id = 75
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(48, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(49, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(50, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
