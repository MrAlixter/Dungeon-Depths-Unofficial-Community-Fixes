Public Class CatLingerie
    Inherits Armor
    'CatLingerie is a cosmetic armor that doesn't provide a defence bonus
    Sub New()
        MyBase.setName("Cat_Lingerie")
        MyBase.setDesc("A skimpy, pink, cat themed set of underwear. Nya." & vbCrLf & _
                       "+0 DEF")
        MyBase.setUsable(False)
        MyBase.dBoost = 0
        MyBase.count = 0
        MyBase.value = 300
        bsize1 = New Tuple(Of Integer, Boolean)(38, True)
        bsize2 = New Tuple(Of Integer, Boolean)(39, True)
        bsize3 = New Tuple(Of Integer, Boolean)(40, True)
        bsize4 = New Tuple(Of Integer, Boolean)(41, True)
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
