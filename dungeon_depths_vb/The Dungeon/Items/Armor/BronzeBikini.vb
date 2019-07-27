Public Class BronzeBikini
    Inherits Armor

    Sub New()
        MyBase.setName("Bronze_Bikini")
        MyBase.setDesc("A bronze bikini covered in a fine mail of bronze rings.  While it won't stop very many hits, it is also lightweight enough to move around freely." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+3 DEF" &
                       "+5 DEF")
        id = 85
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 3
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 250
        MyBase.antiSlutVarInd = 83
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(30, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(31, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(128, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(129, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(130, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
