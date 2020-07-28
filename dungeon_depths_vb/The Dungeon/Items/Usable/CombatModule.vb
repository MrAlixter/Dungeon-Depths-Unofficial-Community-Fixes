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

    Public Overrides Sub use(ByRef p As Player)
        If p.pForm.name.Equals("Cyborg") Or p.pForm.name.Equals("Gynoid") Or p.pForm.name.Equals("Android") Then
            Game.pushLblEvent("Plugging in the combat module floods your system with a wealth of offensive and defensive strategies")
            p.ongoingTFs.Add(New CombatModTF())
            p.update()
            count -= 1
        Else
            Game.pushLblEvent("You can't use this as you aren't robotic in nature.")
        End If
    End Sub
End Class
