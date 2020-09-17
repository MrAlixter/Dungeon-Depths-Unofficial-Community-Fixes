Public Class STBodysuit
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Skin_Tight_Bodysuit")
        id = 103
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isRandoTFAcceptable = False
        MyBase.antiSlutVarInd = 102

        '|Stats|
        MyBase.mBoost = 23
        MyBase.count = 0
        MyBase.value = 1375

        '|Image Index|
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

        '|Description|
        MyBase.setDesc("This sleek bodysuit leaves very little to the imagination, despite covering most of one's body.  Its thin, but flexible material trades any possible defense to maximize energy production." & DDUtils.RNRN & _
                                      getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
