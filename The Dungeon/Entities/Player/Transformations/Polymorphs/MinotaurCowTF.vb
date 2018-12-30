Public Class MinotaurCowTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "MinotaurCowTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Overrides Sub step1()
        Dim p As player = game.player
        Dim out = ""

        'unequips
        Equipment.clothesChange("Cow_Print_Bra")

        'minotaur cow tf transformation
         If p.sex = "Male" Then
            p.sexBool = True
            p.MtF()
            out += " Your body becomes daintier, and you are soon fully female."
        End If
        p.be()
        p.be()
        p.be()
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(16, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(20, True)
        p.iArrInd(6) = New Tuple(Of Integer, Boolean)(8, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(16, True)
        p.hornInd = 2

        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
End Class
