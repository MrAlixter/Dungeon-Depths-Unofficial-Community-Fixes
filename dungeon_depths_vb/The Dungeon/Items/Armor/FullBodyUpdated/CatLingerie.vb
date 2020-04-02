Public Class CatLingerie
    Inherits Armor
    'CatLingerie is a cosmetic armor that doesn't provide a defence bonus
    Sub New()
        MyBase.setName("Cat_Lingerie")
        MyBase.setDesc("A skimpy, pink, cat themed set of underwear. Nya." & vbCrLf & _
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+0 DEF")
        id = 12
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 0
        MyBase.count = 0
        MyBase.value = 300
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(38, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(39, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(40, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(41, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(85, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(86, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(87, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(88, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(89, True, True)

        MyBase.antiSlutVarInd = 146
        MyBase.compressesBreasts = True
    End Sub
End Class
