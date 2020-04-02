Public Class SpotFusion
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Spot Fusion")
        MyBase.setUOC(True)
        setcost(50)
    End Sub
    Public Overrides Sub effect()
        Game.pushLstLog("Spot Fusion!")
        Game.pushLblCombatEvent("Spot Fusion!" & vbCrLf & "Fuses two explorers for 100 turns.")

        Dim i As Integer
        Try
            i = InputBox("Which save slot?   1 2 3 4" & vbCrLf & _
                                        "                              5 6 7 8")
        Catch e As Exception
            Game.pushLblEvent("The spot fusion technique does not react.  It seems that an improper slot was selected.")
            Game.player1.hunger -= 50
            Exit Sub
        End Try
        If Not System.IO.File.Exists("saves/s" & i & ".ave") Then
            Game.pushLblEvent("Despite looking for someone to fuse with, you can't find anyone at that location.")
            Game.player1.hunger -= 50
            Exit Sub
        End If
        Dim save = Game.getPlayerFromFile("saves/s" & i & ".ave")
        Dim p2 As Player = save.Item1
        If save.Item2 <> Game.version Or p2.perks("polymorphed") > -1 Or Not Transformation.canBeTFed(Game.player1) Or (p2.pClass.name.Equals("Magical Girl") Or p2.pClass.name.Equals("Valkyrie")) Then
            Game.pushLblEvent("After talking it over, " & Game.player1.name & " and " & p2.name & " decide that they are incompatable, and not to fuse.")
            Game.player1.hunger -= 50
            Exit Sub
        End If

        Game.pushLblEvent(Game.player1.name & " and " & p2.name & " fuse together to form " & FusionCrystal.nameFusion(Game.player1.name, p2.name) & _
                           ", a superior explorer!")

        Fusion(getUser, p2)
    End Sub


    Shared Sub Fusion(ByVal p1 As Player, ByVal p2 As Player)
        Polymorph.transform(Game.player1, "Fusion")
        Randomize(p1.name.GetHashCode)
        p1.name = FusionCrystal.nameFusion(p1.name, p2.name)

        Dim r As Integer = Int(Rnd() * 2)
        If r = 0 Then p1.pClass = p2.pClass
        If (p1.pClass.name = "Warrior" And p2.pClass.name = "Mage") Or (p2.pClass.name = "Warrior" And p1.pClass.name = "Mage") Then p1.pClass = p1.classes("Paladin")

        r = Int(Rnd() * 2)
        If r = 0 Then p1.sex = p2.sex

        If p1.maxHealth > p2.maxHealth Then
            p1.maxHealth = p1.maxHealth * 1.5
        Else
            p1.maxHealth = p2.maxHealth * 1.5
        End If

        If p1.maxMana > p2.maxMana Then
            p1.mana = p1.maxMana * 1.5
        Else
            p1.mana = p2.maxMana * 1.5
        End If

        If p1.attack > p2.attack Then
            p1.attack = p1.attack * 1.5
        Else
            p1.attack = p2.attack * 1.5
        End If

        If p1.defence > p2.defence Then
            p1.defence = p1.defence * 1.5
        Else
            p1.defence = p2.defence * 1.5
        End If

        If p1.will > p2.will Then
            p1.will = p1.will * 1.5
        Else
            p1.will = p2.will * 1.5
        End If

        If p1.speed > p2.speed Then
            p1.speed = p1.speed * 1.5
        Else
            p1.speed = p2.speed * 1.5
        End If

        If p1.lust > p2.lust Then
            p1.lust = p1.lust * 1.5
        Else
            p1.lust = p2.lust * 1.5
        End If

        If p1.hunger > p2.hunger Then
            p1.hunger = p1.hunger * 1.5
        Else
            p1.hunger = p2.hunger * 1.5
        End If

        For i = 0 To Portrait.NUM_IMG_LAYERS
            If i <> 1 And i <> 15 And i <> 3 And i <> 5 Then
                r = Int(Rnd() * 2)
                If r = 0 Then p1.prt.iArrInd(i) = p2.prt.iArrInd(i)
            ElseIf i = 1 Then
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
        p1.currState.save(p1)
        p1.drawPort()
    End Sub

End Class
