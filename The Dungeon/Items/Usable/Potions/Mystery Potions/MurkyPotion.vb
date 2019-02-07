Public Class MurkyPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Murky_Potion")
        MyBase.setDesc("A bizzare looking potion")
        id = 60
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New MinPainEffect, New MinPainEffect, New PainEffect,
                              New PainEffect, New MinHealthEffect, New MinManaEffect,
                              New MinHungerEffect, New HealthEffect, New ManaEffect,
                              New HungerEffect, New WeakMinRestEffect, New WeakRestEffect})

        sideEffects.AddRange({New BEEffect, New BimbHairEffect, New BimbNameEffect,
                              New BimFaceEffect, New BlondeDyeEffect, New BSEffect,
                              New EarChangeEffect, New FemEffect, New FHairChangeEffect,
                              New HairBleachEffect, New MajBEEffect, New MajBSEffect,
                              New MasEffect, New MHairChangeEffect, New MinBimFaceEffect,
                              New MinFemEffect, New MinMasEffect, New NameChangeEffect,
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
End Class
