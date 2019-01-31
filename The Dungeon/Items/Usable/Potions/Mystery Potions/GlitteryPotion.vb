Public Class GlitteryPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Glittery_Potion")
        MyBase.setDesc("A puzzling looking potion")
        id = 62
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

        sideEffects.AddRange({New BEEffect, New BEEffect, New BlondeDyeEffect,
                              New BlondeDyeEffect, New HairBleachEffect, New HairBleachEffect,
                              New FemEffect, New FemEffect, New MinFemEffect,
                              New MinFemEffect, New MajBEEffect, New RandDyeEffect, New MinBimFaceEffect,
                              New BimFaceEffect, New BimbNameEffect, New BimbHairEffect, New NameChangeEffect,
                              New FHairChangeEffect, New FHairChangeEffect, New RedDyeEffect, New RandDyeEffect,
                              New RandDyeEffect})

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
