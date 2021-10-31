Public Class MasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.prt.sexBool And Not p.perks(perk.slutcurse) > -1 Then
            p.FtM()
            Equipment.antiClothingCurse(p)
            p.drawPort()
        ElseIf p.perks(perk.slutcurse) > -1 Or p.prt.iArrInd(pInd.rearhair).Item2 = True Then
            Dim newRHairInd = If(p.sState.iArrInd(pInd.rearhair).Item1 < 8, p.sState.iArrInd(pInd.rearhair).Item1, Int(Rnd() * 8))
            Dim newMHairInd = If(p.sState.iArrInd(pInd.midhair).Item1 < 8, p.sState.iArrInd(pInd.midhair).Item1, Int(Rnd() * 8))
            Dim newFHairInd = If(p.sState.iArrInd(pInd.fronthair).Item1 < 10, p.sState.iArrInd(pInd.fronthair).Item1, Int(Rnd() * 10))

            p.prt.setIAInd(pInd.rearhair, newRHairInd, False, False)
            p.prt.setIAInd(pInd.midhair, newMHairInd, False, False)
            p.prt.setIAInd(pInd.fronthair, newFHairInd, False, False)

            If p.perks(perk.slutcurse) > -1 Then
                TextEvent.push("Thoughts of modesty return to your mind. You are free of the slut curse!")
                p.perks(perk.slutcurse) = -1
            End If

            Equipment.antiClothingCurse(p)

            p.drawPort()
        Else
            TextEvent.push("Nothing happened!")
            End If
            p.savePState()
            p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Masculine effect"
    End Function
End Class
