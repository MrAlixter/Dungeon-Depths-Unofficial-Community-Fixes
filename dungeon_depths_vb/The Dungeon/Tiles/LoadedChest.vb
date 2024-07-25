Public Class LoadedChest
    Inherits Chest

    Dim onOpen As Action
    Public cid As Integer

    Sub New(ByVal p As Point, ByVal contentID As Integer)
        MyBase.New()
        pos = p
        setInv(contentID)
        onOpen = getOnOpen(contentID)
    End Sub
    Sub New(ByVal s As String)
        Dim cArray = s.Split("*")
        pos = New Point(cArray(1), cArray(2))
        onOpen = getOnOpen(CInt(cArray(3)))
        setInv(CInt(cArray(3)))
    End Sub

    Sub setInv(ByVal contentID As Integer)
        cid = contentID
        Select Case contentID
            Case 3 Or 4
                add(53, 1)
        End Select
    End Sub
    Function getOnOpen(ByVal contentID As Integer) As action
        Select Case contentID
            Case 3
                Return AddressOf keyChest
            Case 4
                Return AddressOf floor4StartChest
            Case 5
                Return AddressOf magSlutChest
            Case 6
                Return AddressOf armorFragmentChest
        End Select
        Return Nothing
    End Function

    Public Overrides Sub open(Optional ByVal try_mimic As Boolean = True)
        MyBase.open()
        onOpen()
        onOpen = Nothing
    End Sub

    Sub floor4StartChest()
        Game.player1.inv.add(53, 1)
        Game.currFloor.beatBoss = False
        Game.player1.formStates(stateInd.preBSBody) = New State()
        Game.mDun.floor_boss(4) = "Ooze Empress"
        Game.player1.formStates(stateInd.preBSBody) = New State(Game.player1)
        Game.player1.forcedPath = Game.currFloor.route(Game.player1.pos, Game.player1.pos)
        Game.player1.forcedPath = {Game.player1.forcedPath(0)}
        TextEvent.push("Upon opening the chest, you find a familiar key.  Well, that was easy.")
        Game.player1.quests(qInd.floor4encounter).init()
    End Sub

    Sub keyChest()
        Game.player1.inv.add(53, 1)
        TextEvent.push("Upon opening the chest, you find a key!")
    End Sub

    Sub magSlutChest()
        Game.player1.inv.add(171, 1)
        Game.player1.equippedWeapon.onUnequip(Game.player1, Game.player1.equippedWeapon)
        Game.player1.equippedWeapon = Game.player1.inv.item(171)
        TextEvent.push("As soon as you open the lid of the chest, a loud click gives you only seconds to react as a pink, heart-tipped wand is flung at you from within!  Miraculously, you are able to catch it mid-air before getting hit in the face.  As it begins glowing and reality around you begins fading away into a techicolor void, though, you wonder if it would have been better to just take the hit...",
                          AddressOf MagSlutChest2)

    End Sub
    Sub MagSlutChest2()
        Game.player1.equippedWeapon.onEquip(Game.player1)
        Game.player1.drawPort()
    End Sub

    Sub armorFragmentChest()
        Game.player1.inv.add("Armor_Fragments", 1)
        TextEvent.push("Upon opening the chest, you find several fragments of an old set of armor!")
    End Sub

    Public Overrides Function ToString() As String
        Return "LOADED*" & CStr(pos.X & "*") & CStr(pos.Y & "*") & CStr(cid) & "*"
    End Function
End Class
