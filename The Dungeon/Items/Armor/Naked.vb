Public Class Naked
    Inherits Armor
    Sub New()
        MyBase.setName("Naked")
        MyBase.setDesc("NO CLOTHES")
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        MyBase.count = 0
        MyBase.value = 100
        bsizeneg1 = New Tuple(Of Integer, Boolean)(5, False)
        bsize1 = New Tuple(Of Integer, Boolean)(47, True)
        bsize2 = New Tuple(Of Integer, Boolean)(47, True)
        bsize3 = New Tuple(Of Integer, Boolean)(47, True)
        bsize4 = New Tuple(Of Integer, Boolean)(47, True)
        bsize5 = New Tuple(Of Integer, Boolean)(47, True)
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
