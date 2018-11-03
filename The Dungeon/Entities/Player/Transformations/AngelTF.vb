Public Class AngelTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "AngelTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "AngelTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Sub step1()
        Dim p = Game.player
        Dim out = ""

        'angel transformation
        p.changeHairColor(Color.FromArgb(255, 245, 231, 184))
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(5, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(14, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(11, True)
        p.wingInd = 1

        'transformation description push
        out += "As you bite into the cake, you are lost in its sweet flavor.  So lost, in fact, that you miss the large white wings growing on you back.  You are now an angel!"
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p = Game.player
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
