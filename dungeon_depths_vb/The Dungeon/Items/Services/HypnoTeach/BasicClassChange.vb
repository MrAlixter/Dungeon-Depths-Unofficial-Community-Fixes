Public Class BasicClassChange
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Basic_Class_Change"
    Public Const COST As Integer = 2950

    Public Shared selected_class As String = "Classless"

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
        onBuy = Sub() teach(h_ind.classchange)

        '|Stats|
        count = 0
        value = COST

        '|Description|
        setDesc("""Not happy with your current class?  With a little hypnosis, I can help you into a new vocation...""")
    End Sub

    '| - OUTCOMES - |
    Protected Overrides Function doHypnosis(ByRef plr As Player, ByVal i As h_ind, Optional ByVal hypnoDesc As String = "") As Boolean
        Game.toPNLSelec("BasicClassChange")

        Return True 'MyBase.doHypnosis(plr, i, hypnoDesc)
    End Function
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        'Don't do anything
    End Sub
    Protected Overrides Sub wakeup(ByRef p As Player, Optional ByVal noticedChanges As String = "")
        Dim out = "As soon as she snaps, your entire reality fades away." & DDUtils.RNRN &
                  "You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses' silky voice, though in your haze you don't understand much of what's being said." & DDUtils.RNRN &
                  "You pass in and out of conciousness several times until gradually you begin to regain your senses yet again." & DDUtils.RNRN &
                  """...annnd one.  Wake up now, little " & selected_class.ToLower & ".  Are you well?  You look a bit confused..."" the teacher asks, stowing something in her pocket and adjusting her glasses.  While it does seem like something has changed, you can't put your finger on it.  You are " & p.getName & " the " & p.className & ", same as you've always been.  Groggily, you tell her that you're fine and just a little dizzy." & DDUtils.RNRN &
                  """Well then, it seems like my work here is done.  If I can help you with anything else, please do not hesitate to ask!"""

        TextEvent.push(out, AddressOf CType(Game.hteach, HypnoTeach).back)

        HypnosisEffect.trigger(p, h_ind.classchange, selected_class)

        p.UIupdate()
        p.savePState()
    End Sub

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        Return getClasses(Game.player1).Count > 0
    End Function

    '| - TRANSFORMATION - |
    Shared Sub hypnotizeP()
        Dim p = Game.player1
        CType(Game.hteach, HypnoTeach).hypnotize(getHypnoDesc(p), p, h_ind.classchange, Sub() CType(p.inv.item(ITEM_NAME), BasicClassChange).wakeup(p))
    End Sub
    Shared Function getClasses(ByRef p As Player) As List(Of String)
        Dim l = New List(Of String)({"Warrior", "Mage", "Rogue", "Cleric"})

        For Each i In l
            If i = p.className Then l.Remove(i) : Exit For
        Next

        Return l
    End Function
End Class
