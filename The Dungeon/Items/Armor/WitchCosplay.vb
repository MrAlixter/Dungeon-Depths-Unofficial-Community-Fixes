Public Class WitchCosplay
    Inherits Armor

    Sub New()
        MyBase.setName("Witch_Cosplay")
        MyBase.setDesc("A glamourous garment made more to show off one's body than to show off any magical ability." & vbCrLf & _
                       "+7 DEF" & vbCrLf & _
                       "+10 MANA")
        MyBase.setUsable(False)
        MyBase.mBoost = 10
        MyBase.dBoost = 7
        MyBase.count = 0
        MyBase.value = 1250
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(25, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(26, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(27, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean)(28, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
