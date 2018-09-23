Public Class HalfSuccubusTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "HalfSuccubusTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Overrides Sub step1()
        Dim p = Game.player
        Dim out = ""

        'unequips
        Equipment.clothesChange("Succubus_Garb")
        Equipment.weaponChange("Fists")
        Equipment.accChange("Nothing")

        'succubus transformation
        If p.sex = "Male" Then
            p.sexBool = True
            p.MtF()
            out += " Your body becomes daintier, and you are soon fully female."
        End If
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(9, True)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(9, True)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(19, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(13, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
        p.wingInd = 2

        'transformation description push
        p.TextColor = Color.HotPink
    End Sub
End Class
