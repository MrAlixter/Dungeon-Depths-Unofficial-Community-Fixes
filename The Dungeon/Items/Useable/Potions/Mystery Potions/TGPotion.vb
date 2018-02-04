Public Class TGPotion
    Inherits Potion
    Sub New()
        MyBase.setRealName("Feminine_Potion")
        MyBase.setDesc("A funny looking potion")
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Form1.player
        p.inventorynames(28) = "Feminine_Potion"
        If p.sexBool = False Then
            p.tg()
            Form1.pushLblEvent("You are now a woman!")
        ElseIf Not p.perks(2) Then
            p.perks(2) = True
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(p.iArrInd(1).Item1, True)
            Form3.clothingCurse1()
            Form1.pushLblEvent("All thoughts of modesty vanish from your brain.  You will now dress sluttier!")
        Else
            Form1.pushLblEvent("Nothing happened!")
        End If
        If Not Form1.player.perks(5) Or Not Form1.player.title.Equals("Magic Girl") Then
            Form1.player.pState.save(Form1.player)
        End If
    End Sub
End Class
