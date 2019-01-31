Public Class BunnySuit
    Inherits Armor
    'the BunnySuit is a cosmetic armor that provides +1 defence
    Sub New()
        MyBase.setName("Bunny_Suit")
        MyBase.setDesc("A sultry outfit worn by waitresses in a club. " & vbCrLf & _
                       "Fits sizes 1 through 5" & vbCrLf & _
                       "+1 DEF")
        id = 16
        tier = 3
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.count = 0
        MyBase.value = 325
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(42, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(43, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(44, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(45, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(46, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
