Public Class Caelia
    Inherits ShopNPC
    Sub New()
        name = "Caelia"
        health = 1.0
        maxHealth = 9999
        attack = 99
        defence = 99
        speed = 999

        'Define the inventory
        inv = New Inventory(False)
        'Armor/Accesories

        isShop = False
        gold = 0
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        picNormal = Game.picCaelia.BackgroundImage
        picPrincess = Game.picCaeliaP.BackgroundImage
        picBunny = Game.picCaeliaB.BackgroundImage

        picNCP = New List(Of Image)
        picNCP.AddRange({picNormal, Game.picFrog.BackgroundImage, Game.picSheep.BackgroundImage, picPrincess, picBunny})

        If speed = Game.player1.speed Then speed -= 1
        title = ""
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If Not target.GetType() Is GetType(Player) Then
            MyBase.attackCMD(target)
        Else
            Game.NPCfromCombat(Me)
            Game.leaveNPC()
            Game.pushLblEvent("""Well, someone needs to relax...""")
            Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
            bTF.step2()
            Game.player1.inv.add(147, 1)
            Equipment.clothesChange("Skimpy_Tube_Top")
            Game.player1.drawPort()
            pos = New Point(-1, -1)
        End If
    End Sub
    Shared Sub teleportPlayer()
        Game.leaveNPC()
        Game.mDun.jumpTo(91017)
        Game.mDun.setFloor(Game.currFloor)
        Game.player1.setPImage()
        Game.drawBoard()
    End Sub
    Public Overrides Sub encounter()
        MyBase.encounter()
        If npcIndex = 0 Then
            Game.pushNPCDialog("Hey, what's up?")
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit.")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("Baaahhh.")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hello, kind " & Game.player1.pClass.name & ", how are you on this fine day?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("*giggle* Hey!")
        End If
    End Sub
    Public Overrides Function toFight() As String
        If npcIndex = 0 Then
            Return "So you want to fight, eh?  I'm ready whenever you are."
        ElseIf npcIndex = 1 Then
            Return "Ribbit . . ."
        ElseIf npcIndex = 2 Then
            Return "BAAAAAHHHH!"
        ElseIf npcIndex = 3 Then
            Return "You would dare to challenge me? If you wish to die, you could just say so."
        ElseIf npcIndex = 4 Then
            Return "I might not be the best fighter any more, but I can definitely give it my best!"
        End If
        Return "Bad move."
    End Function
    Public Overrides Function hitBySpell() As String
        If npcIndex = 0 Then
            Game.NPCtoCombat(Me)
            Return "Did . . . did you just cast a spell on me?  You know I have to kill you now, right?"
        ElseIf npcIndex = 1 Then
            Game.NPCtoCombat(Me)
            Return "Ribbit!!!"
        ElseIf npcIndex = 2 Then
            Game.NPCtoCombat(Me)
            Return "[angry bleets]!"
        ElseIf npcIndex = 3 Then
            Game.NPCtoCombat(Me)
            Return "Casting spells on royalty is genrally not a good idea."
        ElseIf npcIndex = 4 Then
            Return "*giggle* Was that magic?"
        End If
        Return "Woah there!"
    End Function
End Class
