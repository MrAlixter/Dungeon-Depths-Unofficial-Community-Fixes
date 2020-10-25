Public Class LanceOfDarkness
    Inherits Spear

    Sub New()
        '|ID Info|
        MyBase.setName("Lance_of_Darkness")
        id = 238
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isCursed = True

        '|Stats|
        MyBase.aBoost = 31
        MyBase.sBoost = -7
        MyBase.count = 0
        MyBase.value = 3110
        MyBase.weight = 7

        '|Description|
        MyBase.setDesc("A hefty spear crafted from a jet-black alloy.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                       "Can be thrown using the ""Use"" button." & vbCrLf &
                       "+31 ATK" & vbCrLf &
                       "-7 SPD")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        If Not p.className.Equals("Archdemoness") Then
            Dim archdemonessTF = New ArchDemonessTF(1, 0, 0, False)
            archdemonessTF.step1()
            p.drawPort()
        End If
    End Sub

    Overrides Sub wThrow(ByRef p As Player, ByRef m As Entity)
        If m Is Nothing Then
            Game.pushLblEvent("You throw the spear across the dungeon at nothing in particular.")
            Game.pushLstLog("You throw the spear across the dungeon at nothing in particular.")
        Else
            Game.pushLstLog("You throw the spear!")
            Dim dmg As Integer = (p.getATK) + (Me.aBoost) + (Me.aBoost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        If Not p.equippedWeapon.getName.Equals(getName) Then
            durability -= weight + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
            If durability <= 0 Then break()
        End If
    End Sub
End Class
