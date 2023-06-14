Public Class ROfMinRegen
    Inherits Accessory

    Public Const ITEM_NAME As String = "Minor_Ring_of_Regen."

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 77
        tier = 3

        '|Item Flags|
        usable = False

        '|Stats|
        h_boost = 5
        count = 0
        value = 2000

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A ring containing a glowing pink gem." & DDUtils.RNRN &
                "Minor regen effect" & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.minRegen) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.minRegen) = -1
    End Sub
End Class
