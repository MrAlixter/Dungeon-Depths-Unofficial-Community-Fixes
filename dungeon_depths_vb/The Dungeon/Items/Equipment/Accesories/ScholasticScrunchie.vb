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
            Try
                ' Mindless classes have a zero WIL multiplier. Undoing it by division
                ' produces 0 / 0 (NaN), which cannot be converted to Integer.
                ' Restore the pre-class WIL contribution, including the form and buff,
                ' plus this accessory's normal +7 bonus. Widen before adding integers.
                If p.pClass.w = 0.0 Then
                    Return CInt(7.0 + (CDbl(p.will) + CDbl(p.wBuff)) * p.pForm.w)
                End If

                ' Preserve the original intermediate rounding for nonzero multipliers.
                Dim p_will As Double = CInt((p.will + p.wBuff) * p.pClass.w * p.pForm.w)
                Return CInt(7 + ((p_will / p.pClass.w) - p_will))
            Catch ex As OverflowException
                ' Record other overflow cases instead of silently hiding a stat error.
                ' Logging must not replace the original exception if the disk is unavailable.
                Try
                    Dim folder = System.IO.Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "DungeonDepths", "Logs")
                    System.IO.Directory.CreateDirectory(folder)
                    Dim details = String.Format(System.Globalization.CultureInfo.InvariantCulture,
                        "{0:o} ScholasticScrunchie.getWBoost: will={1}, wBuff={2}, classW={3}, formW={4}{5}{6}{5}",
                        DateTime.UtcNow, p.will, p.wBuff, p.pClass.w, p.pForm.w,
                        Environment.NewLine, ex.ToString())
                    System.IO.File.AppendAllText(System.IO.Path.Combine(folder,
                        "scholastic-scrunchie.log"), details)
                Catch logError As System.IO.IOException
                Catch logError As UnauthorizedAccessException
                End Try
                Throw
            End Try
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
