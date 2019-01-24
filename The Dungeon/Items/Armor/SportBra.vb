Public Class SportBra
    Inherits Armor
    Sub New()
        MyBase.setName("Sports_Bra")
        MyBase.setDesc("A sports bra made of a strechy matierial that allows it to fit many different bust sizes." & vbCrLf & _
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+1 DEF" & vbCrLf & _
                       "+5 SPD")
        id = 47
        tier = 3
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 400
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(62, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(63, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(64, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean)(65, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
