Public Class Caelia
    Inherits ShopNPC
    Sub New()
        MyBase.New()

        '|ID Info|
        name = "Caelia"
        sName = name

        '|NPC Flags|
        pronoun = "she"
        p_pronoun = "her"
        r_pronoun = "her"
        title = ""
        isShop = False

        '|Inventory|


        '|Stats|
        maxHealth = 9999
        attack = 99
        defense = 99
        speed = 999
        gold = 0
        xp_value = (maxHealth + attack + defense + speed) / 4
        sMaxHealth = maxHealth
        sMaxMana = maxMana
        sAttack = attack
        sdefense = defense
        sWill = will
        sSpeed = speed

        '|Images|
        picNormal = ShopNPC.npcLib.atrs(0).getAt(32)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(33)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(34)

        picNPC = New List(Of Image)
        picNPC.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not target.GetType() Is GetType(Player) Then
            MyBase.attackCMD(target)
        Else
            Game.NPCfromCombat(Me)
            Game.leaveNPC()
            TextEvent.push("""Well, someone needs to relax...""")
            Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
            bTF.step2()
            Game.player1.inv.add(147, 1)
            EquipmentDialogBackend.armorChange(Game.player1, "Skimpy_Tube_Top")
            Game.player1.drawPort()
            pos = New Point(-1, -1)
        End If
    End Sub
    Shared Sub teleportPlayer()
        Game.leaveNPC()
        Game.mDun.jumpTo(91017)
        Game.mDun.setFloor(Game.currFloor)
        Game.player1.setPlayerImage()
        Game.drawBoard()
    End Sub
    Public Overrides Sub encounter()
        MyBase.encounter()
        If img_index = 0 Then
            TextEvent.pushNPCDialog("Hey, what's up?")
        ElseIf img_index = 1 Then
            TextEvent.pushNPCDialog("Ribbit.  Ribbit.")
        ElseIf img_index = 2 Then
            TextEvent.pushNPCDialog("Baaahhh.")
        ElseIf img_index = 3 Then
            TextEvent.pushNPCDialog("Hello, kind " & Game.player1.className & ", how are you on this fine day?")
        ElseIf img_index = 4 Then
            TextEvent.pushNPCDialog("*giggle* Hey!")
        End If
    End Sub
    Public Overrides Function toFight() As String
        If img_index = 0 Then
            Return "So you want to fight, eh?  I'm ready whenever you are."
        ElseIf img_index = 1 Then
            Return "Ribbit . . ."
        ElseIf img_index = 2 Then
            Return "BAAAAAHHHH!"
        ElseIf img_index = 3 Then
            Return "You would dare to challenge me? If you wish to die, you could just say so."
        ElseIf img_index = 4 Then
            Return "I might not be the best fighter any more, but I can definitely give it my best!"
        End If
        Return "Bad move."
    End Function
    Public Overrides Function hitBySpell() As String
        If img_index = 0 Then
            Game.NPCtoCombat(Me)
            Return "Did . . . did you just cast a spell on me?  You know I have to kill you now, right?"
        ElseIf img_index = 1 Then
            Game.NPCtoCombat(Me)
            Return "Ribbit!!!"
        ElseIf img_index = 2 Then
            Game.NPCtoCombat(Me)
            Return "[angry bleets]!"
        ElseIf img_index = 3 Then
            Game.NPCtoCombat(Me)
            Return "Casting spells on royalty is genrally not a good idea."
        ElseIf img_index = 4 Then
            Return "*giggle* Was that magic?"
        End If
        Return "Woah there!"
    End Function
End Class
