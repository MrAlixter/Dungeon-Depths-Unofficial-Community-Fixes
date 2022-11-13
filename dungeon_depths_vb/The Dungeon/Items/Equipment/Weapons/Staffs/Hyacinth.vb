Public Class Hyacinth
    Inherits Staff

    Private Enum mode
        flower
        weapon
    End Enum

    Public Const ITEM_NAME As String = "Hyacinth"
    Public Const TFED_NAME As String = "Hyacinthian_Staff"
    Private w_mode As mode = mode.flower

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 377
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 3500

        '|Description|
        setDesc("A rosy pink flower with an iconic column of petals.  Pretty, but not much of a weapon...")
    End Sub

    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If Not Game.mDun Is Nothing AndAlso count > 0 AndAlso Game.mDun.numCurrFloor = 13 And w_mode = mode.weapon Then
            TextEvent.pushAndLog("The staff shimmers, transforming into a simple flower!")
            w_mode = mode.flower
        ElseIf Not Game.mDun Is Nothing AndAlso count > 0 AndAlso Game.mDun.numCurrFloor <> 13 And w_mode = mode.flower Then
            TextEvent.pushAndLog("The hyacinth shimmers, transforming into an impressive staff!")
            w_mode = mode.weapon
        End If

        If w_mode = mode.flower Then
            Return 0
        End If

        Return 25
    End Function

    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If w_mode = mode.flower Then
            Return 0
        End If

        Return 70
    End Function

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        If w_mode = mode.flower Then
            Return -1
        End If

        Return MyBase.attack(p, m)
    End Function

    Public Overrides Function getDesc() As Object
        If w_mode = mode.flower Then
            Return "A rosy pink flower with an iconic column of petals.  Pretty, but not much of a weapon..."
        End If

        Return "A sleek black rod, capped with an rosy pink gem in the shape of a flower.  It crackles with magical fury..." & DDUtils.RNRN & getStatInformation()
    End Function

    Public Overrides Function getName() As String
        If w_mode = mode.flower Then
            Return MyBase.getName()
        End If

        Return TFED_NAME
    End Function
End Class
