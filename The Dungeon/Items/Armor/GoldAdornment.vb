Public Class GoldAdornment
    Inherits Armor

    Sub New()
        MyBase.setName("Gold_Adornment")
        MyBase.setDesc("A shiny golden outfit that leaves little to the imagination.  This is a common choice for those who want to be admired" & vbCrLf & _
                       "+15 DEF")
        id = 39
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 15
        MyBase.count = 0
        MyBase.value = 2000
        bsize1 = New Tuple(Of Integer, Boolean)(54, True)
        bsize2 = New Tuple(Of Integer, Boolean)(55, True)
        bsize3 = New Tuple(Of Integer, Boolean)(56, True)
        bsize4 = New Tuple(Of Integer, Boolean)(57, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
