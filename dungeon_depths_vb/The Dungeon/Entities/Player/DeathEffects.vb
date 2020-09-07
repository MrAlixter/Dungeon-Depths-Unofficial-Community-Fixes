Public Class DeathEffects
    '|MONSTER DEATHS|
    Shared Sub MBimboDeath()
        Dim p As Player = Game.player1

        p.perks(perk.bimbotf) = 1
        Dim out As String = "Exausted, you slump to the floor.  Glancing up, the horny mess attacking you seem to have gotten a running start, throwing herself on top of you, and pulling you into a sloppy kiss.  As she clumsily fumbles around, trying to remove your clothes, you roll out from underneath her and beat a hasty retreat, the faint sweetness of bubblegum lingering in your mouth."
        p.currTarget.despawn("p-death")
        Game.pushLblEvent(out)
    End Sub

    '|BOSS / MINIBOSS DEATHS|
    '|NPC DEATHS|
    Shared Sub FVHTInterupt1()

    End Sub
    Shared Sub FVHTInterupt2()

    End Sub

    '|MISC DEATH|
    Shared Sub hardDeath()
        Dim p As Player = Game.player1
        p.isDead = True
        Dim r As Integer = 0 ' CInt(Int(Rnd() * 2))
        If r = 0 Then
            Dim writer As IO.StreamWriter
            writer = IO.File.CreateText("gho.sts")
            writer.WriteLine(p.toGhost())
            writer.Flush()
            writer.Close()
        End If

        Dim c As Chest
        c = Game.baseChest.Create(p.inv, p.pos)
        Game.currFloor.chestList.Add(c)
        Game.currFloor.mBoard(p.pos.Y, p.pos.X).ForeColor = Color.FromArgb(45, 45, 45)
        Game.currFloor.mBoard(p.pos.Y, p.pos.X).Text = "#"
        Game.currFloor.writeFloorToFile()

        Game.pushPnlYesNo("Game Over!  Reload a save?", AddressOf tryToLoadSave, AddressOf askAboutNewGame)
        '.formReset()
    End Sub
    Shared Sub tryToLoadSave()
        Try
            Game.combatmode = False
            Game.solFlag = True
            Game.toSOL()
            Exit Sub
        Catch ex As Exception
            MsgBox("No save detected!")
        End Try
    End Sub
    Shared Sub askAboutNewGame()
        System.Threading.Thread.Sleep(50)
        Game.pushPnlYesNo("Start a new game?", AddressOf Game.newGame, AddressOf Game.formReset)
    End Sub
End Class
