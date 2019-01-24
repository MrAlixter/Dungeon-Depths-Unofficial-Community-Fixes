Public Class ChickenSuit
    Inherits Armor
    Dim prevWingInd As Integer = 0
    Sub New()
        MyBase.setName("Chicken_Suit")
        MyBase.setDesc("This outfit, little more than some wings and straps, lightens its user though it doesn't actually provide any protection." & vbCrLf & _
                      "Fits all sizes" & vbCrLf & _
                      "+10 SPD")
        id = 8
        If DateTime.Now.Month = 9 And DateTime.Now.Day = 10 Then tier = 2 Else tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 300
        bsizeneg1 = New Tuple(Of Integer, Boolean)(21, False)
        bsize0 = New Tuple(Of Integer, Boolean)(22, False)
        bsize1 = New Tuple(Of Integer, Boolean)(111, True)
        bsize2 = New Tuple(Of Integer, Boolean)(112, True)
        bsize3 = New Tuple(Of Integer, Boolean)(113, True)
        bsize4 = New Tuple(Of Integer, Boolean)(114, True)
        bsize5 = New Tuple(Of Integer, Boolean)(115, True)
        bsize5 = New Tuple(Of Integer, Boolean)(116, True)
        MyBase.compressesBreasts = False
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        Polymorph.transform(Game.player, "bimboC")
        prevWingInd = CInt(CStr(Game.player.wingInd))
        Game.player.wingInd = 3
    End Sub

    Public Overrides Sub onUnequip()
        Game.player.wingInd = prevWingInd
    End Sub
End Class
