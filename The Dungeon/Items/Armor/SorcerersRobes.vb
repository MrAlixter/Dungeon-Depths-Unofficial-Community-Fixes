Public Class SorcerersRobes
    Inherits Armor

    Sub New()
        MyBase.setName("Sorcerer's_Robes")
        MyBase.setDesc("A protective garment made more for pratical funtion than for fashion. " & vbCrLf & _
                       "+7 DEF" & vbCrLf & _
                       "+10 MANA")
        MyBase.setUsable(False)
        MyBase.dBoost = 7
        MyBase.mBoost = 10
        MyBase.count = 0
        MyBase.value = 950
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(7, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(21, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(22, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(23, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean)(24, True)

    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
