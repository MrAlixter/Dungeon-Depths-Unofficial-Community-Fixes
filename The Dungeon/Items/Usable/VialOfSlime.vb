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
        Game.pushLstLog("You apply the " & getName())
        Game.player.ongoingTFs.Add(New VialOfSlimeTF())
        Game.player.update()
        count -= 1
        
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
