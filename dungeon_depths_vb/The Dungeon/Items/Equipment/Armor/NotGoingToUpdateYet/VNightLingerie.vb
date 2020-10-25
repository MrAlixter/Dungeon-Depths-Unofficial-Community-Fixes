Public Class VNightLingerie
    Inherits Armor

    Sub New()
        MyBase.setName("Val._Night_Lingerie")
        MyBase.setDesc("" & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+6 DEF") '& vbCrLf & _
        '("Can not attack " & immune)
        id = 78
        If DDDateTime.isValen Then tier = 2 Else tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.antiSlutVarInd = 79
        MyBase.value = 428
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(252, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(117, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(118, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(119, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
        MyBase.compressesBreasts = True
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False
    End Sub
End Class
