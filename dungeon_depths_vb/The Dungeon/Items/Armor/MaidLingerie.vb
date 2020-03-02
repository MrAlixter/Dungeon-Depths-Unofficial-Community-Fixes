Public Class MaidLingerie
    Inherits Armor
    Sub New()
        MyBase.setName("Maid_Lingerie")
        MyBase.setDesc("A smutty version of a French maid's outfit." & vbCrLf & "+4 SPD")
        id = 169
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 4
        MyBase.count = 0
        MyBase.value = 0

        antiSlutVarInd = 72

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(56, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(57, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(223, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(224, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(225, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
