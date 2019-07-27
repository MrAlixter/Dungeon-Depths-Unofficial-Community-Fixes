Public Class Herbs
    Inherits Food

    Sub New()
        MyBase.setName("Medicinal_Tea")
        MyBase.setDesc("A bitter tea that restores health. -15 Hunger, +50 Health")
        id = 33
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 275
        setCalories(15)
    End Sub

    Public Overrides Sub Effect()
        If Game.player.pClass.name.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the herbs on the ground, kicking them all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.""")
            Game.player.UIupdate()
            Exit Sub
        End If
        Game.player.health += 50 / Game.player.getmaxHealth
        If Game.player.health > 1 Then Game.player.health = 1
    End Sub
End Class
