Public Class CombatModule
    Inherits Item

    Sub New()
        MyBase.setName("Combat_Module")
        MyBase.setDesc("A tactical cartridge that looks like  it could be fit into a memory slot, if you have one...")
        id = 142
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 3120
    End Sub

    Public Overrides Sub use()
        If Game.player.pForm.name.Equals("Cyborg") Or Game.player.pForm.name.Equals("Gynoid") Or Game.player.pForm.name.Equals("Android") Then
            Game.pushLblEvent("Plugging in the combat module floods your system with a wealth of offensive and defensive strategies")
            Game.player.ongoingTFs.Add(New CombatModTF())
            Game.player.update()
            count -= 1
        Else
            Game.pushLblEvent("You can't use this as you aren't robotic in nature.")
        End If
    End Sub
End Class
