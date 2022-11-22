Public Enum ShopNPCInd
    shopkeeper
    shadywizard
    hypnoteach
    foodvendor
    weaponsmith
    cursebroker
    maskmaggirl
    timetraveler
    faequeen
End Enum

'| -- Constructor Layout Example -- |
'|ID Info|


'|NPC Flags|


'|Inventory|


'|Stats|


'|Images|

Public MustInherit Class ShopNPC
    Inherits NPC

    Protected Enum LocalImgInd
        normal
        frog
        bunny
        princess
        sheep
        doll
        arachne
        alt1
        alt2
        alt3
        alt4
        alt5
        alt6
        alt7
        alt8
        catgirl
        trilobite
        beegirl
    End Enum

    '| -- Identification Vars -- |
    Public npc_index As ShopNPCInd

    '| -- Combat Vars -- |
    Protected firstCTurn As Boolean = True

    '| -- NPC Flags -- |
    Public isShop As Boolean = False
    Public discount As Double = 0

    '| -- Image Vars -- |
    Protected local_img As Dictionary(Of LocalImgInd, Image)
    Public Shared gbl_img As ImageCollection = New ImageCollection(2)

    Sub New()
        '|-- Inventory -- |
        inv = New Inventory(False)

        '| -- Stats -- |
        health = 1.0

        '| -- Dialog Handles -- |
        title = " The "
    End Sub

    Public Overridable Function fleeFromAnimalTF() As Boolean
        Return True
    End Function

    Public Overrides Sub update()
        '| -- Genral/Clean Up -- |
        If isDead = True Then Exit Sub

        If fleeFromAnimalTF() And (img_index = LocalImgInd.frog Or img_index = LocalImgInd.sheep) Then
            despawn("flee")
            Exit Sub
        End If

        If local_img.ContainsKey(img_index) Then
            Game.picNPC.BackgroundImage = local_img(img_index)
        Else
            Game.picNPC.BackgroundImage = local_img(LocalImgInd.normal)
        End If

        '| -- First Turn -- |
        If firstTurn = True Then
            firstTurn = False
        End If

        If Game.combat_engaged Then Game.lblEName.Text = getName()

        If Game.combat_engaged And firstCTurn = True Then
            firstCTurn = False
        ElseIf Game.combat_engaged Then
            attackCMD(Game.player1)
        End If

        '| -- Polymorph Handling -- |
        If tfCt > 0 Then
            tfCt += 1
        ElseIf tfCt > tfEnd Then
            tfCt = 0
            revert()
        End If
    End Sub
    Public Sub drawPort()
        If local_img.ContainsKey(img_index) Then Game.picNPC.BackgroundImage = local_img(img_index) Else Game.picNPC.BackgroundImage = local_img(LocalImgInd.normal)
    End Sub

    Public Overridable Function getShopInv() As Inventory
        Dim tInv As Inventory = New Inventory(False)

        tInv.mergeRevalue(inv)

        If Game.mDun.floorboss.ContainsKey(Game.mDun.numCurrFloor) AndAlso Game.mDun.floorboss(Game.mDun.numCurrFloor).Equals("Key") Then
            tInv.setCount(53, 1)
        Else
            tInv.setCount(53, 0)
        End If

        Return tInv
    End Function

    Public Overrides Sub despawn(reason As String)
        MyBase.despawn(reason)

        Game.hideNPCButtons()

        'reset the npc image index
        If img_index > 4 And Not Game.picNPC.BackgroundImage.Equals(ShopNPC.gbl_img.atrs(0).getAt(9)) And Not img_index = LocalImgInd.arachne And Not img_index = LocalImgInd.catgirl Then img_index = LocalImgInd.normal
    End Sub

    Public Overridable Sub encounter()
        '| -- Genral/Clean Up -- |
        If isDead = True Then
            TextEvent.push("This NPC is dead.")
            Exit Sub
        End If
        Dim p As Player = Game.player1

        '| -- NPC Reset -- |
        pos = p.pos
        p.currTarget = Me
        Game.active_shop_npc = Me
        discount = 0
        setGold(9999)
        firstCTurn = True
        firstTurn = True

        '| -- Inventory Update -- |
        If Game.mDun.floorboss.ContainsKey(Game.mDun.numCurrFloor) AndAlso Game.mDun.floorboss(Game.mDun.numCurrFloor).Equals("Key") Then
            inv.setCount(53, 1)
        Else
            inv.setCount(53, 0)
        End If
        If img_index = LocalImgInd.arachne And Not p.formName.Equals("Arachne") Then
            inv.setCount(244, 1)
        Else
            inv.setCount(244, 0)
        End If

        inventoryUpdate()

        '| -- Dialog -- |
        Dim dialog = ""
        Select Case img_index
            Case LocalImgInd.frog
                dialog = frogDialog(p)
            Case LocalImgInd.bunny
                dialog = bunnyDialog(p)
            Case LocalImgInd.princess
                dialog = princessDialog(p)
            Case LocalImgInd.sheep
                dialog = sheepDialog(p)
            Case LocalImgInd.doll
                dialog = dollDialog(p)
            Case LocalImgInd.arachne
                dialog = arachneDialog(p)
            Case LocalImgInd.catgirl
                dialog = catgirlDialog(p)
            Case LocalImgInd.trilobite
                dialog = trilobiteDialog(p)
            Case LocalImgInd.beegirl
                dialog = beegirlDialog(p)
            Case Else
                dialog = normalDialog(p)
        End Select

        If Not dialog.Equals("") Then TextEvent.pushNPCDialog(dialog)

        '| -- Image Setting -- |
        drawPort()
    End Sub
    Public Overridable Sub inventoryUpdate()
    End Sub

    Public Overridable Function toFight() As String
        Dim p As Player = Game.player1

        Select Case img_index
            Case LocalImgInd.frog
                Return frogFightDialog(p)
            Case LocalImgInd.bunny
                Return bunnyFightDialog(p)
            Case LocalImgInd.princess
                Return princessFightDialog(p)
            Case LocalImgInd.sheep
                Return sheepFightDialog(p)
            Case LocalImgInd.doll
                Return dollFightDialog(p)
            Case LocalImgInd.arachne
                Return arachneFightDialog(p)
            Case LocalImgInd.catgirl
                Return catgirlFightDialog(p)
            Case LocalImgInd.trilobite
                Return trilobiteDialog(p)
            Case LocalImgInd.beegirl
                Return beegirlFightDialog(p)
            Case Else
                Return normalFightDialog(p)
        End Select
    End Function

    Public Overridable Function hitBySpell() As String
        Dim p As Player = Game.player1

        Select Case img_index
            Case LocalImgInd.frog
                Game.toCombat(Me)
                Return frogSpellDialog(p)
            Case LocalImgInd.bunny
                Return bunnySpellDialog(p)
            Case LocalImgInd.princess
                Game.toCombat(Me)
                Return princessSpellDialog(p)
            Case LocalImgInd.sheep
                Game.toCombat(Me)
                Return sheepSpellDialog(p)
            Case LocalImgInd.doll
                Return dollSpellDialog(p)
            Case LocalImgInd.arachne
                Game.toCombat(Me)
                Return arachneSpellDialog(p)
            Case LocalImgInd.catgirl
                Game.toCombat(Me)
                Return catgirlSpellDialog(p)
            Case LocalImgInd.trilobite
                Return trilobiteDialog(p)
            Case LocalImgInd.beegirl
                Game.toCombat(Me)
                Return beegirlSpellDialog(p)
            Case Else
                Game.toCombat(Me)
                Return normalSpellDialog(p)
        End Select
    End Function

    '| - TRANSFORMATIONS - |
    Public Overridable Sub toFemale(ByVal form As String)
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
    End Sub
    Public Overridable Sub toMale(ByVal form As String)
        pronoun = "he"
        p_pronoun = "his"
        r_pronoun = "him"
    End Sub

    Protected Sub tfStatUpdate()
        health = 1.0
        Game.picNPC.BackgroundImage = local_img(img_index)
    End Sub

    Public Overridable Sub toFrog()
        img_index = LocalImgInd.frog
        tfStatUpdate()
    End Sub
    Public Overridable Sub toBunny()
        tfEnd = 15

        toFemale("bunny")
        form = "Bunny Girl"

        img_index = LocalImgInd.bunny
        tfStatUpdate()

        If Game.combat_engaged Then Game.shopNPCFromCombat(Me)
    End Sub
    Public Overridable Sub toPrincess()
        tfEnd = 15

        toFemale("prin")

        img_index = LocalImgInd.princess
        tfStatUpdate()
    End Sub
    Public Overridable Sub toSheep()
        tfEnd = 15

        img_index = LocalImgInd.sheep
        tfStatUpdate()
    End Sub
    Public Overridable Sub toDoll()
        TextEvent.pushNPCDialog("*squeak*")
        Game.picNPC.BackgroundImage = local_img(LocalImgInd.doll)
        discount = 0.5

        If Game.combat_engaged Then Game.shopNPCFromCombat(Me)
    End Sub
    Public Overridable Sub toArachne()
        tfCt = 1
        tfEnd = 9999999

        toFemale("arachne")
        form = "Arachne"

        img_index = LocalImgInd.arachne
        tfStatUpdate()
    End Sub
    Public Overridable Sub toCatgirl()
        tfEnd = 15

        toFemale("catg")

        img_index = LocalImgInd.catgirl
        tfStatUpdate()
    End Sub
    Public Overridable Sub toTrilobite()
        img_index = LocalImgInd.trilobite
        tfStatUpdate()
    End Sub
    Public Overridable Sub toBeeGirl()
        tfEnd = 15

        toFemale("beeg")

        img_index = LocalImgInd.beegirl
        tfStatUpdate()

        If Game.combat_engaged Then Game.shopNPCFromCombat(Me)
    End Sub

    '| - DIALOG - |
    Protected Overridable Function normalDialog(ByRef p As Player)
        Return "Hello, valued customer!"
    End Function
    Protected Overridable Function frogDialog(ByRef p As Player)
        Return "Ribbit.  Ribbit."
    End Function
    Protected Overridable Function bunnyDialog(ByRef p As Player)
        Return "Like, hey, cutie customer!"
    End Function
    Protected Overridable Function princessDialog(ByRef p As Player)
        Return "Hark, valued customer!"
    End Function
    Protected Overridable Function sheepDialog(ByRef p As Player)
        Return "Baaahhh."
    End Function
    Protected Overridable Function dollDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overridable Function arachneDialog(ByRef p As Player)
        Return "Hello, valued customer!"
    End Function
    Protected Overridable Function catgirlDialog(ByRef p As Player)
        Return "Nya-llo, valued customer!"
    End Function
    Protected Overridable Function trilobiteDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overridable Function beegirlDialog(ByRef p As Player)
        Return "Bzz.  Bzzz."
    End Function

    Protected Overridable Function normalFightDialog(ByRef p As Player)
        Return "Have at you!"
    End Function
    Protected Overridable Function frogFightDialog(ByRef p As Player)
        Return "RIBBIT!"
    End Function
    Protected Overridable Function bunnyFightDialog(ByRef p As Player)
        Return "Like, no!"
    End Function
    Protected Overridable Function princessFightDialog(ByRef p As Player)
        Return "Have at thee!"
    End Function
    Protected Overridable Function sheepFightDialog(ByRef p As Player)
        Return "BAAAAAHHHH!"
    End Function
    Protected Overridable Function dollFightDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overridable Function arachneFightDialog(ByRef p As Player)
        Return "Have at you!"
    End Function
    Protected Overridable Function catgirlFightDialog(ByRef p As Player)
        Return "Have at you!"
    End Function
    Protected Overridable Function trilobiteFightDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overridable Function beegirlFightDialog(ByRef p As Player)
        Return "BZZ! BZZBZZBZZ!"
    End Function

    Protected Overridable Function normalSpellDialog(ByRef p As Player)
        Return "Have at you!"
    End Function
    Protected Overridable Function frogSpellDialog(ByRef p As Player)
        Return "RIBBIT!"
    End Function
    Protected Overridable Function bunnySpellDialog(ByRef p As Player)
        Return "Like, no!"
    End Function
    Protected Overridable Function princessSpellDialog(ByRef p As Player)
        Return "Have at thee!"
    End Function
    Protected Overridable Function sheepSpellDialog(ByRef p As Player)
        Return "BAAAAAHHHH!"
    End Function
    Protected Overridable Function dollSpellDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overridable Function arachneSpellDialog(ByRef p As Player)
        Return "Have at you!"
    End Function
    Protected Overridable Function catgirlSpellDialog(ByRef p As Player)
        Return "Have at you!"
    End Function
    Protected Overridable Function trilobiteSpellDialog(ByRef p As Player)
        Return "..."
    End Function
    Protected Overridable Function beegirlSpellDialog(ByRef p As Player)
        Return "BZZ! BZZBZZBZZ!"
    End Function

    Public Overridable Function postPurchaseDialog(ByRef p As Player)
        Return "Thank you, valued customer!"
    End Function

    '| -- SAVE / LOAD -- |
    Function saveNPC() As String
        Dim out = ""
        out += img_index & "%"   '0
        out += gold & "%"       '1
        out += pos.X & "%"      '2
        out += pos.Y & "%"      '3
        out += form & "%"       '4
        out += title & "%"      '5
        out += pronoun & "%"    '6
        out += p_pronoun & "%"   '7
        out += r_pronoun & "%"   '8
        out += isShop & "%"     '9
        out += isDead & "%"     '10
        Return out
    End Function
    Function loadNPC(ByVal s As String) As Boolean
        Dim loadedVars = s.Split("%")

        img_index = CInt(loadedVars(0))
        gold = CInt(loadedVars(1))
        pos = New Point(CInt(loadedVars(2)), CInt(loadedVars(3)))
        form = loadedVars(4)
        title = loadedVars(5)
        pronoun = loadedVars(6)
        p_pronoun = loadedVars(7)
        r_pronoun = loadedVars(8)
        isShop = CBool(loadedVars(9))
        isDead = CBool(loadedVars(10))
        Return True
    End Function

    '| - MISC - |
    Shared Function shopFactory(ByVal ind As ShopNPCInd)
        Select Case ind
            Case ShopNPCInd.shadywizard
                Return New ShadyWizard
            Case ShopNPCInd.hypnoteach
                Return New HypnoTeach
            Case ShopNPCInd.foodvendor
                Return New FVendor
            Case ShopNPCInd.weaponsmith
                Return New WSmith
            Case ShopNPCInd.cursebroker
                Return New CBrok
            Case ShopNPCInd.maskmaggirl
                Return New MaskedMG
            Case ShopNPCInd.timetraveler
                Return New TimeTraveler
            Case ShopNPCInd.faequeen
                Return New FaeQueen
            Case Else
                Return New Shopkeeper
        End Select
    End Function
    Public Shared Function getAdjustedValue(ByRef sk As ShopNPC, ByRef itm As String) As Integer
        Return (sk.inv.item(itm).value) - (sk.discount * (sk.inv.item(itm).value))
    End Function
    Public Overridable Sub buildShopArea(ByRef floor As mFloor)
        Dim area = {New Point(pos.X - 1, pos.Y - 1), New Point(pos.X, pos.Y - 1), New Point(pos.X + 1, pos.Y - 1),
                    New Point(pos.X - 1, pos.Y), New Point(pos.X, pos.Y), New Point(pos.X + 1, pos.Y),
                    New Point(pos.X - 1, pos.Y + 1), New Point(pos.X, pos.Y + 1), New Point(pos.X + 1, pos.Y + 1)}

        For Each pt In area
            If floor.ptInBounds(pt) Then floor.mBoard(pt.Y, pt.X).Tag = 2
        Next
    End Sub
End Class
