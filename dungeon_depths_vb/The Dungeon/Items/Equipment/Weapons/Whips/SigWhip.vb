Public Class SigWhip
    Inherits Whip

    Sub New()
        MyBase.setName("Signature_Whip")
        MyBase.setDesc("A finely crafted spear bearing a trademarked signature.  Whips will hit critically more often than a standard sword will." & vbCrLf &
                       "Each hit carries a 1 in 3 chance of stunning the opponent." & vbCrLf &
                       "+29 ATK")
        MyBase.setUsable(False)
        MyBase.aBoost = 29
        isMonsterDrop = True
        id = 173
        tier = Nothing
        MyBase.count = 0
        MyBase.value = 2640
    End Sub

    Public Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Dim dmg = MyBase.attack(p, m)

        Dim mp As NPC = m.getNPC

        If Not mp Is Nothing AndAlso Int(Rnd() * 3) = 0 Then
            mp.isStunned = True
            mp.stunct = 0
            Game.pushPnlEvent("Your attack stuns" & mp.title & m.name & "!")
        End If
        Return dmg
    End Function
End Class
