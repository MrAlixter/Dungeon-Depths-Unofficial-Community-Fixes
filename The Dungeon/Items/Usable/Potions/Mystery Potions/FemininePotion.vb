Public Class FemininePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Feminine_Potion")
        MyBase.setDesc("A funny looking potion")
        id = 28
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(28) = "Feminine_Potion"
        If p.sexBool = False Then
            p.MtF()
            Game.pushLblEvent("You are now a woman!")
        ElseIf Not p.perks(2) Then
            p.perks(2) = True
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(1).Item1, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(5).Item1, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(p.sState.iArrInd(15).Item1, True)
            Equipment.clothingCurse1()
            p.be()
            Game.pushLblEvent("All thoughts of modesty vanish from your brain.  You will now dress sluttier!")
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        If Not Game.player.perks(5) And Not Game.player.title.Equals("Magic Girl") Then
            Game.player.pState.save(Game.player)
        End If
        Equipment.portraitUDate()
    End Sub
End Class
