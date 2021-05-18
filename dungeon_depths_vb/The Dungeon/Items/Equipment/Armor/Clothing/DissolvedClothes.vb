Public Class DissolvedClothes
    Inherits Armor
    Sub New()
        '|ID Info|
        setName("Dissolved_Clothes")
        id = 80
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        rando_inv_allowed = False

        '|Stats|
        MyBase.d_boost = 1
        count = 0
        value = 0

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(32, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(32, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(131, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(132, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(64, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(287, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(288, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(288, True, True)

        '|Description|
        setDesc("While at some point this set of apperal may have provided some defense, a generous dousing of slime has left it completely ruined." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
