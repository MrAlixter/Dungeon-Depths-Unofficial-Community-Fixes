Public NotInheritable Class FaerieTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.angel

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        p.savePState()

        '| - HAIR TRANSFORMATION - |
        p.prt.changeHairColor(getHairColor(p.prt.haircolor))

        '| - BODY TRANSFORMATION - |
        p.prt.setIAInd(pInd.ears, 3, p.prt.iArrInd(pInd.ears).Item2, False)
        p.prt.setIAInd(pInd.wings, 10, True, False)

        If p.breastSize > 2 Then p.breastSize = 2
        If p.breastSize < 0 Then p.breastSize = 0

        If p.buttSize > 2 Then p.buttSize = 2
        If p.buttSize < 0 Then p.buttSize = 0

        '| - STAT TRANSFORMATION - |

        If p.getMaxMana > 0 Then
            Dim mratio As Double = p.mana / p.getMaxMana
            p.changeForm("Faerie")
            p.mana = mratio * p.getMaxMana
        Else
            p.changeForm("Faerie")
        End If
    End Sub

    Public Shared Sub step1alt(ByRef p As Player)
        p.savePState()

        '| - HAIR TRANSFORMATION - |
        Dim colors = {Color.Aqua, Color.Chartreuse, Color.Lime, Color.SpringGreen, Color.PaleGreen, Color.LightGreen}
        p.prt.changeHairColor(colors(Int(Rnd() * colors.Length)))
        p.prt.setIAInd(pInd.midhair, 7, True, False)
        p.prt.setIAInd(pInd.rearhair, 0, True, False)

        '| - BODY TRANSFORMATION - |
        p.prt.setIAInd(pInd.ears, 3, p.prt.iArrInd(pInd.ears).Item2, False)
        p.prt.setIAInd(pInd.wings, 10, True, False)
        p.prt.setIAInd(pInd.eyes, 60, True, True)

        If p.breastSize > 3 Then p.breastSize = 3
        If p.breastSize < 1 Then p.breastSize = 1

        If p.buttSize > 3 Then p.buttSize = 3
        If p.buttSize < 1 Then p.buttSize = 1

        '| - STAT TRANSFORMATION - |
        p.changeForm("Faerie")
        If p.inv.getCountAt(SkycladRunes.ITEM_NAME) < 1 Then p.inv.add(SkycladRunes.ITEM_NAME, 1)
        If p.inv.getCountAt(Ballgag.ITEM_NAME) < 1 Then p.inv.add(Ballgag.ITEM_NAME, 1)
        EquipmentDialogBackend.equipArmor(p, SkycladRunes.ITEM_NAME, False)
        EquipmentDialogBackend.equipAcce(p, Ballgag.ITEM_NAME, False)

        p.drawPort()
    End Sub

    Private Shared Function getHairColor(ByVal hc As Color) As Color
        Dim c As Color

        Dim fairyBlack As Color = Color.FromArgb(255, 30, 30, 30)
        Dim fairyBrown As Color = Color.FromArgb(255, 226, 128, 63)
        Dim colors = {fairyBlack, fairyBrown, Color.LightSkyBlue, Color.PaleGreen, Color.Pink, Color.Plum, Color.LightGreen, Color.MistyRose, Color.Aquamarine, Color.Aqua, Color.Chartreuse, Color.Crimson, Color.Magenta, Color.Lime, Color.OrangeRed, Color.SpringGreen, Color.SandyBrown, Color.White, Color.DimGray}

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
