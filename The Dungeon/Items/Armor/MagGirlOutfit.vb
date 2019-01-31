Public Class MagGirlOutfit
    Inherits Armor

    Sub New()
        MyBase.setName("Magic_Girl_Outfit")
        MyBase.setDesc("A mysterious uniform worn by a mysterious protector." & vbCrLf & _
                       "Fits magic girls" & vbCrLf & _
                       "+10 DEF" & vbCrLf & _
                       "Magical girls can not remove this uniform.")
        id = 10
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 10
        MyBase.count = 0
        MyBase.value = 100
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(12, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(37, True, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        If Game.player.pClass.name.Equals("Magic Girl") Then
            Game.pushLstLog("You can't just drop your uniform!")
            
            Exit Sub
        End If
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
