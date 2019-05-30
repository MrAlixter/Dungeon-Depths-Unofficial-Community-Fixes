
Public Class Labcoat
    Inherits Armor

    Sub New()
        MyBase.setName("Labcoat")
        MyBase.setDesc("A white labcoat that gives its wearer an air of scientific authority." & vbCrLf & _
                      "Fits sizes -1 through 2" & vbCrLf & _
                      "+3 DEF, +30 WIL")
        id = 106
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 3
        MyBase.wboost = 30
        MyBase.count = 0
        MyBase.value = 600
        MyBase.slutVarInd = 107
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(39, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(143, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(144, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
