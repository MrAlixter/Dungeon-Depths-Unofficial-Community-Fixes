Public Class HeavyCream
    Inherits Food

    Sub New()
        '|ID Info|
        setName("Heavy_Cream")
        id = 34
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 265
        setCalories(30)

        '|Description|
        setDesc("An increadibly heavy cream that seems a bit fattening." & DDUtils.RNRN &
                "+30 stamina")

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
        Dim r As Integer = Int(Rnd() * 3)
        If r = 0 Or Game.noRNG Then p.be()

        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If

        p.drawPort()
    End Sub
End Class
