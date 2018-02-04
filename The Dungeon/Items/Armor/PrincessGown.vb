Public Class PrincessGown
    Inherits Armor
    Sub New()
        MyBase.setName("Regal_Gown")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        MyBase.setUsable(False)
        MyBase.mBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(48, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(49, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(50, True)

    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
