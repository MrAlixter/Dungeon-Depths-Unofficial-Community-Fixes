Public Class ArmoredLimeBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Armored_Lime_Bikini"

    Public Shared zipped_ind_bsize0 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(457, True, True)
    Public Shared zipped_ind_bsize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(458, True, True)
    Public Shared zipped_ind_bsize2 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(459, True, True)
    Public Shared zipped_ind_bsize3 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(460, True, True)
    Public Shared zipped_ind_bsize4 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(461, True, True)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 345
        tier = Nothing

        '|Item Flags|
        usable = True
        compress_breast = True
        show_underboob = True
        rando_inv_allowed = False
        slut_var_ind = 298
        is_sexy = True

        '|Stats|
        d_boost = 15
        s_boost = 15
        count = 0
        value = 2760

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(452, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(453, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(454, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(455, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(456, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(441, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(442, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(443, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(444, True, True)

        '|Description|
        setDesc("A combat-ready bright green swimsuit." & DDUtils.RNRN &
                "Using this item zips/unzips it" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A combat-ready bright green swimsuit." & DDUtils.RNRN &
                "Using this item zips/unzips it" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation()
    End Function
    Public Overrides Sub use(ByRef p As Player)
        If p.perks(perk.zipped) < 0 Then
            p.perks(perk.zipped) = 1
            TextEvent.pushAndLog("You zip your jacket up.")
        ElseIf p.perks(perk.zipped) > 0 Then
            p.perks(perk.zipped) = -1
            TextEvent.pushAndLog("You unzip your jacket.")
        End If

        p.drawPort()
        p.UIupdate()
    End Sub

    Public Overrides Function getSBoost(ByRef p As Player) As Integer
        Return If(Not p Is Nothing AndAlso p.perks(perk.zipped) < 0, 30, 15)
    End Function
    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        Return If(Not p Is Nothing AndAlso p.perks(perk.zipped) > 0, 30, 15)
    End Function

    Public Overrides Function getClothesIMGTop(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        If p.perks(perk.zipped) > 0 Then
            Select Case p.breastSize
                Case 0
                    Return zipped_ind_bsize0
                Case 1
                    Return zipped_ind_bsize1
                Case 2
                    Return zipped_ind_bsize2
                Case 3
                    Return zipped_ind_bsize3
                Case 4
                    Return zipped_ind_bsize4
                Case Else
                    Return MyBase.getClothesIMGTop(p)
            End Select
        End If

        Return MyBase.getClothesIMGTop(p)
    End Function
End Class
