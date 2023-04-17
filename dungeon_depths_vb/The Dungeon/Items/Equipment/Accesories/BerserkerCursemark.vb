Public Class BerserkerCursemark
    Inherits Accessory

    Public Const ITEM_NAME As String = "Berserker_Cursemark"

    Private Shared img_ind_bsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(29, False, True)
    Private Shared img_ind_bsize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(55, True, True)
    Private Shared img_ind_bsize1plus As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(56, True, True)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 402
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = True
        rando_inv_allowed = False
        under_b_clothes_halfoverride = True

        '|Stats|
        count = 0
        value = 2600

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A series of tattooed glyphs that glow with aggressive magic." & DDUtils.RNRN &
                "Negates Max MP while increasing ATK." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub discard()
        TextEvent.push("You can't discard this!")
        TextEvent.pushLog("You can't discard this!")
    End Sub

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return (((p.maxMana + p.mBuff) * p.pForm.m * p.pClass.m) + p.equippedArmor.getMBoost(p) + p.equippedWeapon.getMBoost(p)) / 2
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return -1 * (((p.maxMana + p.mBuff) * p.pForm.m * p.pClass.m) + p.equippedArmor.getMBoost(p) + p.equippedWeapon.getMBoost(p))
    End Function

    Public Overrides Function getDesc() As Object
        Return "A series of tattooed glyphs that shimmer with aggressive magic." & DDUtils.RNRN &
               "Negates Max MP while increasing ATK." & DDUtils.RNRN &
               getStatInformation()
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
