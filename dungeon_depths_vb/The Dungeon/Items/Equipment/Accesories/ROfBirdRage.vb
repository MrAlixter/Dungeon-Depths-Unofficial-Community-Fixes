Public Class ROfBirdRage
    Inherits Accessory

    Public Const ITEM_NAME As String = "Ring_of_Bird_Rage"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 439
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A small silver ring that makes nearby avians very, very angry." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A small silver ring that makes nearby avians very, very angry." & DDUtils.RNRN &
                getStatInformation()
    End Function

    Public Overrides Function getABoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso p.formName = "Dove" Then Return 35

        Return MyBase.getWBoost(p)
    End Function

    Public Overrides Function getDBoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso p.formName = "Dove" Then Return 35

        Return MyBase.getWBoost(p)
    End Function

    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso p.formName = "Dove" Then Return 35

        Return MyBase.getWBoost(p)
    End Function
End Class
