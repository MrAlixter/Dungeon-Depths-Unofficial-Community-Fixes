Public Class MPStickOfGum
    Inherits Food

    Public Const ITEM_NAME As String = "Charged_Gum_(MP)"

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

    Overrides Sub effect(ByRef p As Player)
        If p.className.Equals("Bimbo") Then
            Dim pMana = p.mana
            p.mana += 30
            If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
            TextEvent.push("Chewing the gum make your head feel warm and fuzzy and stuff. You like, totally, love this gum!" & DDUtils.RNRN &
                           "+" & CInt(p.mana - pMana) & " mana!")
            TextEvent.pushLog("You eat the " & getName())
        ElseIf p.perks(perk.bimbotf) = -1 Then
            TextEvent.push("Chewing the gum causes a dizzy calm wash to over you.")
            p.ongoingTFs.add(New MPBimboTF(2, 5, 0.25, True))
            p.perks(perk.bimbotf) = 0
        End If
    End Sub

    Public Overrides Function getDesc() As Object
        Return "An ordinary looking piece of gum that smells faintly of a mana potion." & DDUtils.RNRN &
               If(Game.player1.className.Equals("Bimbo"), "+30 Mana", "Restores mana if used by a bimbo") & vbCrLf &
               "+10 Stamina"
    End Function
End Class
