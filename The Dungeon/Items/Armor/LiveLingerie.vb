Public Class LiveLingerie
    Inherits Armor
    Sub New()
        MyBase.setName("Living_Lingerie")
        MyBase.setDesc("A suit of living lingerie embued with a the soul of a mimic." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+2 DEF" & vbCrLf & _
                       "The mimic's movment rapidly raises lust" & vbCrLf & _
                       "May not be easy to remove")
        id = 56
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.value = 450
        MyBase.antiSlutVarInd = 55
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(82, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(84, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(86, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(88, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        If Not Game.player.perks("livelinge") > -1 Then Game.player.perks("livelinge") = 0
    End Sub
    Public Overrides Sub onUnequip()
        If Not Game.player.perks("livelinge") > -1 Then Game.player.perks("livelinge") = -1
    End Sub
End Class
