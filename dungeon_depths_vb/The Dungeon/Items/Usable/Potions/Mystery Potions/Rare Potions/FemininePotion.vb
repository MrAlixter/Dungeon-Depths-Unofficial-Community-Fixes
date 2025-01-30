Public Class FemininePotion
    Inherits MysteryPotion

    Public Const ITEM_NAME As String = "Feminine_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 29
        tier = 3

        '|Item Flags|
        usable = True
        MyBase.onBuy = AddressOf reveal

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("An off-looking potion")

    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
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

        mainEffects.AddRange({New FemEffect, New FemEffect, New MinFemEffect, New FemEffect})

        sideEffects.AddRange({New BEEffect, New FHairChangeEffect, New MajBEEffect,
                              New NameChangeEffect, New RHairChangeEffect})


        Dim numMainEffects = mainEffectDistribution()
        Dim numSideEffects = sideEffectDistribution(1)

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
        Return 1
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        Randomize()
        Dim dist = {0, 0, 0, 0, 0, 1, 1, 1, 1, 2}
        Return dist(Int(Rnd() * dist.Length))
    End Function
End Class
