Public Class IcePop
    Inherits Food

    Public Const ITEM_NAME As String = "Ice_Pop"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 295
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
        setDesc("A phallic chunk of brightly colored frozen sugar water, wrapped in a thin sheet of insulating plastic.  The wooden stick running through it contains a ""joke"", apparently..." & DDUtils.RNRN &
                "+15 Stamina" & vbCrLf &
                "-25 LUST")
    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        p.addLust(-25)
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return Nothing
            Case Else
                If DDDateTime.isSummer Then Return 2 Else Return Nothing
        End Select
    End Function
End Class
