Public Class Panacea
    Inherits Food

    Public Const ITEM_NAME As String = "Panacea"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 90
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1777
        setCalories(9999)

        '|Description|

        setDesc("A mystical dish that heals all wounds, sates any hunger, and returns one to their original form.")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        '| - Targax Exception - |
        If p.className.Equals("Soul-Lord") Then
            TextEvent.push("You spike the Panacea on the ground, kicking the mystic dish all over the dungeon floor.  As you go back to your business, you muse on how cowardly healing is." & DDUtils.RNRN & """Only someone who cares about their mortal vessel would bother to maintain it.""")
            TextEvent.pushAndLog("You spike the Panacea on the ground!")
            p.UIupdate()
            Exit Sub
        End If

        '| - Main Effect - |
        Dim av = New AntiVenomEffect
        av.apply(p)
        p.resetPerks()
        Equipment.antiClothingCurse(p)
        p.health = 1.0
        p.revertToSState()
    End Sub
End Class
