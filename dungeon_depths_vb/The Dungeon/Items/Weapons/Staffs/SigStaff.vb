Public Class SigStaff
    Inherits Staff

    Sub New()
        MyBase.setName("Signature_Staff")
        MyBase.setDesc("A finely crafted staff bearing a trademarked signature. The gem contained inside of it produces a nearly infinite pool of incredibly unstable fire magic." & vbCrLf &
                       "+66 Mana" & vbCrLf &
                       "+10 ATK")
        id = 159
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 66
        MyBase.aBoost = 10
        count = 0
        value = 4666
    End Sub

    Public Overrides Sub onEquip()
        If Not Game.player.knownSpells.Contains("Molten Fireball") Then Game.player.knownSpells.Add("Molten Fireball")
    End Sub
    Public Overrides Sub onunEquip()
        Game.player.knownSpells.Remove("Molten Fireball")
    End Sub
End Class
