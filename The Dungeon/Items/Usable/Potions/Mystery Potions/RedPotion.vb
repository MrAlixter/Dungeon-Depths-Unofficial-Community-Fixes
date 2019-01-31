Public Class RedPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Red_Potion")
        MyBase.setDesc("A strange looking potion")
        id = 26
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 250
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)
        mainEffects.AddRange({New MinPainEffect, New MinPainEffect, New MinPainEffect,
                              New MinPainEffect, New PainEffect, New PainEffect})

        mainEffects.AddRange({New MinHungerEffect, New HungerEffect, New MinHealthEffect,
                              New MinHealthEffect, New MinManaEffect, New MinRestEffect,
                              New MinRestEffect, New HealthEffect, New WeakRestEffect})

        sideEffects.AddRange({New BEEffect, New BlondeDyeEffect, New BSEffect, New EarChangeEffect,
                              New MinFemEffect, New RHairChangeEffect, New NameChangeEffect, New RandDyeEffect,
                              New RedDyeEffect, New MinMasEffect, New BEEffect, New BlondeDyeEffect,
                              New BSEffect, New EarChangeEffect, New MinFemEffect, New RHairChangeEffect,
                              New NameChangeEffect, New RandDyeEffect, New RedDyeEffect, New MinMasEffect})

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
        Dim r = Int(Rnd() * 77)
        If r >= 0 And r <= 2 Then
            Return 4
        ElseIf r > 2 And r <= 6 Then
            Return 3
        ElseIf r > 6 And r <= 19 Then
            Return 2
        ElseIf r > 19 And r <= 26 Then
            Return 0
        Else
            Return 1
        End If
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        If i = 0 Then Return 2
        Randomize()
        Return i + (Int(Rnd() * 2))
    End Function
End Class
