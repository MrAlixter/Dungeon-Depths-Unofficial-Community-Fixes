Public Class ScholasticScrunchie
    Inherits Accessory

    Public Const ITEM_NAME As String = "Scholastic_Scrunchie"

    Private Shared img_ind_bsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(31, False, True)
    Private Shared img_ind_bsize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(61, True, True)
    Private Shared img_ind_bsize1plus As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(62, True, True)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 458
        tier = Nothing

        '|Item Flags|
        usable = False
        under_b_clothes_halfoverride = True

        '|Stats|
        w_boost = 7
        count = 0
        value = 2014

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("""Ah, yes... these little things...  You know, silly as they may seem, having something tactile to ground you can really do wonders for your focus.""" & DDUtils.RNRN &
                "- The Hypnotist Teacher" & DDUtils.RNRN &
                "Counteracts negative WIL modifiers in the wearer's class." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDescription() As Object
        Return """Ah, yes... these little things...  You know, silly as they may seem, having something tactile to ground you can really do wonders for your focus.""" & DDUtils.RNRN &
               "- The Hypnotist Teacher" & DDUtils.RNRN &
               "Counteracts negative WIL modifiers in the wearer's class." & DDUtils.RNRN &
               getStatInformation()
    End Function

    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If p Is Nothing AndAlso Not Game.player1 Is Nothing Then p = Game.player1

        If Not p Is Nothing AndAlso p.pClass.w < 1.0 Then
            Dim p_will As Double = CInt((p.will + p.wBuff) * p.pClass.w * p.pForm.w)

            Return 7 + ((p_will / p.pClass.w) - p_will)
        End If


        Return MyBase.getWBoost(p)
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
