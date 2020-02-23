Public Class ScaleArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Scale_Armor")
        MyBase.setDesc("Unlike the its bronze and steel counterparts, this armor set consists of a series of small interlocking plates.  The unique draconic alloy used by these scales provides ample protection, although it's also fairly heavy." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf &
                       "+22 DEF" & vbCrLf &
                       "-3 SPD")
        id = 176
        tier = Nothing
        slutVarInd = 177
        MyBase.setUsable(False)
        MyBase.dBoost = 22
        MyBase.sBoost = -3
        MyBase.count = 0
        MyBase.value = 2300

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(62, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(238, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(239, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(240, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
