Public Class Medusa
    Inherits Boss
    Dim hasAttackedFlag = False
    Dim pIsBlindCt = 3
    Sub New()
        name = "Medusa, Gorgon of Myth"
        setMaxHealth(200)
        setATK(50)
        setDEF(35)
        setSPD(40)

        inv.setCount("Omni_Charm", 1)

        setupMonsterOnSpawn()

        title = " "
        pronoun = "she"
        pPronoun = "her"
        rPronoun = "her"

        xpValue = 1000
    End Sub

    Public Overrides Sub attackCMD(ByRef target As Entity)
        If target.GetType() Is GetType(Player) AndAlso CType(target, Player).perks("blind") < 0 Then
            If Not hasAttackedFlag Then
                CType(target, Player).perks("blind") = 2
                Game.zoom()
                hasAttackedFlag = True
                Game.pushLblEvent("Medusa slaps her emerald tail violently, knocking a cloud of debris and small stones directly at your face.  Raising an arm to shield yourself, you aren't able to fully block the dust as it filters directly into your eyes.  You are temporarily blinded!")
                Exit Sub
            Else

                If Not CType(target, Player).pForm.name.Contains("Gorgon") Then
                    target.currTarget = Me
                    target.die(Me)
                End If
            End If
        End If
        If CType(target, Player).perks("blind") = 2 And pIsBlindCt >= 1 Then pIsBlindCt -= 1
        If pIsBlindCt = 0 Then
            CType(target, Player).perks("blind") = -1
            Game.zoom()
            Game.pushLblEvent("You can see again!")
        End If

        MyBase.attackCMD(target)
    End Sub
End Class
