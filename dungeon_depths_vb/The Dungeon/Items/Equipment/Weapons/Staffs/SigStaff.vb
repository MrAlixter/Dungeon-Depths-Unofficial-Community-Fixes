Public Class SigStaff
    Inherits Staff

    Public Const ITEM_NAME As String = "Signature_Staff"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
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
                "Grants access to the ""Molten Fireball"" spell" & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.learnSpell("Molten Fireball")
    End Sub
    Public Overloads Overrides Sub onUnequip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnequip(p, w)
        p.forgetSpell("Molten Fireball")
    End Sub
End Class
