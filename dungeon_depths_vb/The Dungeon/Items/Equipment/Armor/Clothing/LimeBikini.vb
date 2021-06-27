Public Class LimeBikini
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Lime_Bikini")
        id = 298
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        d_boost = 11
        s_boost = 11
        count = 0
        value = 1760

        '|Image Index|
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(378, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(379, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(380, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(381, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(382, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(362, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(363, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(364, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(365, True, True)

        '|Description|
        setDesc("A bright green swimsuit." & DDUtils.RNRN &
                getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Function getTier() As Integer
        If DDDateTime.isSummer Then Return 3

        Return Nothing
    End Function
End Class
