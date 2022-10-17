Public Class ShrinkRay
    Inherits Weapon

    Public Const ITEM_NAME As String = "Shrink_Ray"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 120
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 7500

        '|Description|
        setDesc("A pistol-like weapon that reduces an opponent to less than a tenth of their initial height.  Unfortunatley, this may take some time... An ""Warning - Exerimental"" sticker hints that it might be risky to use.")
    End Sub

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim mP As NPC = CType(m, NPC)
        If mP.maxHealth > (mP.sMaxHealth / 10) Then
            m.maxHealth -= m.maxHealth / 4
            m.attack -= m.attack / 4
            m.defense -= m.defense / 4
            m.speed += (m.speed / 4)
            mP.tfEnd += Int(3 * m.maxHealth / mP.sMaxHealth)
            TextEvent.push("You zap your target with the shrink ray, and they get slightly smaller!")
        Else
            If Int(Rnd() * 2) = 0 And Not p.className.Equals("Shrunken") And Transformation.canBeTFed(p) Then
                'backfire
                Polymorph.transform(p, "Shrunken")
                EquipmentDialogBackend.weaponChange(p, "Fists")
            Else
                m.maxHealth = mP.sMaxHealth / 10
                m.attack = mP.sAttack / 10
                m.defense = mP.sdefense / 10
                m.speed = (mP.sSpeed / 10)

                TextEvent.push("Your target can get no smaller!")
            End If
        End If
        Return 0
    End Function
End Class
