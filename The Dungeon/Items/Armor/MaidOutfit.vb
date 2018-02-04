Public Class MaidOutfit
    Inherits Armor
    Sub New()
        MyBase.setName("Maid_Outfit")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        MyBase.setUsable(False)
        MyBase.sBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(10, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(58, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(59, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(60, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean)(61, True)
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
