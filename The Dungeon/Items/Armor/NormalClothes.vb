Public Class NormalClothes
    Inherits Armor
    Public Shared bsizeneg1 As Tuple(Of Integer, Boolean)
    Public Shared bsize1 As Tuple(Of Integer, Boolean)
    Public Shared bsize2 As Tuple(Of Integer, Boolean)
    Sub New()
        MyBase.setName("Common_Clothes")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        id = Nothing
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        'MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(Form1.player.sState.iArrInd(3).Item1, False)
        'MyBase.bsize1 = New Tuple(Of Integer, Boolean)(Form1.player.sState.iArrInd(3).Item1, True)
        'If Form1.player.name = "Mark" Then MyBase.bsize2 = New Tuple(Of Integer, Boolean)(CharacterGenerator1.fClothing.Count - 1, True)
    End Sub

    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
