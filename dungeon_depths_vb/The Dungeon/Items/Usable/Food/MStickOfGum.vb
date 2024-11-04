Public Class MStickOfGum
    Inherits StickOfGum

    Public Shadows Const ITEM_NAME As String = "Mint_Stick_of_Gum"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 109
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|
        setDesc("An pale blue piece of gum with a faint chemical smell.  Supposedly, it tastes like mint." & DDUtils.RNRN &
                "+10 Stamina")
    End Sub

    Public Overrides Sub tfEffect(ByRef p As Player)
        p.ongoingTFs.add(New MintBimboTF(2, 5, 0.25, True))
        p.perks(perk.bimbotf) = 0
    End Sub
End Class
