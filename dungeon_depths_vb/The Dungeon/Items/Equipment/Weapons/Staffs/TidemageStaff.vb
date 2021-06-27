Public Class TidemageStaff
    Inherits Staff

    Sub New()
        '|ID Info|
        setName("Staff_of_the_Tidemage")
        id = 297
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        m_boost = 30
        w_boost = 7
        count = 0
        value = 1700

        '|Description|
        setDesc("A staff of arcane coral used by a sect of mages that spend a lot of time at the beach." & DDUtils.RNRN &
                getStatInformation() & vbCrLf &
                "Becomes more powerful if its wielder is wearing a bikini." & vbCrLf &
                "Grants access to the ""Aquageyser"" spell")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If Not p.knownSpells.Contains("Aquageyser") Then p.knownSpells.Add("Aquageyser")
    End Sub
    Public Overloads Overrides Sub onUnEquip(ByRef p As Player, ByRef w As Weapon)
        MyBase.onUnEquip(p, w)
        p.knownSpells.Remove("Aquageyser")
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return If(p.equippedArmor.getAName.Contains("Bikini"), 14, 0)
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 30

        Return If(p.equippedArmor.getAName.Contains("Bikini"), 54, 30)
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 7

        Return If(p.equippedArmor.getAName.Contains("Bikini"), 17, 7)
    End Function

    Public Overrides Function getTier() As Integer
        If DDDateTime.isSummer Then Return 3

        Return Nothing
    End Function

    Public Overrides Function getDesc() As Object
        Return "A staff of arcane coral used by a sect of mages that spend a lot of time at the beach." & DDUtils.RNRN &
                getStatInformation() & vbCrLf &
                "Becomes more powerful if its wielder is wearing a bikini." & vbCrLf &
                "Grants access to the ""Aquageyser"" spell"
    End Function
End Class
