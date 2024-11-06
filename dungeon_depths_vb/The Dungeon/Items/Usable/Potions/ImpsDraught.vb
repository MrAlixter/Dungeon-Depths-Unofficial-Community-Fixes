Public Class ImpsDraught
    Inherits Item

    Public Const ITEM_NAME As String = "Impfernal_Draught"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 452
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1345

        '|Description|
        setDesc("A flask of a swirling crimson beverage.  Who knows what would happen if you were to... just... drink it?" & DDUtils.RNRN &
                "Even holding this potion exposes one to the magic that saturates it... and prevents it from being discarded.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("You chug the " & getName())

        CinnamonBimboTF.impTFPlayer2(p)
        count -= 1
    End Sub

    Public Overrides Sub discard()
        TextEvent.pushAndLog("The potion reappears in your bag.")
    End Sub
End Class
