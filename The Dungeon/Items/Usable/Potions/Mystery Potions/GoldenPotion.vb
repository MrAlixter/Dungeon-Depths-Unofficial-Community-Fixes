Public Class GoldenPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Golden_Potion")
        MyBase.setDesc("A weird looking potion")
        id = 25
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New HealthEffect, New HHealthEffect, New HManaEffect,
                              New HungerEffect, New MajHealthEffect, New MajManaEffect,
                              New ManaEffect, New MinPainEffect, New PainEffect,
                              New RestEffect, New MinRestEffect, New WeakRestEffect,
                              New WeakMinRestEffect, New HealthEffect, New HungerEffect,
                              New ManaEffect, New MajHealthEffect, New MajManaEffect,
                              New PainEffect, New RestEffect})

        sideEffects.AddRange({New BEEffect, New BlondeDyeEffect, New BSEffect,
                              New EarChangeEffect, New EarChangeEffect, New FemEffect,
                              New HairBleachEffect, New MasEffect, New MinBimFaceEffect,
                              New MinFemEffect, New MinFemEffect, New MinMasEffect,
                              New MinMasEffect, New NameChangeEffect, New RandDyeEffect,
                              New RandDyeEffect, New RedDyeEffect, New RHairChangeEffect})

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
        If r >= 0 And r <= 4 Then
            Return 4
        ElseIf r > 4 And r <= 15 Then
            Return 3
        ElseIf r > 15 And r <= 26 Then
            Return 1
        Else
            Return 2
        End If
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        If Int(Rnd() * 5) = 0 Then Return 0
        If i = 0 Then i = 1
        Randomize()
        Return i - Int(Rnd() * 2)
    End Function
End Class
