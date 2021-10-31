Public Class PhaseDeflector
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Phase_Deflector")
        id = 281
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 7566

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, True)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, True)

        '|Description|
        setDesc("A shiny chrome wristband that projects the energy from a AAAAAA battery into a shimmering field that reverts all changes to its wearer." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.savePState()

        p.perks(perk.pdeflector) = 1

        TextEvent.push("The device chimes as you put it on, alerting you that it is now active.")
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.pdeflector) = -1
    End Sub
End Class
