Public Class RubyTrap
    Inherits Trap

    Private Shared gems = {"ruby",
                           "sapphire",
                           "emerald",
                           "topaz",
                           "opal",
                           "garnet",
                           "tourmaline",
                           "jade",
                           "quartz",
                           "moonstone",
                           "amethyst",
                           "amber",
                           "fluorite",
                           "ammolite",
                           "padparadscha",
                           "glass",
                           "sunstone"}

    Private Shared gem_colors = {Color.FromArgb(185, 200, 55, 55),
                                 Color.FromArgb(185, 55, 55, 200),
                                 Color.FromArgb(185, 55, 200, 55),
                                 Color.FromArgb(185, 222, 153, 33),
                                 Color.FromArgb(225, 222, 255, 255),
                                 Color.FromArgb(185, 186, 38, 54),
                                 Color.FromArgb(175, 133, 247, 156),
                                 Color.FromArgb(235, 100, 177, 77),
                                 Color.FromArgb(225, 255, 238, 238),
                                 Color.FromArgb(225, 233, 233, 233),
                                 Color.FromArgb(185, 200, 55, 200),
                                 Color.FromArgb(175, 240, 115, 14),
                                 Color.FromArgb(185, 127, 226, 205),
                                 Color.FromArgb(185, 175, 255, 0),
                                 Color.FromArgb(175, 255, 206, 253),
                                 Color.FromArgb(10, 255, 255, 255),
                                 Color.FromArgb(185, 255, 94, 57)}

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.ruby
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Dim p = Game.player1

        If p.perks(perk.rubytrapstage) < 0 Then
            p.perks(perk.rubytrapstage) = 0
            rubyTF()
        ElseIf p.perks(perk.rubytrapstage) >= UBound(gem_colors) Then
            landmine()
        Else
            p.perks(perk.rubytrapstage) += 1
            rubyPickup()
        End If
    End Sub

    Sub rubyPickup()
        Dim p = Game.player1
        TextEvent.push("As you walk through the dungeon, you see what looks like a valuable " & gems(p.perks(perk.rubytrapstage) - 1) & " on the ground.  Remembering the last time you saw a similar stone, you leave it be and continue on your way." & DDUtils.RNRN &
                          """Not today..."" you mutter to the rock.", AddressOf rubyTF)
    End Sub
    Sub rubyTF()
        Dim p = Game.player1


        p.prt.skincolor = DDUtils.cShift(p.prt.skincolor, gem_colors(p.perks(perk.rubytrapstage)), 10, False)
        p.savePState()

        p.petrify(gem_colors(p.perks(perk.rubytrapstage)), 1)

        Dim out As String = "As you walk through the dungeon, you see what looks like a valuable " & gems(p.perks(perk.rubytrapstage)) & " on the ground, and you bend down to pick it up." & DDUtils.RNRN &
                            "The instant you touch it, a shock runs through your body.  You barely have time to recoil before the hand you made contact with turns into a glistening stone itself.  In seconds, your entire body converts into a solid statue of " & gems(p.perks(perk.rubytrapstage)) & ", and as the nearly silent chittering of your transformation dies down, you are left immobile and silent." & DDUtils.RNRN &
                            "Shit!  Looks like that " & gems(p.perks(perk.rubytrapstage)) & " was probably cursed..."

        Game.currFloor.statueList.Add(New Statue(Game.player1, True))

        TextEvent.push(out, AddressOf rubyRevert)

        Game.player1.drawPort()
    End Sub
    Sub rubyRevert()
        Dim p = Game.player1

        p.canMoveFlag = True
        p.isPetrified = False
        p.perks(perk.astatue) = -1

        TextEvent.push("Several days pass..." & DDUtils.RNRN &
                          "As you stand frozen in the same position you've held since you touched the cursed stone, your legs suddenly give out and you fall face first onto the ground." & DDUtils.RNRN &
                          "Springing to your feet, you are excited to find yourself more or less as you were, and another explorer frozen in your place.  From their pose, it seems that they were going through your stuff and must have accidently touched your immobile body.  What's more, the original " & gems(p.perks(perk.rubytrapstage)) & " you touched is nowhere to be found.  You muse on the nature of the curse for a bit, before grabbing your things and moving on." & DDUtils.RNRN &
                          "Your stomach rumbles loudly, and you can tell that your time as a statue hasn't been kind to your non-stone self...", AddressOf p.revertToPState)

        p.mana = 0
        p.stamina -= 60
    End Sub
    Sub landmine()
        Dim p = Game.player1

        TextEvent.push("As you walk through the dungeon, you see what looks like a valuable " & gems(0) & " on the ground, and you bend down to pick it up.  The instant you touch it, a shock runs thro-" & DDUtils.RNRN &
                          "BOOOOOOM!" & DDUtils.RNRN &
                          "A powerful explosion erupts from the ground beneath you, vaporizing you instantly.  Congratulations!  You found a landmine." & DDUtils.RNRN &
                          "GAME OVER!", AddressOf p.die)
    End Sub
End Class
