Public Class PerkEffects
    Shared p = Game.player
    '|GENERAL EFFECTS|
    Shared Sub hungerEffect()
        If p.perks("hunger") > -1 And Game.turn Mod 5 = 0 Then
            If p.Hunger() < 100 Then
                p.perks("hunger") = -1
            Else
                p.health -= 5 / p.getmaxHealth()
                Game.lstLog.Items.Add("Your stomach aches... -5 health!")
                If p.health <= 0 Then p.setTarg(New Monster(10))
            End If
        End If
    End Sub
    Shared Sub slimeHairRegen()
        If Not p.haircolor.A = 180 Then
            p.perks("slimehair") = -1
        Else
            If p.health < 1 And Game.turn Mod 4 = 0 Then
                p.health += 25 / p.getmaxHealth()
                p.Game.lstLog.Items.Add("Your gel body heals some of the damage done to it. +5 health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Sub vslimeHairRegen()
        If Not p.haircolor.A = 180 Then
            p.perks("vsslimehair") = -1
        Else
            If p.health < 1 And Game.turn Mod 7 = 0 Then
                Dim h As Integer = Int(Rnd() * 15) + 1
                p.health += h / p.getmaxHealth()
                Game.lstLog.Items.Add("The gel portion of your body is able to heal some of your wounds! +" & h & " health")
                If p.health > 1 Then p.health = 1
            End If
        End If
    End Sub
    Shared Function livingArmor() As Boolean
        If p.equippedArmor.getName.Equals("Living_Armor") Then
            If Game.turn Mod 6 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.lust += l
                Game.lstLog.Items.Add("Your living armor raises your lust!")
                Return True
            End If
        Else
            p.perks("livearm") = -1
        End If
        Return False
    End Function
    Shared Function livingLingerie() As Boolean
        If p.equippedArmor.getName.Equals("Living_Lingerie") Then
            If Game.turn Mod 4 = 0 And p.lust < 100 Then
                Dim l As Integer = Int(Rnd() * 15) + 10
                p.lust += l
                Game.lstLog.Items.Add("Your living lingerie raises your lust!")
                Return True
            End If
        Else
            p.perks("livelinge") = -1
        End If
        Return False
    End Function

    '|TRANSFORMATION TRIGGERS|
    Shared Sub targaxSwordTF()
        If p.name <> "Targax" Then
            If Not p.equippedWeapon.getName.Equals("Sword_of_the_Brutal") Then
                p.perks("swordpossess") = -1
            End If
        Else
            p.perks("swordpossess") = -1
        End If
    End Sub
    Shared Sub thrallRestore()
        p.prefForm.shiftTowards(Game.player)
        p.perks("thrall") = 1
    End Sub

    '|SPECIAL MOVE HANDLERS|
    Shared Sub berserkerRage()
        If p.perks("brage") > 0 Then
            p.aBuff = p.aBuff + ((p.getattack - p.abuff) / 2)
            p.dBuff = p.dBuff - ((p.getdefence - p.dbuff) / 3)
            p.perks("brage") -= 1
        Else
            p.aBuff = p.aBuff - (p.getattack - p.abuff) * 1.5
            p.dBuff = p.dBuff + (p.getdefence - p.dbuff) + 1
            p.perks("brage") = -1
            Game.lstLog.Items.Add("Berserker rage has worn off.")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
    Shared Sub massiveMammaries()
        If p.perks("mmammaries") = 1 Then
            p.dBuff = p.dBuff + ((p.getdefence - p.dbuff) * 0.8)
            p.perks("mmammaries") -= 1
        Else
            p.dBuff = p.dBuff - ((p.getdefence - p.dbuff) * 0.8)
            p.perks("mmammaries") = -1
            Game.lstLog.Items.Add("Massive mammaries has worn off.")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
    Shared Sub ironhideFury()
        If p.perks("ihfury") = 3 Then
            p.aBuff = p.aBuff + ((p.getattack - p.abuff) * 0.5)
            p.dBuff = p.dBuff + ((p.getdefence - p.dbuff) * 0.6)
            p.perks("ihfury") -= 1
        ElseIf p.perks("ihfury") > 0 Then
            p.perks("ihfury") -= 1
        Else
            p.aBuff = p.aBuff - ((p.getattack - p.abuff) * 0.5)
            p.dBuff = p.dBuff - ((p.getdefence - p.dbuff) * 0.6)
            p.perks("ihfury") = -1
            Game.lstLog.Items.Add("Ironhide Fury has worn off.")
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
End Class
