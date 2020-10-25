Public Class WitchCosplay
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Witch_Cosplay")
        id = 18
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.antiSlutVarInd = 17

        '|Stats|
        MyBase.mBoost = 10
        MyBase.dBoost = 3
        MyBase.count = 0
        MyBase.value = 1250

        '|Image Index|
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(25, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(26, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(27, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(28, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(39, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(40, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(41, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(42, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(43, True, True)

        '|Description|
        MyBase.setDesc("A glamourous garment made more to show off one's body than to show off any magical ability." & vbCrLf & _
                             getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
