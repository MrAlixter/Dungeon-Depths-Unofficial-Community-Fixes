Public Class HHealthPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Hyper_Health_Potion")
        MyBase.setDesc("A unearthly-looking potion")
        id = 235
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
        MyBase.onBuy = AddressOf reveal
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New HHealthEffect, New HHealthEffect, New HHealthEffect})

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
