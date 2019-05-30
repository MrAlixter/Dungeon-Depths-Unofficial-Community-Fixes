
Public Class PhotonBikini
    Inherits Armor

    Sub New()
        MyBase.setName("Photon_Bikini")
        MyBase.setDesc("Though at a glance it may seem unlikely, this swimsuit houses a powerful shield generator that harnesses its users mana to withstand impacts." & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+7 Max mana, +2 DEF, Hardlight Effect")
        id = 105
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.mBoost = 7
        MyBase.dBoost = 2
        MyBase.count = 0
        MyBase.value = 3331
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(46, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(155, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(156, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(157, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(158, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Public Overrides Sub onEquip()
        MyBase.onEquip()
        Game.player.perks("hardlight") = 1
    End Sub
End Class
