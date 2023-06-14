Public Class TomeOfKnowlege
    Inherits Item

    Public Const ITEM_NAME As String = "Tome_Of_Knowledge"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 286
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        droppable = False
        only_drop_one = True

        '|Stats|
        count = 0
        value = 800

        '|Description|
        setDesc("A suspicious leather-bound book with a back cover promising to grant one the experience of ""walking in anothers shoes"", whatever that means...")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f3f5
                Return If(Game.player1.quests(qInd.oppositeDay).canGet, 2, Nothing)
            Case LootTable.bracket.f6f9
                Return Nothing
            Case LootTable.bracket.f10f12
                Return Nothing
            Case LootTable.bracket.f13
                Return Nothing
            Case LootTable.bracket.f14fXX
                Return Nothing
            Case Else
                Return If(Game.player1.quests(qInd.oppositeDay).canGet, 3, Nothing)
        End Select
    End Function

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
End Class
