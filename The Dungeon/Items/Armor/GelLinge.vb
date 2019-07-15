Public Class GelLinge
    Inherits Armor

    Sub New()
        MyBase.setName("Gelatinous_Negligee")
        MyBase.setDesc("Negligee might even be too much to describe this skimpy outfit formed from the a pink goo that unfortunately only slimes can wear." & vbCrLf & _
                       "Fits all sizes." & vbCrLf & _
                       "+30 Max HP")
        id = 138
        tier = Nothing
        isMonsterDrop = False
        MyBase.setUsable(False)
        MyBase.hBoost = 30
        MyBase.count = 0
        MyBase.value = 0
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(51, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(198, True, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(191, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(192, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(193, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(194, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(195, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(196, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(197, True, True)
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