Public Class Mirror
    Inherits Item

    Dim target As Player

    Sub New()
        '|ID Info|
        setName("Mirror")
        id = 36
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 300

        '|Description|
        setDesc("A shiny mirror that could bounce a spell back at its caster.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        target = p

        If p.knownSpells.Contains("Self Polymorph") Then
            Game.pushPnlYesNo("Do you want to cast Self Polymorph?", AddressOf castSelfPolymorph, AddressOf showPlayerDesc)
        Else
            showPlayerDesc()
        End If
    End Sub

    Private Sub castSelfPolymorph()
        Spell.spellCast(Nothing, target, "Self Polymorph")
    End Sub

    Private Sub showPlayerDesc()
        Game.pushLblEvent(target.genDescription)
        Game.pushLstLog(target.description)
    End Sub
End Class
