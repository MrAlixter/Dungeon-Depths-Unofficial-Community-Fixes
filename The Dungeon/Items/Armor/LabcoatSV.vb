
Public Class LabcoatSV
    Inherits Armor

    Sub New()
        MyBase.setName("Labcoat​")
        MyBase.setDesc("A white labcoat that, despite not containing much underneath itself, still gives its wearer an air of scientific authority" & vbCrLf & _
                       "Fits sizes 0 through 4" & vbCrLf & _
                       "+2 DEF, +20 WIL")
        id = 107
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 2
        MyBase.wboost = 20
        MyBase.count = 0
        MyBase.value = 450
        MyBase.antiSlutVarInd = 106
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(43, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(151, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(152, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(153, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(154, True, True)
        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False
    End Sub
End Class
