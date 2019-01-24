Public Class Shopkeep
    Inherits Monster
    Public firstCTurn As Boolean = True
    Public isShop = False
    Public picNormal, picPrincess, picBunny As Image
    Public picNCP() As Image

    Sub New(ByVal mIndex As Integer)
        MyBase.New(-1)
        Select Case mIndex
            Case 1
               
            Case 2
                MyBase.setName("Shopkeeper")
                MyBase.setHealth(1.0)
                MyBase.setMaxHealth(99999)
                MyBase.setATK(99999)
                MyBase.setDEF(99999)
                MyBase.setSPD(99)

                'Define the inventory
                'Useables
                MyBase.inv.setCount("Compass", 1)
                MyBase.inv.setCount("Spellbook", 1)
                'Potions
                MyBase.inv.setCount("Health_Potion", 1)
                MyBase.inv.setCount("Mana_Potion", 1)
                'Food
                MyBase.inv.setCount("Chicken_Leg", 1)
                'Armor/Accesories
                MyBase.inv.setCount("Steel_Armor", 1)
                MyBase.inv.setCount("Gold_Armor", 1)
                'Weapons
                MyBase.inv.setCount("Steel_Sword", 1)
                MyBase.inv.setCount("Oak_Staff", 1)
                MyBase.inv.setCount("Gold_Sword", 1)
                MyBase.inv.setCount("Golden_Staff", 1)
                MyBase.inv.setCount("Midas_Gauntlet", 1)

                isShop = True
                setGold(99999)
                pronoun = "he"
                pPronoun = "his"
                rPronoun = "him"
                picNormal = Game.picShopkeep.BackgroundImage
                picPrincess = Game.picSKPrin.BackgroundImage
                picBunny = Game.picSKBunny.BackgroundImage
            Case 3
                MyBase.setName("Traveling Wizard")
                MyBase.setHealth(1.0)
                MyBase.setMaxHealth(99999)
                MyBase.setATK(99999)
                MyBase.setDEF(99999)
                MyBase.setSPD(99)

                'Define the inventory
                'Useables
                MyBase.inv.setCount("Spellbook", 1)
                MyBase.inv.setCount("Mana_Charm", 1)
                'Potions
                MyBase.inv.setCount("Mana_Potion", 1)
                MyBase.inv.setCount("Glittery_Potion", 1)
                MyBase.inv.setCount("Azure_Potion", 1)
                MyBase.inv.setCount("Rose_Potion", 1)
                MyBase.inv.setCount("Mauve_Potion", 1)
                MyBase.inv.setCount("Golden_Potion", 1)
                MyBase.inv.setCount("Murky_Potion", 1)
                'Foods
                MyBase.inv.setCount("Apple​", 1)
                MyBase.inv.setCount("Angel_Food_Cake", 1)
                MyBase.inv.setCount("Stick_of_Gum", 1)
                'Armors
                MyBase.inv.setCount("Steel_Bikini", 1)
                MyBase.inv.setCount("Bunny_Suit", 1)
                MyBase.inv.setCount("Witch_Cosplay", 1)
                MyBase.inv.setCount("Cowbell", 1)
                MyBase.inv.setCount("Gold_Adornment", 1)
                'Weapons
                MyBase.inv.setCount("Duster", 1)

                isShop = True
                setGold(99999)
                pronoun = "he"
                pPronoun = "his"
                rPronoun = "him"
                picNormal = Game.picSW.BackgroundImage
                picPrincess = Game.PicSWPrin.BackgroundImage
                picBunny = Game.picSWb.BackgroundImage
            Case Else
                MyBase.setName("BadShopkeeper")
                MyBase.setHealth(1.0)
                MyBase.setMaxHealth(9)
                MyBase.setATK(9)
                MyBase.setDEF(9)
                MyBase.setSPD(9)
                MyBase.inv.setCount("Compass", 1)
        End Select
        If speed = Game.player.speed Then speed -= 1
        MyBase.title = ""
    End Sub
    Sub New(ByVal s As String)
        MyBase.New(-1)
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
        If Game.player.pForm.name.Equals("Black Cat") Or Game.player.pForm.name.Equals("Chicken") Then despawn("animaltf")
        If Game.combatmode Then attackCMD(Game.player)
    End Sub
    Public Sub encounter()
        pos = Game.player.pos
        If isDead = True Then
            Game.pushLblEvent("This NPC is dead.")
            Exit Sub
        End If
        If getName() = "Shopkeeper" Or getName.Equals("Traveling Wizard") Then setGold(9999)
        Game.npcIndex = npcIndex
        If getName.Equals("Traveling Wizard") Then
            If npcIndex = 0 Then
                If CInt(Game.player.health * Game.player.getMaxHealth()) = 69 Then
                    Game.pushNPCDialog("Ehehe. Your health. Nice." & vbCrLf & "Anyway, what are you buying?")
                Else
                    Game.pushNPCDialog("What are you buying?")
                End If
            ElseIf npcIndex = 1 Then
                Game.pushNPCDialog("Ribbit.  Ribbit!")
            ElseIf npcIndex = 2 Then
                Game.pushNPCDialog("*bleets*")
            ElseIf npcIndex = 3 Then
                Game.pushNPCDialog("Hey, " & Game.player.pClass.name & ", how's it going?")
            ElseIf npcIndex = 4 Then
                Game.pushNPCDialog("So are these real or fake?  My ears, I mean.")
            End If
        Else
            If npcIndex = 0 Then
                Game.pushNPCDialog("Hey, what's up?")
            ElseIf npcIndex = 1 Then
                Game.pushNPCDialog("Ribbit.  Ribbit.")
            ElseIf npcIndex = 2 Then
                Game.pushNPCDialog("Baaahhh.")
            ElseIf npcIndex = 3 Then
                Game.pushNPCDialog("Hello, kind " & Game.player.pClass.name & ", how are you on this fine day?")
            ElseIf npcIndex = 4 Then
                Game.pushNPCDialog("*giggle* Hey!")
            End If
        End If
        If Game.floor < 5 AndAlso Game.floorboss(Game.floor).Equals("Key") Then inv.setCount(53, 1) Else inv.setCount(53, 0)
        picNCP = {picNormal, Game.picFrog.BackgroundImage, Game.picSheep.BackgroundImage, picPrincess, picBunny}
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
        firstCTurn = True
        firstTurn = True
    End Sub
    Public Sub toFemale(ByVal form As String)
        Dim out As String = ""
        If form = "bunny" Then out += "As you are about to turn " & getName() & " into an adorable bunny rabbit, another idea crosses your mind. Oh, " & pronoun & " will be a cute bunny alright. "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        out += getName() & " looks suprised as his muscle mass shrinks down, his physique gained over years of training becoming slim and feminine. She is thrown off balance as her hips puff out, giving her a hour glass figure. The shock of her sudden transormation is evident on her now unmistakably female face, a rosy blush coming to her cheeks. As ringlets of her now much longer hair fall in font of her eyes, her suprised expression replaced with an expression of consignment."
        If getName.Equals("Traveling Wizard") Then setName("Traveling Witch")
        Game.pushLblEvent(out)
    End Sub
    Public Sub toMale(ByVal form As String)
        Dim out As String = ""
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        If getName.Equals("Traveling Witch") Then setName("Traveling Wizard")
        Game.pushLblEvent(out)
    End Sub
    Public Overrides Sub despawn(reason As String)
        MyBase.despawn(reason)
        Game.btnTalk.Visible = False
        Game.btnNPCMG.Visible = False
        Game.cboxNPCMG.Visible = False
        Game.btnShop.Visible = False
        Game.btnFight.Visible = False
        Game.btnLeave.Visible = False
    End Sub
End Class
