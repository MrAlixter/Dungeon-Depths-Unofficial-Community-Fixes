Public Class SteelBikini
    Inherits Armor

    Sub New()
        MyBase.setName("Steel_Bikini")
        MyBase.setDesc("A skimpy steel swimsuit that gives a new meaning to 'Breast plates'." & vbCrLf & _
                       "Fits sizes 1 through 5" & vbCrLf & _
                       "+6 DEF")
        id = 7
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.value = 250
        MyBase.antiSlutVarInd = 5
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(27, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(16, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(18, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
