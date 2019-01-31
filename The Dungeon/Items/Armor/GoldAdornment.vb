Public Class GoldAdornment
    Inherits Armor

    Sub New()
        MyBase.setName("Gold_Adornment")
        MyBase.setDesc("A shiny golden outfit that leaves little to the imagination.  This is a common choice for those who want to be admired" & vbCrLf & _
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+15 DEF")
        id = 39
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 15
        MyBase.count = 0
        MyBase.value = 2000
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(54, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(55, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(56, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(57, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
