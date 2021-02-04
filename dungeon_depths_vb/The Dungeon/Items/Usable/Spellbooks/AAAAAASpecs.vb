Public Class AAAAAASpecs
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("AAAAAA_Specification")
        id = 279
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 200

        '|Description|
        MyBase.setDesc("A small paper pamphlet containing a diagam of a sextuple-A battery.  On its back, a simple incantation is scrawled in ink.")
    End Sub

    Overrides Sub use(ByRef p As Player)

        Dim sName = "Summon Battery"

        If Not p.knownSpells.Contains(sName) Then
            p.knownSpells.Add(sName)
            Game.pushLstLog("You learn ""Summon Battery""")
        End If

        count -= 1
    End Sub
End Class
