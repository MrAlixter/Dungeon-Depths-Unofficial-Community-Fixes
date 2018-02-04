Public Class WarriorsCurass
    Inherits Armor

    Sub New()
        MyBase.setName("Warrior's_Curass")
        MyBase.setDesc("A protective garment made more for elite fighters rather than fashion-minded common folk." & vbCrLf & _
                       "+12 DEF" & vbCrLf & _
                       "+5 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 5
        MyBase.dBoost = 12
        MyBase.count = 0
        MyBase.value = 950
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(8, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(29, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(30, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(31, True)
    End Sub

    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
