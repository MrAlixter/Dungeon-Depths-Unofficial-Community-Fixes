Public Class BenedictPotion
    Inherits MysteryPotion
    Sub New()
        setName("Potion_of_Benediction")
        setDesc("A wonky-looking potion")
        id = 246
        tier = 2
        usable = true
        count = 0
        value = 350
        MyBase.onBuy = AddressOf reveal
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New BenedictionEffect})

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
        Return 0
    End Function
End Class
