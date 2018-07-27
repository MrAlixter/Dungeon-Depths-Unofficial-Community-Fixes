Public Class Cowbell
    Inherits Accessory
    'The red headband provides a +1 attack buff
    Sub New()
        MyBase.setName("Cowbell")
        MyBase.setDesc("A large brass bell attached to a collar that rings steadily with its wearer's gait." & vbCrLf & _
                       "+20 Health." & vbCrLf & _
                       "-1 WIL")
        id = 70
        tier = 2
        MyBase.setUsable(False)
        MyBase.hBoost = 20
        MyBase.wboost = -1
        MyBase.count = 0
        MyBase.value = 0
        MyBase.fInd = New Tuple(Of Integer, Boolean)(8, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean)(4, False)
    End Sub

    Overrides Sub onEquip()
        Game.player.health += 20 / Game.player.getmaxHealth
        Game.player.perks("cowbell") = 0
        If Game.player.health > 1 Then Game.player.health = 1
    End Sub
    Public Overrides Sub onUnequip()
        Game.player.perks("cowbell") = -1
        If Game.player.health > 1 Then Game.player.health = 1
    End Sub
End Class
