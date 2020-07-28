Public Class BronzeArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Bronze_Armor")
        MyBase.setDesc("A lightweight armor set forged from bronze that, while not offering much defense also gives a slight speed boost." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+6 DEF" & vbCrLf & _
                       "+2 SPD")
        id = 83
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.sBoost = 2
        MyBase.count = 0

        MyBase.value = 125

        MyBase.slutVarInd = 85

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(28, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(29, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(125, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(126, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(127, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(15, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(24, True, True)

        MyBase.compressesBreasts = True
    End Sub
End Class
