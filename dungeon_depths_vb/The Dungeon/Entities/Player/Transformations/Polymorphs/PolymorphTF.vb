Public MustInherit Class PolymorphTF
    Inherits Transformation
    Sub New()
        MyBase.New(1, 0, 0, False)
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
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
            Case "MASBimbo"
                Return New MASBimboTF()
            Case "Plush"
                Return New PlushTF()
            Case "Fae"
                Return New FaePieTF()
            Case "Horse"
                Return New HorseTF()
            Case "Unicorn"
                Return New UnicornTF()
            Case "Cow"
                Return New CowTF()
            Case "Inflatable Doll"
                Return New BUDollTFBeach()
            Case "Human"
                Return New HumanTF()
            Case "Succubus+"
                Return New SuccubusAssassinTF()
            Case "Slime+"
                Return New SlimePaladinTF()
            Case "Tigress+"
                Return New TigressBarbarianTF()
            Case "Dove"
                Return New DoveTF()
            Case Else
                Return Nothing
        End Select
    End Function

    MustOverride Sub step1()

    Public Overrides Sub update()
        MyBase.update()
        If Not tf_done Then Game.player1.perks(perk.polymorphed) = turns_until_next_step
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        tf_done = True

        Game.player1.revertToPState()
        Game.player1.perks(perk.polymorphed) = -1
    End Sub
    Public Sub stopTf2()
        MyBase.stopTF()
        tf_done = True

        Game.player1.perks(perk.polymorphed) = -1
    End Sub

    Public Overridable Function getTFText() As String
        Return ""
    End Function
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
