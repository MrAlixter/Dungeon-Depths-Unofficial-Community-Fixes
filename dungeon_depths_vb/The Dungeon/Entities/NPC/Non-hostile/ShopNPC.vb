Public Enum sNPCInd
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
    Public npc_index As sNPCInd
    Public firstCTurn As Boolean = True
    Public isShop = False
    Public picNormal, picPrincess, picBunny, picArachne As Image
    Public picNPC As List(Of Image)
    Protected discount As Double = 0
    Public Shared npcLib As ImageCollection = New ImageCollection(2)

    Sub New()
        health = 1.0
        inv = New Inventory(False)
        title = " The "
    End Sub

    Shared Function shopFactory(ByVal nIndex As Integer)
        Select Case nIndex
            Case sNPCInd.shadywizard
                Return New ShadyWizard
            Case sNPCInd.hypnoteach
                Return New HypnoTeach
            Case sNPCInd.foodvendor
                Return New FVendor
            Case sNPCInd.weaponsmith
                Return New WSmith
            Case sNPCInd.cursebroker
                Return New CBrok
            Case sNPCInd.maskmaggirl
                Return New MaskedMG
            Case sNPCInd.timetraveler
                Return New TimeTraveler
            Case sNPCInd.faequeen
                Return New FaeQueen
            Case Else
                Return New Shopkeeper
        End Select
    End Function

    Public Overrides Sub update()
        If isDead = True Then Exit Sub
        If firstTurn = True Then
            firstTurn = False
            Exit Sub
        End If
        If tfCt > 0 Then
            tfCt += 1
        ElseIf tfCt > tfEnd Then
            tfCt = 0
            revert()
        End If
        If Game.combat_engaged And firstCTurn = True Then
            firstCTurn = False
            Exit Sub
        End If
        If img_index = 1 Or img_index = 2 Then despawn("flee")
        Game.picNPC.BackgroundImage = picNPC(img_index)
        If Game.combat_engaged Then attackCMD(Game.player1)
    End Sub
    Public Overridable Sub encounter()
        pos = Game.player1.pos
        If isDead = True Then
            TextEvent.push("This NPC is dead.")
            Exit Sub
        End If
        setGold(9999)

        Game.player1.currTarget = Me
        Game.active_shop_npc = Me

        If Game.mDun.floorboss.ContainsKey(Game.mDun.numCurrFloor) AndAlso
            Game.mDun.floorboss(Game.mDun.numCurrFloor).Equals("Key") Then inv.setCount(53, 1) Else inv.setCount(53, 0)

        If img_index < picNPC.Count Then Game.picNPC.BackgroundImage = picNPC(img_index)
        firstCTurn = True
        firstTurn = True
    End Sub

    Public Overridable Function getShopInv() As Inventory
        Dim tInv As Inventory = New Inventory(False)
        tInv.mergeRevalue(inv)
        If Game.mDun.floorboss.ContainsKey(Game.mDun.numCurrFloor) AndAlso
            Game.mDun.floorboss(Game.mDun.numCurrFloor).Equals("Key") Then tInv.setCount(53, 1) Else tInv.setCount(53, 0)


        For i = 0 To tInv.upperBound()
            Dim n = tInv.item(i).value
            tInv.item(i).value -= (n * discount)
        Next

        Return tInv
    End Function
    Public Function getDiscount() As Double
        Return discount
    End Function

    Public MustOverride Function toFight() As String
    Public MustOverride Function hitBySpell() As String

    Overridable Sub toBunny()
        MyBase.health = 1.0
        MyBase.tfEnd = 15

        MyBase.img_index = 4

        toFemale("bunny")
        MyBase.form = "Bunny Girl"

        Game.NPCfromCombat(Me)

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub
    Overridable Sub toPrincess()
        MyBase.health = 1.0
        MyBase.tfEnd = 15

        MyBase.img_index = 3
        toFemale("prin")

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub
    Overridable Sub toCatgirl()
        MyBase.health = 1.0
        MyBase.tfEnd = 15

        MyBase.img_index = getCatGirlImageInd()
        toFemale("catg")

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub
    Overridable Sub toSheep()
        MyBase.health = 1.0

        MyBase.img_index = 2

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub
    Overridable Sub toFrog()
        MyBase.health = 1.0

        MyBase.img_index = 1

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub
    Overridable Sub toTrilobite()
        MyBase.health = 1.0

        MyBase.img_index = getTrilobiteImageInd()

        Game.picNPC.BackgroundImage = picNPC(img_index)
    End Sub
    Overridable Sub toArachne()
        MyBase.health = 1.0
        MyBase.tfCt = 1
        MyBase.tfEnd = 9999999

        img_index = getArachneImageInd()

        toFemale("arachne")
        MyBase.form = "Arachne"
        Game.picNPC.BackgroundImage = picArachne
    End Sub
    Public Overridable Sub toDoll()
        TextEvent.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNPC(5)

        discount = 0.5
    End Sub
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

    Public Overrides Sub despawn(reason As String)
        MyBase.despawn(reason)
        Dim ratio As Double = Game.Size.Width / 1024
        Game.picNPC.Location = New Point(82 * ratio, 179 * ratio)
        Game.btnTalk.Visible = False
        Game.btnNPCMG.Visible = False
        Game.cboxNPCMG.Visible = False
        Game.btnShop.Visible = False
        Game.btnFight.Visible = False
        Game.btnLeave.Visible = False

        'reset the npc image index
        If img_index > 4 And Not Game.picNPC.BackgroundImage.Equals(ShopNPC.npcLib.atrs(0).getAt(9)) And Not img_index = getArachneImageInd() And Not img_index = getCatGirlImageInd() Then img_index = 0
    End Sub
    Public Overridable Function getArachneImageInd() As Integer
        Return 6
    End Function
    Public Overridable Function getCatGirlImageInd() As Integer
        Return 7
    End Function
    Public Overridable Function getTrilobiteImageInd() As Integer
        Return 8
    End Function

    'save/load methods
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
End Class
