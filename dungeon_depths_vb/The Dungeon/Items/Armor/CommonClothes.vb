Public Class CommonClothes
    Inherits Armor
    Public Shared Shadows bsizeneg1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)
    Public Shared Shadows bsize1 As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Public Shared Shadows bsize2 As Tuple(Of Integer, Boolean, Boolean)
    Sub New()
        MyBase.setName("Common_Clothes")
        MyBase.setDesc("DO NOT SEE THIS EVER")
        id = -2
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 2
        MyBase.count = 0
        MyBase.value = 0
        MyBase.compressesBreasts = True
        MyBase.slutVarInd = -3
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
