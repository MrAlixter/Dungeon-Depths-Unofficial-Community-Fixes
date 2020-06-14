Public Class SteelBikini
    Inherits Armor

    Sub New()
        MyBase.setName("Steel_Bikini")
        MyBase.setDesc("A skimpy steel swimsuit that gives a new meaning to ""breast plates""." & vbCrLf & _
                       "Fits sizes -1 through 5" & vbCrLf & _
                       "+6 DEF")
        id = 7
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 6
        MyBase.count = 0
        MyBase.value = 250
        MyBase.antiSlutVarInd = 5
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(27, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(16, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(18, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(19, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(20, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(152, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(153, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(154, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(155, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(156, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(157, True, True)
        MyBase.compressesBreasts = True
    End Sub
End Class
