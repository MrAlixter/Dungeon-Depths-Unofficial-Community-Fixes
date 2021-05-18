Public Class ROfMinRegen
    Inherits Accessory

    Sub New()
        setName("Minor_Ring_of_Regen.")
        setDesc("A ring containing a glowing pink gem." & vbCrLf & _
                       "+5 Health, Minor Regen Effect.")
        id = 77
        tier = 3
        usable = false
        h_boost = 5
        count = 0
        value = 2000
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.minRegen) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.minRegen) = -1
    End Sub
End Class
