Public Class SkimpyClothes
    Inherits Armor

    Sub New()
        MyBase.setName("Skimpy_Clothes")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        id = -3
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 0
        MyBase.antiSlutVarInd = -2
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(25, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(26, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(6, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(7, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(9, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
