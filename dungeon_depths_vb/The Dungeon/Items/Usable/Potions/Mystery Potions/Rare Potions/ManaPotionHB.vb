Public Class ManaPotionHB
    Inherits MysteryPotion

    Public Const ITEM_NAME As String = "Brewed_Mana_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 383
        tier = 1

        '|Item Flags|
        usable = True
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 700

        '|Description|
        setDesc("An astral potion.")
    End Sub

    Public Overrides Sub setEffectList()
  MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)
        Dim sideEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New ManaEffect, New ManaEffect, New ManaEffect, New ManaEffect, New ManaEffect,
                              New MajManaEffect})

        sideEffects.AddRange({New UEEffect})

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
        Return 1 + (Int(Rnd() * 2))
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        Return (Int(Rnd() * 2))
    End Function
End Class
