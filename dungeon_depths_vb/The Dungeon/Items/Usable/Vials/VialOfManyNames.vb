Public Class VialOfManyNames
    Inherits Item

    Public Const ITEM_NAME As String = "Vial_of_Many_Names"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 373
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False

        '|Stats|
        count = 0
        value = 175

        '|Description|
        setDesc("A vial of swirling minty energy.  Occasionally, a few glyphs brush up against the inside of the bottle.")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)

        If p.perks(perk.vofmanynames) < 0 Then p.perks(perk.vofmanynames) = 0

        p.perks(perk.vofmanynames) += 4

        TextEvent.pushAndLog("Your true name is hidden!  " & p.perks(perk.vofmanynames) & " charges remain.")

        count -= 1
    End Sub
End Class
