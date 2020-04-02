Public Class HealthCharm
    Inherits Item

    Sub New()
        MyBase.setName("Health_Charm")
        MyBase.setDesc("A charm that slightly boosts your health.")
        id = 48
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        If p.pClass.name.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the health charm on the ground, shattering it all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        Game.pushLstLog("You use the " & getName() & ". +10 base health!")

        Game.player1.maxHealth += 10
        Game.player1.health += 10 / Game.player1.getMaxHealth()
        If Game.player1.health > 1 Then Game.player1.health = 1
        Game.player1.UIupdate()
        count -= 1
    End Sub
End Class
