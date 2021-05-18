Public Enum sNPCInd
    shopkeeper
    shadywizard
    hypnoteach
    foodvendor
    weaponsmith
    cursebroker
    maskmaggirl
    timetraveler
End Enum


'| -- New Layout Example -- |
'|ID Info|


'|NPC Flags|


'|Inventory|


'|Stats|


'|Images|



Public MustInherit Class ShopNPC
    Inherits NPC
    Public firstCTurn As Boolean = True
    Public isShop = False
    Public picNormal, picPrincess, picBunny, picArachne As Image
    Public picNPC As List(Of Image)
    Protected discount As Double = 0
    Public Shared npcLib As ImageCollection = New ImageCollection(2)

    Sub New()
        health = 1.0
        inv = New Inventory(False)
        title = " the "
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
            Case Else
                Return New Shopkeeper
        End Select
    End Function

    Sub load(ByVal s As String)
        Dim playArray() As String = s.Split("*")
        setName(playArray(0) & " the " & playArray(1))
        MyBase.health = playArray(3)
        MyBase.maxHealth = playArray(4)
        MyBase.attack = playArray(5)
        MyBase.defense = playArray(6)
        MyBase.speed = playArray(7)
        inv.load(playArray(8))
        MyBase.title = ""
    End Sub
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
        If Game.combatmode And firstCTurn = True Then
            firstCTurn = False
            Exit Sub
        End If
        If npcIndex = 1 Or npcIndex = 2 Then despawn("flee")
        Game.picNPC.BackgroundImage = picNPC(npcIndex)
        If Game.combatmode Then attackCMD(Game.player1)
    End Sub
    Public Overrides Function getName() As String
        Return title & name
    End Function
    Public Overridable Sub encounter()
        pos = Game.player1.pos
        If isDead = True Then
            Game.pushLblEvent("This NPC is dead.")
            Exit Sub
        End If
        setGold(9999)

        Game.player1.currTarget = Me
        Game.currNPC = Me

        If Game.mDun.floorboss.ContainsKey(Game.mDun.numCurrFloor) AndAlso
            Game.mDun.floorboss(Game.mDun.numCurrFloor).Equals("Key") Then inv.setCount(53, 1) Else inv.setCount(53, 0)

        If npcIndex < picNPC.Count Then Game.picNPC.BackgroundImage = picNPC(npcIndex)
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

        MyBase.npcIndex = 4

        toFemale("bunny")
        MyBase.form = "Bunny Girl"

        Game.NPCfromCombat(Me)

        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub
    Overridable Sub toPrincess()
        MyBase.health = 1.0
        MyBase.tfEnd = 15

        MyBase.npcIndex = 3
        toFemale("prin")

        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub
    Overridable Sub toCatgirl()
        MyBase.health = 1.0
        MyBase.tfEnd = 15

        MyBase.npcIndex = getCatGirlImageInd()
        toFemale("catg")

        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub
    Overridable Sub toSheep()
        MyBase.health = 1.0

        MyBase.npcIndex = 2

        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub
    Overridable Sub toFrog()
        MyBase.health = 1.0
  
        MyBase.npcIndex = 1

        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub
    Overridable Sub toTrilobite()
        MyBase.health = 1.0

        MyBase.npcIndex = getTrilobiteImageInd()

        Game.picNPC.BackgroundImage = picNPC(npcIndex)
    End Sub
    Overridable Sub toArachne()
        MyBase.health = 1.0
        MyBase.tfCt = 1
        MyBase.tfEnd = 9999999

        npcIndex = getArachneImageInd()

        toFemale("arachne")
        MyBase.form = "Arachne"
        Game.picNPC.BackgroundImage = picArachne
    End Sub
    Public Overridable Sub toDoll()
        Game.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNPC(5)

        discount = 0.5
    End Sub
    Public Overridable Sub toFemale(ByVal form As String)
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
    End Sub
    Public Overridable Sub toMale(ByVal form As String)
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
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
        If npcIndex > 4 And Not Game.picNPC.BackgroundImage.Equals(ShopNPC.npcLib.atrs(0).getAt(3)) Then npcIndex = 0
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
        out += npcIndex & "%"   '0
        out += gold & "%"       '1
        out += pos.X & "%"      '2
        out += pos.Y & "%"      '3
        out += form & "%"       '4
        out += title & "%"      '5
        out += pronoun & "%"    '6
        out += pPronoun & "%"   '7
        out += rPronoun & "%"   '8
        out += isShop & "%"     '9
        out += isDead & "%"     '10
        Return out
    End Function
    Function loadNPC(ByVal s As String) As Boolean
        Dim loadedVars = s.Split("%")

        npcIndex = CInt(loadedVars(0))
        gold = CInt(loadedVars(1))
        pos = New Point(CInt(loadedVars(2)), CInt(loadedVars(3)))
        form = loadedVars(4)
        title = loadedVars(5)
        pronoun = loadedVars(6)
        pPronoun = loadedVars(7)
        rPronoun = loadedVars(8)
        isShop = CBool(loadedVars(9))
        isDead = CBool(loadedVars(10))
        Return True
    End Function
End Class
