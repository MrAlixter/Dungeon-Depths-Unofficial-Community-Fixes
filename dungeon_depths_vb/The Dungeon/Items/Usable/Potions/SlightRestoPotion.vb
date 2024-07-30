Public Class SlightRestoPotion
    Inherits Item

    Public Const ITEM_NAME As String = "Potion_of_Slight_Resto."

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 435
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 130

        '|Description|
        setDesc("""Restores ye to ye original form, if only by a wee ammount."" says the bottle.")

    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())

        p.name = p.sState.name
        p.changeClass(p.sState.pClass.name)

        p.prt.iArrInd(pInd.eyes) = p.sState.iArrInd(pInd.eyes)
        p.prt.iArrInd(pInd.mouth) = p.sState.iArrInd(pInd.mouth)

        p.prt.iArrInd(pInd.rearhair) = p.sState.iArrInd(pInd.rearhair)
        p.prt.iArrInd(pInd.midhair) = p.sState.iArrInd(pInd.midhair)
        p.prt.iArrInd(pInd.fronthair) = p.sState.iArrInd(pInd.fronthair)

        p.savePState()
        p.drawPort()

        count -= 1
    End Sub
End Class
