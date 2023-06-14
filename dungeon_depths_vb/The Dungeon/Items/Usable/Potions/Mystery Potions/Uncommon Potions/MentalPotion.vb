Public Class MentalPotion
    Inherits MysteryPotion

    Public Const ITEM_NAME As String = "Mental_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 231
        tier = 2

        '|Item Flags|
        usable = True
        MyBase.onBuy = AddressOf reveal

        '|Stats|
        count = 0
        value = 350

        '|Description|
        setDesc("An eerie-looking potion.")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub setEffectList()
        MyBase.setEffectList()
        Dim mainEffects As List(Of PEffect) = New List(Of PEffect)

        mainEffects.AddRange({New MinManaEffect, New ManaEffect, New ManaEffect, New MajManaEffect})

        Dim numMainEffects = 1

        Do While numMainEffects > 0
            If mainEffects.Count > 0 Then
                Dim r = Int(Rnd() * mainEffects.Count)
                effectList.Add(mainEffects(r))
                mainEffects.RemoveAt(r)
            End If
            numMainEffects -= 1
        Loop
    End Sub

    Public Overrides Function mainEffectDistribution() As Integer
        Return 1
    End Function
    Public Overrides Function sideEffectDistribution(i As Integer) As Integer
        Return 0
    End Function
End Class
