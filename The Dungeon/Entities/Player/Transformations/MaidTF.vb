Public Class MaidTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "MaidTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "MaidTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()

        Dim p As Player = Game.player

        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If

        Dim out = ""

        p.pClass.revert()
        out = p.pClass.revertPassage & vbCrLf & vbCrLf
        p.pClass = p.classes("Maid")

        'equip clothes
        Equipment.clothesChange("Maid_Outfit")
        'maid transformation
        p.haircolor = Color.FromArgb(255, 115, 72, 65)
        p.iArrInd(1) = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean, Boolean)(8, True, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean, Boolean)(3, True, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean, Boolean)(2, True, False)

        'transformation description push
        out += "As you shake the duster, the dust coming off of it seems to glow.  As you take a step back, it whips into a frenzy shrouding you in a radiant cloud.  As the glow dies down, your clothes seem to have become skimpy maid's attire to match the duster, and your hair seems to have become auburn.  Sneezing, you continue on your journey to clean this entire dungeon."
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
