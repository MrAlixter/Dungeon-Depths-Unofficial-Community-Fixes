Public Class ShowgirlArmorEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.equippedArmor.getCursed(p) Then
            TextEvent.pushLog("...but nothing happens...")
            Exit Sub
        End If

        p.inv.add(GShowgirlOutfit.ITEM_NAME, 1)
        If Not p.equippedArmor.getAName.Equals("Naked") Then p.inv.add(p.equippedArmor.getAName, -1)
        Equipment.equipWeapon(p, GShowgirlOutfit.ITEM_NAME)

        p.UIupdate()
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Showgirl armor effect"
    End Function
End Class
