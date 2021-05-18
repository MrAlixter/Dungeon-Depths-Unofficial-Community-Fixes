Public Class ActiveCamoflage
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        setName("Active_Camoflage")
        setDesc("Unimplemented")
        id = 141
        tier = Nothing
        usable = false
        count = 0
        value = 0

        rando_inv_allowed = False
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        Game.pushLblEvent("Unimplemented")
        MyBase.onEquip(p)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
    End Sub
End Class
