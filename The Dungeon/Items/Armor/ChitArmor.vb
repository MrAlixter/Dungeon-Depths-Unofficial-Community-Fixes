Public Class ChitArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Chitin_Armor")
        MyBase.setDesc("A set of armor built out of discarded chitin, commonly made and used by arachne huntresses." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+15 DEF" & vbCrLf & _
                       " +10 SPD")
        id = 64
        tier = 3
        MyBase.setUsable(False)
        MyBase.dBoost = 15
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 125
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(17, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(93, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(94, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(95, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
