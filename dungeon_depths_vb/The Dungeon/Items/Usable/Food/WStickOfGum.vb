Public Class WStickOfGum
    Inherits StickOfGum

    Public Shadows Const ITEM_NAME As String = "Melon_Stick_of_Gum"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 132
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|

        setDesc("An pink piece of gum with a faint chemical smell.  Supposedly, it tastes like watermelon." & DDUtils.RNRN &
                "+10 Stamina")
    End Sub

    Public Overrides Sub tfEffect(ByRef p As Player)
        p.ongoingTFs.add(New WatermelonBimboTF(2, 5, 0.25, True))
        p.perks(perk.bimbotf) = 0
    End Sub
End Class
