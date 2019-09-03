Public Class SkimpyTT
    Inherits Armor

    Sub New()
        MyBase.setName("Skimpy_Tube_Top")
        MyBase.setDesc("Barely there, this skimpy outfit boosts agility.")
        id = 147
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 0

        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(215, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(216, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(217, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(218, True, True)
        MyBase.compressesBreasts = True
        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        Game.player.perks("bimbododge") = 2
    End Sub
    Public Overrides Sub onUnequip()
        Game.player.perks("bimbododge") = -1
    End Sub
End Class
