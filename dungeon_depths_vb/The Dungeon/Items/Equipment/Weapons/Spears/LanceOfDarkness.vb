Public Class LanceOfDarkness
    Inherits Spear

    Sub New()
        '|ID Info|
        setName("Lance_of_Darkness")
        id = 238
        tier = Nothing

        '|Item Flags|
        usable = true
        MyBase.cursed = True

        '|Stats|
        MyBase.a_boost = 31
        MyBase.s_boost = -7
        count = 0
        value = 3110
        MyBase.weight = 7

        '|Description|
        setDesc("A hefty spear crafted from a jet-black alloy.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
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
            TextEvent.push("You throw the spear across the dungeon at nothing in particular.")
            TextEvent.pushLog("You throw the spear across the dungeon at nothing in particular.")
        Else
            TextEvent.pushLog("You throw the spear!")
            Dim dmg As Integer = (p.getATK) + (Me.a_boost) + (Me.a_boost) + Int(Rnd() * 3 + 1)
            p.hit(dmg, m)
        End If

        If Not p.equippedWeapon.getName.Equals(getName) Then
            durability -= weight + Int(Rnd() * 3 + 1) + Int(Rnd() * 3 + 1)
            If durability <= 0 Then break()
        End If
    End Sub
End Class
