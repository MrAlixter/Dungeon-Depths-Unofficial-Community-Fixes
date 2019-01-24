Public Class Naked
    Inherits Armor
    Sub New()
        MyBase.setName("Naked")
        MyBase.setDesc("NO CLOTHES")
        id = Nothing
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 100
        bsizeneg1 = New Tuple(Of Integer, Boolean)(5, False)
        bsize1 = New Tuple(Of Integer, Boolean)(47, True)
        bsize2 = New Tuple(Of Integer, Boolean)(47, True)
        bsize3 = New Tuple(Of Integer, Boolean)(47, True)
        bsize4 = New Tuple(Of Integer, Boolean)(47, True)
        bsize5 = New Tuple(Of Integer, Boolean)(47, True)
        MyBase.compressesBreasts = False
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
