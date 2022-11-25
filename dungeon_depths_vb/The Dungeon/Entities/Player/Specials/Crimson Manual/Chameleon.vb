Public Class Chameleon
    Inherits Special

    Private Enum mode
        blackhair
        blonde
        brunette
        neonhair
        pastelhair
        redhead
    End Enum

    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Chameleon")
        MyBase.setUOC(True)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim modes As List(Of Tuple(Of String, Action)) = New List(Of Tuple(Of String, Action))()

        Dim bh = New Tuple(Of String, Action)("Black Hair", AddressOf blackhairEffect)
        Dim bl = New Tuple(Of String, Action)("Blonde Hair", AddressOf blondeEffect)
        Dim br = New Tuple(Of String, Action)("Brunette Hair", AddressOf brunetteEffect)
        Dim nh = New Tuple(Of String, Action)("Neon Hair", AddressOf neonhairEffect)
        Dim ph = New Tuple(Of String, Action)("Pastel Hair", AddressOf pastelhairEffect)
        Dim rh = New Tuple(Of String, Action)("Red Hair", AddressOf redheadEffect)

        modes.AddRange({bh, bl, br, nh, ph, rh})

        TextEvent.pushManySelect("Change your apperance how?", modes)
    End Sub

    Private Sub blackhairEffect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim c As Integer = Int(Rnd() * 35) + 15
        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, c - Int(Rnd() * 5), c - Int(Rnd() * 5), c - Int(Rnd() * 5))

        TextEvent.push("CHAMELEON!  You now have black hair...")

        p.addLust(10)

        p.drawPort()
    End Sub
    Private Sub blondeEffect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim c As Integer = Int(Rnd() * 75) + 180
        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, c, c - 25, 40)

        TextEvent.push("CHAMELEON!  You now have blonde hair...")

        p.addLust(10)

        p.drawPort()
    End Sub
    Private Sub brunetteEffect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim r As Integer = Int(Rnd() * 35) + 110

        Dim b As Integer = Int(Rnd() * 50)

        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, r, 80, b)

        TextEvent.push("CHAMELEON!  You now have brunette hair...")

        p.addLust(10)

        p.drawPort()
    End Sub
    Private Sub neonhairEffect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim colors = {Color.Aqua, Color.Chartreuse, Color.Crimson, Color.Magenta, Color.Lime, Color.OrangeRed, Color.SpringGreen}

        p.prt.haircolor = colors(Int(Rnd() * colors.Length))

        TextEvent.push("CHAMELEON!  You now have neon hair...")

        p.addLust(10)

        p.drawPort()
    End Sub
    Private Sub pastelhairEffect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim colors = {Color.LightSkyBlue, Color.PaleGreen, Color.Pink, Color.Plum, Color.LightGreen, Color.MistyRose, Color.Aquamarine}

        p.prt.haircolor = colors(Int(Rnd() * colors.Length))

        TextEvent.push("CHAMELEON!  You now have pastel hair...")

        p.addLust(10)

        p.drawPort()
    End Sub
    Private Sub redheadEffect()
        Dim p = MyBase.getUser()

        p.savePState()

        Dim r As Integer = Int(Rnd() * 100) + 155
        Dim g As Integer = Int(Rnd() * 100) + 55
        Dim b As Integer = Int(Rnd() * 100) + 55

        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, r, g, b)

        TextEvent.push("CHAMELEON!  You now have red hair...")

        p.addLust(10)

        p.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Changes the user's appearance through the infernal dexterity of a succubus."
    End Function
End Class
