Public Class MagSlutWand
    Inherits Weapon

    Sub New()
        MyBase.setName("Magical_Girl_Wand​")
        MyBase.setDesc("A heart adorned wand used by a mysterious protector.  Every once in a while, if flickers with a sinister crimson aura" & vbCrLf & "+7 ATK, +20 Max Mana")
        id = 171
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 20
        MyBase.aBoost = 7
        MyBase.count = 0
        MyBase.value = 10
        isCursed = True
    End Sub

    Public Overrides Sub onEquip()
        If Not Game.player.pClass.name.Equals("Magical Slut") Then
            Dim magicGirlTF = New MagSlutTF(2, 0, 0, False)
            magicGirlTF.update()
            Game.player.ongoingTFs.Add(magicGirlTF)
        End If
    End Sub
End Class
