Public Class BUDollTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        tfName = "BUDollTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "BUDollTF"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = Int(Rnd() * 25) + 25
    End Sub

    Public Sub step1()
        Dim p = Game.player
        Dim out = ""

        'equip clothes
        Equipment.clothesChange("Naked")
        p.pForm = p.forms("Blowup Doll")

        'maid transformation
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(14, True)
        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(16, True)
        p.iArrInd(4) = New Tuple(Of Integer, Boolean)(1, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(18, True)
        p.iArrInd(7) = New Tuple(Of Integer, Boolean)(1, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(12, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(17, True)
        p.iArrInd(10) = New Tuple(Of Integer, Boolean)(2, False)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(14, True)
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)

        'transformation description push
        out += "Looking down, you see some sort of coupon laying on the ground.  Picking it up, you read " & vbCrLf &
                               """Need potent magic items with no questions asked?  Hit up The Brown Hat, coming to a dungeon near " &
                               "you soon!  See the back for a free sample." & vbCrLf &
                               "Flipping the scrap over, your fingers brush against a rune, activating it with the slightest touch." &
                               "  You suddenly find yourself feeling immobile, yet strangely light as your body collapses in on itself, leaving you an immobile sheet of vinyl." &
                               "  A rush of air from the rune returns you to an exagerated female form, though apart from having changed with the rest of your " &
                               "genitalia seems largly unchanged.  Propping yourself up, you try to re-equip your gear only to find that you can barely hold a weapon, let alone wear armor. This ""free sample"" seems to have turned you into a sentient sex doll." & vbCrLf & vbCrLf & "Brown Hat, huh..."
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
