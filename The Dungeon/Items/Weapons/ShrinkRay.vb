Public Class ShrinkRay
    Inherits Weapon

    Sub New()
        MyBase.setName("Shrink_Ray")
        MyBase.setDesc("A pistol-like weapon that reduces an opponent to less than a tenth of their initial height.  Unfortunatley, this may take some time... An ""Warning - Exerimental"" sticker hints that it might be risky to use.")
        id = 120
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 7500
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer

            Dim mP As NPC = CType(m, NPC)
        If mP.maxHealth > (mP.sMaxHealth / 10) Then
            m.maxHealth -= m.maxHealth / 4
            m.attack -= m.attack / 4
            m.defence -= m.defence / 4
            m.speed += (m.speed / 4)
            mP.tfEnd += Int(3 * m.maxHealth / mP.sMaxHealth)
            Game.pushLblEvent("You zap your target with the shrink ray, and they get slightly smaller!")
        Else
            If Int(Rnd() * 2) = 0 And Not p.pClass.name.Equals("Shrunken") Then
                'backfire
                Polymorph.transform(p, "Shrunken")
                Equipment.weaponChange("Fists")
            Else
                m.maxHealth = mP.sMaxHealth / 10
                m.attack = mP.sAttack / 10
                m.defence = mP.sDefence / 10
                m.speed = (mP.sSpeed / 10)

                Game.pushLblEvent("Your target can get no smaller!")
            End If
        End If
        Return 0
    End Function
End Class
