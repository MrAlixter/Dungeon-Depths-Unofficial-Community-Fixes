Public Class GalaxyDye
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Galaxy_Dye")
        id = 130
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1345

        '|Description|
        setDesc("A swirling nebula of lights that looks like it could contain countless stars.  Who knows what would happen if you follow the instructions on its side and apply it to your hair?")

    End Sub

    Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("You apply the " & getName())

        Dim geffect As GalaxyDyeEffect = New GalaxyDyeEffect
        geffect.apply(p)
        count -= 1
    End Sub
End Class
