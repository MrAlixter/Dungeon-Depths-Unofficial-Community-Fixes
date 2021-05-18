Public Class FusionCrystal
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Fusion_Crystal")
        id = 58
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("A strange looking crystal reported to fuse two beings upon shattering." & DDUtils.RNRN & _
                "Disclaimers:" & vbCrLf &
                "Only saves of the current version can be fused." & vbCrLf &
                "Players that can not be transformed can not fuse." & vbCrLf &
                "Players with the same name can not fuse.")

    End Sub
    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        count -= 1

        FusionDialogBackend.toPNL(p, TypeOfFusion.CRYSTAL_FUSION)
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
        Randomize(String.Compare(p1.name, p2.name))
        Dim player As Player = New Player()
        player.name = nameFusion(p1.name, p2.name)

        Dim r As Integer = Int(Rnd() * 2)
        If r = 0 Then player.pClass = p1.pClass Else player.pClass = p2.pClass
        If (p1.className = "Warrior" And p2.className = "Mage") Or (p2.className = "Warrior" And p1.className = "Mage") Then player.pClass = player.classes("Paladin")

        r = Int(Rnd() * 2)
        If r = 0 Then player.sex = p1.sex Else player.sex = p2.sex

        player.maxHealth = Math.Max(p1.maxHealth * 1.5, p2.maxHealth * 1.5)
        player.health = 1

        player.maxMana = Math.Max(p1.maxMana * 1.5, p2.maxMana * 1.5)
        player.mana = player.maxMana
        player.attack = Math.Max(p1.attack * 1.5, p2.attack * 1.5)
        player.defense = Math.Max(p1.defense * 1.5, p2.defense * 1.5)
        player.will = Math.Max(p1.will * 1.5, p2.will * 1.5)
        player.speed = Math.Max(p1.speed * 1.5, p2.speed * 1.5)
        player.lust = Math.Max(p1.lust * 1.5, p2.lust * 1.5)
        player.stamina = Math.Min(p1.stamina, p2.stamina)

        player.gold = p1.gold

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
        For i = 0 To Portrait.NUM_IMG_LAYERS
            If i <> pInd.rearhair And i <> pInd.fronthair And i <> pInd.midhair Then
                r = Int(Rnd() * 2)
                If r = 0 Then player.prt.iArrInd(i) = p1.prt.iArrInd(i) Else player.prt.iArrInd(i) = p2.prt.iArrInd(i)
            ElseIf i = pInd.rearhair Then
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

        player.reverseAllRoute()

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

        player.inv.invNeedsUDate = True
        player.UIupdate()
        player.description = CStr(player.name & " is a " & player.sex & " " & player.className)
        player.solFlag = False
    End Sub
End Class
