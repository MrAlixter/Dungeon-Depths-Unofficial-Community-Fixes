
Public Class LabcoatSV
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Labcoat​")
        id = 107
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.hide_dick = False
        rando_inv_allowed = False
        MyBase.anti_slut_ind = 106

        '|Stats|
        MyBase.d_boost = 2
        w_boost = 20
        count = 0
        value = 450

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
        setDesc("A white labcoat that, despite not containing much underneath itself, still gives its wearer an air of scientific authority" & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
