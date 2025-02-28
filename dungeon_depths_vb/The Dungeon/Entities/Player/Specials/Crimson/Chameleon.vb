Public Class Chameleon
    Inherits Special

    Private mode As String = ""

    Protected Shared blondeColors() As Color = {ColorTranslator.FromHtml("#FBF4DD"), ColorTranslator.FromHtml("#F7E9B9"), ColorTranslator.FromHtml("#E3C999"), ColorTranslator.FromHtml("#EABD86"), ColorTranslator.FromHtml("#ECC457"), ColorTranslator.FromHtml("#F2D891"), ColorTranslator.FromHtml("#FFD3A3")}
    Protected Shared blackColors() As Color = {ColorTranslator.FromHtml("#444444"), ColorTranslator.FromHtml("#343536"), ColorTranslator.FromHtml("#434456"), ColorTranslator.FromHtml("#363440"), ColorTranslator.FromHtml("#1A191F"), ColorTranslator.FromHtml("#212121"), ColorTranslator.FromHtml("#32343C")}
    Protected Shared brownColors() As Color = {ColorTranslator.FromHtml("#B79562"), ColorTranslator.FromHtml("#997131"), ColorTranslator.FromHtml("#7F6032"), ColorTranslator.FromHtml("#694604"), ColorTranslator.FromHtml("#4E2D26"), ColorTranslator.FromHtml("#A8593A"), ColorTranslator.FromHtml("#8B5936"), ColorTranslator.FromHtml("#734841"), ColorTranslator.FromHtml("#4F3A39")}
    Protected Shared redColors() As Color = {ColorTranslator.FromHtml("#DC2B2B"), ColorTranslator.FromHtml("#FF9D33"), ColorTranslator.FromHtml("#E04B50"), ColorTranslator.FromHtml("#BB262B"), ColorTranslator.FromHtml("#7D1A1C"), ColorTranslator.FromHtml("#E9772C"), ColorTranslator.FromHtml("#FF6C33")}
    Protected Shared pastelColors() As Color = {ColorTranslator.FromHtml("#C2D5F1"), ColorTranslator.FromHtml("#C1E0D0"), ColorTranslator.FromHtml("#BDDEA7"), ColorTranslator.FromHtml("#DC97BA"), ColorTranslator.FromHtml("#C2C493"), ColorTranslator.FromHtml("#F9C4CE"), ColorTranslator.FromHtml("#CCC2DF"), ColorTranslator.FromHtml("#A5F2E6"), ColorTranslator.FromHtml("#DFCC9F")}
    Protected Shared neonColors() As Color = {Color.Aqua, Color.Chartreuse, Color.Crimson, Color.Magenta, Color.Lime, Color.OrangeRed, Color.SpringGreen}

    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Chameleon")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Sub New(ByRef u As Player, ByRef t As NPC, ByVal m As String)
        Me.New(u, t)

        mode = m
    End Sub

    Public Overrides Sub effect()
        If Not DDUtils.isEmpty(mode) Then
            Select Case mode
                Case "bla"
                    hairchangeEffect(blackColors, "black")
                Case "blo"
                    hairchangeEffect(blondeColors, "blonde")
                Case "bru"
                    hairchangeEffect(brownColors, "brown")
                Case "neo"
                    hairchangeEffect(neonColors, "neon")
                Case "pst"
                    hairchangeEffect(pastelColors, "pastel")
                Case "red"
                    hairchangeEffect(redColors, "red")
            End Select

            Exit Sub
        End If

        Dim modes As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        Dim bh = New Tuple(Of String, Action)("Black Hair", Sub() hairchangeEffect(blackColors, "black"))
        Dim bl = New Tuple(Of String, Action)("Blonde Hair", Sub() hairchangeEffect(blondeColors, "blonde"))
        Dim br = New Tuple(Of String, Action)("Brunette Hair", Sub() hairchangeEffect(brownColors, "brown"))
        Dim rh = New Tuple(Of String, Action)("Red Hair", Sub() hairchangeEffect(redColors, "red"))
        Dim nh = New Tuple(Of String, Action)("Neon Hair", Sub() hairchangeEffect(neonColors, "neon"))
        Dim ph = New Tuple(Of String, Action)("Pastel Hair", Sub() hairchangeEffect(pastelColors, "pastel"))

        modes.AddRange({bh, bl, br, nh, ph, rh})

        TextEvent.pushManySelect("Change your apperance how?", modes)
    End Sub

    Private Sub hairchangeEffect(ByRef colors() As Color, ByVal c As String)
        Dim p = MyBase.getUser()

        p.savePState()

        p.prt.haircolor = colors(Int(Rnd() * colors.Length))

        TextEvent.fpush("CHAMELEON!  You now have " & c & " hair...")

        p.addLust(10)

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance through the infernal dexterity of a succubus."
    End Function
End Class
