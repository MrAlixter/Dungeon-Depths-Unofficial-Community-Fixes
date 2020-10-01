Public Class AngelicSweater
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Angelic_Sweater")
        id = 199
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False
        MyBase.compressesBreasts = True
        MyBase.hidesDick = False

        '|Stats|
        MyBase.hBoost = 10
        MyBase.dBoost = 5
        MyBase.mBoost = 20
        MyBase.count = 0
        MyBase.value = 7777

        '|Image Index|
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(280, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(281, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(282, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(283, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(182, True, True)

        '|Description|
        MyBase.setDesc("A glittering, heavenly soft sweater." & DDUtils.RNRN &
                                     getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
