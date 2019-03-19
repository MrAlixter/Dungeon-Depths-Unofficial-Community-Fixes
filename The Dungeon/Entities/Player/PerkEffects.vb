Public Class PerkEffects
    '|GENERAL EFFECTS|
    Shared Sub hungerEffect()
        Dim p As Player = Game.player
        If p.perks("hunger") > -1 And Game.turn Mod 5 = 0 Then
            If p.hunger < 100 Then
                p.perks("hunger") = -1
            Else
                Game.pushLstLog("Your stomach aches... -5 health!")
                p.takeDMG(5, New Monster(10))
            End If
        End If
    End Sub
    Shared Sub slimeHairRegen()
        Dim p As Player = Game.player
        If Not p.haircolor.A = 180 Then
            p.perks("slimehair") = -1
        Else
            If p.health < 1 And Game.turn Mod 4 = 0 Then
                p.health += 5 / p.getMaxHealth()
                Game.pushLstLog("Your gel body heals some of the damage done to it. +5 health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Sub vslimeHairRegen()
        Dim p As Player = Game.player
        If Not p.haircolor.A = 180 Then
            p.perks("vsslimehair") = -1
        Else
            If p.health < 1 And Game.turn Mod 7 = 0 Then
                Dim h As Integer = Int(Rnd() * 5) + 1
                p.health += h / p.getmaxHealth()
                Game.pushLstLog("The gel portion of your body is able to heal some of your wounds! +" & h & " health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Sub minorRegen()
        Dim p As Player = Game.player
        If p.health < 1 And Game.turn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 8) + 1
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("A slight glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1

            If Int(Rnd() * 20) = 0 Then
                Game.pushLblEvent(Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & "Your ring of regeneration goes dim, before shattering into dust.")
                p.inv.item(77).count -= 1
                Equipment.accChange("Nothing")
            End If
        End If
    End Sub
    Shared Sub Regen()
        Dim p As Player = Game.player
        If p.health < 1 And Game.turn Mod 7 = 0 Then
            Dim h As Integer = Int(Rnd() * 15) + 1
            p.health += h / p.getMaxHealth()
            Game.pushLstLog("A glowing aura heals some of your wounds! +" & h & " health")
            If p.health > 1 Then p.health = 1
        End If
    End Sub
    Shared Function livingArmor() As Boolean
        Dim p As Player = Game.player
        If p.equippedArmor.getName.Equals("Living_Armor") Then
            If Game.turn Mod 6 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.lust += l
                Game.pushLstLog("Your living armor raises your lust!")
                Return True
            End If
        Else
            p.perks("livearm") = -1
        End If
        Return False
    End Function
    Shared Function livingLingerie() As Boolean
        Dim p As Player = Game.player
        If p.equippedArmor.getName.Equals("Living_Lingerie") Then
            If Game.turn Mod 4 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.lust += l
                Game.pushLstLog("Your living lingerie raises your lust!")
                Return True
            End If
        Else
            p.perks("livelinge") = -1
        End If
        Return False
    End Function

    Shared Sub ROTLGRoute()
        Dim p As Player = Game.player
        Dim rotlg = CType(p.inv.item(81), ROTLGoddess)
        rotlg.sBoost = CInt(2.2222 * p.breastSize)

        rotlg.dBoost = 0
        rotlg.aBoost = 0
        rotlg.mBoost = 0

        If p.equippedArmor.slutVarInd <> -1 Then
            rotlg.dBoost = -p.equippedArmor.dBoost
        Else
            Dim buff = p.equippedArmor.dBoost
            If buff = 0 Then
                buff = 3
            ElseIf buff < 5 Then
                buff = 5
            End If
            buff *= 4
            rotlg.dBoost = buff
            rotlg.aBoost = p.equippedArmor.aBoost * 1.5
            rotlg.mBoost = p.equippedArmor.mBoost * 1.5
        End If

        p.UIupdate()
    End Sub

    '|TRANSFORMATION TRIGGERS|
    Shared Sub targaxSwordTF()
        Dim p As Player = Game.player
        If p.name <> "Targax" Then
            If Not p.equippedWeapon.getName.Equals("Sword_of_the_Brutal") Then
                p.perks("swordpossess") = -1
            End If
        Else
            p.perks("swordpossess") = -1
        End If
    End Sub
    Shared Sub thrallRestore()
        Dim p As Player = Game.player
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If

        p.prefForm.shiftTowards(Game.player)
        p.perks("thrall") = 1
    End Sub
    Shared Sub aStatue()
        Dim p As Player = Game.player
        If p.perks("astatue") > 1 Then
            p.perks("astatue") -= 1
            p.canMoveFlag = False
        ElseIf p.perks("astatue") <= 1 Then
            p.perks("astatue") = -1
            p.revertToPState()
            p.canMoveFlag = True
        End If
    End Sub
    Shared Sub statueMove(obj As Entity)
        Game.pushLblEvent("You, being a statue, can not do anything.")
    End Sub
    '|SPECIAL MOVE HANDLERS|
    Shared Sub berserkerRage()
        Dim p As Player = Game.player
        If p.perks("brage") > 0 Then
            p.aBuff = p.aBuff + ((p.attack) / 2)
            p.dBuff = p.dBuff - ((p.defence) / 3)
            p.perks("brage") -= 1
        Else
            p.aBuff = 0
            p.dBuff = 0
            p.perks("brage") = -1
            Game.pushLstLog("Berserker rage has worn off.")

        End If
    End Sub
    Shared Sub massiveMammaries()
        Dim p As Player = Game.player
        If p.perks("mmammaries") = 1 Then
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.8)
            p.perks("mmammaries") -= 1
        Else
            p.dBuff = 0
            p.perks("mmammaries") = -1
            Game.pushLstLog("Massive mammaries has worn off.")

        End If
    End Sub
    Shared Sub ironhideFury()
        Dim p As Player = Game.player
        If p.perks("ihfury") = 3 Then
            p.aBuff = p.aBuff + ((p.getATK - p.aBuff) * 0.5)
            p.dBuff = p.dBuff + ((p.getDEF - p.dBuff) * 0.6)
            p.perks("ihfury") -= 1
        ElseIf p.perks("ihfury") > 0 Then
            p.perks("ihfury") -= 1
        Else
            p.aBuff = 0
            p.dBuff = 0
            p.perks("ihfury") = -1
            Game.pushLstLog("Ironhide Fury has worn off.")

        End If
    End Sub
End Class
