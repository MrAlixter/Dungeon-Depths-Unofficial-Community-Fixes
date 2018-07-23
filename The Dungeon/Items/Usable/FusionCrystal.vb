Public Class FusionCrystal
    Inherits Item
    Sub New()
        MyBase.setName("Fusion_Crystal")
        MyBase.setDesc("A strange looking crystal reported to fuse two beings upon shattering." & vbCrLf & _
                       "Disclaimers:" & vbCrLf & _
                       "Only saves of the current version can be fused." & vbCrLf & _
                       "Spells and Forms known by the second fusee are not carried over")
        id = 58
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        If MessageBox.Show("This will rewrite your current player permenantly (Restore potions will restore to the fusion). Continue?", "Fusion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim i As Integer = InputBox("Which save slot?   1 2 3 4" & vbCrLf & _
                                        "                              5 6 7 8")
            If Not System.IO.File.Exists("s" & i & ".ave") Then
                Game.pushLblEvent("Despite looking for someone to fuse with, you can't find anyone at that location")
                Exit Sub
            End If
            Dim save = Game.getPlayerFromFile("s" & i & ".ave")
            Dim p2 As Player = save.Item1
            If save.Item2 <> Game.version Or p2.perks("polymorphed") > -1 Or Not Polymorph.canBeTFed(Game.player) Xor p2.pClass.name.Equals("Magic Girl") Then
                Game.pushLblEvent("After talking it over, " & Game.player.name & " and " & p2.name & " decide that they are incompatable, and not to fuse.")
                Exit Sub
            End If

            Game.pushLblEvent(Game.player.name & " takes the fusion crystal in both hands as they glance over at " & p2.name & _
                               ", who nods in confirmation.  " & Game.player.name & " then snaps the crystal in half, keeping one half " & _
                               "and tossing the other to " & p2.name & ".  Once separated, the shards begin glowing and pulling towards " & _
                               "each other, pulling the two with them.  As the shards gets closer, their attraction increases, and soon " & _
                               "the crystal is whole again.  The second that the two pieces reunite, their glow becomes blinding, engulfing" & _
                               " both explorers." & vbCrLf & _
                               Game.player.name & " and " & p2.name & " fuse together to form " & nameFusion(Game.player.name, p2.name) & _
                               ", a superior explorer!  The change is permenant, and unfortunately " & p2.name & _
                               "'s known spells and forms are lost.")

            Dim fuPlay As Player = Fusion(Game.player, p2)
            fuPlay.solFlag = False
            Game.updatelist = New PQ

            Game.player = fuPlay
            fuPlay.createP()
            fuPlay.invNeedsUDate = True
            fuPlay.UIupdate()
            fuPlay.sState.save(fuPlay)
            Dim f3 As New Equipment
            f3.ShowDialog()
            f3.Dispose()
            fuPlay.currState.save(fuPlay)
            fuPlay.pState.save(fuPlay)
            Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        End If
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub

    Shared Function nameFusion(ByVal s1 As String, ByVal s2 As String) As String
        Dim vowels() As String = {"a", "e", "i", "o", "u"}
        If s1.Equals(s2) Then Return s1
        s1 = s1.ToLower
        s2 = s2.ToLower
        For i = 1 To s1.Length
            If Not vowels.Contains(s1.Substring(s1.Length - 1, 1)) Then
                s1 = s1.Substring(0, s1.Length - 1)
            Else
                Exit For
            End If
        Next
        Dim ct As Integer = 0
        For i = 1 To s2.Length
            If Not vowels.Contains(s2.Substring(0, 1)) Or ct = 0 Then
                s2 = s2.Substring(1, s2.Length - 1)
                If vowels.Contains(s2.Substring(0, 1)) Then ct += 1
            Else
                s2 = s2.Substring(1, s2.Length - 1)
                Exit For
            End If
        Next
        Dim out As String = (s1 + s2)
        out = out.Substring(0, 1).ToUpper() + out.Substring(1, out.Length - 1)
        Return out
    End Function
    Shared Function Fusion(ByVal p1 As Player, ByVal p2 As Player) As Player
        Randomize()
        Dim player As Player = New Player()
        player.name = nameFusion(p1.name, p2.name)

        Dim r As Integer = Int(Rnd() * 2)
        If r = 0 Then player.pClass = p1.pClass Else player.pClass = p2.pClass
        If (p1.pClass.name = "Warrior" And p2.pClass.name = "Mage") Or (p2.pClass.name = "Warrior" And p1.pClass.name = "Mage") Then player.pClass = player.classes("Paladin")

        r = Int(Rnd() * 2)
        If r = 0 Then player.sex = p1.sex Else player.sex = p2.sex

        If p1.maxHealth > p2.maxHealth Then
            player.maxHealth = p1.maxHealth * 1.5
        Else
            player.maxHealth = p2.maxHealth * 1.5
        End If
        player.health = 1

        If p1.maxMana > p2.maxMana Then
            player.mana = p1.maxMana * 1.5
        Else
            player.mana = p2.maxMana * 1.5
        End If
        player.maxMana = player.mana

        If p1.attack > p2.attack Then
            player.attack = p1.attack * 1.5
        Else
            player.attack = p2.attack * 1.5
        End If

        If p1.defence > p2.defence Then
            player.defence = p1.defence * 1.5
        Else
            player.defence = p2.defence * 1.5
        End If

        If p1.will > p2.will Then
            player.will = p1.will * 1.5
        Else
            player.will = p2.will * 1.5
        End If

        If p1.speed > p2.speed Then
            player.speed = p1.speed * 1.5
        Else
            player.speed = p2.speed * 1.5
        End If

        If p1.evade > p2.evade Then
            player.evade = p1.evade * 1.5
        Else
            player.evade = p2.evade * 1.5
        End If

        If p1.lust > p2.lust Then
            player.lust = p1.lust * 1.5
        Else
            player.lust = p2.lust * 1.5
        End If

        If p1.hunger > p2.hunger Then
            player.hunger = p1.hunger * 1.5
        Else
            player.hunger = p2.hunger * 1.5
        End If

        player.gold = p1.gold + p2.gold

        player.inventorynames = p1.inventorynames.Clone

        For i = 0 To player.inventory.Count - 1
            player.inventory(i).setname(p1.inventory(i).getname)
            player.inventory(i).add(p1.inventory(i).count + p2.inventory(i).count)
        Next

        player.inventory(0).add(-1)
        player.inventory(2).add(-1)
        player.inventory(58).add(-1)

        player.iArr = p1.iArr.Clone
        player.iArrInd = p1.iArrInd.Clone
        For i = 0 To 16
            If i <> 1 And i <> 5 And i <> 3 Then
                r = Int(Rnd() * 2)
                If r = 0 Then player.iArrInd(i) = p1.iArrInd(i) Else player.iArrInd(i) = p2.iArrInd(i)
            ElseIf i = 3 Then
                r = Int(Rnd() * 2)
                If r = 0 Then player.iArrInd(i) = p1.sState.iArrInd(i) Else player.iArrInd(i) = p2.sState.iArrInd(i)
            ElseIf i = 1 Then
                r = Int(Rnd() * 2)
                If r = 0 Then player.iArrInd(i) = p1.iArrInd(i) Else player.iArrInd(i) = p2.iArrInd(i)
                If r = 0 Then player.iArrInd(15) = p1.iArrInd(15) Else player.iArrInd(15) = p2.iArrInd(15)
            End If
        Next

        r = Int(Rnd() * 2)
        If r = 0 Then
            player.skincolor = p1.skincolor
            player.haircolor = p2.haircolor
        Else
            player.skincolor = p2.skincolor
            player.haircolor = p1.haircolor
        End If

        player.TextColor = Color.White


        player.pos = p1.pos

        player.pImage = p1.pImage

        player.currState = New State(player)
        player.pState = New State(player)
        player.sState = New State(player)

        player.equippedWeapon = New BareFists
        player.equippedArmor = New Naked

        player.invNeedsUDate = True
        player.UIupdate()

        Return player
    End Function
End Class
