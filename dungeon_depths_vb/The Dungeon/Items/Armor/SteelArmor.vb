Public Class SteelArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Steel_Armor")
        MyBase.setDesc("A basic armor set forged from steel." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+12 DEF")
        id = 5
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 12
        MyBase.count = 0
        MyBase.value = 564
        MyBase.slutVarInd = 7
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(6, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
