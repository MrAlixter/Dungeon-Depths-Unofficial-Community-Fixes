Public Class Rose
    Inherits Whip

    Private Enum mode
        flower
        weapon
    End Enum

    Public Const ITEM_NAME As String = "Rose"
    Public Const TFED_NAME As String = "Whip_of_Thorns"
    Private w_mode As mode = mode.flower

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 381
        tier = 2

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        npc_drop_only = True

        '|Stats|
        a_boost = 0
        count = 0
        value = 1500

        '|Description|
        setDesc("A small red flower with an iconic thorny stem.  Pretty, but not much of a weapon...")
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If w_mode = mode.flower Then
            Return 0
        End If

        Return 38
    End Function

    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        'MsgBox("Not Game.mDun Is Nothing: " & (Not Game.mDun Is Nothing) & vbCrLf & "count > 0: " & (count > 0) & vbCrLf & "Game.mDun.numCurrFloor <> 13: " & (Game.mDun.numCurrFloor <> 13) & vbCrLf & "w_mode = mode.flower: " & (w_mode = mode.flower))
        If Not Game.mDun Is Nothing AndAlso count > 0 AndAlso Game.mDun.numCurrFloor = 13 And w_mode = mode.weapon Then
            TextEvent.pushAndLog("The whip shimmers, transforming into a simple flower!")
            w_mode = mode.flower
        ElseIf Not Game.mDun Is Nothing AndAlso count > 0 AndAlso Game.mDun.numCurrFloor <> 13 And w_mode = mode.flower Then
            TextEvent.pushAndLog("The rose shimmers, transforming into an impressive whip!")
            w_mode = mode.weapon
        End If

        If w_mode = mode.flower Then
            Return -1
        End If

        Return MyBase.attack(p, m)
    End Function

    Public Overrides Function getDesc() As Object
        If w_mode = mode.flower Then
            Return "A small red flower with an iconic thorny stem.  Pretty, but not much of a weapon..."
        End If

        Return "A sleek black cord, lined with crimson spikes.  As beautiful as it is deadly..." & DDUtils.RNRN & getStatInformation()
    End Function

    Public Overrides Function getName() As String
        If w_mode = mode.flower Then
            Return MyBase.getName()
        End If

        Return TFED_NAME
    End Function
End Class
