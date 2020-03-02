
Public Class SAJumpsuit
    Inherits Armor

    Sub New()
        MyBase.setName("Space_Age_Jumpsuit")
        MyBase.setDesc("This garment is clearly not from the world you are used to.  Even the fabric is futuristic; focusing ambient energy from the air." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+14 Max Mana, +4 DEF")
        id = 102
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 14
        MyBase.dBoost = 4
        MyBase.count = 0
        MyBase.value = 700
        MyBase.slutVarInd = 103
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(40, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(41, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(148, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(149, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(150, True, True)
        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False
    End Sub
End Class
