Public Class ManaDisharge
    Inherits Weapon
    Sub New()
        MyBase.setName("Discharge_Gauntlets")
        MyBase.setDesc("These high-tech gauntlets gather up their users mana and release it all in a semi-controlled blast.  While this may be powerful if the user has a deep pool of mana to draw from, it burns through their reserves in one go, so it should probably be used sparingly." & vbCrLf &
                       "+7 Max Mana")
        id = 111
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 7
        count = 0
        value = 4323
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg As Integer = p.mana * 2.5
        p.mana = 0
        Return Player.calcDamage(dmg, m.defence)
    End Function
End Class
