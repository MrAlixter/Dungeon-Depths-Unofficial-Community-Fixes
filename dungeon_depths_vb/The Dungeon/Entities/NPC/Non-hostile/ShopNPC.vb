Public MustInherit Class ShopNPC
    Inherits NPC
    Public firstCTurn As Boolean = True
    Public isShop = False
    Public picNormal, picPrincess, picBunny As Image
    Public picNCP As List(Of Image)
    Protected discount As Double = 0

    Shared Function shopFactory(ByVal nIndex As Integer)
        Select Case nIndex
            Case 1
                Return New TravelingWizard
            Case 2
                Return New HTeach
            Case 3
                Return New FVendor
            Case 4
                Return New WSmith
            Case Else
                Return New Shopkeeper
        End Select
    End Function

    Sub load(ByVal s As String)
        Dim playArray() As String = s.Split("*")
        MyBase.setName(playArray(0) & " the " & playArray(1))
        MyBase.health = playArray(3)
        MyBase.maxHealth = playArray(4)
        MyBase.attack = playArray(5)
        MyBase.defence = playArray(6)
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
        Game.picNPC.BackgroundImage = picNCP(npcIndex)

        If Game.combatmode Then attackCMD(Game.player)
    End Sub
    Public Overridable Sub encounter()
        pos = Game.player.pos
        If isDead = True Then
            Game.pushLblEvent("This NPC is dead.")
            Exit Sub
        End If
        setGold(9999)
        Game.npcIndex = npcIndex

        If Game.mDun.numCurrFloor < 5 AndAlso Game.mDun.floorboss(Game.mDun.numCurrFloor).Equals("Key") Then inv.setCount(53, 1) Else inv.setCount(53, 0)

        picNCP = New List(Of Image)
        picNCP.AddRange({picNormal, Game.picFrog.BackgroundImage, Game.picSheep.BackgroundImage, picPrincess, picBunny})
        If npcIndex < picNCP.Count Then Game.picNPC.BackgroundImage = picNCP(npcIndex)
        firstCTurn = True
        firstTurn = True
    End Sub

    Public Overridable Function getShopInv() As Inventory
        Dim tInv As Inventory = New Inventory(False)
        tInv.mergeRevalue(inv)
        If Game.mDun.numCurrFloor < 5 AndAlso Game.mDun.floorboss(Game.mDun.numCurrFloor).Equals("Key") Then tInv.setCount(53, 1) Else tInv.setCount(53, 0)


        For i = 0 To tInv.upperBound()
            Dim n = tInv.item(i).value
            tInv.item(i).value -= (n * discount)
        Next

        Return tInv
    End Function

    Public MustOverride Function toFight() As String
    Public MustOverride Function hitBySpell() As String

    Overridable Sub toBunny()
        MyBase.health = 1.0
        MyBase.maxHealth = 500
        MyBase.attack = 1
        MyBase.defence = 1
        MyBase.tfCt = 1
        MyBase.tfEnd = 15
        MyBase.npcIndex = 4
        toFemale("bunny")
        MyBase.form = "Bunny Girl"
        Game.NPCfromCombat(Me)
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
    End Sub
    Overridable Sub toPrincess()
        MyBase.health = 1.0
        MyBase.maxHealth = 999
        MyBase.attack = 50
        MyBase.defence = 1
        MyBase.tfCt = 1
        MyBase.tfEnd = 15
        MyBase.npcIndex = 3
        toFemale("prin")
        MyBase.form = "Princess"
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
    End Sub
    Overridable Sub toSheep()
        MyBase.health = 1.0
        MyBase.maxHealth = 600
        MyBase.attack = 1
        MyBase.defence = 40
        MyBase.tfCt = 1
        MyBase.tfEnd = 6
        MyBase.npcIndex = 2
        MyBase.form = "Sheep"
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
    End Sub

    Overridable Sub toFrog()
        MyBase.health = 1.0
        MyBase.maxHealth = 500
        MyBase.attack = 1
        MyBase.defence = 4
        MyBase.tfCt = 1
        MyBase.tfEnd = 6
        MyBase.npcIndex = 1
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
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
        If npcIndex > 4 Then npcIndex = 0
    End Sub

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
        Return True
    End Function
End Class
