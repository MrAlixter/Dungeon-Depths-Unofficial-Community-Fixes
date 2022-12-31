Public Class VialOfSuccubus
    Inherits Item

    Public Const ITEM_NAME As String = "Essence_of_Succubus"

    Private Shared lostXP As Integer = 0

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 395
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("Tastes like XP loss..." & DDUtils.RNRN &
                "Can be discarded to restore all lost XP")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)

        Dim xp = p.deLevel(1)

        TextEvent.pushLog("You lose " & xp & " XP...")
        lostXP += xp
    End Sub

    Public Overrides Sub discard()
        MyBase.discard()

        Game.player1.addXP(lostXP)
        lostXP = 0

        Game.player1.UIupdate()
    End Sub
End Class
