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
            Dim i As Integer
            Try
                i = InputBox("Which save slot?   1 2 3 4" & vbCrLf & _
                                            "                              5 6 7 8")
            Catch e As Exception
                Game.pushLblEvent("The fusion crystal does not react.  It seems that an improper slot was selected.")
                Exit Sub
            End Try
            If Not System.IO.File.Exists("saves/s" & i & ".ave") Then
                Game.pushLblEvent("Despite looking for someone to fuse with, you can't find anyone at that location")
                Exit Sub
            End If
            Dim save = Game.getPlayerFromFile("saves/s" & i & ".ave")
            Dim p2 As Player = save.Item1
            If save.Item2 <> Game.version Or p2.perks("polymorphed") > -1 Or Not Transformation.canBeTFed(Game.player) Or (p2.pClass.name.Equals("Magical Girl") Or p2.pClass.name.Equals("Valkyrie")) Then
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
                               ", a superior explorer!  The change is permenant, though fortunately " & p2.name & _
                               "'s known spells and forms are retained.")

            Dim fuPlay As Player = Fusion(Game.player, p2)

            Game.updatelist = New PQ

            Game.player = fuPlay
            Equipment.setP(Game.player)

            fuPlay.inv.invNeedsUDate = True
            fuPlay.UIupdate()
            fuPlay.sState.save(fuPlay)
            Dim f3 As New Equipment
            f3.ShowDialog()
            f3.Dispose()

            fuPlay.drawPort()
            fuPlay.currState.save(fuPlay)
            fuPlay.pState.save(fuPlay)
        End If
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
        Randomize(p1.name.GetHashCode)
        Dim player As Player = New Player()
        player.name = nameFusion(p1.name, p2.name)

        Dim r As Integer = Int(Rnd() * 2)
        If r = 0 Then player.pClass = p1.pClass Else player.pClass = p2.pClass
        If (p1.pClass.name = "Warrior" And p2.pClass.name = "Mage") Or (p2.pClass.name = "Warrior" And p1.pClass.name = "Mage") Then player.pClass = player.classes("Paladin")

        r = Int(Rnd() * 2)
        If r = 0 Then player.sex = p1.sex Else player.sex = p2.sex

        r = Int(Rnd() * 2)
        If r = 0 Then player.prt.wingInd = p1.prt.wingInd Else player.prt.wingInd = p2.prt.wingInd

        r = Int(Rnd() * 2)
        If r = 0 Then player.prt.hornInd = p1.prt.hornInd Else player.prt.hornInd = p2.prt.hornInd

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

        For i = 0 To player.inv.upperBound
            player.inv.item(i).setName(p1.inv.item(i).getName)
            player.inv.item(i).add(p1.inv.item(i).count + p2.inv.item(i).count)
        Next

        player.inv.add(0, -1)
        player.inv.add(2, -1)
        player.inv.add(58, -1)

        player.breastSize = p1.breastSize + p2.breastSize / 2

        player.prt.iArr = p1.prt.iArr.Clone
        player.prt.iArrInd = p1.prt.iArrInd.Clone
        For i = 0 To 16
            If i <> 1 And i <> 15 And i <> 3 And i <> 5 Then
                r = Int(Rnd() * 2)
                If r = 0 Then player.prt.iArrInd(i) = p1.prt.iArrInd(i) Else player.prt.iArrInd(i) = p2.prt.iArrInd(i)
            ElseIf i = 3 Then
                r = Int(Rnd() * 2)
                If r = 0 Then player.prt.iArrInd(i) = p1.sState.iArrInd(i) Else player.prt.iArrInd(i) = p2.sState.iArrInd(i)
            ElseIf i = 1 Then
                r = Int(Rnd() * 2)
                If r = 0 Then player.prt.iArrInd(pInd.rearhair) = p1.prt.iArrInd(pInd.rearhair) Else player.prt.iArrInd(pInd.rearhair) = p2.prt.iArrInd(pInd.rearhair)
                If r = 0 Then player.prt.iArrInd(pInd.midhair) = p1.prt.iArrInd(pInd.midhair) Else player.prt.iArrInd(pInd.midhair) = p2.prt.iArrInd(pInd.midhair)
                If r = 0 Then player.prt.iArrInd(pInd.fronthair) = p2.prt.iArrInd(pInd.fronthair) Else player.prt.iArrInd(pInd.fronthair) = p1.prt.iArrInd(pInd.fronthair)
            End If
        Next

        r = Int(Rnd() * 2)
        If r = 0 Then
            player.prt.skincolor = p1.prt.skincolor
            player.prt.haircolor = p2.prt.haircolor
        Else
            player.prt.skincolor = p2.prt.skincolor
            player.prt.haircolor = p1.prt.haircolor
        End If

        finalizeFusion(player, p1, p2)

        Return player
    End Function

    Shared Function alUnion(ByVal a As List(Of String), ByVal b As List(Of String)) As List(Of String)
        Dim c = New List(Of String)

        For i = 0 To Math.Max(a.Count, b.Count) - 1
            If i < a.Count AndAlso Not c.Contains(a.Item(i)) Then c.Add(a.Item(i))
            If i < b.Count AndAlso Not c.Contains(b.Item(i)) Then c.Add(b.Item(i))
        Next
        Return c
    End Function
    Shared Sub finalizeFusion(ByRef player As Player, ByRef p1 As Player, ByRef p2 As Player)

        player.knownSpells = alUnion(p1.knownSpells, p2.knownSpells)
        player.knownSpecials = alUnion(p1.knownSpecials, p2.knownSpecials)
        player.selfPolyForms = alUnion(p1.selfPolyForms, p2.selfPolyForms)
        player.enemPolyForms = alUnion(p1.enemPolyForms, p2.enemPolyForms)

        player.TextColor = Color.White

        player.pos = p1.pos

        player.pImage = p1.pImage

        player.currState = New State(player)
        player.pState = New State(player)
        player.sState = New State(player)

        player.equippedWeapon = New BareFists
        player.equippedArmor = New Naked

        player.inv.invNeedsUDate = True
        player.UIupdate()
        player.description = CStr(player.name & " is a " & player.sex & " " & player.pClass.name)
        player.solFlag = False
    End Sub
End Class
