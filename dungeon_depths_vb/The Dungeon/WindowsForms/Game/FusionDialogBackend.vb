Public Enum TypeOfFusion
    CRYSTAL_FUSION
    SPOT_FUSION
End Enum

Public Class FusionDialogBackend
    Shared possibleFusions As Dictionary(Of Integer, Player) = New Dictionary(Of Integer, Player)
    Shared fType As TypeOfFusion = TypeOfFusion.CRYSTAL_FUSION
    Shared Sub btnOKOnClick(sender As Object, e As EventArgs, ByRef p As Player)
        Dim p2 = Game.getPlayerFromFile("saves/s" & Game.cboxFusionTarget.SelectedIndex + 1 & ".ave").Item1

        If fType = TypeOfFusion.CRYSTAL_FUSION Then
            Game.pushLblEvent(p.name & " takes the fusion crystal in both hands as they glance over at " & p2.name & _
                   ", who nods in confirmation.  " & p.name & " then snaps the crystal in half, keeping one half " & _
                   "and tossing the other to " & p2.name & ".  Once separated, the shards begin glowing and pulling towards " & _
                   "each other, pulling the two with them.  As the shards gets closer, their attraction increases, and soon " & _
                   "the crystal is whole again.  The second that the two pieces reunite, their glow becomes blinding, engulfing" & _
                   " both explorers." & vbCrLf & _
                   p.name & " and " & p2.name & " fuse together to form " & FusionCrystal.nameFusion(p.name, p2.name) & _
                   ", a superior explorer!  The change is permenant, though fortunately " & p2.name & _
                   "'s known spells and forms are retained.")

            Dim fuPlay As Player = possibleFusions(possibleFusions.Keys(Game.cboxFusionTarget.SelectedIndex))

            FusionCrystal.finalizeFusion(fuPlay, p, p2)

            Game.updateList = New PQ




            fuPlay.sState.save(fuPlay)

            fuPlay.pState.save(fuPlay)

            p = fuPlay

            Equipment.clothesChange(fuPlay, Game.cboxFusionArmor.Text)
            Equipment.weaponChange(fuPlay, Game.cboxFusionWeapon.Text)
            Equipment.accChange(fuPlay, Game.cboxFusionAccessory.Text)

            fuPlay.drawPort()


        ElseIf fType = TypeOfFusion.SPOT_FUSION Then
            Polymorph.transform(Game.player1, "Fusion")
            Game.pushLblEvent(Game.player1.name & " and " & p2.name & " fuse together to form " & FusionCrystal.nameFusion(Game.player1.name, p2.name) & _
                      ", a superior explorer!")

            p = SpotFusion.Fusion(p, p2)
            p.currState.save(p)
            p.inv.invNeedsUDate = True
            p.UIupdate()

            Equipment.clothesChange(p, Game.cboxFusionArmor.Text)
            Equipment.weaponChange(p, Game.cboxFusionWeapon.Text)
            Equipment.accChange(p, Game.cboxFusionAccessory.Text)

            p.drawPort()
        End If

        fromPNL(p)
    End Sub
    Shared Sub btnCancelOnClick(sender As Object, e As EventArgs, ByRef p As Player)
        fromPNL(p)
    End Sub

    Shared Sub updateDisplay(ByVal p1 As Player, ByVal p2 As Player)
        Dim fuPlay As Player = possibleFusions(possibleFusions.Keys(Game.cboxFusionTarget.SelectedIndex))

        Game.cboxFusionArmor.Items.Clear()
        For Each a In getArmor(p1, p2)
            Game.cboxFusionArmor.Items.Add(a)
        Next

        Game.cboxFusionWeapon.Items.Clear()
        For Each a In getWeapon(p1, p2)
            Game.cboxFusionWeapon.Items.Add(a)
        Next

        Game.cboxFusionAccessory.Items.Clear()
        For Each a In getAcce(p1, p2)
            Game.cboxFusionAccessory.Items.Add(a)
        Next

        Equipment.clothesChange(fuPlay, "Naked", False)

        Game.lblFusionHP.Text = "Max HP = " & fuPlay.getMaxHealth
        Game.lblFusionMP.Text = "Max MP = " & fuPlay.getMaxMana
        Game.lblFusionATK.Text = "ATK = " & fuPlay.getATK
        Game.lblFusionDEF.Text = "DEF = " & fuPlay.getDEF
        Game.lblFusionSPD.Text = "SPD = " & fuPlay.getSPD
        Game.lblFusionWill.Text = "WILL = " & fuPlay.getWIL
        Game.lblFusionLust.Text = "LUST = " & fuPlay.getLust

        Game.picFusionPort.BackgroundImage = fuPlay.prt.draw()
    End Sub

    Shared Sub getFusionTargets(ByVal p As Player)
        possibleFusions.Clear()

        For i = 1 To 8
            Dim saveName = "saves/s" & i & ".ave"

            If Not System.IO.File.Exists(saveName) Then Continue For

            Dim save = Game.getPlayerFromFile(saveName)
            Dim p2 As Player = save.Item1

            If save.Item2 <> Game.version Or
                p2.perks(perk.polymorphed) > -1 Or
                (p2.className.Equals("Magical Girl") Or p2.className.Equals("Valkyrie")) Then Continue For

            If p2.getName.Equals(p.getName) Then Continue For

            Game.cboxFusionTarget.Items.Add(p2.name & " ( Save Slot " & i & " )")
            If fType = TypeOfFusion.CRYSTAL_FUSION Then possibleFusions.Add(i, FusionCrystal.Fusion(p, p2))
            If fType = TypeOfFusion.SPOT_FUSION Then possibleFusions.Add(i, SpotFusion.Fusion(p, p2))
        Next
    End Sub
    Shared Function getArmor(ByVal p1 As Player, ByVal p2 As Player) As List(Of String)
        Dim out = New List(Of String)

        For Each i In p1.inv.getArmors.Item1
            If ((Not p1.inv.item(i) Is Nothing AndAlso p1.inv.item(i).count > 0) Or p1.inv.item(i) Is Nothing) And Not out.Contains(i) Then out.Add(i)
        Next

        If fType = TypeOfFusion.SPOT_FUSION Then Return out

        For Each i In p2.inv.getArmors.Item1
            If ((Not p2.inv.item(i) Is Nothing AndAlso p2.inv.item(i).count > 0) Or p2.inv.item(i) Is Nothing) And Not out.Contains(i) Then out.Add(i)
        Next

        Return out
    End Function
    Shared Function getWeapon(ByVal p1 As Player, ByVal p2 As Player) As List(Of String)
        Dim out = New List(Of String)

        For Each i In p1.inv.getWeapons.Item1
            If ((Not p1.inv.item(i) Is Nothing AndAlso p1.inv.item(i).count > 0) Or p1.inv.item(i) Is Nothing) And Not out.Contains(i) Then out.Add(i)
        Next

        If fType = TypeOfFusion.SPOT_FUSION Then Return out

        For Each i In p2.inv.getWeapons.Item1
            If ((Not p2.inv.item(i) Is Nothing AndAlso p2.inv.item(i).count > 0) Or p2.inv.item(i) Is Nothing) And Not out.Contains(i) Then out.Add(i)
        Next

        Return out
    End Function
    Shared Function getAcce(ByVal p1 As Player, ByVal p2 As Player) As List(Of String)
        Dim out = New List(Of String)

        For Each i In p1.inv.getAccesories.Item1
            If ((Not p1.inv.item(i) Is Nothing AndAlso p1.inv.item(i).count > 0) Or p1.inv.item(i) Is Nothing) And Not out.Contains(i) Then out.Add(i)
        Next

        If fType = TypeOfFusion.SPOT_FUSION Then Return out

        For Each i In p2.inv.getAccesories.Item1
            If ((Not p2.inv.item(i) Is Nothing AndAlso p2.inv.item(i).count > 0) Or p2.inv.item(i) Is Nothing) And Not out.Contains(i) Then out.Add(i)
        Next

        Return out
    End Function

    Shared Function isFusionPossible(ByVal p As Player)
        Return possibleFusions.Count > 0 And Transformation.canBeTFed(p)
    End Function
    Shared Sub toPNL(ByRef p As Player, ByVal fusionType As TypeOfFusion)
        Game.closeLblEvent()


        Game.player1.canMoveFlag = False

        getFusionTargets(p)

        If Not isFusionPossible(p) Then
            Game.pushLblEvent("You can not fuse at the moment!")
            fromPNL(p)
            Exit Sub
        End If

        fType = fusionType

        Game.cboxFusionTarget.SelectedIndex = 0
        Game.cboxFusionArmor.SelectedIndex = 0
        Game.cboxFusionWeapon.SelectedIndex = 0
        Game.cboxFusionAccessory.SelectedIndex = 0

        Game.pnlFusion.Location = New Point(65, Game.pnlFusion.Location.Y)
        If fType = TypeOfFusion.CRYSTAL_FUSION Then Game.lblFusionDisclaimer.Visible = True Else Game.lblFusionDisclaimer.Visible = False
        Game.pnlFusion.Visible = True
    End Sub
    Shared Sub fromPNL(ByRef p As Player)
        Game.player1.canMoveFlag = True
        If fType = TypeOfFusion.SPOT_FUSION Then p.stamina += 50
        If fType = TypeOfFusion.CRYSTAL_FUSION Then p.inv.add("Fusion_Crystal", 1)
        p.UIupdate()
        Game.pnlFusion.Visible = False
    End Sub
End Class
