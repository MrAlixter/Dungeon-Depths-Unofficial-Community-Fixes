Public Class PinkPantiesPLR
    Inherits Accessory

    Public Const ITEM_NAME As String = "Pink_Panties_(PLR)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 453
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        under_b_clothes = True
        hide_dick = True
        stores_inanimate_ent = True

        '|Stats|
        count = 0
        value = 125

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A level -1 piece of pink, silky underwear." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A level " & If(getInanimateEnt() Is Nothing, 0, getInanimateEnt().level) & " piece of pink, silky underwear." & DDUtils.RNRN &
                getStatInformation()
    End Function

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

    Public Overrides Function getHBoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt() Is Nothing, 0, getInanimateEnt().max_health / 8)
    End Function
    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt() Is Nothing, 0, getInanimateEnt().max_mana / 8)
    End Function
    Public Overrides Function getABoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt() Is Nothing, 0, getInanimateEnt().atk / 8)
    End Function
    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt() Is Nothing, 0, getInanimateEnt().def / 8)
    End Function
    Public Overrides Function getSBoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt() Is Nothing, 0, getInanimateEnt().spd / 8)
    End Function
    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        Return If(getInanimateEnt() Is Nothing, 0, getInanimateEnt().wil / 8)
    End Function

End Class
