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

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.pClass.name.Equals("Valkyrie") Then
            Dim valkyrieTF = New ValkyrieTF2(1, 0, 0, False)
            valkyrieTF.step1()
            p.drawPort()
        End If
    End Sub

    Public Overrides Sub onunEquip(ByRef p As Player, ByRef w As Weapon)
        If p.pClass.name.Equals("Valkyrie") And Not w Is Nothing AndAlso Not w.GetType.IsSubclassOf(GetType(Sword)) Then
            Game.pushLstLog("Putting away your sword causes you to change into your regular self!")
            p.inv.add(95, -1)
            p.revertToPState()
        End If
    End Sub
End Class
