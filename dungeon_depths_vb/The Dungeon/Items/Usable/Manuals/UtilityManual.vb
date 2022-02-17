Public Class UtilityManual
    Inherits Item

    Public Const ITEM_NAME As String = "Utility_Manual"

    Public Shared specials() As String = {"Ritual of Mana", "Cleanse", "Spot Fusion", "Uvona's Blessing", "Charm"}

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 89
        tier = 2

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A simple, leather-bound book that likely contains some helpful skills.")
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
                    TextEvent.pushLog("You know all the specials in utility manuals already!")
                    Exit Sub
                End If
            End While
            If Not p.knownSpecials.Contains(sName) Then p.knownSpecials.Add(sName)
            TextEvent.pushLog("You read the " & getName() & ". " & sName & " learned!")
            If Not out.Equals("") Then
                TextEvent.pushLog(out)
                TextEvent.push("You read the " & getName() & ". " & sName & " learned!" & DDUtils.RNRN & out)
            Else
                TextEvent.push("You read the " & getName() & ". " & sName & " learned!")
            End If
        End If
        p.specialRoute()
        count -= 1
    End Sub
End Class
