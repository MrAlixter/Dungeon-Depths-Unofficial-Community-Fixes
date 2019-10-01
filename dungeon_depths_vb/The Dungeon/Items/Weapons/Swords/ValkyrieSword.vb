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
        If Not Game.player.pClass.name.Equals("Valkyrie") Then
            Dim valkyrieTF = New ValkyrieTF2(1, 0, 0, False)
            valkyrieTF.step1()
            Game.player.createP()
        End If
    End Sub
    Public Overrides Sub onUnequip()
        MyBase.onUnequip()
        Equipment.clothesChange("Naked")
    End Sub
End Class
