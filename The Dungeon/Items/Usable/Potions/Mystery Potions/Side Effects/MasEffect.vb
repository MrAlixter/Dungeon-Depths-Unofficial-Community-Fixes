Public Class MasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If
        If p.sexBool And Not p.perks("slutcurse") > -1 Then
            p.FtM()
            Game.pushLblEvent("You are now a man!")
            Equipment.antiClothingCurse()
            p.createP()
        ElseIf p.perks("slutcurse") > -1 Or p.iArrInd(1).Item2 = True Then
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(1).Item1, False)
            p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(4) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(4).Item1, False)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(5).Item1, False)
            p.iArrInd(10) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(10).Item1, False)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(15).Item1, False)
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
