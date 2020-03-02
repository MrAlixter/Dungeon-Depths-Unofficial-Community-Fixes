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
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        Game.pushLblEvent("Unimplemented")
        MyBase.onEquip()
    End Sub

    Public Overrides Sub onUnequip()
        MyBase.onUnequip()
    End Sub
End Class
