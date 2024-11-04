Public Class BBStickOfGum
    Inherits StickOfGum

    Public Shadows Const ITEM_NAME As String = "Berry_Stick_of_Gum"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 125
        tier = 3

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|
        setDesc("An deep violet piece of gum with a faint chemical smell.  Supposedly, it tastes like blackberries. " & DDUtils.RNRN & "+10 Stamina")
    End Sub

    Public Overrides Sub tfEffect(ByRef p As Player)
        p.ongoingTFs.add(New BerryBimboTF(2, 5, 0.25, True))
        p.perks(perk.bimbotf) = 0
    End Sub
End Class
