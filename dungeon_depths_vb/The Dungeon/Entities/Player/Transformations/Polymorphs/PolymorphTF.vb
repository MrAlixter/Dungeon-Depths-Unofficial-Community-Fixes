Public MustInherit Class PolymorphTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub
    Shared Function newPoly(s As String) As PolymorphTF
        Select Case s
            Case "Dragon"
                Return New DragonTF()
            Case "Goddess"
                Return New GoddessTF()
            Case "Slime"
                Return New SlimeTF()
            Case "Succubus"
                Return New SuccubusTF()
            Case "Tigress"
                Return New TigressTF()
            Case "Minotaur Cow"
                Return New MinotaurCowTF()
            Case "Princess​"
                Return New PrincessTFB()
            Case "Bunny Girl​"
                Return New BunnyGirlTFB()
            Case "Sheep"
                Return New SheepTFB()
            Case "Blowup Doll"
                Return New BUDollTF()
            Case "Cake"
                Return New TTCCBF()
            Case "Fusion"
                Return New SpotFuseTF()
            Case "Mindless"
                Return New MindlessTF()
            Case "Shrunken"
                Return New ShrunkenTF()
            Case Else
                Return Nothing
        End Select
    End Function

    MustOverride Sub step1()

    Public Overrides Sub update()
        MyBase.update()
        If Not tfDone Then Game.player.perks("polymorphed") = turnsTilNextStep
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        tfDone = True

        Game.player.revertToPState()
        Game.player.perks("polymorphed") = -1
    End Sub
    Public Sub stopTf2()
        MyBase.stopTF()
        tfDone = True

        Game.player.perks("polymorphed") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public MustOverride Overrides Sub setWaitTime(stage As Integer)
End Class
