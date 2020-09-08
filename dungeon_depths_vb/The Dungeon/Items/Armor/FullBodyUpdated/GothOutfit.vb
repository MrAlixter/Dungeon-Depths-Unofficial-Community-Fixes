Public Class GothOutfit
    Inherits Armor

    Sub New()
        MyBase.setName("TODO_Outfit")
        MyBase.setDesc("Yeah, uhh... I didn't have time to finish the thing this was a part of, so..." & vbCrLf & _
                       "Fits sizes 3 through 7" & vbCrLf &
                       "+9 DEF" & vbCrLf &
                       "+7 SPD")
        id = 181
        tier = Nothing

        MyBase.setUsable(False)
        MyBase.dBoost = 9
        MyBase.sBoost = 7
        MyBase.count = 0
        MyBase.value = 1450

        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(247, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(248, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(249, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(250, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(251, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(256, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(257, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(258, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(259, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(260, True, True)

        MyBase.compressesBreasts = False
    End Sub
End Class
