Public Class ShowgirlWeaponEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.equippedWeapon.getCursed(p) Then
            TextEvent.pushLog("...but nothing happens...")
            Exit Sub
        End If

        p.inv.add(FantomaWand.ITEM_NAME, 1)
        If Not p.equippedWeapon.getAName.Equals("Fists") Then p.inv.add(p.equippedWeapon.getAName, -1)
        Equipment.equipWeapon(p, FantomaWand.ITEM_NAME)

        p.UIupdate()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Showgirl weapon effect"
    End Function
End Class
