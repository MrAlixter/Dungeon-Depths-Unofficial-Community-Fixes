Public Class FemEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.prt.sexBool = False Then
            p.MtF()
            Game.pushLblEvent("You are now a woman!")
        ElseIf Not p.perks("slutcurse") > -1 Then
            p.perks("slutcurse") = 0
            p.prt.setIAInd(pInd.rearhair, p.sState.iArrInd(pInd.rearhair).Item1, True, False)
            p.prt.setIAInd(pInd.midhair, p.sState.iArrInd(pInd.midhair).Item1, True, False)
            p.prt.setIAInd(pInd.fronthair, p.sState.iArrInd(pInd.fronthair).Item1, True, False)
            Equipment.clothingCurse1(p)
            p.be()
            Game.pushLblEvent("All thoughts of modesty vanish from your brain.  You will now dress sluttier!")
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        p.drawPort()
    End Sub
End Class
