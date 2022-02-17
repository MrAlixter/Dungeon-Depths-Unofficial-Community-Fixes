Public Class Herbs
    Inherits Food

    Public Const ITEM_NAME As String = "Medicinal_Tea"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 33
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 275
        setCalories(15)

        '|Description|
        setDesc("A bitter tea that restores health." & DDUtils.RNRN &
                       "+15 Stamina" & vbCrLf & "+50 Health")

    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If p.className.Equals("Soul-Lord") Then
            TextEvent.push("You spike the tea leaves on the ground, kicking them all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.""")
            p.UIupdate()
            Exit Sub
        End If
        p.health += 50 / p.getMaxHealth
        If p.health > 1 Then p.health = 1
    End Sub
End Class
