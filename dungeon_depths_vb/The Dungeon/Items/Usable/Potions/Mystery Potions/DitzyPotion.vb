Public Class DitzyPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setName("Ditzy_Potion")
        MyBase.setDesc("A puzzling looking potion")
        id = 62
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

        mainEffects.AddRange({New FemEffect, New FemEffect, New MinFemEffect,
                              New MinFemEffect})
        sideEffects.AddRange({New BEEffect, New BEEffect, New BlondeDyeEffect,
                              New BlondeDyeEffect, New HairBleachEffect, New HairBleachEffect,
                              New MajBEEffect, New RandDyeEffect, New MinBimFaceEffect,
                              New BimFaceEffect, New BimbNameEffect, New BimbHairEffect, New NameChangeEffect,
                              New FHairChangeEffect, New FHairChangeEffect, New RedDyeEffect, New RandDyeEffect,
                              New RandDyeEffect, New GalaxyDyeEffect})
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
        Return (Int(Rnd() * 2))
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        Return 1 + (Int(Rnd() * 2))
    End Function
End Class
