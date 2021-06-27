Public Class IcePopB
    Inherits Food
    Sub New()
        '|ID Info|
        setName("Ice_Pop​")
        id = 296
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False
        droppable = False

        '|Stats|
        count = 0
        value = 125
        setCalories(15)

        '|Description|
        setDesc("A phallic chunk of brightly colored frozen sugar water, wrapped in a thin sheet of insulating plastic.  The wooden stick running through it contains a lengthy legal disclaimer, apparently..." & DDUtils.RNRN &
                "+15 Stamina" & vbCrLf &
                "-25 LUST")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        p.addLust(-25)

        If Transformation.canBeTFed(Game.player1) Then
            Game.player1.ongoingTFs.add(New BUDollTFBeach())
            Game.player1.update()
        End If
    End Sub

    Public Overrides Function getTier() As Integer
        If DDDateTime.isSummer Then Return 3

        Return Nothing
    End Function
End Class
