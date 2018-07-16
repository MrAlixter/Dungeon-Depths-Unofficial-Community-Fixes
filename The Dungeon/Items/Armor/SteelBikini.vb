Public Class SteelBikini
    Inherits Armor

    Sub New()
        MyBase.setName("Steel_Bikini")
        MyBase.setDesc("A skimpy steel swimsuit that gives a new meaning to 'Breast plates'." & vbCrLf & _
                       "Fits sizes 1 through 5" & vbCrLf & _
                       "+5 DEF")
        id = 7
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 5
        MyBase.count = 0
        MyBase.value = 250
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(16, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(17, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(18, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean)(19, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean)(20, True)

    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
