Public Class MasculinePotion
    Inherits MysteryPotion
    Sub New()
        '|ID Info|
        setName("Masculine_Potion")
        id = 61
        tier = 3

        '|Item Flags|
        usable = True
        MyBase.onBuy = AddressOf reveal

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A vexing-looking potion.")
    End Sub

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New MasEffect, New MasEffect, New MinMasEffect, New MasEffect})

        sideEffects.AddRange({New BSEffect, New MHairChangeEffect, New MajBSEffect,
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
