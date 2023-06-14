Public Class DemonTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.demon

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub step1()
        Dim p = Game.player1

        p.prt.changeSkinColor(Color.FromArgb(255, 214, 106, 106))
        p.prt.changeHairColor(getDemonHairColor(p.prt.haircolor))
        p.changeForm("Demon")
    End Sub

    Public Shared Function getDemonHairColor(ByVal hc As Color) As Color
        Dim c As Color

        Dim demonBlack As Color = Color.FromArgb(255, 30, 27, 27)
        Dim colors = {demonBlack, Color.BlueViolet, Color.Cornsilk, Color.Crimson, Color.DarkMagenta, Color.DeepPink, Color.Fuchsia, Color.HotPink, Color.Lavender, Color.LightPink, Color.Maroon, Color.MediumOrchid, Color.MediumTurquoise, Color.MediumVioletRed, Color.MistyRose, Color.Orchid, Color.PaleVioletRed, Color.Pink, Color.SlateBlue}

        Dim closest As Double = 99999999999999
        For i = 0 To UBound(colors)
            Dim ratio = isShadeOf(hc.R, hc.G, hc.B, colors(i))
            If ratio < closest Then
                closest = ratio
                c = colors(i)
            End If
        Next

        Return c
    End Function

    Private Shared Function isShadeOf(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, ByVal c As Color) As Double
        Dim ratio1, ratio2, ratio3
        Dim totalDelta = 0
        ratio1 = (Math.Abs(r - c.R)) * 5
        ratio2 = (Math.Abs(g - c.G)) * 5
        ratio3 = (Math.Abs(b - c.B)) * 5
        totalDelta += ratio1 + ratio2 + ratio3

        Return totalDelta
    End Function
End Class
