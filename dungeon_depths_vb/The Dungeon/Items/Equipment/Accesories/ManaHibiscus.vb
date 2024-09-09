Public Class ManaHibiscus
    Inherits Accessory

    Public Const ITEM_NAME As String = "Mana_Hibiscus"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 149
        If DDDateTime.isAni Then tier = 2 Else tier = Nothing

        '|Item Flags|
        usable = True
        only_drop_one = True

        '|Stats|
        MyBase.m_boost = 17
        count = 0
        value = 1820

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(4, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(4, True, True)

        '|Description|
        setDesc("This magenta flower is covered in runes that pulse with the glowing aura of magic.  With verdant leaves that never curl with age, there's no telling what would happen if someone were to add a little more mana to the mix...")

    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        If DDDateTime.isAni Then
            Select Case LootTable.getBracket(floor_num)
                Case LootTable.bracket.f1f2
                    Return 4
                Case LootTable.bracket.f3f5
                    Return 3
                Case LootTable.bracket.f6f9
                    Return 2
                Case LootTable.bracket.f10f12
                    Return 2
                Case LootTable.bracket.f13
                    Return Nothing
                Case LootTable.bracket.f14fXX
                    Return 2
                Case Else
                    Return MyBase.getTier(floor_num)
            End Select
        End If

        Return Nothing
    End Function

    Overrides Sub use(ByRef p As Player)
        If Not (mFloor.nonRandomFloors.Contains(Game.currFloor.floorNumber) Or Game.combat_engaged Or Game.shop_npc_engaged) Then
            Equipment.accChange(p, "Nothing")

            count -= 1

            TextEvent.pushLog("The flower opens a rift in space and time!")
            TextEvent.push("You hold the hibiscus with both hands, focusing intently on the mana that pulses through it." & DDUtils.RNRN &
                           "Before you- as the energy surges wildly- a crimson portal twists into being.  It slowly expands, until a hand reaches out and drags you through to the other side!", AddressOf useP2)
        Else
            TextEvent.pushAndLog("The flower doesn't react...")
        End If
    End Sub

    Protected Sub useP2()
        Game.mDun.jumpTo(91017)
        Game.mDun.setFloor(Game.currFloor)
        Game.player1.setPlayerImage()
        Game.drawBoard()

        Dim cae = New Caelia
        Game.npcEncounter(cae)
        Game.hideNPCButtons()

        TextEvent.pushNPCDialog("*giggle* Hi, I'm Caelia!" & DDUtils.RNRN &
                                "The magic on that flower pulled me here from another place.  It also kinda opened up a time rift, soooo have fun with that!", AddressOf Caelia.teleportPlayer)
    End Sub
End Class
