Public Class HTeach
    Inherits ShopNPC

    Dim preHypnoID = 0
    Sub New()
        name = "Hypnotist Teacher"
        health = 1.0
        maxHealth = 9999
        attack = 99
        defense = 999
        speed = 99

        'Define the inventory
        inv = New Inventory(False)
        'Useables
        inv.setCount("Advanced_Spellbook", 1)
        inv.item("Advanced_Spellbook").value -= 0.2 * MyBase.inv.item("Advanced_Spellbook").value
        inv.setCount("Spellbook", 1)
        inv.item("Spellbook").value -= 0.2 * MyBase.inv.item("Spellbook").value
        inv.setCount("Utility_Manual", 1)
        inv.item("Utility_Manual").value -= 0.2 * MyBase.inv.item("Utility_Manual").value
        inv.setCount("Combat_Manual", 1)
        inv.item("Combat_Manual").value -= 0.2 * MyBase.inv.item("Combat_Manual").value
        inv.setCount("Anti_Curse_Tag", 1)
        'Services
        inv.setCount("Bimbo_Lesson", 1)
        inv.setCount("Barbarian_Lesson", 1)
        inv.setCount("Warlock_Lesson", 1)
        inv.setCount("Name_Change", 1)
        inv.setCount("Base_Form_Reset", 1)

        isShop = True
        gold = 99999
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"
        picNormal = ShopNPC.npcLib.atrs(0).getAt(17)
        picPrincess = ShopNPC.npcLib.atrs(0).getAt(19)
        picBunny = ShopNPC.npcLib.atrs(0).getAt(18)

        picNCP = New List(Of Image)
        picNCP.AddRange({picNormal, ShopNPC.npcLib.atrs(0).getAt(4), ShopNPC.npcLib.atrs(0).getAt(5), picPrincess, picBunny})

        picNCP.AddRange({ShopNPC.npcLib.atrs(0).getAt(21), ShopNPC.npcLib.atrs(0).getAt(24), ShopNPC.npcLib.atrs(0).getAt(22), ShopNPC.npcLib.atrs(0).getAt(20)})
        If speed = Game.player1.speed Then speed -= 1
        MyBase.title = " the "
    End Sub

    Public Overrides Sub encounter()
        MyBase.encounter()

        MyBase.discount = 0

        If npcIndex = 0 Then
            If Int(Rnd() * 20) = 0 Then
                MyBase.discount = 0.25
                npcIndex = 6
                Game.pushNPCDialog("Like, hey!  I, like, totally just got back from negot...nagosh...trying to work " &
                                   "out a deal with that wizard guy, and it like, didn't go too well.  But hey, now I " &
                                   "feel soooo gooood, and I'm even doing a I'm-having-fun sale!  I ran into Food Guy, " &
                                   "and don't tell him I said this but he's toootally like my soulmate...  " &
                                   "Anyway, like, he has that panana...penasi...special food thing that can get me back to my normal self!" &
                                   "But first, I'm like, totally gonna take a break from being all serious and see what else he has that I can eat! ~🖤")
            ElseIf Int(Rnd() * 20) = 1 Then
                npcIndex = 7
                Game.pushNPCDialog("Hello, potential customer!  I don't suppose you've seen Mr. Vendor around anywhere, have you?  " &
                                   "He appears to have gotten the cream in my usual morning coffee mixed up with some other malarkey, " &
                                   "and now, as I'm sure you can see, I've begun morphing into some sort of bovine.  I'm hoping he has " &
                                   "some Panacea on hand, because otherwise I might be in a prediciment and if that is the case so help me " &
                                   "I'm going to...*sigh* This isn't appropriate buisness talk.  I have spellbooks and manuals for sale, and if " &
                                   "you're looking for something specific, I have some recorded hypnotic lessons on tape.  Take a look around, " &
                                   "in the meantime I'm going to track down my idiot.")
            Else
                Game.pushNPCDialog("Hello.  I can help you learn spells and abilities via my only somewhat experimental " &
                                   "hypnosis System.  Don't worry, I've worked out most of the kinks thanks to some " &
                                   "volunteering by the Food Vendor you may have seen around, and it's 100% effecive as " &
                                   "far as long term behavior modification goes.  If you're feeling a bit hesitant, I also " &
                                   "sell more...pedestrian books and manuals.  They won't provide as specific of an education though.")
            End If
        ElseIf npcIndex = 1 Then
            Game.pushNPCDialog("CROAK!")
        ElseIf npcIndex = 2 Then
            Game.pushNPCDialog("BLEEEET!")
        ElseIf npcIndex = 3 Then
            Game.pushNPCDialog("Well salutations there, " & Game.player1.pClass.name & ".  Please let me know if there's anything I can do to help you.")
        ElseIf npcIndex = 4 Then
            Game.pushNPCDialog("HI!  I, like, don't know if it would be smart for me to try to hypno...hypotho...do my thing to you right now, but I totally have some tapes you can use!")
        ElseIf npcIndex = 8 Then
            Game.pushNPCDialog("...")
        End If
        If Game.mDun.numCurrFloor > 5 Then inv.setCount(113, 1) Else inv.setCount(113, 0)
        If Game.mDun.numCurrFloor < 5 Then inv.setCount(122, 1) Else inv.setCount(122, 0)
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
    End Sub

    Public Overrides Function toFight() As String
        If npcIndex = 0 Then
            Return "Seems like you need another type of lesson."
        ElseIf npcIndex = 1 Then
            Return "bbbbrrrROOOAAAK!"
        ElseIf npcIndex = 2 Then
            Return "baaaaaahhh."
        ElseIf npcIndex = 3 Then
            Return "You would dare to challenge me? If you wish to die, you could just say so."
        ElseIf npcIndex = 4 Then
            Return "Whaaaaaat?!?  No, like, don't do that!"
        ElseIf npcIndex = 6 Then
            Return "Cmon!  I'm, like, trying to help you out here!"
        ElseIf npcIndex = 8 Then
            Return "..."
        End If
        Return "Bad move."
    End Function
    Public Overrides Function hitBySpell() As String
        If npcIndex = 0 Then
            Game.NPCtoCombat(Me)
            Return "*sigh*...Well, I can always use another test subject."
        ElseIf npcIndex = 1 Then
            Game.NPCtoCombat(Me)
            Return "Ribbit, RIBBIT!"
        ElseIf npcIndex = 2 Then
            Game.NPCtoCombat(Me)
            Return "BAH!  BAH!"
        ElseIf npcIndex = 3 Then
            Game.NPCtoCombat(Me)
            Return "Prepare yourself, I won't be manipulated easily."
        ElseIf npcIndex = 4 Then
            Return "WOAH!  That's a neat trick!"
        ElseIf npcIndex = 6 Then
            Return "Cmon!  I'm, like, trying to help you out here!"
        ElseIf npcIndex = 8 Then
            Return "..."
        End If
        Return "Woah there!"
    End Function

    Public Sub hypnotize(ByVal s As String)
        preHypnoID = npcIndex
        npcIndex = 5

        Game.pushNPCDialog(s, AddressOf back)
        Game.shopMenu.Close()

        Game.picNPC.BackgroundImage = picNCP(npcIndex)
    End Sub
    Public Sub hypnotize(ByVal s As String, a As Action)
        preHypnoID = npcIndex
        npcIndex = 5

        Game.pushNPCDialog(s, a)
        Game.shopMenu.Close()

        Game.picNPC.BackgroundImage = picNCP(npcIndex)
    End Sub
    Public Sub back()
        npcIndex = preHypnoID
        Game.pushNPCDialog("So, anything else?")
        Game.picNPC.BackgroundImage = picNCP(npcIndex)
        Game.showNPCButtons()
        Game.player1.canMoveFlag = False
    End Sub
    Public Overrides Sub toDoll()
        Game.pushNPCDialog("...")
        Game.picNPC.BackgroundImage = picNCP(8)

        discount = 0.5
    End Sub
End Class
