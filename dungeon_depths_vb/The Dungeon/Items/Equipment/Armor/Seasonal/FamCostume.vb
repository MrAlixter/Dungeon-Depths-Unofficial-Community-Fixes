Public Class FamCostume
    Inherits Armor

    Dim oldHat As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
    Sub New()
        '|ID Info|
        MyBase.setName("Familiar's_Costume")
        id = 250
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True
        MyBase.isMonsterDrop = False
        MyBase.antiSlutVarInd = 166

        '|Stats|
        MyBase.dBoost = 1
        MyBase.mBoost = 20
        MyBase.count = 0
        MyBase.value = 200

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(340, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(341, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(342, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(343, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(344, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(322, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(323, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(324, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(325, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(326, True, True)

        '|Description|
        MyBase.setDesc("A skimpy black bunny suit worn by those who aren't afraid of the dark." & DDUtils.RNRN &
                       "When worn by a bunny girl, improves speed and will" & DDUtils.RNRN &
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Function getSBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0
        Return If(p.className.Equals("Bunny Girl"), 13, 0)
    End Function

    Public Overrides Function getWBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0
        Return If(p.className.Equals("Bunny Girl"), 13, 0)
    End Function

    Public Overrides Function getDesc() As Object
        Return "A skimpy black bunny suit worn by those who aren't afraid of the dark." & DDUtils.RNRN &
                "When worn by a bunny girl, improves speed and will" & DDUtils.RNRN &
                 getSizeInformation() & vbCrLf & getStatInformation()
    End Function

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        oldHat = p.prt.iArrInd(pInd.hat)

        p.prt.setIAInd(pInd.hat, 11, True, True)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.prt.iArrInd(pInd.hat) = oldHat
    End Sub
End Class
