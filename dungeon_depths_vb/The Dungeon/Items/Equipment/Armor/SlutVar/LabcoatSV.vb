
Public Class LabcoatSV
    Inherits Armor

    Public Const ITEM_NAME As String = "Labcoat​"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 107
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        hide_dick = False
        rando_inv_allowed = False
        anti_slut_ind = 106

        '|Stats|
        d_boost = 2
        w_boost = 20
        count = 0
        value = 450

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(43, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(151, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(152, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(153, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(154, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(289, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(290, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(291, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(292, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(293, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(294, True, True)

        '|Description|
        setDesc("A white labcoat that, despite not containing much underneath itself, still gives its wearer an air of scientific authority" & DDUtils.RNRN &
                        getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
