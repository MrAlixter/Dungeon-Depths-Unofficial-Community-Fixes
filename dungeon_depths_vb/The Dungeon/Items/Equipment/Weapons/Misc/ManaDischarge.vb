Public Class ManaDisharge
    Inherits Weapon

    Public Const ITEM_NAME As String = "Discharge_Gauntlets"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 111
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        m_boost = 7
        count = 0
        value = 4323

        '|Description|
        setDesc("These high-tech gauntlets gather up their users mana and release it all in a semi-controlled blast.  While this may be powerful if the user has a deep pool of mana to draw from, it burns through their reserves in one go, so it should probably be used sparingly." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = p.mana * 2.5
        p.mana = 0
        Return Player.calcDamage(dmg, m.defense)
    End Function
End Class
