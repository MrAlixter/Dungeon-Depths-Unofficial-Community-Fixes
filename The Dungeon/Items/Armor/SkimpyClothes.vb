Public Class SkimpyClothes
    Inherits Armor

    Sub New()
        MyBase.setName("Skimpy_Clothes")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        id = Nothing
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(6, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(7, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(8, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean)(9, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
