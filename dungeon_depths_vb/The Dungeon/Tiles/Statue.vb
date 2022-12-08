Public Class Statue
    Public pos As Point
    Public name, desc As String
    Public isRuby As Boolean = False
    Sub New(ByVal p As Point, ByVal n As String, ByVal d As String)
        pos = p
        name = n
        desc = d
    End Sub
    Sub New(ByRef m As NPC)
        pos = m.pos
        name = m.name.Split()(0)
        If m.GetType() Is GetType(Monster) Then
            desc = "This " & name & " has been turned to stone."
        ElseIf m.GetType().IsSubclassOf(GetType(MiniBoss)) Then
            If m.name = "Marissa the Enchantress" Then
                desc = "Marissa, once a powerful sorceress, is now little more than a lawn decoration."
            ElseIf m.name = "Targax the Brutal" Then
                desc = "Even Targax's ability to reflect spells was not enough to save him from his stony fate."
            End If
        ElseIf m.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            desc = "The " & name & " has been turned to stone."
        ElseIf m.GetType() Is GetType(Boss) Then

        End If
    End Sub
    Sub New(ByRef p As Player, Optional ByVal r As Boolean = False)
        pos = p.pos
        name = p.name
        desc = "Your old body, turned to stone. Looking at it fills you with nostalgia."


        isRuby = r
    End Sub
    Sub New(ByVal s As String)
        Dim buffer = s.Split("*")

        pos = New Point(CInt(buffer(0)), CInt(buffer(1)))
        name = buffer(2)
        desc = buffer(3)
        isRuby = buffer(4)
    End Sub

    Sub examine()
        If name = "seventailsstatue" Then
            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(152), "You see here a golden statue of a fox.  It begins to shimmer as you approach, and a disembodied voice seems to boom from all around you." & DDUtils.RNRN &
                                                                  """Well, well, well...  What do we have here?  Another " & Game.player1.formName & "; here to no doubt slay and steal, right?""" & DDUtils.RNRN &
                                                                  "The statue begins to morph upwards into a masked kitsune, who stretches lazily as she approaches you.  She clears her throat, and strikes a dramatic pose." & DDUtils.RNRN &
                                                                  """Call me Seven-Tails, because- um, I have seven tails.  PREPARE YOURSELF, fiend, your rampage ends here...""", AddressOf to7TailsFight)
        Else
            TextEvent.pushLog(desc)
            TextEvent.push(desc)
        End If
    End Sub

    Private Sub to7TailsFight()
        Dim m As SevenTails = MiniBoss.miniBossFactory(7)

        'adds the miniboss to combat queues
        Monster.targetRoute(m)
        Game.toCombat(m)

        TextEvent.pushAndLog("The golden statue comes to life, and " & m.getName() & " attacks!")

        Game.player1.perks(perk.seventailsstage) = 1

        pos = New Point(-1, -1)
        Game.drawBoard()
    End Sub

    Function getBoardCharacter() As String
        If name = "Fox" Then Return "d"

        Return "`"
    End Function

    Overrides Function toString() As String
        Return pos.X & "*" & pos.Y & "*" & name & "*" & desc & "*" & isRuby
    End Function
End Class
