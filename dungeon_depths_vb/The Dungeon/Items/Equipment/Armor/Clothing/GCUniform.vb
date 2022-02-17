Public Class GCUniform
    Inherits Armor

    Public Const ITEM_NAME As String = "Gynoid_Uniform"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 116
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True

        '|Stats|
        d_boost = 5
        count = 0
        value = 300

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(47, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(163, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(164, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(165, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(166, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(134, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(135, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(136, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(137, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(138, True, True)

        '|Description|
        setDesc("A special set of clothes equipped through the gynoid conversion process.  While it doesn't do much by itself, if one has a network of circuitry on hand its fabric collects ambient mana and improves reaction time." & DDUtils.RNRN &
                "If worn by someone who is robotic, buff their Max MP and SPD" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
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

    Public Overrides Function getDesc() As Object
        Return "A special set of clothes equipped through the gynoid conversion process.  While it doesn't do much by itself, if one has a network of circuitry on hand its fabric collects ambient mana and improves reaction time." & DDUtils.RNRN &
               "If worn by someone who is robotic, buff their Max MP and SPD" & DDUtils.RNRN &
               getSizeInformation() & DDUtils.RNRN &
               getStatInformation()
    End Function
End Class
