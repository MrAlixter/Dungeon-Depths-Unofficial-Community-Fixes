Public Class TidemageTattoo
    Inherits Accessory

    Public Const ITEM_NAME As String = "Tidemage_Tattoo"

    Private Shared img_ind_bsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(30, False, True)
    Private Shared img_ind_bsize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(57, True, True)
    Private Shared img_ind_bsize1plus As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(58, True, True)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 411
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        under_b_clothes_halfoverride = True

        '|Stats|
        m_boost = 10
        count = 0
        value = 2470

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A swirling azure pattern that can be applied to ones arm.  The spirals resemble the crest of crashing waves." & DDUtils.RNRN &
                "Increases mana regeneration if its bearer is wearing a bikini." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub discard()
        TextEvent.push("You can't discard this!")
        TextEvent.pushLog("You can't discard this!")
    End Sub

    Public Overrides Function getTier(ByVal floor_num As Integer) As Integer
        If DDDateTime.isSummer Then Return 3

        Return Nothing
    End Function

    Public Overrides Function getAccIMG(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.breastSize
            Case -1
                Return img_ind_bsizeneg1
            Case 0
                Return img_ind_bsize0
            Case 1, 2, 3, 4, 5, 6, 7
                Return img_ind_bsize1plus
            Case Else
                Return mInd
        End Select
    End Function
End Class
