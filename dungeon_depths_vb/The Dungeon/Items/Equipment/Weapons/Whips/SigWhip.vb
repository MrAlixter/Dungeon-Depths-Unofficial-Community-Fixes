Public Class SigWhip
    Inherits Whip

    Public Const ITEM_NAME As String = "Signature_Whip"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 173
        tier = Nothing

        '|Item Flags|
        usable = False
        npc_drop_only = True
        can_hit_flying = True

        '|Stats|
        a_boost = 29
        count = 0
        value = 2640

        '|Description|

        setDesc("A finely crafted spear bearing a trademarked signature.  Whips will hit critically more often than a standard sword will." & DDUtils.RNRN &
                "Each hit carries a 1 in 3 chance of stunning the opponent." & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg = MyBase.attack(p, m)

        Dim mp As NPC = m.getNPC

        If Not mp Is Nothing AndAlso Int(Rnd() * 3) = 0 Then
            mp.perks(npc_perk.stun) = 0
            TextEvent.pushEventBox("Your attack stuns" & mp.title & m.name & "!")
        End If
        Return dmg
    End Function
End Class
