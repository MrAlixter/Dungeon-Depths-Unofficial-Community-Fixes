Public Class SLolitaDress
    Inherits Armor

    Sub New()
        MyBase.setName("Lolita_Dress_(Sweet)")
        MyBase.setDesc("A poofy pink dress" & vbCrLf & _
                       "Fits sizes -1 through 4" & vbCrLf & _
                       "+5 DEF" & vbCrLf & _
                       "-5 SPD")
        id = 151
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 5
        MyBase.sBoost = -5
        MyBase.count = 0

        MyBase.value = 2000

        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(55, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(219, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(220, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(221, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(222, True, True)
        MyBase.compressesBreasts = True
        MyBase.isCursed = True
    End Sub
End Class
