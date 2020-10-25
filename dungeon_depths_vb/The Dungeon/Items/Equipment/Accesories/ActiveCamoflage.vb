Public Class ActiveCamoflage
    Inherits Accessory
    'The ruby circlet provides a +1 attack buff
    Sub New()
        MyBase.setName("Active_Camoflage")
        MyBase.setDesc("Unimplemented")
        id = 141
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 0

        MyBase.isRandoTFAcceptable = False
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        Game.pushLblEvent("Unimplemented")
        MyBase.onEquip(p)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
    End Sub
End Class
