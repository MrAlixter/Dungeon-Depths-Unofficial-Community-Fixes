Public Class WitchCosplay
    Inherits Armor

    Sub New()
        MyBase.setName("Witch_Cosplay")
        MyBase.setDesc("A glamourous garment made more to show off one's body than to show off any magical ability." & vbCrLf & _
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+3 DEF" & vbCrLf & _
                       "+10 MANA")
        id = 18
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 10
        MyBase.dBoost = 3
        MyBase.count = 0
        MyBase.value = 1250
        MyBase.antiSlutVarInd = 17
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(25, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(26, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(27, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(28, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
