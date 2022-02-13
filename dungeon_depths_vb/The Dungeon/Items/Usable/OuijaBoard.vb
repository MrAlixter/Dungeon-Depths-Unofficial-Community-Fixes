Public Class OuijaBoard
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Ouija_Board")
        id = 328
        tier = 3

        '|Item Flags|
        usable = True


        '|Stats|
        count = 0
        value = 2

        '|Description|
        setDesc("A plain wooden board covered in letters and occult symbols, and a small planchette with a hole in its center.  Some folks say that it can be used to commune with the dead, but other folks say that the first group of folks are full of it.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        count -= 1

        Try
            If Game.combat_engaged Or Game.shop_npc_engaged Then Throw New Exception
            Dim m As Monster = New PlayerGhost

            Game.toCombat(m)
        Catch ex As Exception
            Dim r = Int(Rnd() * 4)

            Select Case r
                Case 0
                    TextEvent.pushAndLog("The spirits ask for about three and a half gold.  You sever the connection...")
                Case 1
                    TextEvent.pushAndLog("The spirits say afhdadslhfzx cv.  Fascinating stuff!")
                Case 2
                    TextEvent.pushAndLog("The spirits offer their wisdom.  These spirits do not seem wise...")
                Case Else
                    TextEvent.pushAndLog("The spirits give you the silent treatment...")
            End Select
        End Try
    End Sub
End Class
