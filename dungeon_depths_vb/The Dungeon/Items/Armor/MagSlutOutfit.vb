Public Class MagSlutOutfit
    Inherits Armor

    Sub New()
        MyBase.setName("Magical_Slut_Outfit")
        MyBase.setDesc("A mysterious uniform worn by a mysterious protector." & vbCrLf & _
                       "Fits Magical Girls" & vbCrLf & _
                       "+10 DEF" & vbCrLf & _
                       "Magical girls can not remove this uniform.")
        id = 170
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 10
        MyBase.count = 0
        MyBase.value = 100

        antiSlutVarInd = 10

        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(61, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(233, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(234, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(235, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(37, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(236, True, True)

        MyBase.compressesBreasts = True

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub discard()
        If Game.player1.pClass.name.Equals("Magical Girl") Then
            Game.pushLstLog("You can't just drop your uniform!")
            Exit Sub
        End If
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
