Public Class GoddessGown
    Inherits Armor
    Sub New()
        MyBase.setName("Goddess_Gown")
        MyBase.setDesc("A gown worn by a goddess." & vbCrLf & "+2 MaxMana")
        id = 73
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(89, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(90, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
