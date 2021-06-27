Public Class CrimsonManual
    Inherits Item
    Public Shared specials() As String = {"Tits Up", "Tits Down", "Ass Up", "Ass Down", "Dick Up", "Dick Down",
                                          "Chameleon (Blonde)", "Chameleon (Black Hair)", "Chameleon (Redhead)",
                                          "Chameleon (Brunette)", "Chameleon (Neon)", "Chameleon (Pastels)"}
    Sub New()
        setName("Crimson_Manual")
        setDesc("A smoldering leather-bound book that contains something practical written by a succubus.")
        id = 227
        tier = Nothing
        usable = true
        count = 0
        value = 666
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

        p.specialRoute()
        count -= 1
    End Sub

    Public Overrides Function getTier() As Integer
        If DDDateTime.isValen Then Return 2

        Return MyBase.getTier()
    End Function
End Class
