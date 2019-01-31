Public Class RosePotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Rose_Potion")
        MyBase.setDesc("A off looking potion")
        id = 29
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 300
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New MinHealthEffect, New MinManaEffect, New MinHungerEffect,
                              New HealthEffect, New ManaEffect, New HungerEffect,
                              New MajHealthEffect, New MajManaEffect, New PainEffect, New MinPainEffect,
                              New MinPainEffect})

        sideEffects.AddRange({New BEEffect, New BlondeDyeEffect, New EarChangeEffect,
                              New FemEffect, New FHairChangeEffect, New MajBEEffect,
                              New MinFemEffect, New NameChangeEffect, New RandDyeEffect,
                              New RedDyeEffect, New RHairChangeEffect, New FemEffect})

        Dim numMainEffects = mainEffectDistribution()
        Dim numSideEffects = sideEffectDistribution(numMainEffects)
        If numSideEffects < 0 Then numSideEffects = 0

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
        Randomize()
        Dim r = Int(Rnd() * 64)
        If r >= 0 And r <= 7 Then
            Return 2
        ElseIf r > 7 And r <= 14 Then
            Return 0
        Else
            Return 1
        End If
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        If i = 0 Then i = 1
        Randomize()
        Return i + (Int(Rnd() * 2)) + (Int(Rnd() * 2))
    End Function
End Class
