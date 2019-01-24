Public Class TankTop
    Inherits Armor
    Sub New()
        MyBase.setName("Tanktop")
        MyBase.setDesc("A grey tanktop made of a breathable fabric for the athletic." & vbCrLf & _
                       "Fits sizes -1 through 3" & vbCrLf & _
                       "+1 DEF" & vbCrLf & _
                       "+5 SPD")
        id = 46
        tier = 2
        MyBase.setUsable(False)
        MyBase.dBoost = 1
        MyBase.sBoost = 5
        MyBase.count = 0
        MyBase.value = 400
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean)(11, False)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean)(66, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean)(67, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean)(68, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
