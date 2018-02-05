Public Class NPC
    Inherits Monster
    Public firstCTurn As Boolean = True
    Public isShop = False
    Public gold As Integer = 0
    Public picNormal, picPrincess, picBunny As Image
    Public picNCP() As Image

    Sub New(ByVal mIndex As Integer)
        MyBase.New(-1)
        Select Case mIndex
            Case 1
                MyBase.name = "Mark"
                MyBase.health = 999
                MyBase.maxHealth = 999
                MyBase.attack = 99
                MyBase.defence = 99
                MyBase.speed = 99
                MyBase.inventory = {0, 0, 3, 0, 2}
                pronoun = "he"
                pPronoun = "his"
                rPronoun = "him"
            Case 2
                MyBase.name = "Shopkeeper"
                MyBase.health = 99999
                MyBase.maxHealth = 99999
                MyBase.attack = 99999
                MyBase.defence = 99999
                MyBase.speed = 99  '0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53
                MyBase.inventory = {1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0}
                isShop = True
                gold = 99999
                pronoun = "he"
                pPronoun = "his"
                rPronoun = "him"
                picNormal = Game.picShopkeep.BackgroundImage
                picPrincess = Game.picSKPrin.BackgroundImage
                picBunny = Game.picSKBunny.BackgroundImage
            Case Else
                MyBase.name = "eRr0rH3Ro"
                MyBase.health = 60
                MyBase.maxHealth = 60
                MyBase.attack = 1
                MyBase.defence = 1
                MyBase.speed = 1
                MyBase.inventory = {1}
        End Select
        If speed = Game.player.speed Then speed -= 1
        MyBase.title = ""
    End Sub
    Sub New(ByVal s As String)
        MyBase.New(-1)
        Dim playArray() As String = s.Split("*")
        MyBase.name = playArray(0) & " the " & playArray(1)
        MyBase.health = playArray(3)
        MyBase.maxHealth = playArray(4)
        MyBase.attack = playArray(5)
        MyBase.defence = playArray(6)
        MyBase.speed = playArray(7)
        ReDim MyBase.inventory(UBound(playArray) - 8)
        For i = 0 To (UBound(playArray) - 8)
            MyBase.inventory(i) = playArray(8 + i)
        Next
        MyBase.title = ""
    End Sub
    Public Overrides Sub attackCMD(target As Player)
        MyBase.attackCMD(target)
    End Sub
    Public Overrides Sub update()
        If dead = True Then Exit Sub
        If health <= 0 Then
            Die()
            Exit Sub
        End If
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
        If Game.player.title = "Black Cat" Or Game.player.title = "Chicken" Then despawn("animaltf")
        If Game.combatmode Then attackCMD(Game.player)
    End Sub
    Public Sub encounter()
        pos = Game.player.pos
        If dead = True Then Exit Sub
        If name = "Shopkeeper" Then gold = 9999
        Game.npcIndex = npcIndex
        If npcIndex = 0 Then
            Game.pushNPCDialog("Hey, what's up?")
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("Ribbit.  Ribbit.")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("Baaahhh.")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Hello, kind " & Game.player.title & ", how are you on this fine day?")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("*giggle* Hey!")
        End If
        picNCP = {picNormal, Game.picFrog.BackgroundImage, Game.picSheep.BackgroundImage, picPrincess, picBunny}
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
        firstCTurn = True
        firstTurn = True
    End Sub
    Public Sub toFemale(ByVal form As String)
        Dim out As String = ""
        If form = "bunny" Then out += "As you are about to turn " & name & " into an adorable bunny rabbit, another idea crosses your mind. Oh, " & pronoun & " will be a cute bunny alright. "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        out += name & " looks suprised as his muscle mass shrinks down, his physique gained over years of training becoming slim and feminine. She is thrown off balance as her hips puff out, giving her a hour glass figure. The shock of her sudden transormation is evident on her now unmistakably female face, a rosy blush coming to her cheeks. As ringlets of her now much longer hair fall in font of her eyes, her suprised expression replaced with an expression of consignment."
        If name = "Mark" Then name = "Maria"
        If form = "bunny" Then out += " Her hair lightens to an almost white shade of pink, and two hot pink bunny ears pop out of her head. While at first the new bunny girl looks like she might be angry, her rage gives was to a look of confusion, and that is quickly replaced by a bubbly smile. You return the smile, proud of you spellwork."
        If form = "prin" Then out += " Her hair lightens slightly, and a tiara appears on her head. She stops slouching, adopting a regal pose as her clothes become a ballgown. She gives you a quick grin, the look in her eyes indicating that she has abandoned her former life, embracing her new royal lineage."
        Game.pushLblEvent(out)
    End Sub
    Public Sub toMale(ByVal form As String)
        Dim out As String = ""
        pronoun = "he"
        pPronoun = "his"
        rPronoun = "him"
        out += name & " looks suprised as her breasts begin to shrink, her muscles growing more defined at first, and quickly gaining mass."
        If name = "Maria" Then name = "Mark"
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
