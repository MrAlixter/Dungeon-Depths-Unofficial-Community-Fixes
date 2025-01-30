Public Class HealthPotionHB
    Inherits MysteryPotion

    Public Const ITEM_NAME As String = "Brewed_Health_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 382
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 150

        '|Description|
        setDesc("An earthy potion.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f13
                Return 1
            Case LootTable.bracket.f14fXX
                Return 2
            Case LootTable.bracket.misc
                If floor_num = 13 Then Return 1 Else Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New HealthEffect, New HealthEffect, New HealthEffect, New HealthEffect, New HealthEffect,
                              New MajHealthEffect})
        sideEffects.AddRange({New BEEffect})

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
        Return 1 + (Int(Rnd() * 2))
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        Return (Int(Rnd() * 2))
    End Function
End Class
