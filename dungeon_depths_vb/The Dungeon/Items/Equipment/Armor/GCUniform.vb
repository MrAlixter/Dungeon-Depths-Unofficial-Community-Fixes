Public Class GCUniform
    Inherits Armor

    Sub New()
        MyBase.setName("Gynoid_Uniform")

        id = 116
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 5
        MyBase.count = 0
        MyBase.value = 300

        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(47, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(163, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(164, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(165, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(166, True, True)

        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(134, False, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(135, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(136, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(137, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(138, True, True)

        MyBase.compressesBreasts = True

        MyBase.setDesc("A special set of clothes equipped through the gynoid conversion process.  While it doesn't do much by itself, if one has a network of circuitry on hand its fabric collects ambient mana and improves reaction time." & DDUtils.RNRN &
                                      getSizeInformation() & vbCrLf & getStatInformation() & "If the wearer is robotic, +13 Max MP and +10 SPD")
    End Sub

    Public Overrides Function getMBoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso (p.formName.Equals("Cyborg") Or p.formName.Equals("Gynoid") Or p.formName.Equals("Android") Or p.formName.Equals("Combat Unit")) Then
            Return MyBase.getMBoost(p) + 13
        Else
            Return MyBase.getMBoost(p)
        End If
    End Function

    Public Overrides Function getSBoost(ByRef p As Player) As Integer
        If Not p Is Nothing AndAlso (p.formName.Equals("Cyborg") Or p.formName.Equals("Gynoid") Or p.formName.Equals("Android") Or p.formName.Equals("Combat Unit")) Then
            Return MyBase.getSBoost(p) + 10
        Else
            Return MyBase.getSBoost(p)
        End If
    End Function
End Class
