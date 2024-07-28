Public Class Bimbell
    Inherits Accessory

    Public Const ITEM_NAME As String = "Bimbell"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 197
        tier = 3

        '|Item Flags|
        usable = False
        under_chin = True

        '|Stats|
        h_boost = 30
        w_boost = -1
        count = 0
        value = 834

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(17, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)

        '|Description|
        setDesc("A large metal bell attached to a pink collar that rings hypnotically with its wearer's gait." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f1f2
                Return Nothing
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Overrides Sub onEquip(ByRef p As Player)
        p.health += 40 / p.getMaxHealth

        If Not p.ongoingTFs.contains(tfind.bimbomino) And Not p.formName.Contains("Minotaur") And Not p.formName.Contains("Cow") Then
            p.ongoingTFs.add(New BimBellTF(9, 15, 2.0, True))
        Else
            TextEvent.fpush("Your bimbell rings with a pleasant clang.")
        End If

        If p.health > 1 Then p.health = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.perks(perk.cowbell) > -1 Then p.perks(perk.cowbell) = -1
        If p.health > 1 Then p.health = 1
    End Sub
End Class
