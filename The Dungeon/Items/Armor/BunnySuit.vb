Public Class BunnySuit
    Inherits Armor
    'the BunnySuit is a cosmetic armor that provides +1 defence
    Sub New()
        MyBase.setName("Bunny_Suit")
        MyBase.setDesc("A sultry outfit worn by waitresses in a club. " & vbCrLf & _
                       "+1 DEF")
        id = 16
        tier = 3
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 325
        bsize1 = New Tuple(Of Integer, Boolean)(42, True)
        bsize2 = New Tuple(Of Integer, Boolean)(43, True)
        bsize3 = New Tuple(Of Integer, Boolean)(44, True)
        bsize4 = New Tuple(Of Integer, Boolean)(45, True)
        bsize5 = New Tuple(Of Integer, Boolean)(46, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
