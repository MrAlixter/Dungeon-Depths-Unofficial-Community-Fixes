Public Class DeathEffects
    '|MONSTER DEATHS|
    Shared Sub MBimboDeath()
        Dim p As Player = Game.player1

        p.perks(perk.bimbotf) = 1
        Dim out As String = "Exausted, you slump to the floor.  Glancing up, the horny mess attacking you seem to have gotten a running start, throwing herself on top of you, and pulling you into a sloppy kiss.  As she clumsily fumbles around, trying to remove your clothes, you roll out from underneath her and beat a hasty retreat, the faint sweetness of bubblegum lingering in your mouth."
        p.currTarget.despawn("p-death")
        TextEvent.push(out)
    End Sub

    '|BOSS / MINIBOSS DEATHS|
    '|NPC DEATHS|
    Shared Sub FVHTInterupt1()

    End Sub
    Shared Sub FVHTInterupt2()

    End Sub

    '|MISC DEATH|
    Shared Sub hardDeath()
        Dim p As Player = Game.player1
        p.isDead = True
        Dim r As Integer = 0 ' CInt(Int(Rnd() * 2))
        If r = 0 Then
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("gho.sts")
            writer.WriteLine(p.toGhost())
            writer.Flush()
            writer.Close()
        End If

        TextEvent.pushYesNo("Game Over!  Reload a save?", AddressOf tryToLoadSave, AddressOf askAboutNewGame)
        '.formReset()
    End Sub
    Shared Sub tryToLoadSave()
        Try
            Game.combat_engaged = False
            Game.solFlag = True
            Game.toSOL()
            Exit Sub
        Catch ex As Exception
            DDError.noSaveDetectedError()
        End Try
    End Sub
    Shared Sub askAboutNewGame()
        System.Threading.Thread.Sleep(50)

        Dim c As Chest
        c = DDConst.BASE_CHEST.Create(Game.player1.inv, Game.player1.pos)
        Game.currFloor.chestList.Add(c)
        Game.currFloor.mBoard(Game.player1.pos.Y, Game.player1.pos.X).ForeColor = Color.FromArgb(45, 45, 45)
        Game.currFloor.mBoard(Game.player1.pos.Y, Game.player1.pos.X).Text = "#"
        Game.currFloor.writeFloorToFile()

        TextEvent.pushYesNo("Start a new game?", AddressOf Game.newGame, AddressOf Game.formReset)
    End Sub
    Shared Sub bewitchedRation(ByRef p As Player)
        If p.equippedAcce.getAName.Equals(CynnsBimboMark.ITEM_NAME) Then
            p.changeClass("Onahole")

            Objective.showNPC(ShopNPC.gbl_img.atrs(0).getAt(150), "With a blinding flash of light, your perspective skews and you find yourself flopping inanimately to the floor.  A familiar figure looms over your new shape." & DDUtils.RNRN &
                                                                  """Yeah, that wasn't gonna work twice...""" & DDUtils.RNRN &
                                                                  "Cynn struts off, leaving you transformed and helpless; little more than an artificial vagina." & DDUtils.RNRN &
                                                                  """Next time, maybe take me up on my offer.""" & DDUtils.RNRN &
                                                                  "GAME OVER!", AddressOf Game.player1.die)
            p.drawPort()
            Exit Sub
        End If

        If Not p.formName = "Demon" Then
            p.prt.changeSkinColor(Color.FromArgb(255, 214, 106, 106))
            p.prt.changeHairColor(DemonTF.getDemonHairColor(p.prt.haircolor))
            p.changeForm("Demon")
        End If

        If p.prt.iArrInd(pInd.eyes).Item2 Then
            p.prt.setIAInd(pInd.eyes, 66, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 19, False, True)
        End If

        If p.breastSize > 0 Then p.breastSize = 2
        If p.breastSize < 1 Then p.breastSize = 0

        p.changeClass("Rogue")
        p.inv.add(p.equippedArmor.getAName, -1)
        p.inv.add(DarkplateBikini.ITEM_NAME, 1)
        EquipmentDialogBackend.equipArmor(p, DarkplateBikini.ITEM_NAME, False)

        p.inv.add(p.equippedWeapon.getAName, -1)
        p.inv.add(RunecursedDagger.ITEM_NAME, 1)
        EquipmentDialogBackend.equipWeapon(p, RunecursedDagger.ITEM_NAME, False)

        TextEvent.push("You collapse into a smoldering pile, as your body and equipment morph around you." & DDUtils.RNRN &
                       "A cackling voice rings out in your mind, as you feel yourself falling into a trance-like state." & DDUtils.RNRN &
                       """AH, A NEW MINION TO PLAY WITH?  I HAVE SUCH DELIGHTFUL PLANS FOR-""" & DDUtils.RNRN &
                       "As suddenly as it began, though, the voice falls silent mid-sentence.  You heft one of the runed daggers that you now seem to be holding." & DDUtils.RNRN &
                       "Hmm...  what a strange enchantment...")

        p.perks(perk.canmeetcyn) = 3

        p.drawPort()
    End Sub
End Class
