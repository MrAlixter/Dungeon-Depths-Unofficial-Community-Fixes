Public Class GumGun20mm
    Inherits Weapon

    Public Const ITEM_NAME As String = "WSGG_20mm_Railcannon"
    Public selected_ammo As StickOfGum

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 415
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        can_hit_flying = True

        '|Stats|
        s_boost = -21
        count = 0
        value = 4099

        '|Description|
        setDesc("A long-barreled weapon that converts an ordinary stick of gum into potent ammunition." & DDUtils.RNRN &
                getStatInformation() & DDUtils.RNRN &
                "- " & StickOfGum.ITEM_NAME & " 🡆 Shell" & vbCrLf &
                "- " & CStickOfGum.ITEM_NAME & " 🡆 Incandescent Shell" & vbCrLf &
                "- " & MStickOfGum.ITEM_NAME & " 🡆 Cryogenic Shell" & vbCrLf &
                "- " & BBStickOfGum.ITEM_NAME & " 🡆 Cluster Shell" & vbCrLf &
                "- " & WStickOfGum.ITEM_NAME & " 🡆 Poison Shell" & vbCrLf &
                "- " & DFStickOfGum.ITEM_NAME & " 🡆 Explosive Shell" & vbCrLf &
                "- " & GoldenGum.ITEM_NAME & " 🡆 Armor-Piercing Shell" & vbCrLf &
                "- " & GAStickOfGum.ITEM_NAME & " 🡆 Poison Shell" & vbCrLf &
                "- " & HPStickOfGum.ITEM_NAME & " 🡆 Shell" & vbCrLf &
                "- " & MPStickOfGum.ITEM_NAME & " 🡆 Shell")
    End Sub

    Public Overrides Function getDescription() As Object
        If selected_ammo Is Nothing Then selected_ammo = getActiveAmmo()
        Dim out = "A long-barreled weapon that accelerates an ordinary stick of gum far faster than it has any right to go.  It may be bulky, but its projectiles pack a serious punch." & DDUtils.RNRN &
                  "Scales to speed (rather than ATK)" & DDUtils.RNRN &
                  getStatInformation() & vbCrLf

        If selected_ammo.getAName.Equals(StickOfGum.ITEM_NAME) Then
            out += "Standard rounds chambered (" & StickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(CStickOfGum.ITEM_NAME) Then
            out += "Incandescent rounds chambered (" & CStickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(MStickOfGum.ITEM_NAME) Then
            out += "Cryogenic rounds chambered (" & MStickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(BBStickOfGum.ITEM_NAME) Then
            out += "Cluster rounds chambered (" & BBStickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(WStickOfGum.ITEM_NAME) Then
            out += "Poison rounds chambered (" & WStickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(DFStickOfGum.ITEM_NAME) Then
            out += "Explosive rounds chambered (" & DFStickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(GoldenGum.ITEM_NAME) Then
            out += "Armor-piercing rounds chambered (" & GoldenGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(GAStickOfGum.ITEM_NAME) Then
            out += "Poison rounds chambered (" & GAStickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(HPStickOfGum.ITEM_NAME) Then
            out += "Enhanced rounds chambered (" & HPStickOfGum.ITEM_NAME & ")."
        ElseIf selected_ammo.getAName.Equals(MPStickOfGum.ITEM_NAME) Then
            out += "Enhanced rounds chambered (" & MPStickOfGum.ITEM_NAME & ")."
        Else
            out += "Empty chamber."
        End If
        Return out
    End Function

    Public Overrides Sub use(ByRef p As Player)
        MyBase.use(p)

        owner = p

        selectActiveAmmo()
    End Sub
    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        If selected_ammo Is Nothing Then selected_ammo = getActiveAmmo()

        If p.inv.getCountAt(selected_ammo.getAName) < 1 Then
            TextEvent.pushAndLog("You don't have the ammo!")
            Return -3
        End If

        Dim dmg As Integer = Int(Rnd() * 12) + 1

        If dmg <= 2 And Not p.equippedGlasses.getAName.Equals(TargetingSystem.ITEM_NAME) Then
            dmg = -1
        Else
            If selected_ammo.getAName.Equals(StickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 95
            ElseIf selected_ammo.getAName.Equals(CStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 75
                If Not m.getNPC Is Nothing Then m.getNPC.perks(npc_perk.burn) += 5
            ElseIf selected_ammo.getAName.Equals(MStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 65
                If Not m.getNPC Is Nothing Then m.getNPC.perks(npc_perk.freeze) += 2
            ElseIf selected_ammo.getAName.Equals(BBStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 33
                dmg = Player.calcDamage(dmg, m.getDEF)
                For i = 0 To 2
                    p.hit(dmg, m, "", "shoot")

                    If m.isDead Then Exit For
                Next

                dmg = -3
            ElseIf selected_ammo.getAName.Equals(WStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 45
                If Not m.getNPC Is Nothing Then m.getNPC.perks(npc_perk.poison) += 5
            ElseIf selected_ammo.getAName.Equals(DFStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 85
                dmg = Player.calcDamage(dmg, m.getWIL)
                p.hit(dmg, m, "", "shoot")

                dmg = -3
            ElseIf selected_ammo.getAName.Equals(GoldenGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 20
                p.cHit(dmg + 50, m)

                dmg = -3
            ElseIf selected_ammo.getAName.Equals(GAStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 45
                If Not m.getNPC Is Nothing Then m.getNPC.perks(npc_perk.poison) += 5
            ElseIf selected_ammo.getAName.Equals(HPStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 110
            ElseIf selected_ammo.getAName.Equals(MPStickOfGum.ITEM_NAME) Then
                dmg += (p.getSPD) + 110
            End If
        End If

        If Not dmg < 0 Then
            dmg = Player.calcDamage(dmg, m.getDEF)
            p.hit(dmg, m, "", "shoot")
        End If

        p.inv.add(selected_ammo.getAName, -1)
        Dim out_dsc = "Panels on the back of the cannon slide open with a hiss, as its mechanism cycles.  " & p.inv.getCountAt(selected_ammo.getAName) & " shot" & If(p.inv.getCountAt(selected_ammo.getAName) = 1, "", "s") & " left!"

        If Not m.isDead Then
            TextEvent.pushAndLog(out_dsc)
        Else
            TextEvent.pushLog(out_dsc)
        End If

        If selected_ammo.getCount < 1 And getActiveAmmo.getCount > 0 Then
            selected_ammo = getActiveAmmo()
            TextEvent.pushLog("The cannon begins loading " & selected_ammo.getAName() & " rounds.")
        End If

        If dmg < 0 Then Return dmg

        Return -3
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        If selected_ammo Is Nothing Then selected_ammo = getActiveAmmo()
    End Sub
    Private Function getActiveAmmo() As StickOfGum
        If owner Is Nothing Then owner = Game.player1

        If selected_ammo Is Nothing OrElse selected_ammo.getCount < 1 Then
            If System.IO.File.Exists("items\" & Game.sessionID & "_" & id & ".itm") Then loadSavedItem(Game.sessionID, id)
            If selected_ammo Is Nothing OrElse selected_ammo.getCount < 1 Then
                If owner.inv.getCountAt(StickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(StickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(CStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(CStickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(MStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(MStickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(BBStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(BBStickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(WStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(WStickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(DFStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(DFStickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(GoldenGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(GoldenGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(GAStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(GAStickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(HPStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(HPStickOfGum.ITEM_NAME)
                ElseIf owner.inv.getCountAt(MPStickOfGum.ITEM_NAME) > 0 Then
                    selected_ammo = owner.inv.item(MPStickOfGum.ITEM_NAME)
                Else
                    selected_ammo = owner.inv.item(StickOfGum.ITEM_NAME)
                End If
            End If
        End If

        Return selected_ammo
    End Function

    Public Overrides Sub toSavedItem(ByRef ent As Entity)
        Dim output = CStr(selected_ammo.getAName)

        Dim writer As IO.StreamWriter
        Dim filename As String = "items\" & Game.sessionID & "_" & id & ".itm"
        IO.File.Delete(filename)
        writer = IO.File.CreateText(filename)
        writer.WriteLine(output)
        writer.Flush()
        writer.Close()
    End Sub
    Public Overrides Sub loadSavedItem(ByVal sessionID As String, ByVal itmid As Integer)
        Dim filename As String = "items\" & sessionID & "_" & itmid & ".itm"

        Dim reader As IO.StreamReader
        reader = IO.File.OpenText(filename)

        Try
            selected_ammo = Game.player1.inv.item(reader.ReadLine())
        Finally
            reader.Close()
        End Try
    End Sub

    '| - AMMO Selection - |
    Public Sub selectActiveAmmo()
        Dim sog As Action = Nothing
        Dim csog As Action = Nothing
        Dim msog As Action = Nothing
        Dim bbsog As Action = Nothing
        Dim wsog As Action = Nothing
        Dim dfsog As Action = Nothing
        Dim gg As Action = Nothing
        Dim gasog As Action = Nothing
        Dim hpsog As Action = Nothing
        Dim mpsog As Action = Nothing

        Dim options As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))

        If owner.inv.getCountAt(StickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(StickOfGum.ITEM_NAME, AddressOf selectStickOfGum))
        If owner.inv.getCountAt(CStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(CStickOfGum.ITEM_NAME, AddressOf selectCStickOfGum))
        If owner.inv.getCountAt(MStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(MStickOfGum.ITEM_NAME, AddressOf selectMStickOfGum))
        If owner.inv.getCountAt(BBStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(BBStickOfGum.ITEM_NAME, AddressOf selectBBStickOfGum))
        If owner.inv.getCountAt(WStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(WStickOfGum.ITEM_NAME, AddressOf selectWStickOfGum))
        If owner.inv.getCountAt(DFStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(DFStickOfGum.ITEM_NAME, AddressOf selectDFStickOfGum))
        If owner.inv.getCountAt(GoldenGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(GoldenGum.ITEM_NAME, AddressOf selectGoldenGum))
        If owner.inv.getCountAt(GAStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(GAStickOfGum.ITEM_NAME, AddressOf selectGAStickOfGum))
        If owner.inv.getCountAt(HPStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(HPStickOfGum.ITEM_NAME, AddressOf selectHPStickOfGum))
        If owner.inv.getCountAt(MPStickOfGum.ITEM_NAME) > 0 Then options.Add(New Tuple(Of String, Action)(MPStickOfGum.ITEM_NAME, AddressOf selectMPStickOfGum))

        TextEvent.pushManySelect("Select ammo for the cannon...", options)
    End Sub
    Private Sub selectStickOfGum()
        selected_ammo = owner.inv.item(StickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectCStickOfGum()
        selected_ammo = owner.inv.item(CStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectMStickOfGum()
        selected_ammo = owner.inv.item(MStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectBBStickOfGum()
        selected_ammo = owner.inv.item(BBStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectWStickOfGum()
        selected_ammo = owner.inv.item(WStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectDFStickOfGum()
        selected_ammo = owner.inv.item(DFStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectGoldenGum()
        selected_ammo = owner.inv.item(GoldenGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectGAStickOfGum()
        selected_ammo = owner.inv.item(GAStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectHPStickOfGum()
        selected_ammo = owner.inv.item(HPStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
    Private Sub selectMPStickOfGum()
        selected_ammo = owner.inv.item(MPStickOfGum.ITEM_NAME)
        toSavedItem(Nothing)
    End Sub
End Class
