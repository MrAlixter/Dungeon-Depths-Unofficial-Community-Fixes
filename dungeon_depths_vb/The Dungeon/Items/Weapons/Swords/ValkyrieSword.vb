Public Class ValkyrieSword
    Inherits Sword

    Sub New()
        MyBase.setName("Valkyrie_Sword")
        MyBase.setDesc("A blazing sword used by a winged protector." & vbCrLf & "+22 ATK, +7 Max Mana")
        id = 96
        tier = 3
        MyBase.setUsable(False)
        MyBase.mBoost = 7
        MyBase.aBoost = 22
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Public Overrides Sub onEquip()
        If Not Game.player1.pClass.name.Equals("Valkyrie") Then
            Dim valkyrieTF = New ValkyrieTF2(1, 0, 0, False)
            valkyrieTF.step1()
            Game.player1.drawPort()
        End If
    End Sub

    Public Overrides Sub onunEquip(Optional w As Weapon = Nothing)
        Dim p = Game.player1
        If p.pClass.name.Equals("Valkyrie") And Not w.GetType.IsSubclassOf(GetType(Sword)) Then
            Game.pushLstLog("Putting away your sword causes you to change into your regular self!")
            p.inv.add(95, -1)
            p.revertToPState()
        End If
    End Sub
End Class
