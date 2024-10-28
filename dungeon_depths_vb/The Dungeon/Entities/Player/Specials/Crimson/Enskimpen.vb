Public Class Enskimpen
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Enskimpen")
        MyBase.setUOC(True)
        MyBase.setcost(13)
    End Sub
    Public Overrides Sub effect()
        Dim originalArmor As String = getUser.equippedArmor.getAName()
        Dim skimpyVar As String = getUser.inv.item(getUser.equippedArmor.getSlutVarInd).getAName()

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
