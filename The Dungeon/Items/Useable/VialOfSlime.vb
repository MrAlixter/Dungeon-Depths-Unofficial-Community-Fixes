Public Class VialOfSlime
    Inherits Item
    Sub New()
        MyBase.setName("Vial_of_Slime")
        MyBase.setDesc("A glass bottle filled with an aquamarine non-newtonian gel.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Form1.lstLog.Items.Add("You apply the " & getName())
        Form4.transform(Form1.player, "slime", 0)
        count -= 1
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Overrides Sub discard()
        Form1.lstLog.Items.Add("You drop the " & getName())
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
