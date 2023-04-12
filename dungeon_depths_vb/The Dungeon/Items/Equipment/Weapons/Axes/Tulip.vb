Public Class Tulip
    Inherits Axe

    Private Enum mode
        flower
        weapon
    End Enum

    Public Const ITEM_NAME As String = "Tulip"
    Public Const TFED_NAME As String = "Two-Lipped_Battleaxe"
    Private w_mode As mode = mode.flower

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 348
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        a_boost = 0
        count = 0
        value = 2400

        '|Description|
        setDesc("A small purple flower with an iconic petal shape.  Pretty, but not much of a weapon...")
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If w_mode = mode.flower Then
            Return 0
        End If

        Return 45
    End Function

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        If Not Game.mDun Is Nothing AndAlso count > 0 AndAlso Game.mDun.numCurrFloor = 13 And w_mode = mode.weapon Then
            TextEvent.pushAndLog("The axe shimmers, transforming into a simple flower!")
            w_mode = mode.flower
        ElseIf Not Game.mDun Is Nothing AndAlso count > 0 AndAlso Game.mDun.numCurrFloor <> 13 And w_mode = mode.flower Then
            TextEvent.pushAndLog("The tulip shimmers, transforming into an impressive axe!")
            w_mode = mode.weapon
        End If

        If w_mode = mode.flower Then
            Return -1
        End If

        Return MyBase.attack(p, m)
    End Function

    Public Overrides Function getDesc() As Object
        If w_mode = mode.flower Then
            Return "A small purple flower with an iconic petal shape.  Pretty, but not much of a weapon..."
        End If

        Return "A sleek black rod, edged with two violet blades.  Their alignment invokes the petals of a flower..." & DDUtils.RNRN & getStatInformation()
    End Function

    Public Overrides Function getName() As String
        If w_mode = mode.flower Then
            Return MyBase.getName()
        End If

        Return TFED_NAME
    End Function
End Class
