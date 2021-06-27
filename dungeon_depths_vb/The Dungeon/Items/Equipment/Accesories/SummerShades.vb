Public Class SummerShades
    Inherits Accessory

    Dim oldGlasses As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)

    Sub New()
        '|ID Info|
        setName("Summertime_Shades")
        id = 299
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1356
        w_boost = 11

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A pair of shiny black glasses in a sleek yellow frame." & DDUtils.RNRN &
                getStatInformation() & vbCrLf &
                "Triples the defense of any bikinis that its wielder is wearing.")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        oldGlasses = p.prt.iArrInd(pInd.glasses)

        p.prt.setIAInd(pInd.glasses, 9, True, True)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.prt.iArrInd(pInd.glasses) = oldGlasses
    End Sub

    Public Overrides Function getdBoost(ByRef p As Player) As Integer
        If p Is Nothing Then Return 0

        Return If(p.equippedArmor.getAName.Contains("Bikini"), p.equippedArmor.getDBoost(p) * 2, 0)
    End Function

    Public Overrides Function getDesc() As Object
        Return "A pair of shiny black glasses in a sleek yellow frame." & DDUtils.RNRN &
                getStatInformation() & vbCrLf &
                "Triples the defense of any bikinis that its wielder is wearing."
    End Function
End Class
