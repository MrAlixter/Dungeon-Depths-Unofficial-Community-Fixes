Public Class FemEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If
        If p.sexBool = False Then
            p.MtF()
            Game.pushLblEvent("You are now a woman!")
        ElseIf Not p.perks("slutcurse") > -1 Then
            p.perks("slutcurse") = 0
            p.setIAInd(1, p.sState.iArrInd(1).Item1, True, False)
            p.setIAInd(5, p.sState.iArrInd(5).Item1, True, False)
            p.setIAInd(15, p.sState.iArrInd(15).Item1, True, False)
            Equipment.clothingCurse1()
            p.be()
            Game.pushLblEvent("All thoughts of modesty vanish from your brain.  You will now dress sluttier!")
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        p.createP()
    End Sub
End Class
