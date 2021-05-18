Public Class FlamingSword
    Inherits Sword

    Sub New()
        '|ID Info|
        setName("Flaming_Sword")
        id = 172
        tier = Nothing

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.a_boost = 45
        count = 0
        value = 2695

        '|Description|
        setDesc("A slender red-orange blade that becomes engulfed in a ball of flame once pulled from its jet black scabard." & DDUtils.RNRN &
                       "This sword will take damage from attacks" & vbCrLf &
                       getStatInformation())
    End Sub
	
	 Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg = MyBase.attack(p, m)

        If dmg <> -1 Then
            durability -= 20
            If durability <= 0 Then break()
        End If

        Return dmg
    End Function
End Class
