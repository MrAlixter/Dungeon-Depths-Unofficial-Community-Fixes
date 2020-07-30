
Public Class STBodysuit
    Inherits Armor

    Sub New()
        MyBase.setName("Skin_Tight_Bodysuit")
        MyBase.setDesc("This sleek bodysuit leaves very little to the imagination, despite covering most of one's body.  Its thin, but flexible material trades any possible defense to maximize energy production." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+23 Max Mana")
        id = 103
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 23
        MyBase.count = 0
        MyBase.value = 1375
        MyBase.antiSlutVarInd = 102
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(44, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(45, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(159, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(160, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(161, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(162, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(52, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(53, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(230, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(231, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(232, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(233, True, True)
        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False
    End Sub
End Class
