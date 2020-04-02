Public Class BrawlerCosplay
    Inherits Armor
    'BrawlerCosplay provides a +15 defensive boost
    Sub New()
        MyBase.setName("Brawler_Cosplay")
        MyBase.setDesc("A glamourous garment made more for the highlighting one's body than for any practical function. " & vbCrLf &
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+6 DEF" & vbCrLf &
                       "+5 ATK")
        id = 20
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.aBoost = 5
        MyBase.count = 0
        MyBase.value = 1250
        MyBase.antiSlutVarInd = 19
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(32, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(33, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(34, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(35, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(34, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(35, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(36, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(37, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(38, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
