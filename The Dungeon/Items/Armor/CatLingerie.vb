Public Class CatLingerie
    Inherits Armor
    'CatLingerie is a cosmetic armor that doesn't provide a defence bonus
    Sub New()
        MyBase.setName("Cat_Lingerie")
        MyBase.setDesc("A skimpy, pink, cat themed set of underwear. Nya." & vbCrLf & _
                       "Fits sizes 1 through 4" & vbCrLf & _
                       "+0 DEF")
        id = 12
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.dBoost = 0
        MyBase.count = 0
        MyBase.value = 300
        bsize1 = New Tuple(Of Integer, Boolean)(38, True)
        bsize2 = New Tuple(Of Integer, Boolean)(39, True)
        bsize3 = New Tuple(Of Integer, Boolean)(40, True)
        bsize4 = New Tuple(Of Integer, Boolean)(41, True)
        MyBase.compressesBreasts = True
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub
End Class
