Public Class VNightLingerie
    Inherits Armor

    Sub New()
        MyBase.setName("Val._Night_Lingerie")
        MyBase.setDesc("" & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+6 DEF") '& vbCrLf & _
        '("Can not attack " & immune)
        id = 78
        If DateTime.Now.Month = 2 And DateTime.Now.Day = 14 Then tier = 2 Else tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.antiSlutVarInd = 79
        MyBase.value = 428
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(23, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(23, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(117, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(118, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(119, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
