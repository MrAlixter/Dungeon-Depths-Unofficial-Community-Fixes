Public Class SpotFusion
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Spot Fusion")
        MyBase.setUOC(True)
        setcost(50)
    End Sub
    Public Overrides Sub effect()
        TextEvent.pushLog("Spot Fusion!")

        If MyBase.getUser.perks(perk.isspotfused) > 0 Then
            TextEvent.pushAndLog("You can not fuse again for " & MyBase.getUser.perks(perk.isspotfused) & " more turns.")
        ElseIf Not Transformation.canBeTFed(MyBase.getUser) Then
            TextEvent.pushAndLog("You cannot fuse right now...")
        Else
            TextEvent.pushCombat("Spot Fusion!" & vbCrLf & "Fuses two explorers for 100 turns.")

            FusionDialogBackend.toPNL(MyBase.getUser, TypeOfFusion.SPOT_FUSION)
        End If
    End Sub


    Shared Function Fusion(ByVal p1 As Player, ByVal p2 As Player) As Player
        Randomize(String.Compare(p1.name, p2.name))
        p1.name = FusionCrystal.nameFusion(p1.name, p2.name)

        Dim r As Integer = Int(Rnd() * 2)
        If r = 0 Then p1.changeClass(p2.className)
        If (p1.className = "Warrior" And p2.className = "Mage") Or (p2.className = "Warrior" And p1.className = "Mage") Then p1.changeClass("Paladin")
        If (p1.className = "Cleric" And p2.className = "Rogue") Or (p2.className = "Cleric" And p1.className = "Rogue") Then p1.changeClass("Necromancer")

        r = Int(Rnd() * 2)
        If r = 0 Then p1.sex = p2.sex

        p1.hBuff = Math.Abs(p1.maxHealth - Math.Max(p1.maxHealth * 1.5, p2.maxHealth * 1.5))

        p1.mBuff = Math.Abs(p1.maxMana - Math.Max(p1.maxMana * 1.5, p2.maxMana * 1.5))

        p1.aBuff = Math.Abs(p1.attack - Math.Max(p1.attack * 1.5, p2.attack * 1.5))

        p1.dBuff = Math.Abs(p1.defense - Math.Max(p1.defense * 1.5, p2.defense * 1.5))

        p1.wBuff = Math.Abs(p1.will - Math.Max(p1.will * 1.5, p2.will * 1.5))

        p1.sBuff = Math.Abs(p1.speed - Math.Max(p1.speed * 1.5, p2.speed * 1.5))

        p1.lust = Math.Max(p1.lust * 1.5, p2.lust * 1.5)

        p1.stamina = Math.Min(p1.stamina, p2.stamina)

        For i = 0 To Portrait.NUM_IMG_LAYERS
            If i <> pInd.rearhair And i <> pInd.fronthair And i <> pInd.midhair Then
                r = Int(Rnd() * 2)
                If r = 0 Then p1.prt.iArrInd(i) = p2.prt.iArrInd(i)
            ElseIf i = pInd.rearhair Then
                r = Int(Rnd() * 2)
                If r = 0 Then p1.prt.iArrInd(pInd.rearhair) = p2.prt.iArrInd(pInd.rearhair)
                If r = 0 Then p1.prt.iArrInd(pInd.midhair) = p2.prt.iArrInd(pInd.midhair)
                If r = 0 Then p1.prt.iArrInd(pInd.fronthair) = p1.prt.iArrInd(pInd.fronthair)
            End If
        Next

        r = Int(Rnd() * 2)
        If r = 0 Then
            p1.prt.skincolor = p1.prt.skincolor
            p1.prt.haircolor = p2.prt.haircolor
        Else
            p1.prt.skincolor = p2.prt.skincolor
            p1.prt.haircolor = p1.prt.haircolor
        End If

        p1.breastSize = (p1.breastSize + p2.breastSize) / 2

        Return p1
    End Function

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A temporary fusion that combines two explorers into a superior adventurer for 100 turns.  There is a 110 turn cooldown on the fusion, starting immediately after use."
    End Function
End Class
