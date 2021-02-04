Public Class BetterHerbs
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Better_Medicinal_Tea")
        id = 270
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 515
        setCalories(7)

        '|Description|
        MyBase.setDesc("A slightly less bitter tea that restores more health." & DDUtils.RNRN &
                       "+7 Stamina" & vbCrLf & "+110 Health")
    End Sub

    Public Overrides Sub Effect()
        If Game.player1.className.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the tea leaves on the ground, kicking them all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.""")
            Game.player1.UIupdate()
            Exit Sub
        End If
        Game.player1.health += 110 / Game.player1.getMaxHealth
        If Game.player1.health > 1 Then Game.player1.health = 1
    End Sub

    Public Overrides Function getTier() As Integer
        If Not Game.currFloor Is Nothing AndAlso Game.currFloor.floorNumber > 5 Then Return 2

        Return Nothing
    End Function
End Class
