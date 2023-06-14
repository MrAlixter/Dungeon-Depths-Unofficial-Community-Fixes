Public Class DubiousRations
    Inherits Food

    Public Const ITEM_NAME As String = "Dubious_Ration"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 406
        tier = 1

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 160
        setCalories(28)

        '|Description|
        setDesc("A pouch of dried meat and roasted nuts.  It seems safe to eat, but it might be best to take a closer look..." & DDUtils.RNRN &
                "Inspecting this item will identify it, but will also reduce the stamina gained from eating it." & DDUtils.RNRN &
                "+28 Stamina")
    End Sub

    Public Overrides Sub examine()
        MyBase.examine()

        Dim p = Game.player1

        p.inv.add(id, -1)

        If p.passDieRoll(4, 3) Then
            p.inv.add(SafeRations.ITEM_NAME, 1)
            Game.lblEvent.Text = Game.lblEvent.Text.Replace(DDUtils.PAKTC, DDUtils.RNRN & "This ration is safe!" & DDUtils.PAKTC)
            TextEvent.pushLog("This ration is safe!")
        Else
            Select Case Int(Rnd() * (If(Game.currFloor.floorNumber > 1, 2, 1)))
                Case 1
                    p.inv.add(MarissasRation.ITEM_NAME, 1)
                Case Else
                    p.inv.add(BewitchedRations.ITEM_NAME, 1)
            End Select

            Game.lblEvent.Text = Game.lblEvent.Text.Replace(DDUtils.PAKTC, DDUtils.RNRN & "This ration is bewitched!" & DDUtils.PAKTC)
            TextEvent.pushLog("This ration is bewitched!")
        End If

        p.inv.invNeedsUDate = True
        p.UIupdate()
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        If p.passDieRoll(4, 3) Then
            primaryEffect(p)
        Else
            Select Case Int(Rnd() * (If(Game.currFloor.floorNumber > 1, 2, 1)))
                Case 2
                    protoPanaceaEffect(p)
                Case 1
                    marissasEnchantment(p)
                Case Else
                    demonicEffect(p)
            End Select
        End If
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Shared Sub primaryEffect(ByRef p As Player)
        TextEvent.pushAndLog("The ration has no adverse effects.")
    End Sub

    Public Shared Sub protoPanaceaEffect(ByRef p As Player)

        Dim h_color = p.sState.haircolor
        Dim s_color = p.sState.skincolor
        Dim clss = p.sState.pClass

        p.revertToSState()

        p.sState.haircolor = h_color
        p.sState.skincolor = s_color
        p.sState.pClass = clss

        p.resetPerks()

        TextEvent.pushAndLog("The ration was a proto-panacea!  You partially revert to your starting form.")
    End Sub
    Public Shared Sub marissasEnchantment(ByRef p As Player)
        p.savePState()

        If Not p.prt.sexBool Then
            p.MtF()
        Else
            p.be()
        End If

        p.prt.setIAInd(pInd.ears, 1, p.prt.sexBool, False)
        p.prt.setIAInd(pInd.rearhair, 12, True, True)
        p.prt.setIAInd(pInd.midhair, 17, True, True)
        p.prt.setIAInd(pInd.fronthair, 1, True, False)
        p.prt.setIAInd(pInd.eyes, 13, True, True)

        p.drawPort()

        TextEvent.pushAndLog("The ration was bewitched!  You fall under the effect of Marissa's enchantment.")
    End Sub
    Public Shared Sub frogEffect(ByRef p As Player)
        p.savePState()

        p.changeForm("Frog")
        p.perks(perk.polymorphed) = 125

        p.drawPort()

        TextEvent.pushAndLog("The ration was bewitched!  You turn into a frog.")
    End Sub

    Public Shared Sub demonicEffect(ByRef p As Player)
        p.savePState()

        If Not p.formName = "Demon" Then
            p.prt.changeSkinColor(Color.FromArgb(255, 214, 106, 106))
            p.prt.changeHairColor(DemonTF.getDemonHairColor(p.prt.haircolor))
            p.changeForm("Demon")

            p.perks(perk.canmeetcyn) = 2
            TextEvent.pushAndLog("The ration was bewitched!  You turn into a demon.")
        ElseIf p.getLust > 0 And Not p.equippedAcce.getAName.Equals(CynnsBimboMark.ITEM_NAME) Then
            TextEvent.pushAndLog("The ration was bewitched!  You sizzle for " & p.getLust & " damage, and -" & (p.getLust * 0.2) & " lust...")
            p.takeDMG(p.getLust, Monster.monsterFactory(mInd.bewitched_ration))
            p.addLust(-(p.getLust * 0.2))
        Else
            TextEvent.pushAndLog("The ration was bewitched... but you're already a demon.")
        End If

    End Sub
End Class
