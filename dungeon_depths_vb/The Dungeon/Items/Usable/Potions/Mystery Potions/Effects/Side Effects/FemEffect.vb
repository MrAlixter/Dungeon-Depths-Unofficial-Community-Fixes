Public Class FemEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.prt.sexBool = False Then
            p.MtF()
            TextEvent.push("Your sex changes!")
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
            TextEvent.push("All thoughts of modesty vanish from your brain.  You will now dress sluttier!")
        Else
            TextEvent.push("Nothing happened!")
        End If

        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Feminine effect"
    End Function
End Class
