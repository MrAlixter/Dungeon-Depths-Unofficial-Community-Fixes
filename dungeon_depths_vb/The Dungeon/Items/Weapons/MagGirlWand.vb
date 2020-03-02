Public Class MagGirlWand
    Inherits Weapon

    Sub New()
        MyBase.setName("Magic_Girl_Wand")
        MyBase.setDesc("A mysterious wand used by a mysterious protector." & vbCrLf & "+7 ATK, +20 Max Mana")
        id = 11
        tier = 3
        MyBase.setUsable(False)
        MyBase.mBoost = 20
        MyBase.aBoost = 7
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
    Public Overrides Sub onEquip()
        If Not Game.player.pClass.name.Equals("Magic Girl") Then

            Dim magicGirlTF = New MagGirlTF(2, 0, 0, False)
            magicGirlTF.update()
            Game.player.ongoingTFs.Add(magicGirlTF)
        End If
    End Sub
    Public Overrides Sub onUnequip()
        MyBase.onUnequip()

    End Sub
End Class
