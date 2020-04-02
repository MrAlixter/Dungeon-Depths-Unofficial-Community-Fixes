Public Class MasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.prt.sexBool And Not p.perks("slutcurse") > -1 Then
            p.FtM()
            Game.pushLblEvent("You are now a man!")
            Equipment.antiClothingCurse(p)
            p.drawPort()
        ElseIf p.perks("slutcurse") > -1 Or p.prt.iArrInd(pInd.rearhair).Item2 = True Then
            p.prt.setIAInd(pInd.rearhair, p.sState.iArrInd(pInd.rearhair).Item1, False, False)
            p.prt.setIAInd(pInd.body, 0, True, False)
            p.prt.setIAInd(pInd.face, p.sState.iArrInd(pInd.face).Item1, False, False)
            p.prt.setIAInd(pInd.midhair, p.sState.iArrInd(pInd.midhair).Item1, False, False)
            p.prt.setIAInd(pInd.eyebrows, p.sState.iArrInd(pInd.eyebrows).Item1, False, False)
            p.prt.setIAInd(pInd.fronthair, p.sState.iArrInd(pInd.fronthair).Item1, False, False)
            Game.pushLblEvent("Thoughts of modesty return to your mind. You are free of the slut curse!")
            p.perks("slutcurse") = -1
            Equipment.antiClothingCurse(p)
            Game.pushLblEvent("You are now a man!")
            p.drawPort()
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        p.drawPort()
    End Sub
End Class
