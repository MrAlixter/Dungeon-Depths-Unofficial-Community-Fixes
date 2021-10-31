
Public Class Labcoat
    Inherits Armor

    Sub New()
        setName("Labcoat")

        id = 106
        tier = Nothing
        usable = false
        MyBase.d_boost = 3
        w_boost = 30
        count = 0
        value = 600
        MyBase.slut_var_ind = 107
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(39, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(65, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(143, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(144, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(41, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(42, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(139, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(140, True, True)

        MyBase.compress_breast = True

        rando_inv_allowed = False

        setDesc("A white labcoat that gives its wearer an air of scientific authority." & DDUtils.RNRN & _
                                getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
