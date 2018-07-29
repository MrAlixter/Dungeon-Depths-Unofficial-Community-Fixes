Public Class PrincessGown
    Inherits Armor
    Sub New()
        MyBase.setName("Regal_Gown")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        id = Nothing
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
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
