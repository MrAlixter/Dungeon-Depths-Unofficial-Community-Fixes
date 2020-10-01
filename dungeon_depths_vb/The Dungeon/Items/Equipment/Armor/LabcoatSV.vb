
Public Class LabcoatSV
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Labcoat​")
        id = 107
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.hidesDick = False
        MyBase.isRandoTFAcceptable = False
        MyBase.antiSlutVarInd = 106

        '|Stats|
        MyBase.dBoost = 2
        MyBase.wBoost = 20
        MyBase.count = 0
        MyBase.value = 450

        '|Image Index|
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(43, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(151, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(152, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(153, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(154, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(289, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(290, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(291, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(292, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(293, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(294, True, True)

        '|Description|
        MyBase.setDesc("A white labcoat that, despite not containing much underneath itself, still gives its wearer an air of scientific authority" & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
