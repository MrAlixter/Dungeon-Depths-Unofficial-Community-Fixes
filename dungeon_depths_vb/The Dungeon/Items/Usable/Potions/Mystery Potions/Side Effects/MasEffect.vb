Public Class MasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.prt.sexBool And Not p.perks("slutcurse") > -1 Then
            p.FtM()
            Game.pushLblEvent("You are now a man!")
            Equipment.antiClothingCurse()
            p.createP()
        ElseIf p.perks("slutcurse") > -1 Or p.prt.iArrInd(1).Item2 = True Then
            p.prt.setIAInd(1, p.sState.iArrInd(1).Item1, False, False)
            p.prt.setIAInd(2, 0, True, False)
            p.prt.setIAInd(4, p.sState.iArrInd(4).Item1, False, False)
            p.prt.setIAInd(5, p.sState.iArrInd(5).Item1, False, False)
            p.prt.setIAInd(10, p.sState.iArrInd(10).Item1, False, False)
            p.prt.setIAInd(15, p.sState.iArrInd(15).Item1, False, False)
            Game.pushLblEvent("Thoughts of modesty return to your mind. You are free of the slut curse!")
            p.perks("slutcurse") = -1
            Equipment.antiClothingCurse()
            Game.pushLblEvent("You are now a man!")
            p.createP()
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        p.createP()
    End Sub
End Class
