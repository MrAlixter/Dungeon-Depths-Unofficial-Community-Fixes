Public Class ChitArmor
    Inherits Armor

    Sub New()
        MyBase.setName("Chitin_Armor")
        MyBase.setDesc("A set of armor built out of discarded chitin, commonly made and used by arachne huntresses." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+15 DEF" & vbCrLf & _
                       " +10 SPD")
        id = 64
        tier = 3
        MyBase.setUsable(False)
        MyBase.dBoost = 15
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 346
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(17, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(93, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(94, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(95, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
