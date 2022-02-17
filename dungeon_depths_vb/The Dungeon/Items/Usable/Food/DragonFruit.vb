Public Class DragonFruit
    Inherits Food

    Public Const ITEM_NAME As String = "Dragonfruit​"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 230
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        count = 0
        value = 500
        setCalories(20)

        '|Description|
        setDesc("A spikey magenta fruit that seems to glow with a crimson light." & DDUtils.RNRN &
                "+20 Stamina" & vbCrLf &
                "+40% Mana" & vbCrLf &
                "+25 XP")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        TextEvent.pushAndLog("+" & CInt(p.getMaxMana * 0.4) & " Max Mana, +25 XP")
        p.addXP(25)
        p.mana += CInt(p.getMaxMana * 0.4)

        If Int(Rnd() * 6) = 0 Or Settings.active(setting.norng) Then
            BroodmotherTF.halfDragonTF(p)
            TextEvent.pushAndLog("As you bite into the fruit, your form changes!")
        End If
    End Sub
End Class
