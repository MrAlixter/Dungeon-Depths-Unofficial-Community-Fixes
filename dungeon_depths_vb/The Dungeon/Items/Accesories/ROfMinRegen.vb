Public Class ROfMinRegen
    Inherits Accessory

    Sub New()
        MyBase.setName("Minor_Ring_of_Regen.")
        MyBase.setDesc("A ring containing a glowing pink gem." & vbCrLf & _
                       "+5 Health, Minor Regen Effect.")
        id = 77
        tier = 3
        MyBase.setUsable(False)
        MyBase.hBoost = 5
        MyBase.count = 0
        MyBase.value = 2000
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks("minRegen") = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks("minRegen") = -1
    End Sub
End Class
