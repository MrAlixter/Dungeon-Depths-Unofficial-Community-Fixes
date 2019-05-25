Public Class Pancea
    Inherits Food

    Sub New()
        MyBase.setName("Pancea")
        MyBase.setDesc("A mystical dish that heals all wounds, sates any hunger, and returns one to their original form.")
        id = 90
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1777
        setCalories(9999)
    End Sub

    Public Overrides Sub Effect()
        If Game.player.pClass.name.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the Pancea on the ground, kicking the mystic dish all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.""")
            Game.player.UIupdate()
            Exit Sub
        End If
        Dim av = New AntiVenomEffect
        av.apply(Game.player)
        Game.player.health = 1
        Game.player.revertToSState()
    End Sub
End Class
