Public Class PPanties
    Inherits Accessory

    Public Const ITEM_NAME As String = "Pink_Panties"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 180
        tier = Nothing

        '|Item Flags|
        usable = False
        cursed = False
        under_b_clothes = True
        rando_inv_allowed = True
        hide_dick = True

        '|Stats|
        h_boost = 10
        m_boost = 10
        a_boost = 10
        d_boost = 10
        s_boost = 10
        w_boost = 10
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A pink pair of panties that aren't a part of anything in the non-debug menu game.  Well, at least not yet..." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getAccIMG(ByRef p As Player) As Tuple(Of Integer, Boolean, Boolean)
        Select Case p.buttSize
            Case -1
                Return New Tuple(Of Integer, Boolean, Boolean)(34, True, True)
            Case 0
                Return New Tuple(Of Integer, Boolean, Boolean)(35, True, True)
            Case 1
                Return New Tuple(Of Integer, Boolean, Boolean)(15, True, True)
            Case 2
                Return New Tuple(Of Integer, Boolean, Boolean)(36, True, True)
            Case 3
                Return New Tuple(Of Integer, Boolean, Boolean)(37, True, True)
            Case 4
                Return New Tuple(Of Integer, Boolean, Boolean)(38, True, True)
            Case 5
                Return New Tuple(Of Integer, Boolean, Boolean)(39, True, True)
            Case Else
                Return mInd
        End Select
    End Function
End Class
