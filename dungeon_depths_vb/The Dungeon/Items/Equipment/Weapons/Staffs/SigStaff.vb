Public Class SigStaff
    Inherits Staff

    Sub New()
        '|ID Info|
        setName("Signature_Staff")
        id = 159
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False

        '|Stats|
        m_boost = 66
        a_boost = 10
        count = 0
        value = 4666

        '|Description|
        setDesc("A finely crafted staff bearing a trademarked signature. The gem contained inside of it produces a nearly infinite pool of incredibly unstable fire magic." & DDUtils.RNRN &
                getStatInformation() & vbcrlf &
                "Grants access to the ""Molten Fireball"" spell")
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
