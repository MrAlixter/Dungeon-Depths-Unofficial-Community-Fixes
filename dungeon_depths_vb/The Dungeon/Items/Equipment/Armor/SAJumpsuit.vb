
Public Class SAJumpsuit
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Space_Age_Jumpsuit")
        id = 102
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isRandoTFAcceptable = False
        MyBase.slutVarInd = 103

        '|Stats|
        MyBase.mBoost = 14
        MyBase.dBoost = 4
        MyBase.count = 0
        MyBase.value = 700

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(40, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(41, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(148, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(149, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(150, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(68, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(69, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(302, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(303, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(304, True, True)

        '|Description|
        MyBase.setDesc("This garment is clearly not from the world you are used to.  Even the fabric is futuristic; focusing ambient energy from the air." & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
