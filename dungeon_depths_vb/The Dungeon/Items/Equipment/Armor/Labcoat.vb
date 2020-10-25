
Public Class Labcoat
    Inherits Armor

    Sub New()
        MyBase.setName("Labcoat")

        id = 106
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 3
        MyBase.wboost = 30
        MyBase.count = 0
        MyBase.value = 600
        MyBase.slutVarInd = 107
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(39, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(65, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(143, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(144, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(41, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(42, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(139, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(140, True, True)

        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False

        MyBase.setDesc("A white labcoat that gives its wearer an air of scientific authority." & DDUtils.RNRN & _
                                getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
