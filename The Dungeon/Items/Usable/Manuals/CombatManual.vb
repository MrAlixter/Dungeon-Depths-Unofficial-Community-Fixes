Public Class CombatManual
    Inherits Item

    Sub New()
        MyBase.setName("Combat_Manual")
        MyBase.setDesc("A simple, leather-bound book that likely contains some skills specifically for combat.")
        id = 88
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Overrides Sub use()
        If Int(Rnd() * 10) = -1 Then
            'tf
        Else
            Randomize()
            If Me.getUsable() = False Then Exit Sub
            Dim sName As String = "ERROR"
            Dim ct As Integer = 0
            Dim out As String = ""
            While ct < 1 Or Game.player.knownSpecials.Contains(sName)
                ct += 1
                Dim spec As Integer = CInt(Int(Rnd() * 1))
                Select Case spec
                    Case 0
                        sName = "Ritual of Mana"
                End Select
                If ct > 60 Then
                    Game.pushLstLog("You know all the specials in utility manuals already!")
                    count -= 1
                    Exit Sub
                End If
            End While
            If Not Game.player.knownSpecials.Contains(sName) Then Game.player.knownSpecials.Add(sName)
            Game.pushLstLog("You read the " & getName() & ". " & sName & " learned!")
            If Not out.Equals("") Then
                Game.pushLstLog(out)
                Game.pushLblEvent("You read the " & getName() & ". " & sName & " learned!" & vbCrLf & vbCrLf & out)
            Else
                Game.pushLblEvent("You read the " & getName() & ". " & sName & " learned!")
            End If
        End If
        count -= 1
    End Sub
End Class
