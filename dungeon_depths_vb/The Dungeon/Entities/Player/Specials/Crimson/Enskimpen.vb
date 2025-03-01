Public Class Enskimpen
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Enskimpen")
        MyBase.setUOC(True)
        MyBase.setcost(13)
    End Sub
    Public Overrides Sub effect()
        Dim armor As Armor = getUser.equippedArmor

        Dim originalArmor As String = armor.getAName()
        Dim skimpyVar As String = If(Not armor.getSlutVarInd() = -1, getUser.inv.item(armor.getSlutVarInd).getAName(), "skimpy version of itself")

        Dim success As Boolean = EquipmentDialogBackend.clothingCurse(getUser, False)

        If success Then
            getUser.drawPort()
            getUser.addLust(26)

            TextEvent.fpushAndLog(getName() & "!  You twist your " & originalArmor & " into a " & skimpyVar & ".  +26 Lust")
        Else
            TextEvent.fpushAndLog(getName() & "... but nothing happens...")
        End If
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Swaps the player's equipped gear with a skimpier version (if possible)."
    End Function
End Class
