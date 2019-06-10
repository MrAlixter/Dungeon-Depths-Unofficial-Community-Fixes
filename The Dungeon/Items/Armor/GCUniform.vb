Public Class GCUniform
    Inherits Armor

    Sub New()
        MyBase.setName("Gynoid_Uniform")
        MyBase.setDesc("A special set of clothes equipped through the gynoid conversion process.  While it doesn't do much by itself, if one has a network of circuitry on hand its fabric collects ambient mana and improves reaction time." & vbCrLf & _
                       "Fits sizes 0 through 4" & vbCrLf & _
                       "+5 DEF, If its wearer is robotic +13 Max Mana and +10 SPD")
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
        MyBase.compressesBreasts = True
    End Sub

    Public Overrides Sub onEquip()
        MyBase.onEquip()
        If Game.player.pForm.name.Equals("Cyborg") Or Game.player.pForm.name.Equals("Gynoid") Or Game.player.pForm.name.Equals("Android") Then
            MyBase.mBoost = 13
            MyBase.sBoost = 10
        Else
            MyBase.mBoost = 0
            MyBase.sBoost = 0
        End If
    End Sub
    Public Overrides Sub onUnequip()
        MyBase.onUnequip()
        MyBase.mBoost = 0
        MyBase.sBoost = 0
    End Sub
End Class
