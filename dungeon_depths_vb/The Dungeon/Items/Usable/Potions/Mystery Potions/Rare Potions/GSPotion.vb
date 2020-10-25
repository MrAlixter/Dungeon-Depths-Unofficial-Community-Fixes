Public Class GSPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Sex_Swap_Potion")
        MyBase.setDesc("A funny-looking potion")
        id = 28
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
        MyBase.onBuy = AddressOf reveal
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)

        If Game.player1.prt.sexBool Then
            mainEffects.AddRange({New MasEffect, New MasEffect, New MinMasEffect, New MasEffect})
        Else
            mainEffects.AddRange({New FemEffect, New FemEffect, New MinFemEffect, New FemEffect})
        End If

        Dim numMainEffects = 1

        Do While numMainEffects > 0
            If mainEffects.Count > 0 Then
                Dim r = Int(Rnd() * mainEffects.Count)
                effectList.Add(mainEffects(r))
                mainEffects.RemoveAt(r)
            End If
            numMainEffects -= 1
        Loop
    End Sub

    Public Overrides Function mainEffectDistribution() As Integer
        Return 1
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        Return 1
    End Function
End Class
