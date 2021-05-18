Public Class SigStaff
    Inherits Staff

    Sub New()
        setName("Signature_Staff")
        setDesc("A finely crafted staff bearing a trademarked signature. The gem contained inside of it produces a nearly infinite pool of incredibly unstable fire magic." & vbCrLf &
                       "+66 Mana" & vbCrLf &
                       "+10 ATK")
        id = 159
        tier = Nothing
        usable = false
        MyBase.m_boost = 66
        MyBase.a_boost = 10
        count = 0
        value = 4666

        MyBase.droppable = False
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If Not p.knownSpells.Contains("Molten Fireball") Then p.knownSpells.Add("Molten Fireball")
    End Sub
    Public Overloads Overrides Sub onUnEquip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnEquip(p, w)
        p.knownSpells.Remove("Molten Fireball")
    End Sub
End Class
