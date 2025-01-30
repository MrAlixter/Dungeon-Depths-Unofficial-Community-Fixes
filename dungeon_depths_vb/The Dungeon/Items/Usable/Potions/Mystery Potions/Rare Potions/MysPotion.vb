Public Class MysPotion
    Inherits MysteryPotion

    Public Const ITEM_NAME As String = "Mysterious_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 59
        tier = 3

        '|Item Flags|
        usable = True
        MyBase.onBuy = AddressOf reveal

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A fair-looking potion")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return 2
            Case LootTable.bracket.f3f5
                Return 2
            Case LootTable.bracket.f6f9
                Return 2
            Case LootTable.bracket.f10f12
                Return 2
            Case LootTable.bracket.f13
                Return 2
            Case LootTable.bracket.f14fXX
                Return 2
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New HealthEffect, New staminaEffect, New ManaEffect, New MajHealthEffect,
                              New MajManaEffect, New MinHealthEffect, New MinstaminaEffect,
                              New MinManaEffect, New MinRestEffect, New MinRestEffect,
                              New RestEffect, New PainEffect, New MinPainEffect, New WeakRestEffect,
                              New MinFemEffect, New MinMasEffect, New MinFemEffect,
                              New MinMasEffect})

        sideEffects.AddRange({New BEEffect, New BlondeDyeEffect, New BSEffect, New EarChangeEffect,
                              New RHairChangeEffect, New NameChangeEffect, New RandDyeEffect,
                              New RedDyeEffect, New BEEffect, New BlondeDyeEffect,
                              New BSEffect, New EarChangeEffect, New RHairChangeEffect,
                              New NameChangeEffect, New RandDyeEffect, New RedDyeEffect,
                              New DEEffect, New UEEffect})

        Dim numMainEffects = mainEffectDistribution()
        Dim numSideEffects = sideEffectDistribution(numMainEffects)
        If numSideEffects < 0 Then numSideEffects = 0

        Do While numMainEffects > 0
            If mainEffects.count > 0 Then
                Dim r = Int(Rnd() * mainEffects.Count)
                effectList.Add(mainEffects(r))
                mainEffects.RemoveAt(r)
            End If
            numMainEffects -= 1
        Loop
        Do While numSideEffects > 0
            If sideEffects.count > 0 Then
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
