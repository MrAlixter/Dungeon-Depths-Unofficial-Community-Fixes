Public Class CombatManual
    Inherits Item
    Public Shared specials() As String = {"Rapid Fire Jabs", "Focused Roundhouse", "Heavy Blow", "Focused Barrage", "Aura Cannon", "Dodge"}
    Sub New()
        MyBase.setName("Combat_Manual")
        MyBase.setDesc("A simple, leather-bound book that likely contains some skills specifically for combat.")
        id = 88
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Int(Rnd() * 10) = -1 Then
            'tf
        Else
            Randomize()
            If Me.getUsable() = False Then Exit Sub
            Dim sName As String = "ERROR"
            Dim ct As Integer = 0
            Dim out As String = ""
            While ct < 1 Or p.knownSpecials.Contains(sName)
                ct += 1
                Dim spec As Integer = CInt(Int(Rnd() * (specials.Length)))
                Select Case spec
                    Case Else
                        sName = specials(spec)
                End Select
                If ct > 60 Then
                    Game.pushLstLog("You know all the specials in combat manuals already!")
                    Exit Sub
                End If
            End While
            If Not p.knownSpecials.Contains(sName) Then p.knownSpecials.Add(sName)
            Game.pushLstLog("You read the " & getName() & ". " & sName & " learned!")
            If Not out.Equals("") Then
                Game.pushLstLog(out)
                Game.pushLblEvent("You read the " & getName() & ". " & sName & " learned!" & DDUtils.RNRN & out)
            Else
                Game.pushLblEvent("You read the " & getName() & ". " & sName & " learned!")
            End If
        End If
        count -= 1
    End Sub
End Class
