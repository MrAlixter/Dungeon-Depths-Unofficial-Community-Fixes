Public Class SuccubusGarb
    Inherits Armor
    Sub New()
        MyBase.setName("Succubus_Garb")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        MyBase.setUsable(False)
        MyBase.aBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(91, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(92, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(11, True)

    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
