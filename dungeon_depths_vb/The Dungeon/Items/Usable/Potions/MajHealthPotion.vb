Public Class MajHealthPotion
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Major_Health_Potion")
        id = 82
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 550

        '|Description|
        setDesc("A turbo-charged health potion that heals all wounds completely.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If p.className.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the health potion on the ground, shattering it all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        Game.pushLstLog("You drink the " & getName())
        Dim phHealth = p.health
        p.health = 1.0
        Game.pushLblEvent("You drink the " & getName() & ".  +" & CInt((p.health - phHealth) * p.getMaxHealth) & " health!")
        count -= 1
    End Sub
End Class
