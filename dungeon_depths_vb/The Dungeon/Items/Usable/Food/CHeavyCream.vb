Public Class CHeavyCream
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Cursed_Heavy_Cream")
        id = 98
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 265
        setCalories(30)

        '|Description|
        setDesc("An increadibly heavy cream that seems a bit fattening.  Apperantly it might be a little bit cursed." & DDUtils.RNRN &
                       "-30 stamina" & DDUtils.RNRN &
                       "Major breast enlargement")
    End Sub
    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())
        p.stamina += getCalories()
        If p.stamina > 100 Then p.stamina = 100
        effect(p)

        count -= 1
    End Sub
    Public Overrides Sub effect(ByRef p As Player)
        p.be()
        p.be()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        p.drawPort()
    End Sub
End Class
