Public Class SteelArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Steel_Armor")
        MyBase.setDesc("A basic armor set forged from steel." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+5 DEF")
        id = 5
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 5
        MyBase.count = 0
        MyBase.value = 125
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(6, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(13, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(14, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(15, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
