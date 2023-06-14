Public Class HPStickOfGum
    Inherits StickOfGum

    Public Shadows Const ITEM_NAME As String = "Charged_Gum_(HP)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 358
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 100
        setCalories(10)

        '|Description|
        setDesc("An ordinary looking piece of gum that smells faintly of a health potion." & DDUtils.RNRN &
                "+10 Stamina")
    End Sub

    Public Overrides Function getTier(floor_num As Integer) As Integer
        Select Case LootTable.getBracket(floor_num)
            Case LootTable.bracket.f10f12
                Return 1
            Case LootTable.bracket.f13
                Return 1
            Case LootTable.bracket.f14fXX
                Return 1
            Case Else
                Return MyBase.getTier(floor_num)
        End Select
    End Function

    Public Overrides Sub tfEffect(ByRef p As Player)
        p.ongoingTFs.add(New HPBimboTF(2, 5, 0.25, True))
        p.perks(perk.bimbotf) = 0
    End Sub
    Public Overrides Sub bimboEffect(ByRef p As Player)
        Dim phHealth = p.health
        p.health += 85 / p.getMaxHealth
        If p.health > 1 Then p.health = 1
    End Sub

    Public Overrides Function getDescription() As Object
        Return "An ordinary looking piece of gum that smells faintly of a health potion." & DDUtils.RNRN &
               If(Game.player1.className.Equals("Bimbo"), "+85 Health", "Restores health if used by a bimbo") & vbCrLf &
               "+10 Stamina"
    End Function
End Class
