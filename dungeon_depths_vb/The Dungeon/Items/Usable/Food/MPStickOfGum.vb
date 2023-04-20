Public Class MPStickOfGum
    Inherits StickOfGum

    Public Shadows Const ITEM_NAME As String = "Charged_Gum_(MP)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 360
        tier = Nothing

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 400
        setCalories(10)

        '|Description|
        setDesc("An ordinary looking piece of gum that smells faintly of a mana potion." & DDUtils.RNRN &
                "+10 Stamina")
    End Sub

    Public Overrides Sub tfEffect(ByRef p As Player)
        p.ongoingTFs.add(New MPBimboTF(2, 5, 0.25, True))
        p.perks(perk.bimbotf) = 0
    End Sub
    Public Overrides Sub bimboEffect(ByRef p As Player)
        Dim pMana = p.mana
        p.mana += 30
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
    End Sub

    Public Overrides Function getDesc() As Object
        Return "An ordinary looking piece of gum that smells faintly of a mana potion." & DDUtils.RNRN &
               If(Game.player1.className.Contains("Bimbo"), "+30 Mana", "Restores mana if used by a bimbo") & vbCrLf &
               "+10 Stamina"
    End Function
End Class
