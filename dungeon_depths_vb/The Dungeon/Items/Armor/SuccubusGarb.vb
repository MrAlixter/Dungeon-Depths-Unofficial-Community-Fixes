Public Class SuccubusGarb
    Inherits Armor
    Sub New()
        MyBase.setName("Succubus_Garb")
        MyBase.setDesc("The scanty clothes of a succubus." & vbCrLf & "+2 ATK")
        id = 74
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(91, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(92, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(11, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
