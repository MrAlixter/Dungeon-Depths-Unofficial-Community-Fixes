Public Class HellflamingSword
    Inherits Sword

    Public Const ITEM_NAME As String = "Hellfire_Sword"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 401
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        a_boost = 35
        count = 0
        value = 3666

        '|Description|
        setDesc("A jet black blade that becomes engulfed in a ball of rosy flame once pulled from its leather scabbard." & DDUtils.RNRN &
                "This sword will take damage from each attack." & DDUtils.RNRN &
                "Each attack will its wielder's lust by one third." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return MyBase.getABoost(p)

        Return MyBase.getABoost(p) + (p.getLust() / 3)
    End Function

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg = MyBase.attack(p, m)

        p.addLust(p.getLust() / -3)

        If dmg <> -1 Then
            durability -= 20
            If durability <= 0 Then break()
        End If

        Return dmg
    End Function

    Public Overrides Sub outOfCombatAttack(ByRef p As Player)
        p.addLust(p.getLust() / -3)

        MyBase.outOfCombatAttack(p)
    End Sub
End Class
