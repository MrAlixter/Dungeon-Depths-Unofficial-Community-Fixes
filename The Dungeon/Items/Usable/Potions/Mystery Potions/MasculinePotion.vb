Public Class MasculinePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Masculine_Potion")
        MyBase.setDesc("A chancy looking potion")
        id = 59
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(59) = "Masculine_Potion"
        If p.sexBool And Not p.perks("slutcurse") > -1 Then
            p.FtM()
            Game.pushLblEvent("You are now a man!")
            Equipment.antiClothingCurse()
            Equipment.portraitUDate()
        ElseIf p.perks("slutcurse") > -1 Or p.iArrInd(1).Item2 = True Then
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(1).Item1, False)
            p.iArrInd(2) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(4) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(4).Item1, False)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(5).Item1, False)
            p.iArrInd(10) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(10).Item1, False)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(15).Item1, False)
            p.perks("slutcurse") = -1
            Equipment.antiClothingCurse()
            Game.pushLblEvent("You are now a man!")
            Equipment.portraitUDate()
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        If Not Game.player.perks("polymorphed") > -1 And Not Game.player.title.Equals("Magic Girl") Then
            Game.player.pState.save(Game.player)
        End If
        Equipment.portraitUDate()
    End Sub
End Class
