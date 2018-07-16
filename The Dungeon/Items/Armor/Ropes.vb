Public Class Ropes
    Inherits Armor
    Sub New()
        MyBase.setName("Ropes")
        MyBase.setDesc("A tightened set of ropes that both reduces mobility and leaves one nearly naked." & vbCrLf & _
                       "Fits sizes -1 through 5" & vbCrLf & _
                       "-5 DEF" & vbCrLf & _
                       "-5 ATK" & vbCrLf & _
                       "-5 SPD" & vbCrLf & _
                       "May not be easy to remove")
        id = 54
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = -5
        MyBase.dBoost = -5
        MyBase.sBoost = -5
        MyBase.count = 0
        MyBase.value = 100
        bsizeneg1 = New Tuple(Of Integer, Boolean)(13, False)
        bsize1 = New Tuple(Of Integer, Boolean)(72, True)
        bsize2 = New Tuple(Of Integer, Boolean)(73, True)
        bsize3 = New Tuple(Of Integer, Boolean)(74, True)
        bsize4 = New Tuple(Of Integer, Boolean)(75, True)
        bsize5 = New Tuple(Of Integer, Boolean)(76, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
