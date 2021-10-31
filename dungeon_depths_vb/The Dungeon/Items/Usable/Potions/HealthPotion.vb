Public Class HealthPotion
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Health_Potion")
        id = 2
        tier = 1

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 125

        '|Description|

        setDesc("A normal, everyday health potion." & DDUtils.RNRN &
                "+75 Health")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If p.className.Equals("Soul-Lord") Then
            TextEvent.push("You spike the health potion on the ground, shattering it all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        TextEvent.pushLog("You drink the " & getName())
        Dim phHealth = p.health
        Dim heffect As HealthEffect = New HealthEffect
        heffect.apply(p)
        TextEvent.push("You drink the " & getName() & ".  +" & CInt((p.health - phHealth) * p.getMaxHealth) & " health!")
        count -= 1
    End Sub
End Class
