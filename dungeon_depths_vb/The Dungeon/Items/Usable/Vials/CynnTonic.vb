Public Class CynnTonic
    Inherits Item

    Public Const ITEM_NAME As String = "Cynn's_Tonic"

    Public Const TIER2 = 75
    Public Const TIER3 = 150
    Public Const TIER4 = 300
    Public Const TIER5 = 500

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 380
        tier = 4

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2666

        '|Description|
        setDesc("A glass vial filled to the brim with a brilliant scarlet elixir.  A small label with a crude drawing of a grinning demoness states that it should be used ""for a good time""..." & DDUtils.RNRN &
                "Increases the XP of all defeated enemies for a limited time.  Drink Cynn's Tonic responsibly..." & DDUtils.RNRN & DDUtils.RNRN &
                "[Cannot be used if the player's form is not stable]")
    End Sub

    Public Overrides Function getDescription() As Object
        Return "A glass vial filled to the brim with a brilliant scarlet elixir.  A small label with a crude drawing of a grinning demoness states that it should be used ""for a good time""..." & DDUtils.RNRN &
                "Increases the XP of all defeated enemies for a limited time.  Drink Cynn's Tonic responsibly..." & DDUtils.RNRN &
                If(Transformation.canBeTFed(Game.player1), "[Cannot be used if the player's form is not stable]", "Your form is not stable, and the vial doesn't seem to want to open...")
    End Function

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        Dim mp_prompt As String = InputBox("Charge the tonic with how much MP?", "Cynn's Tonic Charge", 0)
        Dim mp As Integer = If(IsNumeric(mp_prompt), mp_prompt, 0)
        Dim charge As Integer = 0

        If mp < 1 Or Not Transformation.canBeTFed(p) Then
            TextEvent.pushAndLog("The vial of " & ITEM_NAME.Replace("_", " ") & " will not open...")
            Exit Sub
        Else
            If mp > p.mana Then mp = p.mana
            charge = Math.Ceiling(mp / 2)
            TextEvent.pushLog("You charge the vial with " & mp & " MP...")
            p.mana -= mp
        End If

        p.perks(perk.cynnstonic) += Math.Max(charge, charge * (charge / p.perks(perk.cynnstonic)))

        count -= 1
        TextEvent.pushLog("You drink the vial of " & ITEM_NAME.Replace("_", " ") & "!")

        If p.perks(perk.cynnstonic) < TIER2 Then
            TextEvent.push("You drink the vial of " & ITEM_NAME.Replace("_", " ") & "!")
        ElseIf p.perks(perk.cynnstonic) < TIER3 Then
            TextEvent.push("You drink the vial of " & ITEM_NAME.Replace("_", " ") & "!" & DDUtils.RNRN &
                           "Afterwards, you feel a little... tingly...")
        ElseIf p.perks(perk.cynnstonic) < TIER4 Then
            TextEvent.push("You drink the vial of " & ITEM_NAME.Replace("_", " ") & "!" & DDUtils.RNRN &
                           "Afterwards, you feel very tingly...")
        ElseIf p.perks(perk.cynnstonic) < TIER5 Then
            TextEvent.push("You drink the vial of " & ITEM_NAME.Replace("_", " ") & "!" & DDUtils.RNRN &
                           "Afterwards, you feel dizzy...  Almost as though your entire world is spinning...")
        Else
            TextEvent.push("You drink the vial of " & ITEM_NAME.Replace("_", " ") & "!" & DDUtils.RNRN &
                           "Afterwards, you feel all... twirly...  Almost like your mind has turned into cotton candy...")
        End If
    End Sub

    Public Shared Function getEffectTier(ByRef p As Player) As String
        If p.perks(perk.cynnstonic) < TIER2 Then
            Return "Tier 1"
        ElseIf p.perks(perk.cynnstonic) < TIER3 Then
            Return "Tier 2"
        ElseIf p.perks(perk.cynnstonic) < TIER4 Then
            Return "Tier 3"
        ElseIf p.perks(perk.cynnstonic) < TIER5 Then
            Return "Tier 4"
        Else
            Return "Tier 5"
        End If
    End Function
End Class
