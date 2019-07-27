Public Class VSkimpyClothes
    Inherits Armor

    Sub New()
        MyBase.setName("Very_Skimpy_Clothes")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        id = -4
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.antiSlutVarInd = -3
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(177, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
