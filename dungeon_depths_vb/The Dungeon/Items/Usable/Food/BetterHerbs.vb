Public Class BetterHerbs
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Better_Medicinal_Tea")
        id = 270
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 515
        setCalories(7)

        '|Description|
        setDesc("A slightly less bitter tea that restores more health." & DDUtils.RNRN &
                       "+7 Stamina" & vbCrLf & "+110 Health")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If p.className.Equals("Soul-Lord") Then
            TextEvent.push("You spike the tea leaves on the ground, kicking them all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.""")
            p.UIupdate()
            Exit Sub
        End If
        p.health += 110 / p.getMaxHealth
        If p.health > 1 Then p.health = 1
    End Sub

    Public Overrides Function getTier() As Integer
        If Not Game.currFloor Is Nothing AndAlso Game.currFloor.floorNumber > 5 Then Return 2

        Return Nothing
    End Function
End Class
