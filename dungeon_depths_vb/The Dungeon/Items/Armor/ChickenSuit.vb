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
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(21, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(22, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(111, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(112, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(113, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(114, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(114, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(115, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(116, True, True)
        MyBase.compressesBreasts = False

        MyBase.isRandoTFAcceptable = False
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub

    Public Overrides Sub onEquip()
        Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
        bTF.chickenTf()
        prevWingInd = CInt(CStr(Game.player.prt.wingInd))
        Game.player.prt.wingInd = 3
    End Sub

    Public Overrides Sub onUnequip()
        Game.player.prt.wingInd = prevWingInd
    End Sub
End Class
