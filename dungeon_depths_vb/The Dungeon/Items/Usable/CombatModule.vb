Public Class CombatModule
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Combat_Module")
        id = 142
        tier = Nothing

        '|Item Flags|
        MyBase.count = 0
        MyBase.value = 3120

        '|Stats|
        MyBase.setUsable(True)

        '|Description|
        MyBase.setDesc("A tactical cartridge that looks like  it could be fit into a memory slot, if you have one...")
    End Sub

    Public Overrides Sub use(ByRef p As Player)
        If p.formName.Equals("Cyborg") Or p.formName.Equals("Gynoid") Or p.formName.Equals("Android") Then
            Game.pushLblEvent("Plugging in the combat module floods your system with a wealth of offensive and defensive strategies")
            p.ongoingTFs.Add(New CombatModTF())
            p.update()
            count -= 1
        Else
            Game.pushLblEvent("You can't use this as you aren't robotic in nature.")
        End If
    End Sub
End Class
