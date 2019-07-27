Public Class PlantfolkTF
    Inherits Transformation

    Dim summerColor As Color = Color.FromArgb(255, 55, 146, 46)
    Dim springColor As Color = Color.FromArgb(255, 204, 254, 158)
    Dim fallColor As Color = Color.FromArgb(255, 226, 121, 5)
    Dim winterColor As Color = Color.FromArgb(255, 233, 228, 228)

    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "PlantfolkTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "PlantfolkTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        Dim p As player = game.player
        Dim out = ""

        'angel transformation
        If DateTime.Now.Month = 12 Or DateTime.Now.Month = 1 Or DateTime.Now.Month = 2 Then
            p.changeHairColor(winterColor)
        ElseIf DateTime.Now.Month = 3 Or DateTime.Now.Month = 4 Or DateTime.Now.Month = 5 Then
            p.changeHairColor(springColor)
        ElseIf DateTime.Now.Month = 6 Or DateTime.Now.Month = 7 Or DateTime.Now.Month = 8 Then
            p.changeHairColor(summerColor)
        ElseIf DateTime.Now.Month = 9 Or DateTime.Now.Month = 10 Or DateTime.Now.Month = 11 Then
            p.changeHairColor(fallColor)
        End If

        If p.sex.Equals("Male") Then
            p.prt.setIAInd(1, 6, False, True)
            p.prt.setIAInd(5, 6, False, True)
            p.prt.setIAInd(15, 7, False, True)
        Else
            p.prt.setIAInd(1, 21, True, True)
            p.prt.setIAInd(5, 24, True, True)
            p.prt.setIAInd(15, 22, True, True)
        End If


        p.changeSkinColor(Game.cShift(p.prt.skincolor, summerColor, 50))

        p.pForm = p.forms("Plantfolk")
        'transformation description push
        out += "As you chew on a particularly leafy portion of the salad, you feel the familiar flow of transformative magic flow through your body!  Expecting the worse, you are suprised to find that it seems to be providing your body with a benevolent energy.  It isn't until a leaf droops down from the top of your head that you realize something has indeed been changed.  You are now a plantfolk."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
