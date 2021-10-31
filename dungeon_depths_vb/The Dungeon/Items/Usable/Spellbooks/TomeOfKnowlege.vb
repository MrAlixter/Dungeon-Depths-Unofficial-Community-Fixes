Public Class TomeOfKnowlege
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Tome_Of_Knowledge")
        id = 286
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        MyBase.droppable = False

        '|Stats|
        count = 0
        value = 800

        '|Description|
        setDesc("A suspicious leather-bound book with a back cover promising to grant one the experience of ""walking in anothers shoes"", whatever that means...")
    End Sub

    Overrides Sub use(ByRef p As Player)
        TextEvent.push("As you crack open the spellbook, a brilliant white light flares from its pages, and you drop it to cover your eyes." & DDUtils.RNRN &
                          """SO, YOU WISH TO OBTAIN KNOWLEDGE..."" a disembodied voice thunders, ""VERY WELL, GAZE THROUGH THE EYES OF ANOTHER AND LEARN WELL.""" & DDUtils.RNRN &
                          "As your vision returns, and the light recedes, the book collapses into a pile of ash, and a tingling sensation begins rushing through your limbs..." & DDUtils.RNRN & DDUtils.RNRN &
                          "Quest ""Opposite Day"" acquired!", AddressOf tf)

        count -= 1
    End Sub

    Private Sub tf()
        Dim iTF = New InversionTF
        iTF.step1()

        Game.player1.drawPort()
    End Sub

    Public Overrides Function getTier() As Integer
        Return If(Game.player1.quests(qInds.oppositeDay).canGet, 2, Nothing) And Game.player1.inv.getCountAt(getAName) < 1
    End Function
End Class
