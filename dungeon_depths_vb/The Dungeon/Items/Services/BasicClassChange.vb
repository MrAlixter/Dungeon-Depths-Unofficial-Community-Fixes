Public Class BasicClassChange
    Inherits Item

    Public Const ITEM_NAME As String = "Basic_Class_Change"
    Public Const COST As Integer = 2950

    Public Shared selectedClass As String = "Classless"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 114
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False
        can_be_stolen = False
        onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = COST

        '|Description|
        setDesc("""Not happy with your current class?  With a little hypnosis, I can help you into a new vocation...""")
    End Sub

    Sub teach()
        count = 0

        Game.shopMenu.Close()
        Game.hideNPCButtons()

        Game.toPNLSelec("BasicClassChange")
    End Sub

    Shared Sub hypnotizeP()
        TextEvent.pushNPCDialog("Before we get started, I would like to make sure you really want this. This lesson will change a core aspect of your personality, afterall...", AddressOf warning)
    End Sub

    Shared Sub warning()
        TextEvent.pushYesNo("Become a " & selectedClass & "?", AddressOf tf, AddressOf cancel)
    End Sub
    Shared Sub cancel()
        Game.player1.gold += COST
        CType(Game.hteach, HypnoTeach).back()
    End Sub
    Shared Sub tf()
        CType(Game.hteach, HypnoTeach).hypnotize("Perfect!" & DDUtils.RNRN &
                                                 "Speaking of perfection, have you seen my pendant?  I know it is a bit cliched, but does seeing it swing back and forth not just relax you so... perfectly?" & DDUtils.RNRN &
                                                 "Back... and forth... watch it glisten in the light..." & DDUtils.RNRN &
                                                 "Feel yourself go deeper and deeper... deeper... and deeper... until you just..." & DDUtils.RNRN &
                                                 "*SNAP*" & DDUtils.RNRN &
                                                 "...drift away...", AddressOf tf2)
    End Sub
    Shared Sub tf2()
        Dim p = Game.player1

        Dim out = "As soon as she snaps, your entire reality fades away." & DDUtils.RNRN &
                  "You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses' silky voice, though in your haze you don't understand much of what's being said." & DDUtils.RNRN &
                  "You pass in and out of conciousness several times until gradually you begin to regain your senses yet again." & DDUtils.RNRN &
                  """...annnd one.  Wake up now, little " & selectedClass.ToLower & ".  Are you well?  You look a bit confused..."" the teacher asks, stowing something in her pocket and adjusting her glasses.  While it does seem like something has changed, you can't put your finger on it.  You are " & p.getName & " the " & p.className & ", same as you've always been.  Groggily, you tell her that you're fine and just a little dizzy." & DDUtils.RNRN &
                  """Well then, it seems like my work here is done.  If I can help you with anything else, please do not hesitate to ask!"""

        TextEvent.push(out, AddressOf CType(Game.hteach, HypnoTeach).back)

        p.changeClass(selectedClass)

        p.UIupdate()
        p.savePState()
    End Sub

    Shared Function getClasses(ByRef p As Player) As List(Of String)
        Dim l = New List(Of String)({"Warrior", "Mage", "Rogue", "Cleric"})

        For Each i In l
            If i = p.className Then l.Remove(i) : Exit For
        Next

        Return l
    End Function
End Class
