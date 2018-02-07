Public Class LiveLingerie
    Inherits Armor
    Sub New()
        MyBase.setName("Living_Lingerie")
        MyBase.setDesc("A suit of living lingerie embued with a the soul of a mimic." & vbCrLf & _
                       "+2 DEF" & vbCrLf & _
                       "The mimic's movment rapidly raises lust" & vbCrLf & _
                       "May not be easy to remove")
        id = 56
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.value = 450
        bsizeneg1 = New Tuple(Of Integer, Boolean)(16, False)
        bsize1 = New Tuple(Of Integer, Boolean)(82, True)
        bsize2 = New Tuple(Of Integer, Boolean)(84, True)
        bsize3 = New Tuple(Of Integer, Boolean)(86, True)
        bsize4 = New Tuple(Of Integer, Boolean)(88, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
