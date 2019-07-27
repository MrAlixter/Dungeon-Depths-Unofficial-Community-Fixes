Public Class SVBunnySuit
    Inherits Armor
    'the BunnySuit is a cosmetic armor that provides +1 defence
    Sub New()
        MyBase.setName("Bunny_Suit​")
        MyBase.setDesc("An extremely sultry outfit worn by waitresses in a club. " & vbCrLf & _
                       "Fits sizes -1 through 7" & vbCrLf & _
                       "+1 DEF")
        id = 129
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 650

        MyBase.antiSlutVarInd = 16

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(50, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(183, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(184, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(185, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(186, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(187, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(188, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(189, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(190, True, True)
        MyBase.compressesBreasts = False
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
