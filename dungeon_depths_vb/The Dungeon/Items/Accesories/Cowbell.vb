Public Class Cowbell
    Inherits Accessory
    'The red headband provides a +1 attack buff
    Sub New()
        MyBase.setName("Cowbell")
        MyBase.setDesc("A large brass bell attached to a collar that rings steadily with its wearer's gait." & vbCrLf &
                       "+20 Health." & vbCrLf &
                       "-1 WIL")
        id = 70
        tier = 2
        MyBase.setUsable(False)
        MyBase.hBoost = 20
        MyBase.wBoost = -1
        MyBase.count = 0
        MyBase.value = 434
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(4, False, True)
    End Sub

    Overrides Sub onEquip()
        'If transformation.canbeTFed(Game.player) Then Game.player.pState.save(Game.player)
        Game.player.health += 20 / Game.player.getmaxHealth
        Game.player.ongoingTFs.Add(New MinoFTF(9, 15, 2.0, True))
        'If Game.player.perks("cowbell") = -1 Then Game.player.perks("cowbell") = 0
        If Game.player.health > 1 Then Game.player.health = 1
    End Sub
    Public Overrides Sub onUnequip()
        If Game.player.perks("cowbell") > -1 Then Game.player.perks("cowbell") = -1
            If Game.player.health > 1 Then Game.player.health = 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
