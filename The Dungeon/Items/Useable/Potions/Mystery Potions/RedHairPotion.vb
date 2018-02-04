Public Class RedHairPotion
    Inherits Potion
    Sub New()

        MyBase.setRealName("Red_Hair_Potion")
        MyBase.setDesc("A curious looking potion")
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Form1.player
        p.inventorynames(27) = "Red_Hair_Potion"
        If p.iArrInd(1).Item1 < 5 Or (p.iArrInd(1).Item1 = 7 And p.sexBool) Then
            Form1.pushLblEvent("You now have red hair!")
            p.haircolor = Color.FromArgb(p.haircolor.A, 255, 69, 0)
            p.createP()
            If Not Form1.player.perks(5) Or Not Form1.player.title.Equals("Magic Girl") Then
                Form1.player.pState.save(Form1.player)
            End If
        Else
            Form1.pushLblEvent("Your hair color doesn't change!")
        End If
    End Sub
End Class
