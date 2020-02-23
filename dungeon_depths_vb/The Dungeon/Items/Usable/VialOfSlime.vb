Public Class VialOfSlime
    Inherits Item
    Sub New()
        MyBase.setName("Vial_of_Slime")
        MyBase.setDesc("A glass bottle filled with an aquamarine non-newtonian gel.")
        id = 3
        tier = 1
        isMonsterDrop = True
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Dim p = Game.player

        Game.pushLstLog("You apply the " & getName())

        If p.pForm.name.Equals("Slime") Or p.pForm.name.Equals("Goo Girl") Then
            p.health += 0.25
            If p.health > 1 Then p.health = 1
            count -= 1
            Exit Sub
        End If
        If p.perks("slimetf") = -1 Or p.prt.haircolor.A = 255 Then
            p.perks("slimetf") = 2
        End If

        p.ongoingTFs.Add(New VialOfSlimeTF(p.perks("slimetf")))
        p.update()
        count -= 1

    End Sub
End Class
