Public Class MagGirlTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Magic Girl"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Magic Girl"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = game.player
        p.pClass = p.classes("Magic Girl​")
        Dim out = "Swinging your wand, you are engulfed in a rain of stars. As the light around your body grows blinding and your clothes disolve into the aether, you become a buxom young woman wearing a skimpy uniform!"
        If p.sex = "Male" Then
            p.sex = "Female"
            p.sexBool = True
        End If
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 3, True)
        Game.pushLblEvent(out, AddressOf step2)
        
        p.TextColor = Game.lblEvent.ForeColor
        Game.cmboxSpec.Items.Clear()
        Game.specialRoute()
    End Sub
    Sub step2()
        Game.lblEvent.Text = ""
        Dim p As Player = Game.player
        If p.magGState.initFlag Then
            p.magGState.load(p)
        Else
            p.breastSize = 1
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(7, True)
            p.iArrInd(2) = New Tuple(Of Integer, Boolean)(10, True)
            p.iArrInd(3) = New Tuple(Of Integer, Boolean)(12, True)
            p.iArrInd(4) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(7, True)
            p.iArrInd(6) = New Tuple(Of Integer, Boolean)(6, True)
            p.iArrInd(7) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(8) = New Tuple(Of Integer, Boolean)(7, True)
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(9, True)
            p.iArrInd(10) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(8, True)
            p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
            p.magGState.save(p)
            p.magGState.initFlag = True
        End If
        Game.cboxMG.Items.Add("Heartblast Starcannon")
        p.inv.add(10, 1)
        p.pClass = p.classes("Magic Girl")
        Equipment.clothesChange("Magic_Girl_Outfit")
        p.equippedArmor = New MagGirlOutfit
        Game.pushLstLog("'Heartblast Starcannon' spell learned!")
        Game.lblEvent.Visible = False
        p.canMoveFlag = True
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        If p.pClass.name.Equals("Magic Girl​") Then
            Return AddressOf step2
        ElseIf p.pClass.name.Equals("Magic Girl") Then
            Return AddressOf stopTF
        Else
            Return AddressOf step1
        End If
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 0
    End Sub
End Class
