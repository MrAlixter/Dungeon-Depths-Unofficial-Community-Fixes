Public Class FemEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.prt.sexBool = False Then
            p.MtF()
            Game.pushLblEvent("Your sex changes!")
        ElseIf Not p.perks(perk.slutcurse) > -1 Then
            p.perks(perk.slutcurse) = 0

            Dim newRHairInd = If(p.sState.iArrInd(pInd.rearhair).Item1 < 13, p.sState.iArrInd(pInd.rearhair).Item1, Int(Rnd() * 13))
            Dim newMHairInd = If(p.sState.iArrInd(pInd.midhair).Item1 < 13, p.sState.iArrInd(pInd.midhair).Item1, Int(Rnd() * 13))
            Dim newFHairInd = If(p.sState.iArrInd(pInd.fronthair).Item1 < 10, p.sState.iArrInd(pInd.fronthair).Item1, Int(Rnd() * 10))

            p.prt.setIAInd(pInd.rearhair, newRHairInd, True, False)
            p.prt.setIAInd(pInd.midhair, newMHairInd, True, False)
            p.prt.setIAInd(pInd.fronthair, newFHairInd, True, False)

            Equipment.clothingCurse1(p)
            p.be()
            Game.pushLblEvent("All thoughts of modesty vanish from your brain.  You will now dress sluttier!")
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        p.savePState()
        p.drawPort()
    End Sub
End Class
