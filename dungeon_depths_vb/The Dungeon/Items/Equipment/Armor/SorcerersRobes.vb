Public Class SorcerersRobes
    Inherits Armor

    Sub New()
        MyBase.setName("Sorcerer's_Robes")
        MyBase.setDesc("A protective garment made more for pratical funtion than for fashion. " & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+7 DEF" & vbCrLf & _
                       "+10 MANA")
        id = 17
        tier = 3
        MyBase.setUsable(False)
        MyBase.dBoost = 7
        MyBase.mBoost = 10
        MyBase.count = 0
        MyBase.value = 950
        MyBase.slutVarInd = 18
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(7, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(23, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(24, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
