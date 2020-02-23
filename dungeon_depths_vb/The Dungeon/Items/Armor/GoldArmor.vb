Public Class GoldArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Gold_Armor")
        MyBase.setDesc("A expensive looking armor set made for the wealthy." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+30 DEF")
        id = 38

        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 30
        MyBase.count = 0
        MyBase.value = 3800
        MyBase.slutVarInd = 39
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(9, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(51, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(52, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(53, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
