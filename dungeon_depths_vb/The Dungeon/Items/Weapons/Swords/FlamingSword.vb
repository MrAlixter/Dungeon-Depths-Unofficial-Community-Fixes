Public Class FlamingSword
    Inherits Sword

    Sub New()
        MyBase.setName("Flaming_Sword")
        MyBase.setDesc("A slender red-orange blade that becomes engulfed in a ball of flame once pulled from its jet black scabard." & vbcrlf & 
		               "+45 ATK" & vbcrlf &
					   "This sword will take damage from attacks")
        id = 172
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 45
        MyBase.count = 0
        MyBase.value = 2695
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
