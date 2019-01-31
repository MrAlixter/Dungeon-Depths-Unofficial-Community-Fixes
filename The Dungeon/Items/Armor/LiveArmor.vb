Public Class LiveArmor
    Inherits Armor
    Sub New()
        MyBase.setName("Living_Armor")
        MyBase.setDesc("A suit of living armor embued with a the soul of a mimic." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+6 DEF" & vbCrLf & _
                       "The mimic's movment continually raises lust" & vbCrLf & _
                       "May not be easy to remove")
        id = 55
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.value = 350
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(15, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(81, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(83, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(85, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(87, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        If Not Game.player.perks("livearm") > -1 Then Game.player.perks("livearm") = 0
    End Sub
    Public Overrides Sub onUnequip()
        If Not Game.player.perks("livearm") > -1 Then Game.player.perks("livearm") = -1
    End Sub
End Class
