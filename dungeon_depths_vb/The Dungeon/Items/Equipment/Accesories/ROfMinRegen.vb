Public Class ROfMinRegen
    Inherits Accessory

    Sub New()
        '|ID Info|
        setName("Minor_Ring_of_Regen.")
        id = 77
        tier = 3

        '|Item Flags|
        usable = False

        '|Stats|
        h_boost = 5
        count = 0
        value = 2000

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A ring containing a glowing pink gem." & DDUtils.RNRN &
                "Minor regen effect" & DDUtils.RNRN &
                getStatInformation())
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.minRegen) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.minRegen) = -1
    End Sub
End Class
