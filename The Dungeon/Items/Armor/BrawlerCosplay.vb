Public Class BrawlerCosplay
    Inherits Armor
    'BrawlerCosplay provides a +15 defensive boost
    Sub New()
        MyBase.setName("Brawler_Cosplay")
        MyBase.setDesc("A glamourous garment made more for the highlighting one's body than for any practical function. " & vbCrLf & _
                       "+12 DEF" & vbCrLf & _
                       "+5 ATK")
        MyBase.setUsable(False)
        MyBase.dBoost = 12
        MyBase.aBoost = 5
        MyBase.count = 0
        MyBase.value = 1250
        bsize1 = New Tuple(Of Integer, Boolean)(32, True)
        bsize2 = New Tuple(Of Integer, Boolean)(33, True)
        bsize3 = New Tuple(Of Integer, Boolean)(34, True)
        bsize4 = New Tuple(Of Integer, Boolean)(35, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
