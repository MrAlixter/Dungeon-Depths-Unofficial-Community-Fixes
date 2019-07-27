Public Class FemininePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Feminine_Potion")
        MyBase.setDesc("A off looking potion")
        id = 29
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
        MyBase.onBuy = AddressOf reveal
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New FemEffect, New FemEffect, New MinFemEffect, New FemEffect})

        sideEffects.AddRange({New BEEffect, New FHairChangeEffect, New MajBEEffect,
                              New NameChangeEffect, New RHairChangeEffect})


        Dim numMainEffects = mainEffectDistribution()
        Dim numSideEffects = sideEffectDistribution(1)

        Do While numMainEffects > 0
            If mainEffects.Count > 0 Then
                Dim r = Int(Rnd() * mainEffects.Count)
                effectList.Add(mainEffects(r))
                mainEffects.RemoveAt(r)
            End If
            numMainEffects -= 1
        Loop
        Do While numSideEffects > 0
            If sideEffects.Count > 0 Then
                Dim r = Int(Rnd() * sideEffects.Count)
                effectList.Add(sideEffects(r))
                sideEffects.RemoveAt(r)
            End If
            numSideEffects -= 1
        Loop
    End Sub

    Public Overrides Function mainEffectDistribution() As Integer
        Return 1
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        Randomize()
        Dim dist = {0, 0, 0, 0, 0, 1, 1, 1, 1, 2}
        Return dist(Int(Rnd() * dist.Length))
    End Function
End Class
