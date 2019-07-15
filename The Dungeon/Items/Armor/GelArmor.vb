Public Class GelArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Gelatinous_Shell")
        MyBase.setDesc("An extra layer of a more durable goo for extra protection when donned by a slime.  Unfortunately, due to its weak consisancy slime's are the only ones that can don it." & vbCrLf & _
                       "Fits all sizes." & vbCrLf & _
                       "+20 Max HP" & vbCrLf & _
                       "+15 DEF")
        id = 137
        tier = Nothing
        isMonsterDrop = False
        MyBase.setUsable(False)
        MyBase.hBoost = 20
        MyBase.dBoost = 15
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(52, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(199, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(93, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(94, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(93, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(94, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(206, True, True)
        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        MyBase.onEquip()

        If Not Game.player.pForm.name.Contains("Slime") And Not Game.player.pForm.name.Contains("Goo") Then
            Equipment.clothesChange("Naked")
            Game.pushLblEvent("Your clothes melt off!")
            Game.player.createP()
        End If
    End Sub
End Class